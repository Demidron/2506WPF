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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string name = pName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("производителя не ввели",
                    "",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
            }
            else
            {

                string path = @"..\..\Data\Producers.xml";
                XDocument doc = XDocument.Load(path);
                XElement root = doc.Element("root");
                var produsers = root.Elements("Producer");

                //task
                var lastProducer = produsers.LastOrDefault();
                int k = 0;
                if (lastProducer != null)
                {
                    k = Convert.ToInt32(lastProducer.Attribute("id").Value);
                    k++;
                }

                string path2 = @"..\..\Data\Categories.xml";
                XDocument doc2 = XDocument.Load(path2);
                XElement root2 = doc2.Element("root");
                var categories = root2.Elements("category");

                int categoryIndex = cList.SelectedIndex;
                if (categoryIndex == 0)
                {
                    MessageBox.Show("Категорию не ввели",
                    "",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                    return;
                }
                var category = categories.ToList()[categoryIndex];
 
                string cid = category.Attribute("id").Value;


                XElement elem = new XElement("Producer",
                    new XAttribute("id", k.ToString()),
                    new XAttribute("name", name),
                    new XAttribute("cid", cid));

                root.Add(elem);
                doc.Save(path);
                this.DialogResult = true;
            }

        }
    }
}
