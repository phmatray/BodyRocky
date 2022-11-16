using BodyRocky.Back.Server.DataAccess.Enumerations;
using BodyRocky.Back.Server.DataAccess.Factories;
using BodyRocky.Back.Server.DataAccess.Repositories;

namespace BodyRocky.Back.Server.Services;

public class OrderService
{
    private readonly OrderFactory _orderFactory;
    private readonly BasketFactory _basketFactory;

    private readonly OrderRepository _orderRepository;
    private readonly BasketRepository _basketRepository;
    private readonly CustomerRepository _customerRepository;
    private readonly AddressRepository _addressRepository;
    
    public OrderService(
        OrderFactory orderFactory,
        BasketFactory basketFactory,
        OrderRepository orderRepository,
        BasketRepository basketRepository,
        CustomerRepository customerRepository,
        AddressRepository addressRepository)
    {
        _orderFactory = orderFactory;
        _basketFactory = basketFactory;
        _orderRepository = orderRepository;
        _basketRepository = basketRepository;
        _customerRepository = customerRepository;
        _addressRepository = addressRepository;
    }
    
    public async Task<Order> ExecuteOrderAsync(Guid basketID)
    {
        // read the basket
        var basket = 
            await _basketRepository.GetByIDAsync(basketID)
            ?? throw new Exception("Basket not found");
        
        // read the customer
        var customer = 
            await _customerRepository.GetByIDAsync(basket.CustomerID)
            ?? throw new Exception("Customer not found");
        
        // read some other stuff like shipping address, etc.
        // for demo purposes we will just use a dummy address.
        var billingAddress = await _addressRepository.GetRandomAsync();
        var deliveryAddress = await _addressRepository.GetRandomAsync();

        // create the order
        var order = _orderFactory.CreateOrder(basket, customer, billingAddress.AddressID, deliveryAddress.AddressID);
        await _orderRepository.InsertAsync(order);
        
        // change the status of the basket
        basket.BasketStatusCode = (int)BasketStatusEnum.Paid;
        await _basketRepository.UpdateAsync(basket);
        
        // add a new basket for the customer
        var newBasket = _basketFactory.CreateEmptyBasket(basket.CustomerID);
        await _basketRepository.InsertAsync(newBasket);
        
        return order;
    }
}