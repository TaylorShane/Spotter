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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void lblName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbName.Visibility = System.Windows.Visibility.Visible;
        }

        private void lblDOB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbDOB.Visibility = System.Windows.Visibility.Visible;
        }

        private void lblUsername_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbUsername.Visibility = System.Windows.Visibility.Visible;

        }

        private void lblWeight_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbWeight.Visibility = System.Windows.Visibility.Visible;

        }

        private void lblStartDate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbStartDate.Visibility = System.Windows.Visibility.Visible;

        }

        private void lblPassword_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbPassword.Visibility = System.Windows.Visibility.Visible;

        }

        private void lblWorkout_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            cbWorkouts.Visibility = System.Windows.Visibility.Visible;

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbGoals.Visibility = System.Windows.Visibility.Visible;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
