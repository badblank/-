using Subway.Pages;
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

namespace Subway
{
    /// <summary>
    /// SeletedVeision.xaml 的交互逻辑
    /// </summary>
    public partial class SeletedVeision : Window
    {
        public SeletedVeision()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button bt = e.Source as Button;
            switch (bt.Name)
            {
                case "selectedTicket":
                    MainWindow mw = new MainWindow();
                   // this.Close();
                    mw.ShowDialog();
                    
                    break;
                case "AdminLogin":H:\java测试\Subway\Subway\Images\t1.jpg
                    AdminMainWindow amw = new AdminMainWindow();
                   // this.Close();
                    amw.ShowDialog();
                    break;
                case "SelectedIn":
                    UserLogin ul = new UserLogin();
                    ul.ShowDialog();
                    break;
            }
        }
    }
}
