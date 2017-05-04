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
    /// Interaction logic for Workout.xaml
    /// </summary>
    /// 
  
    public partial class Workout : UserControl

       
    {
        public Workout()
        {
            InitializeComponent();
            setWorkoutInformation();
        }


        string stevePath = @"C:\Users\drof\Source\Repos\Spotter_group\Spotter_group\Data\workit.xml";
        string shaneWorkitPath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/workit.xml";
        string jasonPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\SampleUsers.xml";
        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Users.xml";
        string currentUser = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/CurrentUser.xml";
        string user = "";

        public void setWorkoutInformation()
        {
        }

       /* private void workout_cboBox_DropDownClosed(object sender, EventArgs e)
        {
            

            workout_name.Text = user_workout;

           // MessageBox.Show(user_workout);

            IEnumerable<string> workouts = from exercise in XDocument.Load(stevePath).Descendants("muscle")
                                           where (string)exercise.Element("name") == user_workout
                                           select exercise.Element("machine").Value;

            //MessageBox.Show(workouts.FirstOrDefault());

            machine_name.Text = workouts.FirstOrDefault().ToString();


            IEnumerable<string> otherstuff = from exercise in XDocument.Load(stevePath).Descendants("muscle")
                                             where (string)exercise.Element("name") == user_workout
                                             select exercise.Element("details").Value;

          //  MessageBox.Show(otherstuff.FirstOrDefault());

            workout_instructions.Text = otherstuff.FirstOrDefault().ToString();
            }*/


        private void fun_button_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<string> otherstuff = from exercise in XDocument.Load(shaneWorkitPath).Descendants("muscle")
                                                         select exercise.Element("details").Value;

            IEnumerable<string> otherstuff2 = from exercise in XDocument.Load(shaneWorkitPath).Descendants("muscle")
                                             select exercise.Element("machine").Value;

            Random rand = new Random();
            


            int i_count = 0;
            int m_count = 0;
            string[] instruction_Array = new string[99];
            string[] machine_Array = new string[99];





            foreach (var item in otherstuff)
            {

                instruction_Array[i_count] = item;
                i_count++;
            }

            


            foreach (var item in otherstuff2)
            {

                machine_Array[m_count] = item;
                m_count++;
            }






            int lucky = rand.Next(0, i_count);

            workout_instructions.Text = instruction_Array[lucky];
            machine_name.Text = machine_Array[lucky];
           // MessageBox.Show(instruction_Array[lucky])



        }
    }


    /*
     * int count = 0;

            foreach(var item in otherstuff)
            {
                count++;
            }

            int[] funArray = new int[99];

            for(int i=0; i< count; i++)
            {
                funArray[i] = i;
            }

            var rando = funArray.*/



}
 