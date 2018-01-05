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
    /// State.xaml 的交互逻辑
    /// </summary>
    public partial class State : Window
    {
        public State()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void ensure_click(object sender, RoutedEventArgs e)
        {
            if (ticketId.Text == "")
            {
                MessageBox.Show("请您先填好信息！");
                return;
            }
            int x;
            if (!int.TryParse(ticketId.Text, out x))
            {
                MessageBox.Show("您输入的信息有误");
                return;
            }

            using (SubwayDatabaseEntities6 c = new SubwayDatabaseEntities6())
            {
                var q = from t in c.Ticket
                        where t.Id == x
                        select t;
                if (q != null && q.Count() >= 1)
                {
                    TicketState ts = new TicketState();
                    foreach (var v in q)
                    {
                        ts.StartState.Content = v.BeginStation;
                        ts.EndState.Content = v.EndStation;
                        ts.TicketType.Content = v.Type;
                    };
                    ts.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("您输入的信息有误");
                }

            }
        }
    }
}
