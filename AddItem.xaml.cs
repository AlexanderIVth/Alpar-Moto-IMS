﻿/*Project Title: AlparMoto IMS
 * FileName: AddItem.xaml.cs
 * Author: Alexander A. Parcasio IV
 */
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace AlparMoto_IMS
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        //Global varaibles for the database,IMSWindow and current User
        public AlparMotoDBEntities db = new AlparMotoDBEntities();
        public MainIMSWindow mainIMSWindow;
        public User currentUser;
        public AddItem(MainIMSWindow IMSWindow, User current)
        {
            InitializeComponent();
            mainIMSWindow = IMSWindow;
            currentUser = current;
        }

        /* Function Name: ButtonCancel_Click
         * Description: Closes the Add Item Window
         */
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /* Function Name: ButtonAdd_Click
         * Description: Adds a valid Item Entry to the Products Inventory Database
         */
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            //Initial local variables for Product Details
            float stockAmount,price,retailPrice;
            String partNumber, productName;

            //Determine if stockAmount, price, retailPrice are valid Numbers
            stockAmount = checkNumber(txtBlockStockAmount, txtBoxStockAmount);
            price = checkNumber(txtBlockPrice, txtBoxPrice);
            retailPrice = checkNumber(txtBlockRetailPrice, txtBoxRetailPrice);
            //Determine if partNumber, productName are valid Texts
            partNumber = checkText(txtBlockPartNumber, txtBoxPartNumber);
            productName = checkText(txtBlockProductName, txtBoxProductName);
            //Determine if datePickerDateReceived is a vaild date
            if (datePickerDateReceived.SelectedDate == null)
            {
                //Change the txtBlockDateReceived Foreground to Red if invalid
                txtBlockDateReceived.Foreground = Brushes.Red;
            }
            else
            {
                //Change the txtBlockDateReceived Foreground to Green if valid
                txtBlockDateReceived.Foreground = Brushes.Green;
            }

            //Check if all Inputs are valid
            if (checkAllValidEntry())
            {
                //Get the Current Time and Date for Time_Date_Added
                DateTime now = DateTime.Now;
                //Input the product details into a new Product
                Product newProduct = new Product()
                {
                    Part_Number = partNumber,
                    Product_Name = productName,
                    Stock_Amount = stockAmount,
                    Price = price,
                    Retail_Price = retailPrice,
                    Date_Received = datePickerDateReceived.SelectedDate.Value,
                    Time_Date_Added = now,
                    Description = txtBoxDescription.Text,
                    Keywords = txtBoxKeywords.Text
                };
                //Add this change to the User Changes Log
                User_change userChange = new User_change
                {
                    UserID = currentUser.UserId,
                    Name = currentUser.Name,
                    Change = "Added:" + newProduct.Id + "/" + newProduct.Part_Number + "/" + newProduct.Product_Name +
                    "/" + newProduct.Stock_Amount + "/" + newProduct.Description + "/" + newProduct.Keywords + "/" +
                    newProduct.Date_Received.ToString() + "/" + newProduct.Price + "/" + newProduct.Retail_Price + "/" + newProduct.Time_Date_Added,
                    Time_Date_of_Change = DateTime.Now,
                };
                db.User_Changes.Add(userChange);

                //Add the valid New Product to the database
                db.Products.Add(newProduct);
                //Save changes to the database
                db.SaveChanges();
                //Display that the Product has been added through the title window
                this.Title = productName + " Added";
            }
            else{
                //Display that the product is Invalid through the title window
                this.Title = "Invalid Product, Check Boxes";
            }

            //Populate the Products Inventory and User Changes Database
            mainIMSWindow.DataInventory.ItemsSource = (from d in db.Products select d).ToList();
            mainIMSWindow.DataUserChanges.ItemsSource = (from d in db.User_Changes select d).ToList();
        }
        /* Function Name: checkAllValidEntry
         * Description: Determines if the All Entries are valid by color
         */
        private bool checkAllValidEntry()
        {
            //Determine if all inputs returns are valid
            if (checkValidEntry(txtBlockPartNumber) &&
                checkValidEntry(txtBlockProductName) &&
                checkValidEntry(txtBlockStockAmount) &&
                checkValidEntry(txtBlockPrice) &&
                checkValidEntry(txtBlockRetailPrice) &&
                checkValidEntry(txtBlockDateReceived))
            {
                //Return true if valid
                return true;
            }
            //Return false if invalid
            return false;
        }
        /* Function Name: checkValidEntry
         * Parameter: TextBlock txtBlock (TextBlock to check)
         * Description: Determines if the Entry is valid by color
         */
        private bool checkValidEntry(TextBlock txtBlock)
        {
            if(txtBlock.Foreground == Brushes.Red)
            {
                return false;
            }
            return true;
        }
        /* Function Name: checkText
         * Parameter: TextBlock txtBlock, TextBox txtBox (TextBlock and TextBox assigned for the input)
         * Description: Determines if input contains strings and changes TextBlock color (red for empty,
         * green for valid)
         */
        private String checkText(TextBlock txtBlock, TextBox txtBox)
        {
            //Initial null String text to return
            String text = null;
            //Check of the Textbox is not empty
            if (txtBox.Text != "")
            {
                //apply the TextBox values to text variable
                text = txtBox.Text;
                //Change the TextBlock color to green if TextBox is not empty
                txtBlock.Foreground = Brushes.Green;
            }
            else
            {
                //Change the TextBlock color to red if TextBox is empty
                txtBlock.Foreground = Brushes.Red;
            }
            //Return the String value
            return text;
        }
        /* Function Name: checkNumber
         * Parameter: TextBlock txtBlock, TextBox txtBox (TextBlock and TextBox assigned for the input)
         * Description: Determines if input contains valid numbers and changes TextBlock color (red for NaN,
         * green for valid)
         */
        private float checkNumber(TextBlock txtBlock,TextBox txtBox)
        {
            //initial integer to return
            float number;
            //Try to get the number from TextBox and apply the number to the variable
            if (float.TryParse(txtBox.Text, out number))
            {
                //Change the TextBlock color to geen if true
                txtBlock.Foreground = Brushes.Green;
            }
            else
            {
                //Change the TextBlock color to red if false or NaN
                txtBlock.Foreground = Brushes.Red;
            }
            //Return the integer value
            return number;
        }
    }
}
