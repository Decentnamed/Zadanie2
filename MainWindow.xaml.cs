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

namespace Zadanie2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model model = new Model();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;
        }

        private void Cyfra(object sender, RoutedEventArgs e)
        {
            model.PobierzCyfrę(
                (string)((Button)sender).Content
                );

        }

        private void Przecinek(object sender, RoutedEventArgs e)
        {
            model.PobierzPrzecinek(
                (string)((Button)sender).Content
                );
        }

        private void Znak(object sender, RoutedEventArgs e)
        {
            model.PrzełączZnak();
        }

        private void RównaSię(object sender, RoutedEventArgs e)
        {
            model.ObliczeniaDwuargumentowe();
        }

        private void Procent(object sender, RoutedEventArgs e)
        {
            model.DziałanieProcentowe();
        }

        private void Operator(object sender, RoutedEventArgs e)
        {
            model.PrzełączOperator(
                (string)((Button)sender).Content
                );
            model.PobierzOperator(
                (string)((Button)sender).Content
                );
        }

        private void Jednoargumentowe(object sender, RoutedEventArgs e)
        {
            model.PobierzDziałanieJednoargumentowe(
                (string)((Button)sender).Content
                );
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            model.CofnijZnak();
        }

        private void Resetuj(object sender, RoutedEventArgs e)
        {
            model.Czyść();
        }

        private void Skasuj(object sender, RoutedEventArgs e)
        {
            model.Czyść();
        }
    }
}
