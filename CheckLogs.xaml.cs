/*Project Title: AlparMoto IMS
 * FileName: CheckLogs.xaml.cs
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
    /// Interaction logic for CheckLogs.xaml
    /// </summary>
    public partial class CheckLogs : Window
    {
        public AlparMotoDBEntities database = new AlparMotoDBEntities();
        public CheckLogs()
        {
            InitializeComponent();
            this.dataChangeLog.ItemsSource = (from d in database.User_Changes select d).ToList();
        }
    }
}
