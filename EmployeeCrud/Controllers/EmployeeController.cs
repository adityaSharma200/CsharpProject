
using CrudOperationEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CrudOperationEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        Employeehandle emph = new Employeehandle();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List()
        {
            //OpenXmlExcelUtility openXmlExcelUtility = new OpenXmlExcelUtility();
            //openXmlExcelUtility.ImportData("ProductData.xlsx");


            List<EmployeeModel> model = emph.GetInfo();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertNewRecord(EmployeeModel models)
        {
            if (models != null)
            {
                //EmployeeModel em = new EmployeeModel();
                
                bool result = emph.InsertNewRecord(models);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Return validation errors if any
                return Json(new { success = false, message = "Invalid data" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteRecord(int id)
        {
            if (id > 0)
            {
                bool result = emph.DeleteRecord(id);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Return an error message if ID is invalid
                return Json(new { success = false, message = "Invalid ID" }, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult UpdateRecord(EmployeeModel models)
        {
            if (models != null)
            {
                bool res = emph.UpdateRecord(models);
                return Json(res , JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "Invalid record" }, JsonRequestBehavior.AllowGet);

            }
        
        
        }
        [HttpPost]
        public ActionResult ExportToExcel(string name)
        
        {
            OpenXmlExcelUtility openXmlExcelUtility = new OpenXmlExcelUtility();
            openXmlExcelUtility.ExportToExcel(emph.getDataTable());

            return Json("export successfully");
        }


    }
}
