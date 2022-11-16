namespace BodyRocky.Back.Server.DataAccess;

public static class ReferentialData
{
    public static List<Category> GetPredefinedCategories()
    {
        List<Category> categories = new();
        
        categories.Add(new()
        {
            CategoryID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            CategoryName = "Cardio-training",
            CategoryImage = "/assets/images/category/category-1.jpg",
            CategoryIcon = "fas fa-heartbeat",
            IsFeatured = true
        });
        
        categories.Add(new()
        {
            CategoryID = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            CategoryName = "Musculation",
            CategoryImage = "/assets/images/category/category-2.jpg",
            CategoryIcon = "fas fa-dumbbell",
            IsFeatured = true
        });
        
        categories.Add(new()
        {
            CategoryID = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            CategoryName = "Jeux et loisirs",
            CategoryImage = "/assets/images/category/category-3.jpg",
            CategoryIcon = "fas fa-gamepad",
            IsFeatured = true
        });
        
        categories.Add(new()
        {
            CategoryID = Guid.Parse("00000000-0000-0000-0000-000000000004"),
            CategoryName = "Fitness",
            CategoryImage = "/assets/images/category/category-4.jpg",
            CategoryIcon = "fas fa-running",
            IsFeatured = true
        });
        
        categories.Add(new()
        {
            CategoryID = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            CategoryName = "Yoga et bien-être",
            CategoryImage = "/assets/images/category/category-5.jpg",
            CategoryIcon = "fas fa-heart",
            IsFeatured = true
        });
        
        categories.Add(new()
        {
            CategoryID = Guid.Parse("00000000-0000-0000-0000-000000000006"),
            CategoryName = "Nutrition",
            CategoryImage = "/assets/images/category/category-6.jpg",
            CategoryIcon = "fas fa-utensils",
            IsFeatured = true
        });

        return categories;
    }
    
    public static List<BasketStatus> GetPredefinedBasketStatuses()
    {
        List<BasketStatus> basketStatuses = new();
        
        basketStatuses.Add(new()
        {
            Description = "Basket is empty",
            Code = 1
        });
        
        basketStatuses.Add(new()
        {
            Description = "Basket is not empty",
            Code = 2
        });
        
        basketStatuses.Add(new()
        {
            Description = "Basket is paid",
            Code = 3
        });

        return basketStatuses;
    }

    public static List<OrderStatus> GetPredefinedOrderStatuses()
    {
        List<OrderStatus> orderStatuses = new();
        
        orderStatuses.Add(new()
        {
            Description = "Order is created",
            Code = 1
        });
        
        orderStatuses.Add(new()
        {
            Description = "Order is paid",
            Code = 2
        });
        
        orderStatuses.Add(new()
        {
            Description = "Order is shipped",
            Code = 3
        });
        
        orderStatuses.Add(new()
        {
            Description = "Order is delivered",
            Code = 4
        });
        
        orderStatuses.Add(new()
        {
            Description = "Order is cancelled",
            Code = 5
        });

        return orderStatuses;
    }

    public static List<ZipCode> GetPredefinedZipCodes()
    {
        List<ZipCode> zipCodes = new();

        // 1000 Bruxelles
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Code = 1000,
            Commune = "Bruxelles"
        });
        // 1030 Schaerbeek
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Code = 1030,
            Commune = "Schaerbeek"
        });
        // 1040 Etterbeek
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            Code = 1040,
            Commune = "Etterbeek"
        });
        // 1050 Ixelles
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000004"),
            Code = 1050,
            Commune = "Ixelles"
        });
        // 1060 Saint-Gilles
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000005"),
            Code = 1060,
            Commune = "Saint-Gilles"
        });
        // 1070 Anderlecht
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000006"),
            Code = 1070,
            Commune = "Anderlecht"
        });
        // 1080 Molenbeek-Saint-Jean
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000007"),
            Code = 1080,
            Commune = "Molenbeek-Saint-Jean"
        });
        // 4000 Liège
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000008"),
            Code = 4000,
            Commune = "Liège"
        });
        // 4020 Liège
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000009"),
            Code = 4020,
            Commune = "Liège"
        });
        // 4030 Grivegnée
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000010"),
            Code = 4030,
            Commune = "Grivegnée"
        });
        // 4040 Herstal
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000011"),
            Code = 4040,
            Commune = "Herstal"
        });
        // 4050 Chênée
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000012"),
            Code = 4050,
            Commune = "Chênée"
        });
        // 4060 Liège
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000013"),
            Code = 4060,
            Commune = "Liège"
        });
        // 4070 Leernes
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000014"),
            Code = 4070,
            Commune = "Leernes"
        });
        // 4100 Seraing
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000015"),
            Code = 4100,
            Commune = "Seraing"
        });
        // 4120 Neupré
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000016"),
            Code = 4120,
            Commune = "Neupré"
        });
        // 4130 Esneux
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000017"),
            Code = 4130,
            Commune = "Esneux"
        });
        // 4140 Sprimont
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000018"),
            Code = 4140,
            Commune = "Sprimont"
        });
        // 4150 Comblain-au-Pont
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000019"),
            Code = 4150,
            Commune = "Comblain-au-Pont"
        });
        // 4160 Ans
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000020"),
            Code = 4160,
            Commune = "Ans"
        });
        // 4170 Faymonville
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000021"),
            Code = 4170,
            Commune = "Faymonville"
        });
        // 4180 Hamoir
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000022"),
            Code = 4180,
            Commune = "Hamoir"
        });
        // 4190 Fexhe-le-Haut-Clocher
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000023"),
            Code = 4190,
            Commune = "Fexhe-le-Haut-Clocher"
        });
        // 4600 Visé
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000024"),
            Code = 4600,
            Commune = "Visé"
        });
        // 4620 Fléron
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000025"),
            Code = 4620,
            Commune = "Fléron"
        });
        // 4630 Soumagne
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000026"),
            Code = 4630,
            Commune = "Soumagne"
        });
        // 4650 Herve
        zipCodes.Add(new()
        {
            ZipCodeID = Guid.Parse("00000000-0000-0000-0000-000000000027"),
            Code = 4650,
            Commune = "Herve"
        });

        return zipCodes;
    }
}