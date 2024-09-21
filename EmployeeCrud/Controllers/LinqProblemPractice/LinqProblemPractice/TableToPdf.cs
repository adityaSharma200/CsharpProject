using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinqProblemPractice
{
    public class TableToPdf
    {
        public static void Main(string[] args)
        {
            string con = "Data Source=PCD746;Initial Catalog=Product;Integrated Security=True;";
            string query = "SELECT * FROM Product";
          DataTable dt = test(con, query);
            string filepath = "C://Users//User//Documents//PhoneData.pdf";
            DataToPdf(dt, filepath);
        }

       public static DataTable test(string con,string query)
        { 
            SqlConnection sqlcon = new SqlConnection(con);

            DataTable dt = new DataTable();
            SqlDataAdapter adaptar = new SqlDataAdapter(query,con);
            adaptar.Fill(dt);

            return dt;
            
        }

        public static void DataToPdf(DataTable dt,string path)
        {


            //using(var pdfwriter = new PdfWriter(path))
            //using (var pdfdocument = new PdfDocument(pdfwriter))
            //{

            //}

            Rectangle rec = new Rectangle(PageSize.A4);
            Document doc = new Document();
            doc.SetPageSize(PageSize.A4);
            var filestream = new FileStream(path, FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, filestream);
            PdfPTable ptable = new PdfPTable(dt.Columns.Count);

            doc.Open();
            foreach (DataColumn col in dt.Columns)
            {
                ptable.AddCell(Convert.ToString(col));
            }

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    ptable.AddCell(Convert.ToString(row[Convert.ToString(col)]));
                }
            }
            doc.Add(ptable);
            doc.Close();

        
        }



    }
}
