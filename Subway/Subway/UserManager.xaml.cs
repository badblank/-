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
    /// UserManager.xaml 的交互逻辑
    /// </summary>
    public partial class UserManager : Window
    {
        public UserManager()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            if (AdminMainWindow.adminType == "一般职员")
            {
                this.addManager.Visibility = Visibility.Hidden;
                this.DeleteManager.Visibility = Visibility.Hidden;
            };
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            //   TreeViewItem parent = item.Parent as TreeViewItem;
            //  if (parent == null) return;
            string path = string.Format("/Pages/{0}.xaml", item.Header);
            Uri source = new Uri(path, UriKind.Relative);
            object obj = null;
            try
            {
                obj = Application.LoadComponent(source);
            }
            catch
            {
                MessageBox.Show("未找到" + source.OriginalString);
                return;
            }
            Page p = obj as Page;
            if (p != null)
            {
                frame1.NavigationService.RemoveBackEntry();
                frame1.Source = source;
                return;
            }
            //Window w = obj as Window;
            //if (w != null)
            //{
            //    w.Owner = this;
            //    w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            //    w.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("you are wrong");
            //}
        }
    }
}
