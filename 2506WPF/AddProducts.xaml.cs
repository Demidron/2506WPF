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
    /// Логика взаимодействия для AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Window
    {
        public AddProducts()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string name = ProductName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("имя не ввели",
                    "",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
            }
            else
            {


                XDocument doc = XDocument.Load(@"..\..\Data\Products.xml");
                var root = doc.Element("root");
                var product = doc.Element("root").Elements("Product");


                var lastProduct = product.LastOrDefault();
                int k = 0;
                if (lastProduct != null)
                {
                    k = Convert.ToInt32(lastProduct.Attribute("id").Value);
                    k++;
                }


                XDocument doc2 = XDocument.Load(@"..\..\Data\Producers.xml");
                XDocument doc3 = XDocument.Load(@"..\..\Data\Categories.xml");
                var producers = doc2.Element("root").Elements("Producer");

                if (producerList.SelectedIndex == 0)
                {
                    MessageBox.Show("производителя не ввели",
                    "",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                    return;
                }
                var producer = producers.ToList()[producerList.SelectedIndex];
                string pid = producer.Attribute("id").Value;
                string cid= producer.Attribute("cid").Value;
                string ProducerName = producer.Attribute("name").Value;
                string CategoryName = doc3.Element("root").Elements("category").First(x=>x.Attribute("id").Value==cid).Attribute("name").Value;
                //id="2" name="Костюмы" price="7528" num="50" pid="2" producer="Produser2" cid="1" category="Одежда"
                XElement elem = new XElement("Product",
                    new XAttribute("id", k.ToString()),
                    new XAttribute("name", name),
                    new XAttribute("price", priceName.Text),
                    new XAttribute("num", QuantityName.Text),
                    new XAttribute("pid", pid),
                    new XAttribute("producer", ProducerName),
                    new XAttribute("cid", cid),
                    new XAttribute("category", CategoryName));

                root.Add(elem);
                doc.Save(@"..\..\Data\Products.xml");
                this.DialogResult = true;
            }
        }
    }
}
