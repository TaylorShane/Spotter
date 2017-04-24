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
    /// Interaction logic for Nutrition.xaml
    /// </summary>
    public partial class Nutrition : UserControl
    {
        public Nutrition()
        {
            InitializeComponent();
        }

        string path = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Food.xml";

        // List<string> Food = new List<string>();

        

        private void btnSaveMeal_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string protein = cboBox_Proteins.Text;
                int proteinCalories = Convert.ToInt32(tboxProteinCalories.Text);
                int veggieCalories = Convert.ToInt32(tboxVeggieCalories.Text);
                int fruitsCalories = Convert.ToInt32(tboxFruitsCalories.Text);
                int alcoholCalories = Convert.ToInt32(tboxAlcoholCalories.Text);
                int miscCalories = Convert.ToInt32(tboxMiscCalories.Text);
                int totalCalories = proteinCalories + veggieCalories + fruitsCalories + alcoholCalories + miscCalories;
                txtBlock_CaloriesToConsume.Text = totalCalories.ToString();
                string display = txtBlock_CaloriesToConsume.Text;

                var converter = new System.Windows.Media.BrushConverter();
                var teal = (Brush)converter.ConvertFromString("#009999");

                if (totalCalories < 1500)
                {
                    txtBlock_CaloriesToConsume.Foreground = Brushes.Green;
                }
                else if (totalCalories >= 1800 && totalCalories < 2000)
                {
                    txtBlock_CaloriesToConsume.Foreground = Brushes.Yellow;
                }
                else if (totalCalories == 2000)
                {
                    
                    display = txtBlock_CaloriesToConsume.Text;
                    
                    txtBlock_CaloriesToConsume.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#009999")); ;
                    txtBlock_CaloriesToConsume.Text = "Great! " + display + " calories";
                }
                else if(totalCalories > 2000)
                {
                    txtBlock_CaloriesToConsume.Foreground = Brushes.Red;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Please enter a numeric value for each calorie count box");
            }

        }

        private void cboBox_Proteins_DropDownClosed(object sender, EventArgs e)
        {
            /*  this doesn't work 
            XDocument xmlDocument = XDocument.Load(path);
            string foodItem = cboBox_Proteins.SelectedItem.ToString();
            var foodCalories = xmlDocument.Descendants("calories")
                .Where(item => item.Attribute("Id").Value.Equals("foodItem"));
            tboxProteinCalories.Text = foodCalories.ToString();
            */

            // Xdocument method
            string refItem = cboBox_Proteins.SelectedItem.ToString();
            XDocument xmlDocument = XDocument.Load(path);
            /*
            IEnumerable<string> foodcal = from Food in xmlDocument.Descendants("food_items")
                .Elements("food")
                .Elements("protein")
                .Where(x => x.Attribute("Id").Value == refItem)
                select Food.Element("calories").Value;
            */

            string caloriesFound = (from c in xmlDocument.Descendants("calories")
                                    where (string)c.Attribute("Id") == refItem
                                    select c.Element("calories").Value).ToString();

            tboxProteinCalories.Text = caloriesFound;

            //foodcal.ToString();

            // List method
            /*
            IEnumerable<String> calories = from xmlDoc in XDocument.Load(path).Descendants("Book")
                                        where (double)xmlDoc.Element("Price") > xmlDoc
                                        select xmlDoc.Element("Title").Value;

            IEnumerable<String> Price = from Books in XDocument.Load(path).Descendants("Book")
                                        where (double)Books.Element("Price") > BookPrice
                                        select Books.Element("Title").Value;

            XDocument xmlDoc = XDocument.Load(path);
            List<string> Foodlist = new List<string> { }; 
            Foodlist = xmlDoc.Root.Elements("Id")
                                       .Select(element => element.Value)
                                       .ToList();
            foreach (string c in Foodlist)
                MessageBox.Show(c);     
                */
        }

        public class Foodlist
        {
            public string name { get; set; }
            public string calories { get; set; }
        }
    }
}
