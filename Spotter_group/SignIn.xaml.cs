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
        UserGlobal use_me = new UserGlobal();

        public SignIn()
        {
            InitializeComponent();
            
        }


        string stevePath = @"C:/Users/drof/Source/Repos/Spotter_group/Spotter_group/Data/Users.xml";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // SignIn signIn = new SignIn();

            

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

                IEnumerable<string> UserPassword = from Users in XDocument.Load(stevePath).Descendants("User")
                                                   where (string)Users.Element("Username") == user_name1
                                                   select Users.Element("Password").Value;


                string s2 = UserPassword.FirstOrDefault().ToString();
                

                if (s2 != pass_word1)
                {
                    throw new Exception("Password Mismatch");
                }

                else
                {
                    MessageBox.Show("Successful Login! \n Please return to profile");

                    //set global first name
                    IEnumerable<string> FirstName = from Users in XDocument.Load(stevePath).Descendants("User")
                                                       where (string)Users.Element("Username") == user_name1
                                                       select Users.Element("FirstName").Value;


                    string firstname = FirstName.FirstOrDefault().ToString();
                    use_me.set_First_Name(firstname);

                    //set global last name
                    IEnumerable<string> LastName = from Users in XDocument.Load(stevePath).Descendants("User")
                                                    where (string)Users.Element("Username") == user_name1
                                                    select Users.Element("LastName").Value;


                    string lastname = LastName.FirstOrDefault().ToString();
                    use_me.set_Last_Name(lastname);

                    //set global birth
                    IEnumerable<string> birth = from Users in XDocument.Load(stevePath).Descendants("User")
                                                   where (string)Users.Element("Username") == user_name1
                                                   select Users.Element("LastName").Value;


                    string birthdate = birth.FirstOrDefault().ToString();
                    use_me.set_Birth_Date(birthdate);

                    //set global username
                    IEnumerable<string> username = from Users in XDocument.Load(stevePath).Descendants("User")
                                                where (string)Users.Element("Username") == user_name1
                                                select Users.Element("Username").Value;


                    string username1 = username.FirstOrDefault().ToString();
                    use_me.set_user_Name(username1);

                    //set global startdate
                    IEnumerable<string> startdate = from Users in XDocument.Load(stevePath).Descendants("User")
                                                where (string)Users.Element("Username") == user_name1
                                                select Users.Element("LastName").Value;


                    string startdate1 = startdate.FirstOrDefault().ToString();
                    use_me.set_Start_Date(startdate1);

                    //set global gender
                    IEnumerable<string> gender = from Users in XDocument.Load(stevePath).Descendants("User")
                                                where (string)Users.Element("Username") == user_name1
                                                select Users.Element("Gender").Value;


                    string gender1 = gender.FirstOrDefault().ToString();
                    use_me.set_Gender(gender1);

                    //set global weight
                    IEnumerable<string> curr_W = from Users in XDocument.Load(stevePath).Descendants("User")
                                                 where (string)Users.Element("Username") == user_name1
                                                 select Users.Element("CurrentWeight").Value;


                    string current_WEight = curr_W.FirstOrDefault().ToString();
                    use_me.set_Gender(current_WEight);

                    //set global height
                    IEnumerable<string> user_height = from Users in XDocument.Load(stevePath).Descendants("User")
                                                 where (string)Users.Element("Username") == user_name1
                                                 select Users.Element("CurrentHeight").Value;


                    string height1 = user_height.FirstOrDefault().ToString();
                    use_me.set_Gender(height1);

                    //set global gender
                    IEnumerable<string> workout1 = from Users in XDocument.Load(stevePath).Descendants("User")
                                                 where (string)Users.Element("Username") == user_name1
                                                 select Users.Element("Workout").Value;


                    string workout2 = workout1.FirstOrDefault().ToString();
                    use_me.set_Workout(workout2);

                    //set global admin
                    IEnumerable<string> admin = from Users in XDocument.Load(stevePath).Descendants("User")
                                                 where (string)Users.Element("Username") == user_name1
                                                 select Users.Element("Gender").Value;


                    string admin1 = admin.FirstOrDefault().ToString();
                    use_me.set_Gender(admin1);

                    MessageBox.Show("Hopefully this shows some stuff \n" +
                        use_me.get_Gender + "<- should be gender");
                }


                


            }


            //when login and password dont match, we catch the error and display box you are a naughty person
            catch (Exception err)
            {
                MessageBox.Show("Please Ty Aain!");
            }




            /*use_me.set_user_Name(user_name1);


               string new1 = "";

               XDocument xmlDoc = XDocument.Load(stevePath);

               new1 = xmlDoc.Element("users")
                       .Elements("profile")
                       .Where(x => x.Attribute("Id").Value == user_name1)
                       .FirstOrDefault()
                       .ToString();

               MessageBox.Show(new1 + "!!!");



              // Password
               IEnumerable<string> UserPassword = from Users in XDocument.Load(shanePath).Descendants("User")
                                                  where (string)Users.Element("Username") == refItem
                                                  select Users.Element("Password").Value;

               txtBoxPassword.Text = UserPassword.FirstOrDefault().ToString();



*/
        }
    }

   
}

 
 
 