using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CrudFirstAditya.Models
{
    public class StudentDBHandle
    {
        private SqlConnection con;

        //this is use to connect DB to C#
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
            con =new  SqlConnection(constring);
        }

        //+++++++++++++++++++++ Add Student Record +++++++++++
        public bool AddStudent(StudentModel smodel)
        {
            connection();
            SqlCommand sqlcmd = new SqlCommand("AddNewStudent", con);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@Name", smodel.name);
            sqlcmd.Parameters.AddWithValue("@Age", smodel.age);
            sqlcmd.Parameters.AddWithValue("@city", smodel.City);
            con.Open();

            int i = sqlcmd.ExecuteNonQuery();

            if (i >= 1) return true;
            else return false;

       }

        //++++++++++++++++++ View Student Details+++++++++++++
        public List<StudentModel> GetInfo()
        {
            connection();
            List<StudentModel> studentModels = new List<StudentModel>();

            SqlCommand sqlcmd = new SqlCommand("GetStudentDetails", con);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(sqlcmd);

            DataTable dt = new DataTable();                           

            con.Open();
            sd.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows)
            {
                studentModels.Add(new StudentModel
                {
                    id = Convert.ToInt32(dr["id"]),
                    name = Convert.ToString(dr["name"]),
                    City = Convert.ToString(dr["City"]),
                    age = Convert.ToInt32(dr["age"])


                });
            }

            return studentModels;
        
        }

        //+++++++++++++++++++Update Student details++++++++++++
        public bool UpdateDetail(StudentModel smodel)
        {

            connection();
            SqlCommand sqlcmd = new SqlCommand("UpdateStudentDetails",con);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@StdId", smodel.id);
            sqlcmd.Parameters.AddWithValue("@Name", smodel.name);
            sqlcmd.Parameters.AddWithValue("@City", smodel.City);
            sqlcmd.Parameters.AddWithValue("@Age", smodel.age);

            con.Open();
            int i = sqlcmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeleteStudent(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StdId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();  
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}