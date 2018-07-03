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

namespace _2506WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            int k1 = categoryList.SelectedIndex;
            int k2 = producerList.SelectedIndex;

            XmlDataProvider xdp = (XmlDataProvider)FindResource("productProvider");
            Binding b = new Binding();
            b.Source = xdp;
            if (k1 > 0 && k2 == 0)
            {
                b.XPath = $"Product[@cid={k1}]";
            }
            else if (k1 == 0 && k2 > 0)
            {
                b.XPath = $"Product[@pid={k2}]";

            }
            else if (k1 > 0 && k2 > 0)
            {
                b.XPath = $"Product[@cid={k1} and @pid={k2}]";
            }
            else
                b.XPath = "Product";
            productList.SetBinding(ListView.ItemsSourceProperty, b);
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addCategory_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            if( win.ShowDialog()==true)
            {
                XmlDataProvider xdp = (XmlDataProvider)FindResource("categoryProvider");
                Binding b = new Binding();
                b.Source = xdp;
                b.XPath = "category";
                categoryList.SetBinding(ComboBox.ItemsSourceProperty, b);
                
            }
        }

        private void delCategory_Click(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            if(win2.ShowDialog()==true)
            {

            }

        }

        private void addProducer_Click(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();
            if (win3.ShowDialog() == true)
            {

            }

        }

        private void delProducer_Click(object sender, RoutedEventArgs e)
        {
            Window4 win4 = new Window4();
            if (win4.ShowDialog() == true)
            {

            }
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProducts win5 = new AddProducts();
            if (win5.ShowDialog() == true)
            {

            }
        }

        private void delProduct_Click(object sender, RoutedEventArgs e)
        {
            DelProducts delWin = new DelProducts();
            if(delWin.ShowDialog()==true)
            {

            }
        }

        private void ChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProducts win5 = new AddProducts();
            if (win5.ShowDialog() == true)
            {

            }
        }
    }
}
