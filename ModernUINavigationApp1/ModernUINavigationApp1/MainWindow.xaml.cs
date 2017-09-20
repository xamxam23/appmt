using FirstFloor.ModernUI.Windows.Controls;
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

namespace ModernUINavigationApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Factory.StartNew((Action)(() =>
            {
                ServiceLayer.GetUsersResponse response = ServiceLayer.RestUsers.getUsers();
                if (response != null)
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        if (response.data!=null)
                            foreach (ServiceLayer.User user in response.data)
                            {
                                Console.WriteLine(user);
                            }
                    }));
            }));
        }
    }
}
