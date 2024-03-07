using BaseWpfWithAuth.Wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaseWpfWithAuth.Wpf.Views;

/// <summary>
/// Logique d'interaction pour UserView.xaml
/// </summary>
public partial class UserView : UserControl
{
    public UserView()
    {
        InitializeComponent();
        this.DataContext = new UserViewModel();
    }

    private void AddUserButton_Click(object sender, RoutedEventArgs e) 
        => ((UserViewModel)this.DataContext).AddUser();

    private void DeleteUserButton_Click(object sender, RoutedEventArgs e) 
        => ((UserViewModel)this.DataContext).RemoveUser();

    private void UpdateUserButton_Click(object sender, RoutedEventArgs e) 
        => ((UserViewModel)this.DataContext).UpdateUser();

    private void ListBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e) =>PasswordBoxUser.Password = null;

    private void PasswordBoxUser_PasswordChanged(object sender, RoutedEventArgs e) 
        =>((UserViewModel)this.DataContext).UnhashedPassword = PasswordBoxUser.Password;
}