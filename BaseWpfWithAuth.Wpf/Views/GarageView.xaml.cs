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

namespace BaseWpfWithAuth.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour GarageView.xaml
    /// </summary>
    public partial class GarageView : UserControl
    {
        public GarageView()
        {
            InitializeComponent();
            this.DataContext = new GarageViewModel();
        }

        private void UpdateGarageButton_Click(object sender, RoutedEventArgs e)
            => ((GarageViewModel)this.DataContext).UpdateGarage();

        private void AddGarageButton_Click(object sender, RoutedEventArgs e)
            => ((GarageViewModel)this.DataContext).AddGarage();

        private void DeleteGarageButton_Click(object sender, RoutedEventArgs e)
            => ((GarageViewModel)this.DataContext).RemoveGarage();

        private void DeleteCarButton_Click(object sender, RoutedEventArgs e)
            => ((GarageViewModel)this.DataContext).RemoveCar();

        private void UpdateCarButton_Click(object sender, RoutedEventArgs e)
            => ((GarageViewModel)this.DataContext).UpdateCar();

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
            => ((GarageViewModel)this.DataContext).AddCar();
    }
}
