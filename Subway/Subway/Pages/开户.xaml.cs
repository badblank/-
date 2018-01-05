﻿using System;
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
    /// 开户.xaml 的交互逻辑
    /// </summary>
    public partial class 开户 : Page
    {
        public 开户()
        {
            InitializeComponent();
        }
        private void button_ensure_click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || password.Text == "")
            {
                MessageBox.Show("输入信息不能为空！");
                return;
            }
            using (SubwayDatabaseEntities6 c = new SubwayDatabaseEntities6())
            {
                User u = new User()
                {
                    uName = name.Text,
                    uPassword = password.Text,
                    addTime = DateTime.Now,
                    balance = 0
                };
                try
                {
                    c.User.Add(u);
                    c.SaveChanges();
                    MessageBox.Show("添加用户成功！");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("添加失败：" + ex.Message);
                }
            }

         }
        private void button_cancle_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
