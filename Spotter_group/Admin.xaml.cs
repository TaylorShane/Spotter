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
using System.Xml.Linq;

namespace Spotter_group
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : UserControl
    {
        public Admin()
        {
            InitializeComponent();
        }

        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Food.xml";

        private void cboBox_Proteins_DropDownClosed(object sender, EventArgs e)
        {

            /*
            string refItem = cboBoxFoodType.Text;
            MessageBox.Show(refItem);
            XDocument doc = XDocument.Load(shanePath);
            IEnumerable<string> CaloriesResult = from food_items in XDocument.Load(shanePath).Descendants("protein")
                                                 where (string)food_items.Element("name") == refItem
                                                 select food_items.Element("calories").Value;
            
            tboxProteinCalories.Text = CaloriesResult.FirstOrDefault().ToString();
            */
        }

        private void btnAddFood_Click(object sender, RoutedEventArgs e)
        {
            string foodType = cboBoxFoodType.Text;
            string name = txBoxFoodName.Text;
            string calories = txtBoxNewFoodCalories.Text;
            // Protein Vegetable  Fruit Alcohol Other

            if(foodType == "Protein")
            {
                try
                {
                    XDocument xmlDocument = XDocument.Load(shanePath);

                    xmlDocument.Element("food_items").AddFirst(//AddFirst()
                        new XElement("protein", foodType,
                        new XElement("name", name, new XAttribute("Id", name)),
                        new XElement("calories", calories))
                    );

                    xmlDocument.Save(shanePath);
                    MessageBox.Show("New Food Saved" + 
                        "\n" + "Type: " + foodType +
                        "\n" + "Name: " + name +
                        "\n" +"Calories: " + calories);
                }
                catch (Exception er)
                {
                    MessageBox.Show("XML file does not exist");
                }
            }

            else if (foodType == "Vegetable")
            {
                try
                {
                    XDocument xmlDocument = XDocument.Load(shanePath);

                    xmlDocument.Element("food_items").AddFirst(//AddFirst()
                        new XElement("veggie", foodType,
                        new XElement("name", name, new XAttribute("Id", name)),
                        new XElement("calories", calories))
                    );

                    xmlDocument.Save(shanePath);
                    MessageBox.Show("New Food Saved" +
                        "\n" + "Type: " + foodType +
                        "\n" + "Name: " + name +
                        "\n" + "Calories: " + calories);
                }
                catch (Exception er)
                {
                    MessageBox.Show("XML file does not exist" +
                        "\n" + "New food not added");
                }
            }

            else if (foodType == "Fruit")
            {
                try
                {
                    XDocument xmlDocument = XDocument.Load(shanePath);

                    xmlDocument.Element("food_items").AddFirst(//AddFirst()
                        new XElement("fruit", foodType,
                        new XElement("name", name, new XAttribute("Id", name)),
                        new XElement("calories", calories))
                    );

                    xmlDocument.Save(shanePath);
                    MessageBox.Show("New Food Saved" +
                        "\n" + "Type: " + foodType +
                        "\n" + "Name: " + name +
                        "\n" + "Calories: " + calories);
                }
                catch (Exception er)
                {
                    MessageBox.Show("XML file does not exist" +
                        "\n" + "New food not added");
                }
            }

            else if (foodType == "Alcohol")
            {
                try
                {
                    XDocument xmlDocument = XDocument.Load(shanePath);

                    xmlDocument.Element("food_items").AddFirst(//AddFirst()
                        new XElement("alcohol", foodType,
                        new XElement("name", name, new XAttribute("Id", name)),
                        new XElement("calories", calories))
                    );

                    xmlDocument.Save(shanePath);
                    MessageBox.Show("New Food Saved" +
                        "\n" + "Type: " + foodType +
                        "\n" + "Name: " + name +
                        "\n" + "Calories: " + calories);
                }
                catch (Exception er)
                {
                    MessageBox.Show("XML file does not exist" +
                        "\n" + "New food not added");
                }
            }

            else 
            {
                try
                {
                    XDocument xmlDocument = XDocument.Load(shanePath);

                    xmlDocument.Element("food_items").AddFirst(//AddFirst()
                        new XElement("Other", foodType,
                        new XElement("name", name, new XAttribute("Id", name)),
                        new XElement("calories", calories))
                    );

                    xmlDocument.Save(shanePath);
                    MessageBox.Show("New Food Saved" +
                        "\n" + "Type: " + foodType +
                        "\n" + "Name: " + name +
                        "\n" + "Calories: " + calories);
                }
                catch (Exception er)
                {
                    MessageBox.Show("XML file does not exist" +
                        "\n" + "New food not added");
                }
            }
        }
    }
}
