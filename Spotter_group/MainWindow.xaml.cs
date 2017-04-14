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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            grid2.Children.Clear();
            grid2.Children.Add(profile);
        }

        private void MenuItemSignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            grid2.Children.Clear();
            grid2.Children.Add(signIn);
        }

        private void MenuItemRegister_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            grid2.Children.Clear();
            grid2.Children.Add(register);
        }

        private void MenuItemProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            grid2.Children.Clear();
            grid2.Children.Add(profile);
        }

        private void MenuItemSpotter_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void MenuItemCalendar_Click(object sender, RoutedEventArgs e)
        {
            Calendar calendar = new Calendar();
            grid2.Children.Clear();
            grid2.Children.Add(calendar);
        }

        private void MenuItemWorkout_Click(object sender, RoutedEventArgs e)
        {
            Workout workout = new Workout();
            grid2.Children.Clear();
            grid2.Children.Add(workout);
        }

        private void MenuItemNutrition_Click(object sender, RoutedEventArgs e)
        {
            Nutrition nutrition = new Nutrition();
            grid2.Children.Clear();
            grid2.Children.Add(nutrition);
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
