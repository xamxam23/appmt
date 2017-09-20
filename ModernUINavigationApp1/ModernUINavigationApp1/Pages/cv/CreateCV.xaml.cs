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
            if (spAddSkillSet.Visibility == System.Windows.Visibility.Collapsed)
            {
                spAddSkillSet.Visibility = System.Windows.Visibility.Visible;
                Button_AddSkillSet.Content = "-";
            }
            else
            {
                spAddSkillSet.Visibility = System.Windows.Visibility.Collapsed;
                Button_AddSkillSet.Content = "+";
            }
            
        }

        private void AddWorkExperience_Click_1(object sender, RoutedEventArgs e)
        {
            if (StackPanel_AddWorkExperience.Visibility == System.Windows.Visibility.Collapsed)
            {
                StackPanel_AddWorkExperience.Visibility = System.Windows.Visibility.Visible;
                Button_AddWorkExperience.Content = "-";
            }
            else
            {
                StackPanel_AddWorkExperience.Visibility = System.Windows.Visibility.Collapsed;
                Button_AddWorkExperience.Content = "+";
            }
        }
    }
}
