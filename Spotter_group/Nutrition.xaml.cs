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

        private void btnSaveMeal_Click(object sender, RoutedEventArgs e)
        {
            
            string protein = cboBox_Proteins.Text;

            int proteinCalories = Convert.ToInt32(tboxProteinCalories.Text);
            int veggieCalories = Convert.ToInt32(tboxVeggieCalories.Text);
            int fruitsCalories = Convert.ToInt32(tboxFruitsCalories.Text);
            int alcoholCalories = Convert.ToInt32(tboxAlcoholCalories.Text);
            int miscCalories = Convert.ToInt32(tboxMiscCalories.Text);


            int totalCalories = proteinCalories + veggieCalories + fruitsCalories + alcoholCalories + miscCalories;


            
            txtBlock_CaloriesToConsume.Text = totalCalories.ToString();

            if (totalCalories < 1500){
                txtBlock_CaloriesToConsume.Foreground = Brushes.Green;
            }
            else if (totalCalories >= 1500 && totalCalories < 2000)
            {
                txtBlock_CaloriesToConsume.Foreground = Brushes.Yellow;
            }
            else if (totalCalories == 2000)
            {
                txtBlock_CaloriesToConsume.Foreground = Brushes.White;
                txtBlock_CaloriesToConsume.Text = "Great 2000 calories!";
            }
            else
            {
                txtBlock_CaloriesToConsume.Foreground = Brushes.Red;
                
            }
        }
    }
}
