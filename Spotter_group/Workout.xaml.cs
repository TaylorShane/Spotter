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


        string stevePath = @"file:///C:/Users/Gamer/Source/Repos/Spotter_group/Spotter_group/Data/workit.xml";


        public void setWorkoutInformation()
        {
        }

        private void workout_cboBox_DropDownClosed(object sender, EventArgs e)
        {
            string user_workout = workout_cboBox.Text;

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

            
                                             

        }

       
    }

}