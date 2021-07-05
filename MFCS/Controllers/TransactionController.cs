using ClosedXML.Excel;
using MFCS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;

namespace MFCS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TransactionController : Controller
    {
        // GET: Transaction
        MFCSEntities context = new MFCSEntities();
        public ActionResult Index()
        {
            var transacton = context.Transactions.ToList();
            return View(transacton);
        }
        [HttpPost]
        public ActionResult Export()
        {
            var transacton = context.Transactions.ToList();
            using (XLWorkbook wb = new XLWorkbook())
            {
               // DataTable dt =Json(data: new { data = transacton }, JsonRequestBehavior.AllowGet).Tables[0];
               DataTable dt = this.GetTransactions().Tables[0];
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
        public ActionResult Details(int Id)
        {
            var tr = context.Transactions.FirstOrDefault(e => e.Id == Id);
            return View(tr);
        }
       private DataSet GetTransactions()
        {
            DataSet ds = new DataSet();
            string constr = @"Server=.\sqlexpress;Database=MFCS;Integrated Security=true;";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM Transactions";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }
                }
            }

            return ds;
        }
    }
}