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

namespace hackCodeit
{
    /// <summary>
    /// Interaction logic for CodingQuestions.xaml
    /// </summary>
    public partial class CodingQuestions : Page
    {
        public CodingQuestions()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService((Button)sender);
            if (nav != null)
                nav.Navigate(new Uri("CodingEditor.xaml", UriKind.RelativeOrAbsolute));

            NavigationWindow window = new NavigationWindow();
            window.Source = new Uri("Pages/Coding/CodingEditor.xaml", UriKind.Relative);
            window.ShowDialog();
        }
    }
}
