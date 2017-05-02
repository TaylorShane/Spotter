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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        string jasonPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\Users.xml";
        string currentPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\CurrentUser.xml";

        List<WorkoutProgress> workout = new List<WorkoutProgress>();
        string cUser = "";
        

        public Profile()
        {
            InitializeComponent();
            findUser();
        }

        public void findUser()
        {
            IEnumerable<string> CurrentUser = from CurrentUsers in XDocument.Load(currentPath).Descendants("User")
                                              select CurrentUsers.Element("UserName").Value;

            cUser = CurrentUser.FirstOrDefault().ToString();
            populatePage();

        }

        public void populatePage()
        {
            try
            {
                
                string refItem = cUser;
                string fName = "";
                string lName = "";
                string name = "";
                string progressImage = "";

                XDocument doc = XDocument.Load(jasonPath);

                // First Name
                IEnumerable<string> UserFirstName = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                    where (string)Users.Element("Username") == refItem
                                                    select Users.Element("FirstName").Value;

                fName = UserFirstName.FirstOrDefault().ToString();

                // Last Name
                IEnumerable<string> UserLastName = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                   where (string)Users.Element("Username") == refItem
                                                   select Users.Element("LastName").Value;

                lName = UserLastName.FirstOrDefault().ToString();
                name = fName + " " + lName;
                lblName.Content = name;


                // Birth Date
                IEnumerable<string> UserBirthDate = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                    where (string)Users.Element("Username") == refItem
                                                    select Users.Element("BirthDate").Value;

                lblDOB.Content = UserBirthDate.FirstOrDefault().ToString();


                // Workout
                IEnumerable<string> UserWorkout = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                  where (string)Users.Element("Username") == refItem
                                                  select Users.Element("Workout").Value;

                lblWorkout.Content = UserWorkout.FirstOrDefault().ToString();

                // Workout Start Date
                IEnumerable<string> UserWorkoutStartDate = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                           where (string)Users.Element("Username") == refItem
                                                           select Users.Element("StartDate").Value;


                lblStartDate.Content = UserWorkoutStartDate.FirstOrDefault().ToString();

                // Gender
                IEnumerable<string> UserGender = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                 where (string)Users.Element("Username") == refItem
                                                 select Users.Element("Gender").Value;

                lblGender.Content = UserGender.FirstOrDefault().ToString();

                // UserName
                IEnumerable<string> UserName = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                 where (string)Users.Element("Username") == refItem
                                                 select Users.Element("Username").Value;

                lblUsername.Content = UserName.FirstOrDefault().ToString();

                // Current Weight
                IEnumerable<string> UserCurrentWeight = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                        where (string)Users.Element("Username") == refItem
                                                        select Users.Element("CurrentWeight").Value;

                lblWeight.Content = UserGender.FirstOrDefault().ToString();

                // Heigth
                IEnumerable<string> UserHeight = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                 where (string)Users.Element("Username") == refItem
                                                 select Users.Element("CurrentHeight").Value;

                lblHeight.Content = UserHeight.FirstOrDefault().ToString();

                // Password
                IEnumerable<string> UserPassword = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                   where (string)Users.Element("Username") == refItem
                                                   select Users.Element("Password").Value;

                lblPassword.Content = UserPassword.FirstOrDefault().ToString();


                //Progress bar
                int count = 75;
                

                             
               //Image
                IEnumerable<string> progImage = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                   where (string)Users.Element("Username") == refItem
                                                   select Users.Element("ImageAfter").Value;

                progressImage = progImage.FirstOrDefault().ToString();

                workout.Add(new WorkoutProgress() { Progress = count, image = progressImage });
                ListWorkout.ItemsSource = workout;

            }
            catch (Exception er)
            {
                MessageBox.Show("Check the file path.  Make sure it works for your machine.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            populatePage();

        }
    }

    public class WorkoutProgress
    {
        public int Progress { get; set; }
        public string image { get; set; }
    }

    

}
