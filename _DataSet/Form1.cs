using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DataSet
{
    public partial class Form1 : Form
    {
        private SqlDataReader reader;
        private DataTable table;
        private SqlConnection conn;
        string cs = "";

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            cs = ConfigurationManager.
                ConnectionStrings["LibraryConnStr"].
                ConnectionString;
            conn.ConnectionString = cs;
        }

        private void show_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = textBox1.Text;
                comm.Connection = conn;
                conn.Open(); // connect

                table = new DataTable();
                reader = comm.ExecuteReader();
                
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    table.Columns.Add(reader.GetName(i));
                }
                do
                {
                    while (reader.Read())
                    {
                        DataRow row = table.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        table.Rows.Add(row);
                    }

                } while (reader.NextResult());

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = table;
            }
            catch (Exception)
            {
                MessageBox.Show("Probably wrong request syntax");
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close(); // disconnect
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}