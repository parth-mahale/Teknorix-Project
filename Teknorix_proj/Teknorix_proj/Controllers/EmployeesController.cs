using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teknorix_proj.Models;

namespace Teknorix_proj.Controllers
{
    public class EmployeesController : Controller
    {
        private Tenorix_DBContext db = new Tenorix_DBContext();

        // GET: Employees
        //[HttpPost]
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Firstname")
            {
                return View(db.Employees.Where(x => x.emp_fname.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.Employees.Where(x => x.emp_lname.StartsWith(search) || search == null).ToList());
            }
        }
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    try
        //    {
        //        //var FacultyList = _Db.Faculty_Tbl.ToList();
        //        var EmployeeList = from EMP in db.Employee_Tbl
        //                           join DEPT in db.Department_Tbl
        //                          on EMP.dept_id equals DEPT.dept_id
        //                           into Dep
        //                           from DEPT in Dep.DefaultIfEmpty()

        //                           select new Employee_Tbl
        //                          {
        //                              emp_id = EMP.emp_id,
        //                              emp_fname = EMP.emp_fname,
        //                              emp_lname = EMP.emp_lname,
        //                              emp_gender = EMP.emp_gender,
        //                              emp_address = EMP.emp_address,
        //                              emp_phone_no = EMP.emp_phone_no,
        //                              emp_mobile_no = EMP.emp_mobile_no,
        //                              dept_id = DEPT.dept_name
        //                          };


        //        return View(EmployeeList);
        //    }
        //    catch
        //    {
        //        return View();
        //    }

        //}
        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_id,emp_fname,emp_lname,emp_gender,emp_address,emp_phone_no,emp_mobile_no,emp_desgn_id,dept_id")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_id,emp_fname,emp_lname,emp_gender,emp_address,emp_phone_no,emp_mobile_no,emp_desgn_id,dept_id")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
