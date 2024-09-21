using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using System.Data;
using System.Web.Mvc;
using System.IO;
using System.Security.AccessControl;
using DocumentFormat.OpenXml.Wordprocessing;
using Syroot.Windows.IO;
using System.Net.Mail;

using Text = DocumentFormat.OpenXml.Spreadsheet.Text;
using System.Text.RegularExpressions;
namespace CrudOperationEmployee.Models
{
    public class OpenXmlExcelUtility
    {
        public void ExportToExcel(DataTable dt)
        {
            
            string extension = ".xlsx";
            string fileName = "MyDoc1";
            string path2 = null;
            String path = "C:\\Users\\User\\Documents\\MyDoc1.xlsx";
            if(File.Exists("C:\\Users\\User\\Documents\\MyDoc1.xlsx"))
            {
                string s = Path.GetFullPath("MyDoc1.xlsx");
                //string s2= new FileInfo(s).FullName;
                
                string info = new FileInfo(s).Name;


                //string resultString = Regex.Match("C:\\Users\\User\\Documents\\MyDoc1.xlsx", @"\d+").Value;
                //int num = Convert.ToInt32(resultString);
                //path2 = $"C:\\Users\\User\\Documents\\MyDoc{++num}.xlsx";
                //path.Replace(path,path2);
            }
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Create((path2 != null)? path2 : path, SpreadsheetDocumentType.Workbook))
            { 
                WorkbookPart workbookPart = spreadsheet.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();
                SheetData sheetData = new SheetData();
                Row sheetRow = new Row();
                for (int row = -1; row < dt.Rows.Count; row++)
                {
                    DataRow myRow = null;
                    sheetRow = new Row();
                    if(row>=0)
                    {
                        myRow = dt.Rows[row];
                    }
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        if (row == -1)
                        {
                            sheetRow.InsertAt<Cell>(
                                new Cell
                                {
                                    DataType = CellValues.InlineString,
                                    InlineString = new InlineString() { Text = new Text((dt.Columns[col].ColumnName)) }
                                },
                                col
                                );

                        }
                        else
                        {
                            sheetRow.InsertAt<Cell>(
                                new Cell
                                {
                                    DataType = CellValues.InlineString,
                                    InlineString = new InlineString() { Text = new Text(Convert.ToString(myRow[dt.Columns[col].ColumnName])) }
                                },
                                col
                                );

                        }
                    }
                    sheetData.InsertAt(sheetRow, row+1);
                }
                worksheetPart.Worksheet.Append(sheetData);
                Sheets sheets = spreadsheet.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                sheets.Append(new Sheet
                {
                    Id = spreadsheet.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "mySheet"
                });
                workbookPart.Workbook.Save();
            }
        }
        private string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            string value = cell.InnerText;

            // If the cell contains a shared string
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                var stringTablePart = document.WorkbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                if (stringTablePart != null)
                {
                    value = stringTablePart.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
                }
            }

            return value;
        }
        public System.Data.DataTable ImportData(string file)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            using (SpreadsheetDocument ssp = SpreadsheetDocument.Open($"C:\\Users\\User\\Documents\\{file}",false))
            {
                WorkbookPart workbookPart = ssp.WorkbookPart;
                IEnumerable<Sheet> sheet = ssp.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                string rid = sheet.First().Id.Value;

                WorksheetPart worksheetPart = (WorksheetPart)ssp.WorkbookPart.GetPartById(rid);

                Worksheet worksheet = worksheetPart.Worksheet;

                SheetData sheetData =  worksheet.GetFirstChild<SheetData>();

               var row = sheetData.Descendants<Row>().ToList();

                foreach (Cell cell in row[0].Descendants<Cell>())
                {
                    dt.Columns.Add(GetCellValue(ssp,cell));
                }

                foreach (Row rows in row)
                { 
                    DataRow tempRow = dt.NewRow();
                    for (int i = 0; i < rows.Descendants<Cell>().Count();i++ )
                    {
                        tempRow[i] = GetCellValue(ssp, rows.Descendants<Cell>().ElementAt(i));
                    }
                    dt.Rows.Add(tempRow);   
                
                }
                dt.Rows.RemoveAt(0);

                return dt;
                       
            
            }
        
        
        
        }

        
    }
}