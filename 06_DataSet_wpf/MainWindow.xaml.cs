using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace _06_DataSet_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // connection class to database
        private SqlConnection conn = null;
        // data adapter for disconnected mode
        private SqlDataAdapter da = null;
        // DataSet
        private DataSet set = null;

        public MainWindow()
        {
            InitializeComponent();

            // read connection string from config file
            string cs = ConfigurationManager.ConnectionStrings["SportShopConn"].ConnectionString;
            // create sql connection class
            conn = new SqlConnection(cs);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // query for select data
                string sql = commandTextBox.Text;
                // create data adapter
                da = new SqlDataAdapter(sql, conn);
                // create command builder for auto generate insert, update and delete queries
                new SqlCommandBuilder(da);

                // create empty DataSet
                set = new DataSet();
                // execute select query on server and put data to DataSet
                da.Fill(set, "MyTable");

                // bind table to DataGrid
                dataGrid.ItemsSource = set.Tables["MyTable"].DefaultView;

                // access elements
                //set.Tables[0].Rows[0][2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // update server data (sync DataSet with database)
                da.Update(set.Tables["MyTable"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
