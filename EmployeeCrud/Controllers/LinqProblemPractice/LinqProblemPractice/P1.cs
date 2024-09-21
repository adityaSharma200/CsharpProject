using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;

namespace LinqProblemPractice
{
    public class P1
    {
        public static void Main(string[] args)
        {
              //Encrypt = True; Trust Server Certificate = True
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = PCD746;" + "Initial Catalog = Product;" + " Integrated Security = True;";
            con.Open();
            string query = "select * from Product";
            //SqlCommand is help to connect to database and exceute sql query 
            SqlCommand cmd = new  SqlCommand(query,con);
           
            DataTable dt = new DataTable();
            //SqlDataAdapter is use copy table from server databse int Datatable or DataSet
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            for (int col = 0; col < dt.Columns.Count; col++)
            {
                Console.Write(dt.Columns[col].ColumnName+"|");
            }
            Console.WriteLine();
            for (int row = 0; row < dt.Rows.Count; row++)
            {

                for(int col = 0; col < dt.Columns.Count; col++)
                {
                    Console.Write(dt.Rows[row][col].ToString() + "|");
                }
                Console.WriteLine();
               
            }


        }
    }
}
