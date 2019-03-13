using System;
using System.Windows;

namespace clu.active.learning.app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void btnMakeCoffee_Click(object sender, RoutedEventArgs e)
        //{
        //    lblResult.Content = "Your coffee is on its way.";
        //}

        private void coffeeSelector1_OrderPlaced(object sender, EventArgs e)
        {
            lblResult.Content = coffeeSelector1.Order;
        }

    }
}
