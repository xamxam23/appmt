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
            setSkilSet();
            setWorkExperience();
            setQualifications();
        }

        private void setSkilSet()
        {
            //AAARecords.test_clean();
            //AAARecords.test_insert(0, 10000);
            List<Model.SkillSet> items = new List<Model.SkillSet>();
            items.Add(new Model.SkillSet() { name = "java", months = 5, rating = 3 });
            items.Add(new Model.SkillSet() { name = "C#", months = 5, rating = 2});
            items.Add(new Model.SkillSet() { name = "Python", months = 5, rating = 1 });
            items.Add(new Model.SkillSet() { name = "C", months = 1, rating = 2 });
            items.Add(new Model.SkillSet() { name = "C++", months = 7, rating = 4 });
            items.Add(new Model.SkillSet() { name = "PHP", months = 2, rating = 1 });
            items.Add(new Model.SkillSet() { name = "Javascript", months = 5, rating = 1 });
            items.Add(new Model.SkillSet() { name = "Perl", months = 1, rating = 1 });
            items.Add(new Model.SkillSet() { name = "Kornshell", months = 5, rating = 1 });
            items.Add(new Model.SkillSet() { name = "Scall", months = 1, rating = 1 });
            items.Add(new Model.SkillSet() { name = "Kotlin", months = 1, rating = 1 });
            items.Add(new Model.SkillSet() { name = "VB", months = 1, rating = 1 });
            items.Add(new Model.SkillSet() { name = "SQL", months = 1, rating = 1 });
            items.Add(new Model.SkillSet() { name = "Postgres", months = 3, rating = 1 });
            items.Add(new Model.SkillSet() { name = "PHP", months = 2, rating = 1 });
            items.Add(new Model.SkillSet() { name = "Haskell", months = 1, rating = 1 });
            if (items != null)
            {
                lvSkillSet.ItemsSource = items;
            }
        }
        private void setWorkExperience()
        {
            List<Model.WorkExperience> items = new List<Model.WorkExperience>();
            items.Add(new Model.WorkExperience() { company = "iSolv Technologies",  position="Team Lead Senior Sofware Engineer", months = 70 });
            items.Add(new Model.WorkExperience() { company = "Tracker", position="Senior Android Developer", months = 8});
            items.Add(new Model.WorkExperience() { company = "Tracker", position="Senior Android Developer", months = 7});
            if (items != null)
                lvWorkExperience.ItemsSource = items;
        }

        private void setQualifications()
        {
            List<Model.Qualifications> items = new List<Model.Qualifications>();
            items.Add(new Model.Qualifications() { title = "Bsc Computer Engineer", year = 1998 });
            items.Add(new Model.Qualifications() { title = "Honor Data Analytics", year = 2002 });
            items.Add(new Model.Qualifications() { title = "Master Robotics", year = 2004});
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GetUsersResponse usersResponse = ServiceLayer.RestUsers.getUsers();
            List<User> users = usersResponse.data;

            string applicantName = name.Text;
            int applicantAge = Convert.ToInt16(age.Text);
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
            ServiceLayer.RestUsers.updateCV("bob", serializedCVInfo);
            //String s = jsonString + "ddf";

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
