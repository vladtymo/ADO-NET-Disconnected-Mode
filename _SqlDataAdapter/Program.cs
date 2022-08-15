using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SqlDataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //для создания объекта DbDataAdapter надо иметь
            //запрос select и объект DbConnection
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\v11.0;
                                                     InitialCatalog=Library;
                                                     Integrated Security=SSPI");

            string selectSQL = "SELECT * FROM Books";

            //создаем объект DbDataAdapter
            SqlDataAdapter da = new SqlDataAdapter(selectSQL, conn);
            //объяснение этой строки почитайте ниже
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(da);
            //создаем объект DataSet для локального хранения
            //данных из БД
            DataSet ds = new DataSet();
            //вызов метода Fill() выполняет запрос select из
            //свойства SelectCommand и заносит прочитанные
            //данные в объект DataSet
            da.Fill(ds);

            // some changes
            ds.Tables[0].Rows[2]["Price"] = 20;
            ds.Tables[0].Rows.RemoveAt(0);

            // some operation: insert, update, delete...
            da.Update(ds);
        }
    }
}
