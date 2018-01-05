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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Subway
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int Ticketnum=0;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = string.Format("/Pages/All.xaml");
            Uri source = new Uri(path, UriKind.Relative);
            object obj = null;
            try
            {
                obj = Application.LoadComponent(source);
            }
            catch
            {
                MessageBox.Show("未找到" + source.OriginalString);
            }
            Page p = obj as Page;
            if (p != null)
            {
                frame1.Padding = new Thickness(0);
                frame1.NavigationService.RemoveBackEntry();
                frame1.Source = source;
                return;
            }
            else
            {
                MessageBox.Show("无法将加载的对象转换为Window类型");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = string.Format("/Pages/LineOne.xaml");
            Uri source = new Uri(path, UriKind.Relative);
            object obj = null;
            try
            {
                obj = Application.LoadComponent(source);
            }
            catch
            {
                MessageBox.Show("未找到" + source.OriginalString);
            }
            Page p = obj as Page;
            if (p != null)
            {
                double left = this.ActualWidth / 10;
                double top = this.ActualHeight / 100;
                frame1.Padding = new Thickness(left, top, 0, 0);
                frame1.NavigationService.RemoveBackEntry();
                frame1.Source = source;
                return;
                

            }
            else
            {
                MessageBox.Show("无法将加载的对象转换为Window类型");
            }
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (LineOne.num1 == -1 || LineOne.num2 == -1)
            {
                MessageBox.Show("请您先选择好站点再取票！");
            }
            else
            {
                string path = string.Format("Pages/GetTicket.xaml");
                Uri source = new Uri(path, UriKind.Relative);
                object obj = null;
                try
                {
                    obj = Application.LoadComponent(source);
                }
                catch
                {
                    MessageBox.Show("未找到" + source.OriginalString);
                }
                Window w = obj as Window;
                if (w != null)
                {
                    w.Owner = this;
                    w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    
                    w.ShowDialog();

                }
                else
                {
                    MessageBox.Show("无法将加载的对象转换为Window类型");
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (frame1.Content!=null&&frame1.Content.ToString()=="Subway.Pages.LineOne")
            {
                double left = this.ActualWidth / 10;
                double top = this.ActualHeight / 100;
                frame1.Padding = new Thickness(left,top,0,0);
            }
            
        }

        //快捷选择购票张数
        private void getNum_Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            Ticketnum = int.Parse(btn.Name.ToString().Remove(0, 4));
        }
        private void firstbuyticket_button_click(object sender, RoutedEventArgs e)
        {
            FastBuyTicket fs = new FastBuyTicket();
            fs.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            fs.ShowDialog();
           
        }   
    }
}
