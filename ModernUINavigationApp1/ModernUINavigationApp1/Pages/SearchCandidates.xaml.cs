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

namespace ModernUINavigationApp1.Pages
{
    /// <summary>
    /// Interaction logic for SearchCandidates.xaml
    /// </summary>
    public partial class SearchCandidates : UserControl
    {
        public SearchCandidates()
        {
            InitializeComponent();
            List<Model.CVScored> data = new List<Model.CVScored>();
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                Model.CVScored item = new Model.CVScored() {
                    name = "user " + rand.NextDouble(),
                    workScore = 100 * rand.NextDouble(),
                    skillScore = 100 * rand.NextDouble(),
                    qualificationScore = 100 * rand.NextDouble()
                };
                data.Add(item);
            }
            dataGridUsers.DataContext = new[] { new Model.CVScored() };
            dataGridUsers.ItemsSource = data;
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
