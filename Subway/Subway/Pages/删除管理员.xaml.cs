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
    /// 删除管理员.xaml 的交互逻辑
    /// </summary>
    public partial class 删除管理员 : Page
    {
        public 删除管理员()
        {
            InitializeComponent();
            using (SubwayDatabaseEntities6 c = new SubwayDatabaseEntities6())
            {
                var q = from t in c.Admin
                        select t;
                if (q != null && q.Count() >= 1)
                {
                    this.datagrid.ItemsSource = q.ToList();
                }
            }
        }

        private void button_delete_click(object sender, RoutedEventArgs e)
        {
            if (userID.Text == "")
            {
                MessageBox.Show("输入信息不能为空！");
            }
            int x;
            if (!int.TryParse(userID.Text, out x))
            {
                MessageBox.Show("输入信息有误！");
            }
            using (SubwayDatabaseEntities6 c = new SubwayDatabaseEntities6())
            {
                var q = from t in c.Admin
                        where t.aId == x
                        select t;

                if (q != null && q.Count() >= 1)
                {
                    foreach (var v in q)
                    {
                        c.Admin.Remove(v);
                        MessageBox.Show("ID:    " + v.aId + "Name: " + v.aName + "\r\n删除成功");

                        var p = from t in c.Admin
                                select t;
                        if (p != null && p.Count() >= 1)
                        {
                            this.datagrid.ItemsSource = p.ToList();
                        }
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
