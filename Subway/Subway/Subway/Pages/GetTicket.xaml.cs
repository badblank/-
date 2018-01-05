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

namespace Subway.Pages
{
    /// <summary>
    /// GetTicket.xaml 的交互逻辑
    /// </summary>
    public partial class GetTicket : Window
    {
        public static int Ticketnum;
        public GetTicket()
        {
            InitializeComponent();
            this.RB1.IsChecked = true;
            
        }

        public static int getPrice( int num )
        {
            int Price;
            if (num < 6)
            {
                Price = 2;
            }else if (num < 12)
            {
                Price = 3;
            }else if (num < 18)
            {
                Price = 4;
            }else
            {
                Price = 5;
            }
            return Price;
        }

        private void get_Ticket_type_checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = e.Source as RadioButton;
            switch (rb.Name)
            {
                case "RB1":
                    this.label2.Content = LineOne.station[LineOne.num1];
                    this.label3.Content = LineOne.station[LineOne.num2];
                    this.label4.Content = GetTicket.getPrice(LineOne.num2 - LineOne.num1) + ".00 元";
                    Ticketnum = (MainWindow.Ticketnum > 0) ? MainWindow.Ticketnum : 1;
                    this.label5.Content = Ticketnum.ToString();
                    this.label6.Content = GetTicket.getPrice(LineOne.num2 - LineOne.num1) * Ticketnum + ".00 元";
                    break;
                case "RB2":
                    label2.Content = LineOne.station[LineOne.num1];
                    this.label3.Content = LineOne.station[LineOne.num2];
                    this.label4.Content = GetTicket.getPrice(LineOne.num2 - LineOne.num1)*1.5 + "0元";
                    this.label6.Content = GetTicket.getPrice(LineOne.num2 - LineOne.num1)*1.5 * Ticketnum + "0元";
                    break;
                case "RB3":
                    this.label2.Content = "*";
                    this.label3.Content = "*";
                    this.label4.Content = "10.00 元";
                    this.label6.Content = 10 * Ticketnum + ".00 元";
                    break;
            }
        }

        private void Button_search_Click(object sender, RoutedEventArgs e)
        {
            if (userID.Text != "" && password.Password != "")
            {
                
            }
        }
    }
}
