using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudOperationEmployee.Models
{
    public class Employeehandle
    {
        SqlConnection con;

        private SqlConnection Con()
        {
            string strcon = ConfigurationManager.ConnectionStrings["empdbcon"].ToString();
            con = new SqlConnection(strcon);
            return con; 
        }

        public List<EmployeeModel> GetInfo()
        {
            Con();
            List<EmployeeModel> empmodel = new List<EmployeeModel>();
            con.Open();
            SqlCommand cmd = new SqlCommand("SelectEmployee",con);
            
            //use to read data 
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {

                empmodel.Add(new EmployeeModel
                {

                    id = Convert.ToInt32(reader["id"]),
                    name = Convert.ToString(reader["name"]),
                    email = Convert.ToString(reader["email"]),
                    phone = Convert.ToString(reader["phone"]),
                    city = Convert.ToString(reader["city"]),
                    gender = Convert.ToString(reader["gender"])


                });
            
            }
            con.Close();
            return empmodel;

        }


        public bool InsertNewRecord(EmployeeModel em)
        {
            Con();
            con.Open();
            SqlCommand sqlcmd = new SqlCommand("AddNewEmployee", con);
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@name", em.name);
            sqlcmd.Parameters.AddWithValue("@email", em.phone);
            sqlcmd.Parameters.AddWithValue("@phone", em.email);
            sqlcmd.Parameters.AddWithValue("city", em.city);
            sqlcmd.Parameters.AddWithValue("gender", em.gender);

            int res = sqlcmd.ExecuteNonQuery();
            con.Close();

            if (res >= 1)
            {
                return true;

            }
            else {
                return false;
            }

        
        }



        public bool DeleteRecord(int id)
        { 
         Con();
            con.Open();
            SqlCommand sqlcmd = new SqlCommand("DeleteEmployee", con);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@Id",id);
           int i = sqlcmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            { 
                return false;
            }

            
        }



        public bool UpdateRecord(EmployeeModel em)
        {
            Con();
            con.Open();
            SqlCommand sqlcmd = new SqlCommand("UpdateEmployee", con);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", em.id);
            sqlcmd.Parameters.AddWithValue("@name", em.name);
            sqlcmd.Parameters.AddWithValue("@email", em.phone);
            sqlcmd.Parameters.AddWithValue("@phone", em.email);
            sqlcmd.Parameters.AddWithValue("city", em.city);
            sqlcmd.Parameters.AddWithValue("gender", em.gender);

            int res = sqlcmd.ExecuteNonQuery();

            con.Close();

            if (res >= 1)
            {
                return true;

            }
            else
            {
                return false;
            }


        }

        public DataTable getDataTable()
        {
            Con();
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SelectEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
           return dt;
            


        }


    }
}