/*Project Title: AlparMoto IMS
 * FileName: MainWindow.xaml.cs
 * Author: Alexander A. Parcasio IV
 */
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

namespace AlparMoto_IMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* Function Name: MainWindow
         * Description: Initializes MainWindow elements from MainWindow.xaml
         */
        public MainWindow()
        {
            InitializeComponent();
        }
        /* Function Name: BtnExit_Click
         * Parameter: Object sender, RoutedEventArgs e
         * Description: Closes the MainWindow window Application
         */
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            //Close or Shutdown the AlparMoto IMS application
            Application.Current.Shutdown();
        }
        /* Function Name: BtnCheckLog_Click
         * Parameter: Object sender, RoutedEventArgs e
         * Description: Initializes CheckLogsWindow
         */
        private void BtnCheckLog_Click(object sender, RoutedEventArgs e)
        {
            new CheckLogs().Show();
        }
        /* Function Name: BtnLogin_Click
         * Parameter: Object sender, RoutedEventArgs e
         * Description: Determines if User Name is Valid to Launch the MainIMSWindow,
         * Throws a notification through a TextBox if User Name is Invalid
         */
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Variable for various invalid special characters
            var specialChar = new[] { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "=", "\"" };

            //When the TxtBoxName is empty
            if (TxtBoxName.Text == "")
            {
                //Notify the user that the TxtBoxName is empty
                TxtNotify.Text = "Name Text Box is Empty, Please enter a Name without Numbers";
            }
            //When the TxtBoxName has numbers
            else if (TxtBoxName.Text.Any(char.IsDigit) == true)
            {
                //Notify the user that the TxtBoxName has numbers
                TxtNotify.Text = "Name Text Box has a Number, Please enter a Name without Numbers";
            }
            //When the TxtBoxName contains special characters stated from above
            else if (specialChar.Any(TxtBoxName.Text.Contains) == true)
            {
                //Notify the user that the TxtBoxName has special characters
                TxtNotify.Text = "Name Text Box has special characters, Please enter a valid Name";
            }
            //When Conditions above are met and the TxtBoxName is valid
            else
            {
                //Change the Colour of the TxtNotify to Green
                TxtNotify.Foreground = Brushes.Green;
                //Notify that the user is logging in as the user specified name
                TxtNotify.Text = "Logging in as " + TxtBoxName.Text;
                //Variable that uses the inputed Name in UPPER cases to initialize the MainIMSWindow
                MainIMSWindow mainIMSWindow = new MainIMSWindow(TxtBoxName.Text.ToUpper());
                //Display or show the MainIMSWindow
                mainIMSWindow.Show();
                //Close this current Startup/Login Window
                this.Close();
            }
        }
    }
}
