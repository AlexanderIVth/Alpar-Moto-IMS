/*Project Title: AlparMoto IMS
 * FileName: MainIMSWindow.xaml.cs
 * Author: Alexander A. Parcasio IV
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AlparMoto_IMS
{
    /// <summary>
    /// Interaction logic for MainIMSWindow.xaml
    /// </summary>
    public partial class MainIMSWindow : Window
    {
        //Initial Global Variables
        // Global variable for User's Name
        public String UserName;
        // Global variable for User's Initial Login Time
        public DateTime InitialLoginTime = DateTime.Now;
        // Global variable for current User
        public User currentUser;
        // Global variable for AlparMoto's Database Connection
        public AlparMotoDBEntities database = new AlparMotoDBEntities();

        /* Function Name: MainIMSWindow
         * Parameter: String Name - Takes in the User's Name from MainWindow TextBox
         * Description: Initializes the Window Title, User Session Name, Session Time
         * and Datagrid Tables
         */
        public MainIMSWindow(String name)
        {
            //Initialize the AlparMoto IMS Window from MainIMSWindow.xaml
            InitializeComponent();
            //Apply the parameter name to the global UserName Variable
            UserName = name;
            //Apply the UserName to the window title
            this.Title = "Alpar Moto IMS, User: " + UserName;
            //Apply the UserName and InitialLoginTime to the UserTxtblock
            UserTxtBlock.Text = UserName + " Session" + "\n" + InitialLoginTime.ToString();
            //Initialize the Timer and Code that runs every second
            InitializeTimer();
            //Populate the Products Inventory Database
            this.DataInventory.ItemsSource = (from d in database.Products select d).ToList();
            //Create or Update the current User
            CreateOrUpdateUser(UserName);
        }
        /* Function Name: CreateOrUpdateUser
         * Parameter: String name - name of the user to update or create
         * Description: Creates or Updates User information
         */
        private void CreateOrUpdateUser(String name)
        {
            //Get user information from the database
            currentUser = (from d in database.Users where d.Name == name select d).SingleOrDefault();
            //When the User does not exist in the database
            if (currentUser == null)
            {
                //Set the local variables for a new user with the name
                currentUser = new User
                {
                    Name = name,
                    Last_Login = DateTime.Now,
                    Date_Created = DateTime.Now
                };
                //Add this user into the database
                database.Users.Add(currentUser);
            }
            //When the user already exists in the database
            else if (currentUser.Name == name) 
            {
                //Update Recent Login Date and Time
                currentUser.Last_Login = DateTime.Now;
                //Update this user's Last Login information
                database.Users.AddOrUpdate(currentUser);
            }
            database.SaveChanges();
        }
        /* Function Name: InitializeTimer
         * Description: A timer that runs the function IntervalSeconds Code every second
         */
        public void InitializeTimer()
        {
            //Define dt as a DispatcherTimer
            DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
            //This Starts at 0 and will run the IntervalSeconds function
            dt.Tick += IntervalSeconds;
            //Makes sure Interval is every second
            dt.Interval = new TimeSpan(0, 0, 1);
            //Starts the Timer
            dt.Start();
        }
        /* Function Name: IntervalSeconds
         * Description: Function that is applied every second
         */
        public void IntervalSeconds(object sender, EventArgs e)
        {
            //Gets the difference of InitialLoginTime and current time each second
            String interval = DateTime.Now.Subtract(InitialLoginTime).ToString();
            //Updates the UserTxtBlock with UserName and Session Time every second
            UserTxtBlock.Text = UserName + " Session" + "\n Time: " + interval;
        }
        /* Function Name: OnClose
         * Parameter: object sender, EventArgs e
         * Description: Runs the Logout Function when the application is closed
         */
        public void OnClose(object sender, EventArgs e)
        {
            //Makes sure that the user is logged out properly
            Logout();
        }
        /* Function Name: ButtonLogout_Click
         * Parameter: object sender, RoutedEventArgs e
         * Description: Runs the Logout Function when the user clicks on 'Logout'
         */
        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            //Makes sure that the user is logged out properly
            Logout();
        }
        /* Function Name: Logout
         * Description: Restarts the Startup/Login Window when the user Log's out or closes the IMS
         */
        private void Logout()
        {
            //Restart the Startup/Login Window
            System.Diagnostics.Process.Start("AlparMoto IMS.exe");

            //Update the UserChanges Database
            //Update the Users Database [Last Login], [Total Session Time]

            //Close this current Window
            try
            {
                this.Close();
            }catch (Exception ex) { Console.WriteLine(ex); }
        }
        /* Function Name: ButtonEnglish_Click
         * Parameter: object sender, EventArgs e
         * Description: Changes the Language to English
         */
        private void ButtonEnglish_Click(object sender, RoutedEventArgs e)
        {
            ButtonLogout.Content = "Logout";
            AddItemButton.Content = "Add";
            EditItemButton.Content = "Edit";
            RemoveItemButton.Content = "Delete";
        }
        /* Function Name: ButtonTagalog_Click
         * Parameter: object sender, EventArgs e
         * Description: Changes the Language to Tagalog
         */
        private void ButtonTagalog_Click(object sender, RoutedEventArgs e)
        {
            ButtonLogout.Content = "Takdang Alis";
            AddItemButton.Content = "Dagdagan";
            EditItemButton.Content = "Ayusin";
            RemoveItemButton.Content = "Tanggalin";
        }
        /* Function Name: ButtonIlocano_Click
         * Parameter: object sender, EventArgs e
         * Description: Changes the Language to Ilocano
         */
        private void ButtonIlocano_Click(object sender, RoutedEventArgs e)
        {
            ButtonLogout.Content = "Isurat ti Ruar";
            AddItemButton.Content = "Nayunan";
            EditItemButton.Content = "Urnusin";
            RemoveItemButton.Content = "Ikkatin";
        }
        /* Function Name: TxtBoxSearch_TextChanged
         * Parameter: object sender, EventArgs e
         * Description: Applies changes to the Inventory Datagrid according to
         * search terms
         */
        private void TxtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Re-initialize database connection
            database = new AlparMotoDBEntities();
            //If the Search Box contains characters
            if (TxtBoxSearch.Text != "")
            {
                //Make a Database Query depending on selected column with the search term
                if (SelectSearch.SelectedItem.ToString().Contains("Part Number"))
                {
                    this.DataInventory.ItemsSource = (from d in database.Products where d.Part_Number.Contains(TxtBoxSearch.Text) select d).ToList();
                }
                else if (SelectSearch.SelectedItem.ToString().Contains("Product Name"))
                {
                    this.DataInventory.ItemsSource = (from d in database.Products where d.Product_Name.Contains(TxtBoxSearch.Text) select d).ToList();
                }
                else if (SelectSearch.SelectedItem.ToString().Contains("Description"))
                {
                    this.DataInventory.ItemsSource = (from d in database.Products where d.Description.Contains(TxtBoxSearch.Text) select d).ToList();
                }
                else if (SelectSearch.SelectedItem.ToString().Contains("Keywords"))
                {
                    this.DataInventory.ItemsSource = (from d in database.Products where d.Keywords.Contains(TxtBoxSearch.Text) select d).ToList();
                }
            }
            else if (TxtBoxSearch.Text == "")
            {
                //Populate the Products Inventory Database
                this.DataInventory.ItemsSource = (from d in database.Products select d).ToList();
            }
        }

        /* Function Name: AddItemButton_Click
         * Parameter: object sender, EventArgs e
         * Description: Add an Item to the Products Inventory Database
         */
        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            //Initialize the Add Item Window with this window to update the table
            new AddItem(this,currentUser).Show();
        }
        /* Function Name: RemoveItemButton_Click
         * Parameter: object sender, EventArgs e
         * Description: Remove an Item to the Products Inventory Database
         */
        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            //Get the currently selected Product, selects the product at index 0 by default
            Product selectedProduct;
            try
            {
                selectedProduct = this.DataInventory.SelectedItems[0] as Product;
            }catch (Exception)
            { return; }
            //Display a Messagebox confirming if the user wants to delete the Product
            MessageBoxResult msgBoxDelete = MessageBox.Show("Are you sure you want to Delete [id:" + selectedProduct.Id + ",Product Name:" + selectedProduct.Product_Name + "] ?",
                "Delete Product", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            //If the user confirms on deleting the Product
            if(msgBoxDelete == MessageBoxResult.Yes)
            {
                //Query the database for the selected product
                Product p = (from d in database.Products where d.Id == selectedProduct.Id select d).SingleOrDefault();
                //Add this change to the User Changes Log
                User_change userChange = new User_change { 
                    UserID = currentUser.UserId,
                    Name = currentUser.Name,
                    Change = "Deleted:" + p.Id + "/" + p.Part_Number + "/" + p.Product_Name + 
                    "/" + p.Stock_Amount + "/" + p.Description + "/" + p.Keywords + "/" +
                    p.Date_Received.ToString() + "/" + p.Price + "/" + p.Retail_Price + "/" + p.Time_Date_Added,
                    Time_Date_of_Change = DateTime.Now,
                };
                database.User_Changes.Add(userChange);
                //Remove the Product from the database and save changes
                database.Products.Remove(p);
                database.SaveChanges();
                //Populate the Products Inventory Database
                this.DataInventory.ItemsSource = (from d in database.Products select d).ToList();
                this.DataUserChanges.ItemsSource =  (from d in database.User_Changes select d).ToList();
            }
        }
        /* Function Name: EditItemButton_Click
         * Parameter: object sender, EventArgs e
         * Description: Edit an Item to the Products Inventory Database
         */
        private void EditItemButton_Click(object sender, RoutedEventArgs e)
        {
            //Get the currently selected Product, selects the product at index 0 by default
            Product selectedProduct;
            try { 
                selectedProduct = this.DataInventory.SelectedItems[0] as Product;
            }
            catch (Exception) { return; }
            //Display a Messagebox confirming if the user wants to delete the Product
            MessageBoxResult msgBoxEdit = MessageBox.Show("Are you sure you want to Edit [id:" + selectedProduct.Id + ",Product Name:" + selectedProduct.Product_Name + "] ?",
                "Edit Product", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            //If the user confirms on editing the Product
            if (msgBoxEdit == MessageBoxResult.Yes)
            {
                //Query the database for the selected product
                Product p = (from d in database.Products where d.Id == selectedProduct.Id select d).SingleOrDefault();
                //Initialize the Add Item Window with this window to update the table
                new EditItem(this,p,currentUser).Show();
            }
        }
    }
}
