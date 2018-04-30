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

namespace H2_Case_Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Customer cus = new Customer();

        public MainWindow()
        {
            InitializeComponent();
            Kundeoversigt_DataGrid.ItemsSource = cus.ReturnCustomers();
        }

        private void Kundeoversigt_DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow MW = new MainWindow();
            Window1 win = new Window1();

            win.Show();
            this.Close();
            
        }

        private void Fornavn_TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("Ingen tal i Fornavn", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Efternavn_TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("Ingen tal i Fornavn", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Opret_Button_Click(object sender, RoutedEventArgs e)
        {
            cus.CreateCustomer(Fornavn_TextBox.Text, Efternavn_TextBox.Text);

            Kundeoversigt_DataGrid.ItemsSource = null;
            Kundeoversigt_DataGrid.ItemsSource = cus.ReturnCustomers();
        }
    }
}
