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
            int totalCalories = proteinCalories + 0;

            // What is wrong here?
            lbl_CaloriesToConsume.Text = totalCalories.ToString();

            if (totalCalories < 1500){
                lbl_CaloriesToConsume.Foreground = Brushes.Green;
            }
            else if (totalCalories >= 1500 && totalCalories < 2000)
            {
                lbl_CaloriesToConsume.Foreground = Brushes.Yellow;
            }
            else if (totalCalories >= 1500 && totalCalories < 2000)
            {
                lbl_CaloriesToConsume.Foreground = Brushes.White;
            }
            else
            {
                lbl_CaloriesToConsume.Foreground = Brushes.Red;
            }

        }
    }
}
