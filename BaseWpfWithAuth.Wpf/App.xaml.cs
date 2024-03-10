using BaseWpfWithAuth.DbLib.Model;
using BaseWpfWithAuth.Wpf.Windows;
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
        MainWindow mainWindow = new();
        App.Current.MainWindow.Close();
        App.Current.MainWindow = mainWindow;
        mainWindow.Show();
    }
    public void Logout()
    {
        LoggedUser = null;
        WindowLogin windowLogin = new();
        App.Current.MainWindow.Close();
        App.Current.MainWindow = windowLogin;
        windowLogin.Show();
    }
}