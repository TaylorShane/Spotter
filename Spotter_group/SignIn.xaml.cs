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
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : UserControl
    {
      

        public SignIn()
        {
            InitializeComponent();
            
        }
        string currentPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\CurrentUser.xml";
        string jasonPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\Users.xml";
        string stevePath = @"C:/Users/drof/Source/Repos/Spotter_group/Spotter_group/Data/Users.xml";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            

            try
            {
                //this is trying to signin


                string user_name1 = user_name.Text;
                string pass_word1 = pass_word.Text;

                

                MessageBox.Show(user_name1);
                MessageBox.Show(pass_word1);

                /*
                //user da user name
                IEnumerable<string> UserName = from Users in XDocument.Load(stevePath).Descendants("User")
                                               where (string)Users.Element("Username") == user_name1
                                              select Users.Element("Username").Value;
*/


                //user password list of 1

                IEnumerable<string> UserPassword = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                   where (string)Users.Element("Username") == user_name1
                                                   select Users.Element("Password").Value;


                string s2 = UserPassword.FirstOrDefault().ToString();
                

                if (s2 != pass_word1)
                {
                    throw new Exception("Password Mismatch");
                }

                else
                {
                    XDocument xmlDocument = XDocument.Load(currentPath);
                    xmlDocument.Element("CurrentUser").Add(
                       new XElement("User", new XAttribute("ID", 0),
                       new XElement("UserName", user_name1)));
                    xmlDocument.Save(currentPath);



                    MessageBox.Show("Successful Login! \n Please return to profile");

                   
                }


                


            }


            //when login and password dont match, we catch the error and display box you are a naughty person
            catch (Exception err)
            {
                MessageBox.Show("Please Ty Aain! Password Mismatch!");
            }



        }
    }

   
}
 