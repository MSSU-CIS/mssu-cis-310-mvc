using SeventhGUI.model;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace SeventhGUI
{
    /// <summary>
    /// Interaction logic for ManagingUI.xaml
    /// </summary>
    public partial class ManagingUI : Window
    {
        private IList<Manager> managerList;

        public ManagingUI()
        {
            InitializeComponent();
            managerList = new List<Manager>();
        }

        //Use this as a reference for your GetBattingAverageButtonClick or GetStrikeoutsPerInningButtonClick
        private void GetWinningPercentageButtonClick(object sender, RoutedEventArgs e)
        {
            Manager selectedManager = null;
            if (outputListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a manager from the list.");
                return;
            }
            else
            {
                selectedManager = (Manager)outputListBox.SelectedItem;
            }

            if (selectedManager != null)
            {
                //TODO: The selectedManager object has properties you can access to display 
                // the first name, last name, and (batting average or strikeouts per inning)
                // Write a line of code that displays a message box with this information.
            }
            else
            {
                MessageBox.Show("Please select a manager from the list.");
            }
        }

        //Use this as a reference for your populateList method
        private void PopulateList()
        {
            outputListBox.Items.Clear();
            foreach (Manager m in managerList)
            {
                outputListBox.Items.Add(m);
            }
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            string sql = SearchSQLString(txtFirstName.Text, txtLastName.Text);
            DataTable searchResults = ExecuteSQL(sql);

            managerList.Clear();
            foreach (DataRow row in searchResults.Rows)
            {
                //TODO: Create a new object of type Manager
                // The arguments to the constructor should match the parameters in the Manager class constructor
                // You'll use the results of your SQL query (much like you did in the previous assignment with playerRow)
                // You may need to convert some of your arguments from a long (that SQL returns) to a uint32. 
            }
            PopulateList();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string SearchSQLString(string firstName, string lastName)
        {
            //TODO: What SQL string would let you search for Pitchers or Batters by name?
            // Hint: There is a table called Pitching and a table called Batting, along with Master
            // A description of the fields is located here: http://www.seanlahman.com/files/database/readme2012.txt
            return "";
        }

        private DataTable ExecuteSQL(string sql)
        {
            DataTable dt = new DataTable();

            string datasource = @"Data Source=..\..\lahman2016.sqlite;";

            using (SQLiteConnection conn = new SQLiteConnection(datasource))
            {
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }
    }
}
