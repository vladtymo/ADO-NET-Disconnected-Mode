using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            DataColumn col1 = new DataColumn("Price");
            col1.DataType = typeof(int);
            table.Columns.Add(col1);         
            table.Columns.Add("Id");
            table.Columns.Add("FirstName");   
            table.Columns.Add("LastName");
         
            DataRow row = table.NewRow();
            row["Id"] = 1;
            row[1] = "Francis";
            row[2] = "Becon";

            table.Rows.Add(row);

            table.Rows[0]["Id"] = 56;
        }
    }
}
