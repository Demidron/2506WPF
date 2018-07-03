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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            int k = categoriesList.SelectedIndex;
            string CategoryPath = @"..\..\Data\Categories.xml";
            XDocument doc = XDocument.Load(CategoryPath);

            XElement root = doc.Element("root");
            var categories = root.Elements("category");

            var category = categories.ToList()[k];
            //var category = categories.Where(c => c.Attribute("id").Value == k.ToString()).FirstOrDefault();
            if(category==null || k==0)
            {
                return;
            }
            XDocument ProductsDoc = XDocument.Load(@"..\..\Data\Products.xml");
            XDocument ProducersDoc = XDocument.Load(@"..\..\Data\Producers.xml");

            var products = ProductsDoc.Element("root").Elements("Product");
            var producers = ProducersDoc.Element("root").Elements("Producer");
            products.Where(x => x.Attribute("cid").Value == category.Attribute("id").Value).Remove();
            producers.Where(x => x.Attribute("cid").Value == category.Attribute("id").Value).Remove();  

            category.Remove();
            doc.Save(CategoryPath);
            ProducersDoc.Save(@"..\..\Data\Produsers.xml");
            ProductsDoc.Save(@"..\..\Data\Products.xml");

            MessageBox.Show($"Категория {category.Attribute("name").Value} успешно удалена");
            this.DialogResult = true;
        }
    }
}
