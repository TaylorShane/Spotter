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
        string jasonPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\SampleUsers.xml";
        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Users.xml";
        // PATH LOCATION
        DateTime futureDate = new DateTime(2017, 05, 30);
        public DateTime startDate;
        public void populateStartDate()
        {
            /* how to convert from string to DateTime
            * string date = "01/08/2008";
            * DateTime dt = Convert.ToDateTime(date);
            * 
            * DateTime to String
            * Value.ToString("MM/dd/yyyy")
            * 
            * (EndDate - StartDate).TotalDays
            * 
            *   DateTime userStartDate;
            *   userStartDate = DateTime.Parse(userStartDate);
            *   string workoutstartdate = UserWorkoutStartDate.FirstOrDefault().ToString();
            *   datePickerWorkoutStartDate.SelectedDate = DateTime.Parse(workoutstartdate);
            *   public DateTime startdate = new DateTime(2017, 04, 01);
            */

            string thisUser = "MasterOfTheUniverse"; // replace with global user ID
            IEnumerable<string> thisUserStartDate = from Users in XDocument.Load(shanePath).Descendants("User")
                                                    where (string)Users.Element("Username") == thisUser
                                                    select Users.Element("StartDate").Value;


            string workoutStartDate = thisUserStartDate.FirstOrDefault().ToString();
            txtStartDate.Text = workoutStartDate;
            DateTime startDT = Convert.ToDateTime(workoutStartDate);
            startDate = startDT;
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateClicked = calendar.SelectedDate.Value;
            double day = (dateClicked - startDate).TotalDays;

            txtBlockDateSeleted.Text = calendar.SelectedDate.Value.ToString("MM/dd/yyyy");
            txtDaysPassed.Text = day.ToString();

        }

        // public DateTime startdate = new DateTime(2017, 04, 01);
    }
}
