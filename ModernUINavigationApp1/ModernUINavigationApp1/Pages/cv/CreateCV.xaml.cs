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
    /// <summary>
    /// Interaction logic for CreateCV.xaml
    /// </summary>
    public partial class CreateCV : UserControl
    {
        public CreateCV()
        {
            InitializeComponent();
            MockIt();
        }
        private void MockIt()
        {
            setSkilSet();
            setWorkExperience();
            setQualifications();
        }
        
        Random rand = new Random();
        string[] MockSkillSet = { "Java", "C#", "Python", "C", "C++", 
                                    "PHP", "JavaScript" , "Java Enterprise",
                                    "Perl", "SQL", "Scala", "Android", "iOS", "Object C", "Swift"};

        string[] MockCompanies = { "IBM", "FNB", "Standard Bank", "DVT", "Entelect", 
                                    "Indigo Cube", "MultiChoice" , "MTN",
                                    "Vodacom", "Cellc", "Amazon", "Coca-Cola", "Microsoft", "Apple"};

        string[] MockPosition = { "Developer", "Engineer", "Team Lead", "Senior Developer", "Junior iOs Developer", 
                                    "Full-Stack Developer", "Front-End Developer" , "ScrumMaster"};

        private void setSkilSet()
        {
            //AAARecords.test_clean();
            //AAARecords.test_insert(0, 10000);
            List<Model.SkillSet> items = new List<Model.SkillSet>();
            for (int i = 0; i < 3 + rand.Next(3); i++)
            {
                items.Add(new Model.SkillSet()
                {
                    name = MockSkillSet[rand.Next(MockSkillSet.Length)],
                    months = 1 + rand.Next(120),
                    rating = 1 + rand.Next(4)
                });
            }
            if (items != null)
            {
                lvSkillSet.ItemsSource = items;
            }
        }
        private void setWorkExperience()
        {
            List<Model.WorkExperience> items = new List<Model.WorkExperience>();
            for (int i = 0; i < 1 + rand.Next(5); i++)
                items.Add(new Model.WorkExperience() { 
                    company = MockCompanies[rand.Next(MockCompanies.Length)],
                    position = MockPosition[rand.Next(MockPosition.Length)],
                    months = 1+rand.Next(120)
                });
            if (items != null)
                lvWorkExperience.ItemsSource = items;
        }

        private void setQualifications()
        {
            List<Model.Qualifications> items = new List<Model.Qualifications>();
            items.Add(new Model.Qualifications() { title = "degree", year = 1990 + rand.Next(27) });
            items.Add(new Model.Qualifications() { title = "honour", year = 2002 });
            items.Add(new Model.Qualifications() { title = "master", year = 2004 });
            if (items != null)
                lvQualifications.ItemsSource = items;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HideShowAddPanel(spAddSkillSet, Button_AddSkillSet);
        }

        private void AddWorkExperience_Click_1(object sender, RoutedEventArgs e)
        {
            HideShowAddPanel(StackPanel_AddWorkExperience, Button_AddWorkExperience);
        }

        private void Button_AddQualification_Click_1(object sender, RoutedEventArgs e)
        {
            HideShowAddPanel(StackPanel_AddQualification, Button_AddQualification);
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
        public static List<string[]> MockUserName = new List<string[]>();
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Mock
            MockUserName = new List<string[]>();
            for (int i = 0; i < 50; i++)
            {
                string[] a = new string[] { "name - " + i, "user - " + i };
                MockUserName.Add(a);
            }
            string applicantName = name.Text;

            string[] user = MockUserName[rand.Next(MockUserName.Count)];

            applicantName = user[0];

            int applicantAge = 0;
            int.TryParse(age.Text, out applicantAge);

            string applicantPhone = phone.Text;
            string applicantEmail = email.Text;
            string applicantID = id.Text;
            List<SkillSet> skillSet = getSkillSet();
            List<WorkExperience> workExperience = getWorkExperience();
            List<Qualifications> qualification = getQualifications();

            CVInfo cvinfo = new CVInfo();
            cvinfo.name = applicantName;
            cvinfo.age = applicantAge;
            cvinfo.rating = 3;
            cvinfo.skillSet = skillSet;
            cvinfo.workExperience = workExperience;
            cvinfo.qualifications = qualification;

            String serializedCVInfo = JsonConvert.SerializeObject(cvinfo);

        
            ServiceLayer.RestUsers.updateCV(user[1], serializedCVInfo);
            //String s = jsonString + "ddf";
            MockIt();
        }

        private List<Qualifications> getQualifications()
        {
            List<Qualifications> results = new List<Qualifications>();

            if (lvQualifications.Items.Count == 0)
                return results;

            foreach (Qualifications qualification in lvQualifications.Items)
            {
                results.Add(qualification);
            }

            return results;
        }

        private List<WorkExperience> getWorkExperience()
        {
            List<WorkExperience> results = new List<WorkExperience>();

            if (lvWorkExperience.Items.Count == 0)
                return results;

            foreach (WorkExperience experience in lvWorkExperience.Items)
            {
                results.Add(experience);
            }

            return results;
        }

        private List<SkillSet> getSkillSet()
        {
            List<SkillSet> results = new List<SkillSet>();

            if (lvSkillSet.Items.Count == 0)
                return results;

            foreach (SkillSet skill in lvSkillSet.Items)
            {
                results.Add(skill);
            }

            return results;
        }
    }
}
