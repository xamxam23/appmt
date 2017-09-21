using ModernUINavigationApp1.Computation;
using ModernUINavigationApp1.Model;
using Newtonsoft.Json;
using ServiceLayer;
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
    class Criterion
    {
        public string skill { get; set; }
        public int minYears { get; set; }
        public string minQualifications { get; set; }
        public int minIndex { get; set; }
    }
    /// <summary>
    /// Interaction logic for SearchCriteria.xaml
    /// </summary>
    public partial class SearchCriteria : UserControl
    {
        List<Criterion> listOfCriterion = new List<Criterion>();
        public SearchCriteria()
        {
            InitializeComponent();
            ListView_Criteria.ItemsSource = new List<Criterion>();
        }

        private void Button_AddSkillSet_Click_1(object sender, RoutedEventArgs e)
        {
            // HideShowAddPanel(StackPanel_AddCriterion, Button_AddCriterion);
            Criterion criterion = new Criterion()
            {
                skill = Text_skill.Text,
                minQualifications = GetQualificationString(),
                minIndex = ComboBox_Qualifications.SelectedIndex,
                minYears = GetYears()
            };
            listOfCriterion.Insert(0, criterion);
            ListView_Criteria.ItemsSource = null;
            ListView_Criteria.ItemsSource = listOfCriterion;

        }
        int GetYears()
        {
            int years = 0;
            int.TryParse(Text_Years.Text,out years);
            
            return years;
        }
        string GetQualificationString()
        {
            int x = ComboBox_Qualifications.SelectedIndex;
            string[] q = { "High School", "Certification", "Diploma", "Degree", "Honor", "Master", "Phd" };
            if (x >= 0)
                return q[x];
            return "";
        }

        private void HideShowAddPanel(StackPanel panel, Button button)
        {
            if (panel.Visibility == System.Windows.Visibility.Collapsed)
            {
                panel.Visibility = System.Windows.Visibility.Visible;
                button.Content = "-";
            }
            else
            {
                panel.Visibility = System.Windows.Visibility.Collapsed;
                button.Content = "+";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Criterion> preferedSkillSet = getPreferredCriterion();
            List<CVInfo> candidates = getRegisteredApplicants();
            ShowPotentialCandidates(getScoredCVs(candidates, preferedSkillSet));
            ///ShowPotentialCandidates(createTestData());
        }

        private List<CVScored> getScoredCVs(List<CVInfo> candidates, List<Criterion> preferedSkillSet)
        {
            List<CVScored> results = new List<CVScored>();
            CVScored scoredCV;
            foreach(CVInfo cvInfo in candidates)
            {
                scoredCV = new CVScored();

                try
                {
                    double workExperienceScore = Calculator.calculateWorkExperience(cvInfo.workExperience);
                    double skillSetScore = Calculator.calculateSkillSet(cvInfo.skillSet, preferedSkillSet);
                    double qualificationScore = Calculator.calculateWorkQualifications(cvInfo.qualifications);

                    scoredCV.name = cvInfo.name;
                    scoredCV.workScore = workExperienceScore;
                    scoredCV.skillScore = skillSetScore;
                    scoredCV.qualificationScore = qualificationScore;

                    results.Add(scoredCV);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return results;

        }

        private List<Criterion> getPreferredCriterion()
        {
            List<Criterion> results = new List<Criterion>();
            foreach (Criterion criteria in ListView_Criteria.Items)
                results.Add(criteria);
            return results;
        }

        private List<CVInfo> getRegisteredApplicants()
        {
            GetUsersResponse usersResponse = ServiceLayer.RestUsers.getUsers();
            List<User> usersData = usersResponse.data;
            List<CVInfo> cvList = new List<CVInfo>();

            foreach (User user in usersData)
            {
                try
                {
                    cvList.Add(JsonConvert.DeserializeObject<CVInfo>(user.cv));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            return cvList;

        }

        void ShowPotentialCandidates(List<Model.CVScored> data)
        {
            dataGridUsers.DataContext = new[] { new Model.CVScored() };
            dataGridUsers.ItemsSource = null;
            dataGridUsers.ItemsSource = data;
            ScrollViewer_CriteriaContainer.Visibility = System.Windows.Visibility.Collapsed;
            ScrollViewer_ResultContainer.Visibility = System.Windows.Visibility.Visible;
        
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        List<Model.CVScored> createTestData()
        {
            List<Model.CVScored> data = new List<Model.CVScored>();
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                Model.CVScored item = new Model.CVScored()
                {
                    name = "user " + rand.NextDouble(),
                    workScore = 100 * rand.NextDouble(),
                    skillScore = 100 * rand.NextDouble(),
                    qualificationScore = 100 * rand.NextDouble()
                };
                data.Add(item);
            }
            return data;
        }

        private void BackToSearCriteria(object sender, RoutedEventArgs e)
        {
            ListView_Criteria.ItemsSource = null;
            ScrollViewer_CriteriaContainer.Visibility = System.Windows.Visibility.Visible;
            ScrollViewer_ResultContainer.Visibility = System.Windows.Visibility.Collapsed;

        }
    }
}
