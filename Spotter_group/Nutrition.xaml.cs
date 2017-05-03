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

        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Food.xml";
        // PATH LOCATION
        public int TotalMealsCalories = 0;

        public void getTotalMealCalories(int total)
        {

        }
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
                txtThisMealCalories.Text = totalCalories.ToString();
                string display = txtThisMealCalories.Text;

                TotalMealsCalories += totalCalories;
                var converter = new System.Windows.Media.BrushConverter();
                var teal = (Brush)converter.ConvertFromString("#009999");

                getTotalMealCalories(TotalMealsCalories);
                lblCalorieTotal.Text = TotalMealsCalories.ToString();

                if (TotalMealsCalories < 1500)
                {
                    lblCalorieTotal.Foreground = Brushes.Green;
                }
                else if (TotalMealsCalories >= 1800 && TotalMealsCalories < 2000)
                {
                    lblCalorieTotal.Foreground = Brushes.Yellow;
                }
                else if (TotalMealsCalories == 2000)
                {
                    display = lblCalorieTotal.Text;

                    lblCalorieTotal.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#009999")); ;
                    lblCalorieTotal.Text = "Great! " + display + " calories";
                }
                else if(TotalMealsCalories > 2000)
                {
                    lblCalorieTotal.Foreground = Brushes.Red;
                }


            }
            catch (Exception er)
            { // vs17 kept giving me crap for not displaying the er.tostring sorry 
                MessageBox.Show("Please enter a numeric value for each calorie count box" + er.ToString());
            }
        }
        
        private void cboBox_Proteins_DropDownClosed(object sender, EventArgs e)
        {
            
            string refItem = cboBox_Proteins.Text;
            // MessageBox.Show(refItem);

            IEnumerable<string> CaloriesResult = from food_items in XDocument.Load(shanePath).Descendants("protein")
                                        where (string)food_items.Element("name") == refItem
                                                 select food_items.Element("calories").Value;

            try
            {
                tboxProteinCalories.Text = CaloriesResult.FirstOrDefault().ToString();
            }
            catch (Exception er)
            {
                tboxProteinCalories.Text = 0.ToString();
            }
        }

        private void cboBox_Vegetables_DropDownClosed(object sender, EventArgs e)
        {
            string refItem = cboBox_Vegetables.Text;
            // MessageBox.Show(refItem);

            IEnumerable<string> CaloriesResult = from food_items in XDocument.Load(shanePath).Descendants("veggie")
                                                 where (string)food_items.Element("name") == refItem
                                                 select food_items.Element("calories").Value;

            
            try
            {
                tboxVeggieCalories.Text = CaloriesResult.FirstOrDefault().ToString();
            }
            catch (Exception er)
            {
                tboxProteinCalories.Text = 0.ToString();
            }
        }

        private void cboBox_Fruits_DropDownClosed(object sender, EventArgs e)
        {
            string refItem = cboBox_Fruits.Text;
            // MessageBox.Show(refItem);

            IEnumerable<string> CaloriesResult = from food_items in XDocument.Load(shanePath).Descendants("fruit")
                                                 where (string)food_items.Element("name") == refItem
                                                 select food_items.Element("calories").Value;

            
            try
            {
                tboxFruitsCalories.Text = CaloriesResult.FirstOrDefault().ToString();
            }
            catch (Exception er)
            {
                tboxProteinCalories.Text = 0.ToString();
            }
        }

        private void cboBox_Alcohol_DropDownClosed(object sender, EventArgs e)
        {
            string refItem = cboBox_Alcohol.Text;
            // MessageBox.Show(refItem);

            IEnumerable<string> CaloriesResult = from food_items in XDocument.Load(shanePath).Descendants("alcohol")
                                                 where (string)food_items.Element("name") == refItem
                                                 select food_items.Element("calories").Value;

            
            try
            {
                tboxAlcoholCalories.Text = CaloriesResult.FirstOrDefault().ToString();
            }
            catch (Exception er)
            {
                tboxProteinCalories.Text = 0.ToString();
            }
        }

        private void cboBox_Misc_DropDownClosed(object sender, EventArgs e)
        {
            string refItem = cboBox_Misc.Text;
            // MessageBox.Show(refItem);

            IEnumerable<string> CaloriesResult = from food_items in XDocument.Load(shanePath).Descendants("other")
                                                 where (string)food_items.Element("name") == refItem
                                                 select food_items.Element("calories").Value;

            
            try
            {
                tboxMiscCalories.Text = CaloriesResult.FirstOrDefault().ToString();
            }
            catch (Exception er)
            {
                tboxProteinCalories.Text = 0.ToString();
            }
        }
    }
}
