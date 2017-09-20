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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hackCodeit
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameNavigator.Navigate(new Uri("Register.xaml", UriKind.RelativeOrAbsolute));
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigator.Navigate(new Uri("Login.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameNavigator.Navigate(new Uri("CodingQuestions.xaml", UriKind.RelativeOrAbsolute));
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.ShowDialog();
        }

    }
}
