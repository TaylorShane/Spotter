using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
           
            for (int i = 0; i < 100; i++)
            {
                Random r = new Random(i);
                int a = r.Next();
                list.Add(a.ToString());
            }
           // this.ListBoxWorkoutsResults.ItemsSource = list;
           // this.lboxSelectedDateWorkoutDisplay.ItemsSource = list;
        }

        //public List<UserData> user = new List<UserData>();              
        // PATH LOCATION
        string jasonPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\SampleUsers.xml";
        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Users.xml";
        string currentUser = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/CurrentUser.xml";
        string user = "";
        List<DaysPassed> mydate = new List<DaysPassed>();

        public DateTime startDate;
        public double day;
        public string dayStringFormat;

        public class DaysPassed
        {
            public string days { get; set; }
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
            dayStringFormat = workoutStartDate.ToString();
            startDate =  Convert.ToDateTime(dayStringFormat);
            //startDate = startDT;


        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateClicked = calendar.SelectedDate.Value;
            
            day = (dateClicked - startDate).TotalDays;
            
            txtBlockDateSeleted.Text = calendar.SelectedDate.Value.ToString("MM/dd/yyyy");
            txtDaysPassed.Text = day.ToString();

            mydate.Add(new DaysPassed() { days = dayStringFormat });
            //lboxSelectedDateWorkoutDisplay.ItemsSource = mydate;
        }
        
        public ObservableCollection<string> list = new ObservableCollection<string>();
       
        public Visual GetDescendantByType(Visual element, Type type)
        {
            if (element == null) return null;
            if (element.GetType() == type) return element;
            Visual foundElement = null;
            if (element is FrameworkElement)
            {
                (element as FrameworkElement).ApplyTemplate();
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = GetDescendantByType(visual, type);
                if (foundElement != null)
                    break;
            }
            return foundElement;
        }
        private void lbx1_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer _listboxScrollViewer1 = GetDescendantByType(ListBoxWorkoutsResults, typeof(ScrollViewer)) as ScrollViewer;
            ScrollViewer _listboxScrollViewer2 = GetDescendantByType(lboxSelectedDateWorkoutDisplay, typeof(ScrollViewer)) as ScrollViewer;
            ScrollViewer _listboxScrollViewer3 = GetDescendantByType(lboxWorkoutDayDisplay, typeof(ScrollViewer)) as ScrollViewer;
            _listboxScrollViewer2.ScrollToVerticalOffset(_listboxScrollViewer1.VerticalOffset);
            _listboxScrollViewer3.ScrollToVerticalOffset(_listboxScrollViewer1.VerticalOffset);
        }
    }
}

