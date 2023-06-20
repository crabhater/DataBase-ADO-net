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

namespace ДЗ_Модуль_16
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Task1.xaml", UriKind.Relative));

        }

        private void Task3Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Task3.xaml", UriKind.Relative));
        }

        private void Task2Button_Click(object sender, RoutedEventArgs e)
        {
            TableFiller.GoFill(new Person());
            TableFiller.GoFill(new Order());

            MessageBox.Show("Таблицы были заполнены");
        }
    }
}
