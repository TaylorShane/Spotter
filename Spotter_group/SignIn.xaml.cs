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


        string stevePath = @"file:///C:/Users/Gamer/Source/Repos/Spotter_group/Spotter_group/Data/Signin.xml";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();

            UserGlobal use_me = new UserGlobal();

            try
            {

                string user_name1 = user_name.Text;
                string pass_word1 = pass_word.Text;

                use_me.set_user_Name(user_name1);


                string new1 = "";

                XDocument xmlDoc = XDocument.Load(stevePath);

                new1 = xmlDoc.Element("users")
                        .Elements("profile")
                        .Where(x => x.Attribute("Id").Value == user_name1)
                        .FirstOrDefault()
                        .ToString();

                MessageBox.Show(new1 + "!!!");

            }

            catch(Exception err)
            {
                MessageBox.Show("There was a serious Error! \n" +
                    err.ToString());
                    }


        }
    }
}
