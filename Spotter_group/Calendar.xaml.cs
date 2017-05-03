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
            populateDataGrid();

        }
        public class Record
        {
            public string Day { get; set; }
            public string Muscle { get; set; }
            public string Workout { get; set; }
            public string Details { get; set; }
        }

        public void populateDataGrid()
        {
            try
            {
                
                IEnumerable<string> day1 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                           where (string)Exercises.Element("workout").Attribute("id") == "lWv1"
                                          select Exercises.Element("workout").Element("day").Value;

                string date1 = day1.FirstOrDefault().ToString();


                IEnumerable<string> muscle1 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                              where (string)Exercises.Element("workout").Attribute("id") == "lWv1"
                                              select Exercises.Element("workout").Element("muscle").Value;

                string musc1 = muscle1.FirstOrDefault().ToString();

                IEnumerable<string> workout1 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                               where (string)Exercises.Element("workout").Attribute("id") == "lWv1"
                                               select Exercises.Element("workout").Element("name").Value;

                string wo1 = workout1.FirstOrDefault().ToString();

                IEnumerable<string> dets1 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                            where (string)Exercises.Element("workout").Attribute("id") == "lWv1"
                                            select Exercises.Element("workout").Element("details").Value;

                string details1 = dets1.FirstOrDefault().ToString();
                /*
                IEnumerable<string> day2 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                           where (string)Exercises.Element("workout").Attribute("id") == "lWv2"
                                           select Exercises.Element("workout").Element("day").Value;

                string date2 = day2.FirstOrDefault().ToString();



                IEnumerable<string> muscle2 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                              where (string)Exercises.Element("workout").Attribute("id") == "lWv2"
                                              select Exercises.Element("workout").Element("muscle").Value;

                string musc2 = muscle2.FirstOrDefault().ToString();


                IEnumerable<string> workout2 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                               where (string)Exercises.Element("workout").Attribute("id") == "lWv2"
                                               select Exercises.Element("workout").Element("name").Value;

                string wo2 = workout2.FirstOrDefault().ToString();

                IEnumerable<string> dets2 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                            where (string)Exercises.Element("workout").Attribute("id") == "lWv2"
                                            select Exercises.Element("workout").Element("details").Value;

                string details2 = dets2.FirstOrDefault().ToString();
                
                                IEnumerable<string> day3 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                                           where (string)Exercises.Element("workout").Attribute("id") == "lWv3"
                                                           select Exercises.Element("workout").Element("day").Value;

                                string date3 = day3.FirstOrDefault().ToString();


                                IEnumerable<string> muscle3 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                                              where (string)Exercises.Element("workout").Attribute("id") == "lWv3"
                                                              select Exercises.Element("workout").Element("muscle").Value;

                                string musc3 = muscle3.FirstOrDefault().ToString();

                                IEnumerable<string> workout3 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                                               where (string)Exercises.Element("workout").Attribute("id") == "lWv3"
                                                               select Exercises.Element("workout").Element("name").Value;

                                string wo3 = workout3.FirstOrDefault().ToString();

                                IEnumerable<string> dets3 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                                            where (string)Exercises.Element("workout").Attribute("id") == "lWv3"
                                                            select Exercises.Element("workout").Element("details").Value;

                                string details3 = dets3.FirstOrDefault().ToString();

                
                                               IEnumerable<string> day4 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                                          where (string)Exercises.Element("workout").Attribute("id") == "lWv4"
                                                         select Exercises.Element("workout").Element("day").Value;

                               string date4 = day4.FirstOrDefault().ToString();


                               IEnumerable<string> muscle4 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                                             where (string)Exercises.Element("workout").Attribute("id") == "lWv4"
                                                             select Exercises.Element("workout").Element("muscle").Value;

                               string musc4 = muscle4.FirstOrDefault().ToString();

                               IEnumerable<string> workout4 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                                              where (string)Exercises.Element("workout").Attribute("id") == "lWv4"
                                                              select Exercises.Element("workout").Element("name").Value;

                               string wo4 = workout4.FirstOrDefault().ToString();

                               IEnumerable<string> dets4 = from Exercises in XDocument.Load(jasonExercisePath).Descendants("Exercises")
                                                           where (string)Exercises.Element("workout").Attribute("id") == "lWv4"
                                                           select Exercises.Element("workout").Element("details").Value;

                               string details4 = dets4.FirstOrDefault().ToString();
                              */
                dataGrid.ItemsSource = new Record[] {
                new Record {
                Day = date1,
                Muscle = musc1,
                Workout = wo1,
                Details = details1
                },/*
                new Record {
                Day = date2,
                Muscle = musc2,
                Workout = wo2,
                Details = details2
                },
                new Record {
                Day = date3,
                Muscle = musc3,
                Workout = wo3,
                Details = details3
                },
                new Record {
                Day = date4,
                Muscle = musc4,
                Workout = wo4,
                Details = details4
                }*/
            };
                dataGrid.IsReadOnly = true;

            }
            catch ( Exception err)
            {
                MessageBox.Show("not working");
            }




        }

        //public List<UserData> user = new List<UserData>();              
        // PATH LOCATION
        string currentPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\CurrentUser.xml";

        string jasonPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\Users.xml";
        string jasonExercisePath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\Exercises.xml";
        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Users.xml";
        string currentUser = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/CurrentUser.xml";
        string shaneExercisePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Exercises.xml";
        string user = "";

        string dayStringFormat = DateTime.Now.ToString();
       	


        public double day = 0;
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

            //result = "day" + dayStringFormat;
            //mydate.Add(new DaysPassed() { days = "Source={StaticResource workouts}, XPath=" + dayStringFormat });
            // Source={StaticResource workouts}, XPath=day2
            //MessageBox.Show(result);
            //lboxSelectedDateWorkoutDisplay.ItemsSource = mydate;
        }

        public void populateStartDate()
        {
            //Get current user
            // replace with global user ID
            IEnumerable<string> thisUser = from CurrentUser in XDocument.Load(currentPath).Descendants("User")
                                           select CurrentUser.Element("UserName").Value;

            user = thisUser.FirstOrDefault().ToString();

            //Get current username startdate

            IEnumerable<string> thisUserStartDate = from Users in XDocument.Load(jasonPath).Descendants("User")
                                                    where (string)Users.Element("Username") == user
                                                    select Users.Element("StartDate").Value;


            string workoutStartDate = thisUserStartDate.FirstOrDefault().ToString();
            txtStartDate.Text = workoutStartDate;
            startDate = Convert.ToDateTime(workoutStartDate);
            //startDate = startDT;

           
        }




    }
   
}
