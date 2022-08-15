using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataSet_base
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаем объект ds
            DataSet ds = new DataSet();

            // ds add two tables

            //каким-либо способом заполняем объект ds
            //результатами наших двух запросов
            //извлекаем из ds первую таблицу по индексу
            DataTable dt1 = ds.Tables[0];
            //извлекаем из ds вторую таблицу по индексу
            DataTable dt2 = ds.Tables[1];
            //извлекаем из ds первую таблицу по имени
            DataTable dt3 = ds.Tables["table"];
            //извлекаем из ds вторую таблицу по имени
            DataTable dt4 = ds.Tables["table1"];
            //извлекаем LastName автора из первой строки таблицы
            //dt1 по индексам
            string lastName1 = dt1.Rows[0][1].ToString();
            //извлекаем LastName автора прямо из объекта DataSet
            string lastName2 = (string)ds.Tables[0].Rows[0]["LastName"];
        }
    }
}
