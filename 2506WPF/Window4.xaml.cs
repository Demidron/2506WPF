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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            var k = pList.SelectedIndex;
            //
            XDocument ProductsDoc = XDocument.Load(@"..\..\Data\Products.xml");
            XDocument ProducersDoc = XDocument.Load(@"..\..\Data\Producers.xml");
            var products = ProductsDoc.Element("root").Elements("Product");
            var producers = ProducersDoc.Element("root").Elements("Producer");
            var producer = producers.ToList()[k];

            products.Where(x => x.Attribute("pid").Value == producer.Attribute("id").Value).Remove();
            
            MessageBox.Show($"Категория {producer.Attribute("name").Value} успешно удалена");
            producer.Remove();
            ProductsDoc.Save(@"..\..\Data\Products.xml");
            ProducersDoc.Save(@"..\..\Data\Producers.xml");
            this.DialogResult = true;

        }
    }
}
