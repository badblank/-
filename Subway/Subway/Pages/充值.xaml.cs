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

namespace Subway.Pages
{
    /// <summary>
    /// 充值.xaml 的交互逻辑
    /// </summary>
    public partial class 充值 : Page
    {
        public 充值()
        {
            InitializeComponent();
        }
        private void button_ensure_click(object sender, RoutedEventArgs e)
        {
            if (userid.Text == "" || money.Text == "")
            {
                MessageBox.Show("输入信息不能为空！");
                return;
            }
            int x;
            double d;
            if (!int.TryParse(userid.Text, out x)||!double.TryParse(money.Text,out d))
            {
                MessageBox.Show("输入信息有误"+"12");
                return;
            }
            using (SubwayDatabaseEntities6 c = new SubwayDatabaseEntities6())
            {
                var q = from t in c.User
                        where t.uID == x
                        select t;
                if (q != null && q.Count() >= 1)
                {
                    foreach (var v in q)
                    {
                        v.balance += d;
                        MessageBox.Show("您已成功为"+v.uName+"充值现金"+d+"元\r\n当前余额"+v.balance+"元");
                    }
                    c.SaveChanges();
                    
                }
                else
                {
                    MessageBox.Show("输入信息有误");
                }
            }
        }
    }
}
