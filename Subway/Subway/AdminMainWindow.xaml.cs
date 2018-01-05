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
    /// AdminMainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public static String adminType;
        public AdminMainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            if (userID.Text == "" || password.Password == "" || typebox.Text == "")
            {
                MessageBox.Show("请您先填好信息再登录！");
                return;
            }

            int x;
            if (!int.TryParse(userID.Text, out x))
            {
                MessageBox.Show("您输入的信息有误");
                return;
            }

            using (SubwayDatabaseEntities6 c = new SubwayDatabaseEntities6())
            {
                var q = from t in c.Admin
                        where t.aId == x && t.aPassword == password.Password.ToString() && t.Type == typebox.Text
                        select t;
                if (q != null && q.Count() >= 1)
                {
                    AdminMainWindow.adminType = typebox.Text;
                    UserManager um = new UserManager();
                    um.ShowDialog();
                }
                else
                {
                    MessageBox.Show("您输入的信息有误");
                }

             }
            
        }
        private void button_cancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
