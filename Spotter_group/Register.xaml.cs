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
        int ID = 0;
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
            string password = tbPassword.Text;

            try
            {
                XDocument xmlDocument = XDocument.Load(jasonPath);

                xmlDocument.Element("Users").Add(
                    new XElement("User", new XAttribute("ID", ID),
                    new XElement("FirstName", firstName),
                    new XElement("LastName", lastName),
                    new XElement("Username", userName),
                    new XElement("CurrentWeight", currentWeight),
                    new XElement("CurrentHeight", currentHeight),
                    new XElement("Password", password)
                    ));
                xmlDocument.Save(jasonPath);

                ID++;
            }
            catch (Exception er)
            {
                MessageBox.Show("XML file could not be loaded.");
            }
        }

        private void cbFemale_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cbMale_Checked(object sender, RoutedEventArgs e)
        {

        }
        
        private void tbDOB_CalendarClosed(object sender, RoutedEventArgs e)
        {
        }


    }
}
