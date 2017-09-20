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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void onLogin(object sender, RoutedEventArgs e)
        {
            string user = userText.Text;
            string pass = passText.Text;
                
            Task.Factory.StartNew((Action)(()=>{
                ServiceLayer.BaseResult data = ServiceLayer.RestRegister.login(user, pass);
                if (data != null)
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        //sourceText.Content = data.ToString();
                        resultView.Foreground = data.ok ? Brushes.Green : Brushes.Red;
 
                        resultView.Text = data.ToString();
                    }));
            }));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Page1.xaml", UriKind.Relative));

        }
    }
}
