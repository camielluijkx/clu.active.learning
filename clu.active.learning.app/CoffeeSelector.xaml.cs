using System;
using System.Windows;
using System.Windows.Controls;

namespace clu.active.learning.app
{
    /// <summary>
    /// Interaction logic for CoffeeSelector.xaml
    /// </summary>
    public partial class CoffeeSelector : UserControl
    {
        public CoffeeSelector()
        {
            InitializeComponent();
        }

        private string beverage;
        private string milk;
        private string sugar;

        public string Order
        {
            get
            {
                return $"{beverage}, {milk}, {sugar}";
            }
        }
        public event EventHandler<EventArgs> OrderPlaced;

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrderPlaced != null)
                OrderPlaced(this, EventArgs.Empty);
        }

        private void radCoffee_Checked(object sender, RoutedEventArgs e) { beverage = "Coffee"; }
        private void radTea_Checked(object sender, RoutedEventArgs e) { beverage = "Tea"; }
        private void radMilk_Checked(object sender, RoutedEventArgs e) { milk = "Milk"; }
        private void radNoMilk_Checked(object sender, RoutedEventArgs e) { milk = "No Milk"; }
        private void radSugar_Checked(object sender, RoutedEventArgs e) { sugar = "Sugar"; }
        private void radNoSugar_Checked(object sender, RoutedEventArgs e) { sugar = "No Sugar"; }
    }
}
