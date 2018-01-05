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
    /// UserLogin.xaml 的交互逻辑
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void state_login_Click(object sender, RoutedEventArgs e)
        {
            if (UserID.Text == "" || password.Password == "")
            {
                MessageBox.Show("请您先填好信息再登录！");
                return;
            }

            int x;
            if (!int.TryParse(UserID.Text, out x))
            {
                MessageBox.Show("您输入的信息有误");
                return;
            }

            using (SubwayDatabaseEntities6 c = new SubwayDatabaseEntities6())
            {
                var q = from t in c.User
                        where t.uID == x && t.uPassword == password.Password.ToString()
                        select t;
                if (q != null && q.Count() >= 1)
                {
                    var p = from t in c.Ticket
                            where t.UserID == x
                            select t;
                    if (p != null && p.Count() >= 1)
                    {
                        State st = new State();
                        st.datagrid.ItemsSource = p.ToList();
                        st.Show();
                        this.Close();
                    }else
                    {
                        MessageBox.Show("您当前还未购买票，请前往购票！");
                    }
                }
                else
                {
                    MessageBox.Show("您输入的信息有误");
                }

            }

        }
    }
}
