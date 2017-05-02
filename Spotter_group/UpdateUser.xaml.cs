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
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
   
    public partial class UpdateUser : UserControl
    {
        public UpdateUser()
        {
            InitializeComponent();
        }

        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Users.xml";

        private void cboBoxUsername_DropDownClosed(object sender, EventArgs e)
        {
           
            string refItem = cboBoxUsername.Text;
            string FirstName = txtBoxFirstName.Text;
            string LastName = txtBoxLastName.Text;
            string BirthDate = datePickerBirthDate.Text;
            string StartDate = datePickerWorkoutStartDate.Text;
            string Gender = txtBoxGender.Text;
            string CurrentWeight = txtBoxCurrentWeight.Text;
            string CurrentHeight = txtBoxHeight.Text;
            string Password = txtBoxPassword.Text;
            string Workout = cboBoxWorkout.Text;
            string Admin = cboBoxAdmin.Text;

            try
            {
                // First Name
                IEnumerable<string> UserFirstName = from Users in XDocument.Load(shanePath).Descendants("User")
                                                    where (string)Users.Element("Username") == refItem
                                                    select Users.Element("FirstName").Value;

                txtBoxFirstName.Text = UserFirstName.FirstOrDefault().ToString();

                // Last Name
                IEnumerable<string> UserLastName = from Users in XDocument.Load(shanePath).Descendants("User")
                                                   where (string)Users.Element("Username") == refItem
                                                   select Users.Element("LastName").Value;
                
                txtBoxLastName.Text = UserLastName.FirstOrDefault().ToString();

                // Birth Date
                IEnumerable<string> UserBirthDate = from Users in XDocument.Load(shanePath).Descendants("User")
                                                    where (string)Users.Element("Username") == refItem
                                                    select Users.Element("BirthDate").Value;

                string DOB = UserBirthDate.FirstOrDefault().ToString();
                datePickerBirthDate.SelectedDate = DateTime.Parse(DOB);
                

                // Workout
                IEnumerable<string> UserWorkout = from Users in XDocument.Load(shanePath).Descendants("User")
                                                  where (string)Users.Element("Username") == refItem
                                                  select Users.Element("Workout").Value;

                cboBoxWorkout.Text = UserWorkout.FirstOrDefault().ToString();

                // Workout Start Date
                IEnumerable<string> UserWorkoutStartDate = from Users in XDocument.Load(shanePath).Descendants("User")
                                                           where (string)Users.Element("Username") == refItem
                                                           select Users.Element("StartDate").Value;


                string workoutstartdate = UserWorkoutStartDate.FirstOrDefault().ToString();                
                datePickerWorkoutStartDate.SelectedDate = DateTime.Parse(workoutstartdate); 

                // Gender
                IEnumerable<string> UserGender = from Users in XDocument.Load(shanePath).Descendants("User")
                                                 where (string)Users.Element("Username") == refItem
                                                 select Users.Element("Gender").Value;

                txtBoxGender.Text = UserGender.FirstOrDefault().ToString();

                // Current Weight
                IEnumerable<string> UserCurrentWeight = from Users in XDocument.Load(shanePath).Descendants("User")
                                                        where (string)Users.Element("Username") == refItem
                                                        select Users.Element("CurrentWeight").Value;

                txtBoxCurrentWeight.Text = UserGender.FirstOrDefault().ToString();

                // Heigth
                IEnumerable<string> UserHeight = from Users in XDocument.Load(shanePath).Descendants("User")
                                                   where (string)Users.Element("Username") == refItem
                                                   select Users.Element("CurrentHeight").Value;

                txtBoxHeight.Text = UserHeight.FirstOrDefault().ToString();

                // Password
                IEnumerable<string> UserPassword = from Users in XDocument.Load(shanePath).Descendants("User")
                                                   where (string)Users.Element("Username") == refItem
                                                   select Users.Element("Password").Value;

                txtBoxPassword.Text = UserPassword.FirstOrDefault().ToString();

                // Admin
                IEnumerable<string> UserAdmin = from Users in XDocument.Load(shanePath).Descendants("User")
                                                   where (string)Users.Element("Username") == refItem
                                                   select Users.Element("Admin").Value;

                cboBoxAdmin.Text = UserAdmin.FirstOrDefault().ToString();
            }
            catch(Exception er)
            {
                MessageBox.Show("Check the file path.  Make sure it works for your machine.");
            }
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            string refItem = cboBoxUsername.Text;
            string FirstName = txtBoxFirstName.Text;
            string LastName = txtBoxLastName.Text;
            string BirthDate = datePickerWorkoutStartDate.Text;
            string StartDate = datePickerWorkoutStartDate.Text;
            string Gender = txtBoxGender.Text;
            string CurrentWeight = txtBoxCurrentWeight.Text;
            string CurrentHeight = txtBoxHeight.Text;
            string Password = txtBoxPassword.Text;
            string Workout = cboBoxWorkout.Text;
            string Admin = cboBoxAdmin.Text;

            try
            {
                XDocument doc = XDocument.Load(shanePath);

                doc.Element("Users")
                    .Elements("User")
                    .Where(x => x.Element("Username").Value == refItem).FirstOrDefault()
                    .SetElementValue("FirstName", FirstName );
                doc.Element("Users")
                   .Elements("User")
                   .Where(x => x.Element("Username").Value == refItem).FirstOrDefault()
                   .SetElementValue("LastName", LastName);
                doc.Element("Users")
                   .Elements("User")
                   .Where(x => x.Element("Username").Value == refItem).FirstOrDefault()
                   .SetElementValue("BirthDate", BirthDate);
                doc.Element("Users")
                   .Elements("User")
                   .Where(x => x.Element("Username").Value == refItem).FirstOrDefault()
                   .SetElementValue("StartDate", StartDate);
                doc.Element("Users")
                   .Elements("User")
                   .Where(x => x.Element("Username").Value == refItem).FirstOrDefault()
                   .SetElementValue("Gender", Gender);
                doc.Element("Users")
                   .Elements("User")
                   .Where(x => x.Element("Username").Value == refItem).FirstOrDefault()
                   .SetElementValue("CurrentWeight", CurrentWeight);
                doc.Element("Users")
                   .Elements("User")
                   .Where(x => x.Element("Username").Value == refItem).FirstOrDefault()
                   .SetElementValue("CurrentHeight", CurrentHeight);
                doc.Element("Users")
                   .Elements("User")
                   .Where(x => x.Element("Username").Value == refItem).FirstOrDefault()
                   .SetElementValue("Password", Password);
                doc.Element("Users")
                   .Elements("User")
                   .Where(x => x.Element("Username").Value == refItem).FirstOrDefault()
                   .SetElementValue("Workout", Workout);
                doc.Element("Users")
                   .Elements("User")
                   .Where(x => x.Element("Username").Value == refItem).FirstOrDefault()
                   .SetElementValue("Admin", Admin);


                doc.Save(shanePath);
                MessageBox.Show("User successfully updated");
                
            }

            catch(Exception er)
            {
                MessageBox.Show("User not updated");
            }
        }
    }
}
