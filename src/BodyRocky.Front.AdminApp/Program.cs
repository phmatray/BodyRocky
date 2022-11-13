using System;
using BodyRocky.Front.AdminApp.Views;
using Gtk;

namespace BodyRocky.Front.AdminApp;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        Application.Init();
        DiContainer.BuildServiceProvider();

        var app = new Application("org.BodyRocky.Front.AdminApp.BodyRocky.Front.AdminApp", GLib.ApplicationFlags.None);
        app.Register(GLib.Cancellable.Current);

        var win = new MainWindow();
        app.AddWindow(win);

        win.Show();
        Application.Run();
    }
}