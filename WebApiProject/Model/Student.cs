using System;
using System.Data;
using System.Data.SqlClient;



namespace WebApiProject.Model
{
    public class Student
    {
        private IConfiguration configuration;

        public Student(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        SqlConnection con;

        public void conn()
        {
            string strcon = configuration.GetConnectionString("DefaultConnction");
            con = new SqlConnection(strcon);
        }

        public void GetStudentInfo()
        {
            List<Student> students = new List<Student>();
            string query = "select * from student";
            conn();
;
            con.Open();
            SqlCommand cmd =new  SqlCommand(query,con) ;
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) { 
                
            
            
            }

        
        }
    }
}
