﻿using BaseWpfWithAuth.Wpf.ViewModel;
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
using System.Windows.Shapes;

namespace BaseWpfWithAuth.Wpf.Windows
{
    /// <summary>
    /// Logique d'interaction pour WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            ((LoginViewModel)this.DataContext).Password = PasswordBoxLogin.Password;
            ((LoginViewModel)this.DataContext).Login();
        }
    }
}
