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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\CurrentUser.xml";
        string jasonPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\Users.xml";
        string shaneCurrentPath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/CurrentUser.xml";

        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            grid2.Children.Clear();
            grid2.Children.Add(register);
            
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItemAdmin_Click(object sender, RoutedEventArgs e)
        {

            IEnumerable<string> CurrentUser = from user1 in XDocument.Load(shaneCurrentPath).Descendants("User")
                                              select user1.Element("UserName").Value;

            string theUserName = CurrentUser.FirstOrDefault().ToString();



            MessageBox.Show(theUserName);



            IEnumerable<string> adminStuff = from user2 in XDocument.Load(shaneCurrentPath).Descendants("User")
                                             where (string)user2.Element("Username") == theUserName
                                             select user2.Element("Admin").Value;



            string adminVal = adminStuff.FirstOrDefault().ToString();

            MessageBox.Show(adminVal);

            if (adminVal == "Yes")
            {

                Admin admin = new Admin();
                grid2.Children.Clear();
                grid2.Children.Add(admin);

            }

            else
            {
                MessageBox.Show("Game Over");
            }




     
        }

        private void MenuItemUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            UpdateUser updateUser = new UpdateUser();
            grid2.Children.Clear();
            grid2.Children.Add(updateUser);
        }

      

        private void btnSign_in_Click(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            grid2.Children.Clear();
            grid2.Children.Add(signIn);
            MenuItemSpotter.Visibility = System.Windows.Visibility.Visible;
        }

        private void menuLogOut_Click(object sender, RoutedEventArgs e)
        {
            XDocument xmlDocument = XDocument.Load(shaneCurrentPath);
            xmlDocument.Root.Elements().Remove();
            xmlDocument.Save(shaneCurrentPath);
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
