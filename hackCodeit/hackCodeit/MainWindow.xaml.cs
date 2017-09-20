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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string GetString(RichTextBox rtb)
        {
            var textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return textRange.Text;
        }
        object lockObject = new object();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            resultView.Text = "...";
            Task.Factory.StartNew(() =>
            {
                lock (lockObject)
                {

                    string lang = "Java";
                    string source = GetString(vSource);
                    ServiceLayer.CodingResult data = ServiceLayer.RestCoding.scoreCode(lang, source);
                    if (data != null)
                        Dispatcher.BeginInvoke((Action)(() =>
                        {
                            //sourceText.Content = data.ToString();
                            resultView.Text = data.ToString();
                        }));
                }
            });

        }
    }
}