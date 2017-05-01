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
    /// Interaction logic for Register.xaml
    /// </summary>
    /// 


    public partial class Register : UserControl
    {
        string jasonPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\Users.xml";
        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Users.xml";

        int ID = 0;
        string gender = "";
        string workout = "";
        string dateOfBirth = "";
        string startDate = "";
        int nextID = 0;

        //PATH LOCATION

        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            string firstName = tbFirstName.Text;
            string lastName = tbLastName.Text;
            string userName = tbUserName.Text;
            string currentWeight = tbCurrentWeight.Text;
            string currentHeight = tbCurrentHeight.Text;
            string password = tbPassword.Password;
            string admin = "No";

            try
            {
                XDocument xmlDocument = XDocument.Load(jasonPath);
                //nextId = xmlDocument.Root.LastNode()
                int nextId = (int)xmlDocument.Descendants("User").Last().Attribute("ID");//  xmlDocument.Root.LastNode
                xmlDocument.Element("Users").Add(
                    new XElement("User", new XAttribute("ID", nextId + 1),
                    new XElement("FirstName", firstName),
                    new XElement("LastName", lastName),
                    new XElement("BirthDate", dateOfBirth),
                    new XElement("Username", userName),
                    new XElement("StartDate", startDate),
                    new XElement("Gender", gender),
                    new XElement("CurrentWeight", currentWeight),
                    new XElement("CurrentHeight", currentHeight),
                    new XElement("Password", password),
                    new XElement("Workout", workout),
                    new XElement("Admin", admin)
                    ));
                xmlDocument.Save(jasonPath);

                ID++;
                MessageBox.Show("User successfully added to database.");
                // this refresh method isn't working    this.NavigationService.Navigate(new Uri("Register.xaml", UriKind.Relative));
                // not this     Refresh();
            }
            catch (Exception er)
            {
                MessageBox.Show("XML file could not be loaded.");
            }


            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbDOB.SelectedDate = null;
            tbStartDate.SelectedDate = null;
            tbUserName.Text = "";
            tbCurrentWeight.Text = "";
            tbCurrentHeight.Text = "";
            cbFemale.IsChecked = false;
            cbMale.IsChecked = false;
            tbPassword.Password = "";
            tbConfirmPassword.Password = "";
            cbToneUp.IsChecked = false;
            cbGainMuslce.IsChecked = false;
            cbLoseWeight.IsChecked = false;
            cbCardio.IsChecked = false;


        }

        private void cbFemale_Checked(object sender, RoutedEventArgs e)
        {
            gender = cbFemale.Content.ToString();
        }

        private void cbMale_Checked(object sender, RoutedEventArgs e)
        {
            gender = cbMale.Content.ToString();
        }
        
        private void tbDOB_CalendarClosed(object sender, RoutedEventArgs e)
        {
           dateOfBirth = tbDOB.SelectedDate.Value.ToString("dd/MM/yyyy");
        }

        private void cbToneUp_Checked(object sender, RoutedEventArgs e)
        {
            workout = lblToneUP.Text;
        }

        private void cbGainMuslce_Checked(object sender, RoutedEventArgs e)
        {
            workout = lblGain.Text;
        }

        private void cbLoseWeight_Checked(object sender, RoutedEventArgs e)
        {
            workout = lblLoseWeight.Text;
        }

        private void cbCardio_Checked(object sender, RoutedEventArgs e)
        {
            workout = lblCardio.Text;
        }

        private void tbStartDate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            startDate = tbStartDate.SelectedDate.Value.ToString("dd/MM/yyyy");
        }
    }
}
