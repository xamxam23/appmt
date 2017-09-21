using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }
        public static List<string[]> user_name = new List<string[]>();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            resultView.Text = "...";
            string name = nameText.Text;
            string user = userText.Text;
            string pass1 = pass1Text.Text;
            string pass2 = pass2Text.Text;
            for (int i = 0; i < 50; i++)
            {
                string[] a = new string[] { "name - " + i, "user - " + i };
                user_name.Add(a);
            }
            //name = "name - " + i;
            //user = "user - " + i;
            Thread.Sleep(100);
            Task.Factory.StartNew(() =>
            {
                ServiceLayer.BaseResult data = ServiceLayer.RestUsers.register(name, user, pass1);
                if (data != null)
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        //sourceText.Content = data.ToString();
                        resultView.Text = data.ToString();
                    }));
            });
        }
    }

}
