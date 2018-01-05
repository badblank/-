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
    /// LineOne.xaml 的交互逻辑
    /// </summary>
    public partial class LineOne : Page
    {
        public static string[] station = { "西流湖","西三环","秦岭路","桐柏路","碧沙岗","绿城广场","医学院",
                                            "郑州火车站","二七广场","人民路","紫荆山","燕庄","民航路","会展中心",
                                            "黄河南路","农业南路","东风南路","郑州东站","博学路","市体育中心"};
        public Button[] button = new Button[20];
        public Line[] line = new Line[20];


        public static string station1;
        public static string station2;
        public static int num1 = -1;
        public static int num2 = -1;

        public LineOne()
        {
            InitializeComponent();
            button[0] = btn0;
            button[1] = btn1;
            button[2] = btn2;
            button[3] = btn3;
            button[4] = btn4;
            button[5] = btn5;
            button[6] = btn6;
            button[7] = btn7;
            button[8] = btn8;
            button[9] = btn9;
            button[10] = btn10;
            button[11] = btn11;
            button[12] = btn12;
            button[13] = btn13;
            button[14] = btn14;
            button[15] = btn15;
            button[16] = btn16;
            button[17] = btn17;
            button[18] = btn18;
            button[19] = btn19;

            line[1] = line1;
            line[2] = line2;
            line[3] = line3;
            line[4] = line4;
            line[5] = line5;
            line[6] = line6;
            line[7] = line7;
            line[8] = line8;
            line[9] = line9;
            line[10] = line10;
            line[11] = line11;
            line[12] = line12;
            line[13] = line13;
            line[14] = line14;
            line[15] = line15;
            line[16] = line16;
            line[17] = line17;
            line[18] = line18;
            line[19] = line19;
        }

        private void Button_Station_Click(object sender, RoutedEventArgs e)
        {
            Button b = e.Source as Button;
            int num = int.Parse(b.Name.Remove(0,3));
            if( num1 == -1)
            {
                num1 = num;
                b.Background = Brushes.Beige;
            }
            else if( num1 == num && num2 == -1)
            {
                num1 = -1;   
                b.Background = Brushes.CadetBlue;
            }
            else if(num1 == num && num2 != -1){
                for (int i = num1; i <= num2; i++)
                {
                    if (i != num2)
                    {
                        button[i].Background = Brushes.CadetBlue;
                    }
                   
                    if (num1 != i)
                    {
                        line[i].Stroke = Brushes.CadetBlue;
                    }
                }
                num1 = num2;
                num2 = -1;
            }
            else if (num2 == -1)
            {
                if (num > num1)
                {
                    num2 = num;
                }else
                {
                    num2 = num1;
                    num1 = num;
                }
                for( int i = num1; i <= num2; i++)
                {
                   button[i].Background= Brushes.Beige;
                   if(num1 != i)
                    {
                        line[i].Stroke = Brushes.Beige;
                    }
                   
                }
            }
            else if(num2 == num && num1 !=-1)
            {
                for (int i = num1+1; i <= num2; i++)
                {
                    button[i].Background = Brushes.CadetBlue;
                    line[i].Stroke = Brushes.CadetBlue;

                }
                num2 = -1;
            }
            else if (num2 == num && num1 == -1)
            {
                num2 = -1;
                b.Background = Brushes.CadetBlue;
            }
        }
    }
}
