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
        public  int ID;
        public  string type = "单程票";
        public  int Ticketnum;
        public  double blance;
        public  double price;
        public double allprice;
        public  string startstation;
        public  string endstation;
        public  string name;
        public GetTicket()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
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
                    startstation = LineOne.station[LineOne.num1];
                    endstation = LineOne.station[LineOne.num2];
                    price = GetTicket.getPrice(LineOne.num2 - LineOne.num1);
                    Ticketnum = (MainWindow.Ticketnum > 0) ? MainWindow.Ticketnum : 1;
                    type = "单程票";
                    allprice = price * Ticketnum;
                    this.label2.Content = startstation;
                    this.label3.Content = endstation;
                    this.label4.Content = price + ".00 元";
                    this.label5.Content = Ticketnum.ToString();
                    this.label6.Content = GetTicket.getPrice(LineOne.num2 - LineOne.num1) * Ticketnum + ".00 元"; 
                    break;
                case "RB2":
                    startstation = LineOne.station[LineOne.num1];
                    endstation = LineOne.station[LineOne.num2];
                    price = GetTicket.getPrice(LineOne.num2 - LineOne.num1)*1.5;
                    Ticketnum = (MainWindow.Ticketnum > 0) ? MainWindow.Ticketnum : 1;
                    type = "往返票";
                    allprice = price * Ticketnum;
                    label2.Content = LineOne.station[LineOne.num1];
                    this.label3.Content = LineOne.station[LineOne.num2];
                    this.label4.Content = string.Format("{0:n2}",GetTicket.getPrice(LineOne.num2 - LineOne.num1)*1.5) + "元";
                    this.label6.Content = string.Format("{0:n2}", GetTicket.getPrice(LineOne.num2 - LineOne.num1) * 1.5*Ticketnum) + "元";
                    
                    break;
                case "RB3":
                    startstation = "*";
                    endstation = "*";
                    price = 10;
                    Ticketnum = (MainWindow.Ticketnum > 0) ? MainWindow.Ticketnum : 1;
                    type = "通票";
                    allprice = price * Ticketnum;
                    this.label2.Content = "*";
                    this.label3.Content = "*";
                    this.label4.Content = "10.00 元";
                    this.label6.Content = 10 * Ticketnum + ".00 元";
                    break;
            }
        }



            private void button_search_Click(object sender, RoutedEventArgs e)
        {
            if (userID.Text != "" || password.Password != "")
            {
                int x;
                if(int.TryParse(userID.Text,out x)){
                    using (var context = new SubwayDatabaseEntities6())
                    {
                        int i = 0;
                        var q = from t in context.User
                                where t.uID == x 
                                select t;
                        foreach (var v in q)
                        {
                            if (v.uPassword.ToString() == password.Password.ToString())
                            {
                                ID = v.uID;
                                blance = v.balance;
                                name = v.uName;
                                balancelabel.Content = "Balance    :  ";
                                balancelabel2.Content =v.balance.ToString(); 
                                 
                            }else
                            {
                                MessageBox.Show("输入信息有误");
                            }
                            i++;
                        }
                        if (i == 0)
                        {
                            MessageBox.Show("输入信息有误");
                        }
                        
                    }
                }else
                {
                    MessageBox.Show("输入信息有误！");
                }

            }else
            {
                MessageBox.Show("请输入用户信息！");
            }
        }

        
       private void button_getTicket_Click(object sender, RoutedEventArgs e)
        {
            if ((balancelabel2.Content).ToString() != "")
            {
                if (blance >= allprice)
                {
                    using (var context = new SubwayDatabaseEntities6())
                    {
                        var q = from t in context.User
                                where t.uID == ID
                                select t;
                        foreach( var v in q)
                        {
                            v.balance -= allprice;
                            balancelabel2.Content = v.balance;
                            blance = v.balance;
                        }
                        context.SaveChanges();

                        Ticket ticket = new Ticket()
                        {
                            UserName = name,
                            UserID = ID,
                            Type = type,
                            BeginStation = startstation,
                            EndStation = endstation,
                            Price = price,
                            num = Ticketnum
                        };
                        try
                        {
                            context.Ticket.Add(ticket);
                            context.SaveChanges();
                            MessageBox.Show("恭喜您，购票成功！");

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("添加失败：" + ex.Message);
                        }

                       
                    }
                }
                else
                {
                    MessageBox.Show("金额不足,请联系管理员充值!");
                }
            }
        }

    }
}
