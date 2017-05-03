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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public Calendar()
        {
            InitializeComponent();
            populateStartDate();
        }

        //public List<UserData> user = new List<UserData>();              
        // PATH LOCATION
        string jasonPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\SampleUsers.xml";
        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Users.xml";
        string currentUser = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/CurrentUser.xml";
        string shaneExercisePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Exercises.xml";
        string user = "";
        public string dayStringFormat;
        double day = 0;
        List<Workouts> todaysWorkouts = new List<Workouts>();

        public string result;
        public DateTime startDate;

        public class Workouts
        {
            public string details1 { get; set; }
            public string details2 { get; set; }
            public string details3 { get; set; }
            public string details4 { get; set; }
        }
       
        

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateClicked = calendar.SelectedDate.Value;
            day = (dateClicked - startDate).TotalDays;
            dayStringFormat = day.ToString();
            txtBlockDateSeleted.Text = calendar.SelectedDate.Value.ToString("MM/dd/yyyy");
            txtDaysPassed.Text = dayStringFormat;

            result = "day" + dayStringFormat;
            //mydate.Add(new DaysPassed() { days = "Source={StaticResource workouts}, XPath=" + dayStringFormat });
            // Source={StaticResource workouts}, XPath=day2
            MessageBox.Show(result);
            //lboxSelectedDateWorkoutDisplay.ItemsSource = mydate;
        }

        public void populateStartDate()
        {
            //Get current user
            // replace with global user ID
            IEnumerable<string> thisUser = from CurrentUser in XDocument.Load(currentUser).Descendants("User")
                                           select CurrentUser.Element("UserName").Value;

            user = thisUser.FirstOrDefault().ToString();

            //Get current username startdate

            IEnumerable<string> thisUserStartDate = from Users in XDocument.Load(shanePath).Descendants("User")
                                                    where (string)Users.Element("Username") == user
                                                    select Users.Element("StartDate").Value;


            string workoutStartDate = thisUserStartDate.FirstOrDefault().ToString();
            txtStartDate.Text = workoutStartDate;
            startDate = Convert.ToDateTime(workoutStartDate);
            //startDate = startDT;

            IEnumerable<string> workout1 = from Exercises in XDocument.Load(shaneExercisePath).Descendants("workout")
                                           where (string)Exercises.Element("day") == dayStringFormat
                                           select Exercises.Element("details1").Value;
            try
            {
                MessageBox.Show(workout1.ToString());

                todaysWorkouts.Add(new Workouts() { details1 = workout1.FirstOrDefault().ToString() });
            }
            catch(Exception er)
            {
                MessageBox.Show(workout1.ToString());
            }

            
            IEnumerable<string> workout2 = from Exercises in XDocument.Load(shaneExercisePath).Descendants("workout")
                                           where (string)Exercises.Element("day") == dayStringFormat
                                           select Exercises.Element("details2").Value;

            todaysWorkouts.Add(new Workouts() { details2 = workout2.FirstOrDefault().ToString() });


            IEnumerable<string> workout3 = from Exercises in XDocument.Load(shaneExercisePath).Descendants("workout")
                                           where (string)Exercises.Element("day") == dayStringFormat
                                           select Exercises.Element("details3").Value;

            todaysWorkouts.Add(new Workouts() { details3 = workout3.FirstOrDefault().ToString() });


            IEnumerable<string> workout4 = from Exercises in XDocument.Load(shaneExercisePath).Descendants("workout")
                                           where (string)Exercises.Element("day") == dayStringFormat
                                           select Exercises.Element("details4").Value;

            todaysWorkouts.Add(new Workouts() { details4 = workout4.FirstOrDefault().ToString() });

            ListBoxWorkoutsResults.ItemsSource = todaysWorkouts;
        }
    }
   
}
