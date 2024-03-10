using BaseWpfWithAuth.DbLib.Model;
using BaseWpfWithAuth.Wpf.ViewModel;
using BaseWpfWithAuth.Wpf.Views;
using BaseWpfWithAuth.Wpf.Windows;
using Microsoft.Identity.Client;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaseWpfWithAuth.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Button? SelectedButton { get; set; }


    public MainWindow()
    {
        InitializeComponent();
        SelectedButton = ButtonHome;
        this.DataContext = new MainWindowViewModel();
    }

    private void ButtonHome_Click(object sender, RoutedEventArgs e)
    {
        MainPanel.Children.Clear();
        MainPanel.Children.Add(new MainView());
        ChangeSelectedButton(sender as Button);
    }

    private void ButtonGarage_Click(object sender, RoutedEventArgs e)
    {
        MainPanel.Children.Clear();
        MainPanel.Children.Add(new GarageView());
        ChangeSelectedButton(sender as Button);
    }

    private void ButtonUser_Click(object sender, RoutedEventArgs e)
    {
        MainPanel.Children.Clear();
        MainPanel.Children.Add(new UserView());
        ChangeSelectedButton(sender as Button);
    }

    private void ChangeSelectedButton(Button? button)
    {
        if (SelectedButton is not null)
            SelectedButton.Background = TryFindResource("MenuButtonColor") as SolidColorBrush;

        SelectedButton = button;

        if (SelectedButton is not null)
            SelectedButton.Background = TryFindResource("MenuButtonColorSelected") as SolidColorBrush;
        
    }

    private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        => ((MainWindowViewModel)this.DataContext).Logout();
}