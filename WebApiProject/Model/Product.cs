using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace WebApiProject.Model
{
    public class Product
    {
        private SqlConnection con;
        private IConfiguration configuration;
        public Product(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Product()
        { 
        }
        public void conn()
        {
            string dbcon = configuration.GetConnectionString("DefaultConnction").ToString(); 
            con = new SqlConnection(dbcon);
        }

        public List<ProductEntity> getProduct() {

            conn();
        List<ProductEntity> products = new List<ProductEntity>();
            con.Open();
            string query = "SELECT * FROM Product";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {

                products.Add(new ProductEntity()
                {
                    Pid = Convert.ToInt16(reader["Pid"]),
                    Pname = Convert.ToString(reader["Pname"]),
                    Price = Convert.ToInt32(reader["Price"])    
                }
                );
           
            }
            return products;
        
        }


        public void DeleteRecord(int id)
        {
            conn();
            con.Open();
            string query = $"Delete from Product where Pid = {id}";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();
        
        }

        public void InsertRecord(ProductEntity pe)
        {
            conn();
            con.Open();
            SqlCommand com = new SqlCommand("Insert into Product Values(@Pname,@Price)", con);


            com.Parameters.AddWithValue("@Pname", pe.Pname);
            com.Parameters.AddWithValue("@Price", pe.Price);

            int i = com.ExecuteNonQuery();
            con.Close();
        
        
        }

        public void UpdateRecord(ProductEntity p)
        {
            conn();
            string qry = "Update Product set Pname = @Pname ,Price = @Price where Pid = @Pid  ";
            con.Open();
            SqlCommand com = new SqlCommand(qry, con);
            com.Parameters.AddWithValue("Pid", p.Pid);
            com.Parameters.AddWithValue("Pname", p.Pname);
            com.Parameters.AddWithValue("Price", p.Price);
            int i = com.ExecuteNonQuery();
            con.Close();

        }

    }
}
