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
        Account acc = new Account();
        Account CreateAccount = new Account();
        Account SelectedAccount = new Account();
        Customer cus = new Customer();
        Transaction trans = new Transaction();
        public Window1()
        {
            InitializeComponent();
            
            
            Rente();
            UdførButton_content();
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

        private void KontoType_Combobox_DropDownClosed(object sender, EventArgs e)
        {
            Rente();
        }
        


        private void Udfør_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Aktion_ComboBox.SelectedIndex == 0)
            {
                //Indsæt

            }

            else if (Aktion_ComboBox.SelectedIndex == 1)
            {
                //Udbetal
                SelectedAccount.Withdraw(int.Parse(KontoNR_TextBox.Text), decimal.Parse(Beløb_TextBox.Text));

                Transaktion_DataGrid.ItemsSource = null;

                cus.UserID = int.Parse(UserID_TextBox.Text);
                KundeNavn_DataGrid.ItemsSource = SelectedAccount.getCustomerAccounts(cus);


            }
            
        }

         private void Aktion_ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            UdførButton_content();
        }

        private void Rente()
        {
            if (KontoType_Combobox.SelectedIndex == 0)
            {
                Rente_TextBox.Text = "0.80";
            }
            else if (KontoType_Combobox.SelectedIndex == 1)
            {
                Rente_TextBox.Text = "1.12";
            }
            else if (KontoType_Combobox.SelectedIndex == 2)
            {
                Rente_TextBox.Text = "0.52";
            }
            else if (KontoType_Combobox.SelectedIndex == 3)
            {
                Rente_TextBox.Text = "2.07";
            }
        }
        private void UdførButton_content()
        {
            if (Aktion_ComboBox.SelectedIndex == 0)
            {
                Udfør_Button.Content = "Indsæt";
            }

            else if (Aktion_ComboBox.SelectedIndex == 1)
            {
                Udfør_Button.Content = "Udbetal";
            }
        }

        private void KundeNavn_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // IF Selected account is null select first item on list
            SelectedAccount = (Account)KundeNavn_DataGrid.SelectedItem;
            if (SelectedAccount == null)
            {
                KundeNavn_DataGrid.SelectedIndex = 0;
                SelectedAccount = (Account)KundeNavn_DataGrid.SelectedItem;
            }

            //SelectedAccount = (Account)KundeNavn_DataGrid.SelectedItem;

            Transaktion_DataGrid.ItemsSource = trans.getTransactions(SelectedAccount);
            
            Transaktion_Label.Content = "Overførelser (" + SelectedAccount.Accountnumber + ")";

            KontoNR_TextBox.Text = SelectedAccount.Accountnumber.ToString();
           
        }

        private void Opret_Button_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount.Accounttype = KontoType_Combobox.Text;
            CreateAccount.Interest = decimal.Parse(Rente_TextBox.Text);
            CreateAccount.Balance = decimal.Parse(Balance_TextBox.Text);
            CreateAccount.FK_CustomerID = int.Parse(UserID_TextBox.Text);

            CreateAccount.CreateAccount(CreateAccount);

            cus.UserID = int.Parse(UserID_TextBox.Text);
            KundeNavn_DataGrid.ItemsSource = null;
            KundeNavn_DataGrid.ItemsSource = acc.getCustomerAccounts(cus);
        }
    }
}
