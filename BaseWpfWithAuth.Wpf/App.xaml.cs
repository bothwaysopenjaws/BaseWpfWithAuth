﻿using BaseWpfWithAuth.DbLib.Model;
using System.Configuration;
using System.Data;
using System.Windows;

namespace BaseWpfWithAuth.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public User? LoggedUser { get; set; }


    public App()
    {
        using (ApplicationDBContext? db = new())
        {
            db.Database.EnsureCreated();
            if (!db.Users.Any())
            {
                db.Users.Add(new User { UserName = "admin", HashedPassword = new Microsoft.AspNet.Identity.PasswordHasher().HashPassword( "test") });
                db.SaveChanges();
            }
        }
    }

    public void Login(User user)
    {
        LoggedUser = user;
        MainWindow mainWindow = new MainWindow();
        App.Current.MainWindow.Close();
        App.Current.MainWindow = mainWindow;
        mainWindow.Show();
    }
}