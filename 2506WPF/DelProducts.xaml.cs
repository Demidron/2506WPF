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
using System.Xml.Linq;
namespace _2506WPF
{
    /// <summary>
    /// Логика взаимодействия для DelProducts.xaml
    /// </summary>
    public partial class DelProducts : Window
    {
        public DelProducts()
        {
            InitializeComponent();
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            XDocument doc2 = XDocument.Load(@"..\..\Data\Products.xml");
           
            var product = doc2.Element("root").Elements("Product").ToList()[productList.SelectedIndex];
            product.Remove();
            doc2.Save(@"..\..\Data\Products.xml");
            MessageBox.Show($"Продукт {product.Attribute("name").Value} успешно удален");
            this.DialogResult = true;
        }
    }
}
