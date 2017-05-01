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
        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/SampleUsers.xml";
        // PATH LOCATION

        public void populateStartDate()
        {
            /* how to convert from string to DateTime
            // string date = "01/08/2008";
            // DateTime dt = Convert.ToDateTime(date);
            */

            txtBlockTest.Text = startdate.ToString("dd/MM/yyyy");

            DateTime StartDate;
            string user = "Shane";
            IEnumerable<string> startDateResult = from Users in XDocument.Load(shanePath).Descendants("Users")
                                                 where (string)Users.Element("name") == user
                                                 select Users.Element("startDate").Value;

            txtBlockTest.Text = startDateResult.FirstOrDefault().ToString();
        }

        public DateTime startdate = new DateTime(2017, 04, 01);

        // txtBlockTest.Text = 

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            txtBlockDateSeleted.Text = calendar.SelectedDate.Value.ToString("dd/MM/yyyy");

        }

        // public DateTime startdate = new DateTime(2017, 04, 01);
    }
}
