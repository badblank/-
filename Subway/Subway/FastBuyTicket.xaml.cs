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
    /// FastBuyTicket.xaml 的交互逻辑
    /// </summary>
    public partial class FastBuyTicket : Window
    {
        public string name;
        public int id;
        public double price;
        public string type;
        bool flag = false;
        public FastBuyTicket()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }


        private void get_fast_Ticket_type_checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = e.Source as RadioButton;
            switch (rb.Name)
            {
                case "nRB1":
                    price = 2;
                    type = "2元票";
                    this.flag = true;
                    break;
                case "nBR2":
                    price = 3;
                    type = "3元票";
                    this.flag = true;
                    break;
                case "nRB3":
                    price = 4;
                    type = "4元票";
                    this.flag = true;
                    break;
                case "nRB4":
                    price = 5;
                    type = "5元票";
                    this.flag = true;
                    break;
            }
        }

        private void get_fast_Ticket_button_click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            if(flag==false|| UserId.Text == "" || password.Password == "")
            {
                MessageBox.Show("请您选输入好信息再取票！");
                MessageBox.Show(flag + UserId.Text + password.Password);
            }
            else
            {
                int x;
                if(int.TryParse(UserId.Text,out x))
                {
                    using(SubwayDatabaseEntities6 c = new SubwayDatabaseEntities6())
                    {
                        var q = from t in c.User
                                where t.uID == x && t.uPassword == password.Password.ToString()
                                select t;
                        if (q != null && q.Count() >= 1)
                        {
                            double balance=0;
                            foreach (var v in q)
                            {
                                name = v.uName;
                                id = v.uID;
                                if (v.balance >= price)
                                {
                                    v.balance -= price;
                                    balance = v.balance;
                                }
                                else
                                {
                                    MessageBox.Show("您当前余额不足，请联系管理员充值！");
                                    return;
                                } 
                            }
                            c.SaveChanges();
                            var p = from t in c.Ticket
                                    select t;
                            test test = new test();
                            test.testGrid.ItemsSource = p.ToList();
                            Ticket ticket = new Ticket()
                            {
                                UserName = name,
                                UserID = id,
                                Type = type,
                                BeginStation = "*",
                                EndStation = "*",
                                Price = price,
                                num = 1,
                            };
                            try
                            {
                                c.Ticket.Add(ticket);
                                c.SaveChanges();
                                MessageBox.Show("恭喜您，购票成功！\r\n您当前余额为;"+ balance);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("购票失败：" + ex.Message);
                            }
                            var o = from t in c.Ticket
                                    select t;

                        }
                        else
                        {
                            MessageBox.Show("您输入的用户名和密码有误！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("您输入的用户名和密码有误！");
                }
            }

        }
    }
}
