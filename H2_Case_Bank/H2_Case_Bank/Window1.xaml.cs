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

namespace H2_Case_Bank
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            if (KontoType_Combobox.SelectedIndex == 0)
            {
                Rente_TextBox.Text = "1.00";
            }
        }

        private void Tilbage_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
           
            MW.Show();
            this.Close();
        }

        private void Beløb_TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("Beløbet kan kun bestå af tal.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
