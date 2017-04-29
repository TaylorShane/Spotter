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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : UserControl
    {
        public Admin()
        {
            InitializeComponent();
        }

        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Food.xml";

        private void cboBox_Proteins_DropDownClosed(object sender, EventArgs e)
        {
            /*
            string refItem = cboBox_Proteins.Text;
            MessageBox.Show(refItem);
            XDocument doc = XDocument.Load(shanePath);
            IEnumerable<string> CaloriesResult = from food_items in XDocument.Load(shanePath).Descendants("protein")
                                                 where (string)food_items.Element("name") == refItem
                                                 select food_items.Element("calories").Value;
            
            tboxProteinCalories.Text = CaloriesResult.FirstOrDefault().ToString();
            */
        }
    }
}
