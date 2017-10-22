using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviePro.Models;
using System.Data.Entity;

namespace MoviePro.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult loaddata()
        {
            using (DBModel dc = new DBModel())
            {
                var data = dc.People.OrderBy(a => a.CustomerName).ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new People());
            
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.People.Where(x => x.CustomerId== id).FirstOrDefault<People>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(People emp)
        {
            using (DBModel db = new DBModel())
            {
                if (emp.CustomerId == 0)
                {
                  
                    db.People.Add(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                People emp = db.People.Where(x => x.CustomerId == id).FirstOrDefault<People>();

                db.People.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}