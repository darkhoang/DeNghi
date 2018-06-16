using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using denghikiemtra.Models;

namespace denghikiemtra.Controllers
{
    public class DeNghiKiemTraOnlineController : Controller
    {
        private DeNghiEntities db = new DeNghiEntities();

        // GET: DeNghiKiemTraOnline
        public ActionResult Index()
        {
            return View(db.tbl_DeNghiKiemTraOnline.ToList());
        }

        // GET: DeNghiKiemTraOnline/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DeNghiKiemTraOnline applicationUser = db.tbl_DeNghiKiemTraOnline.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: DeNghiKiemTraOnline/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeNghiKiemTraOnline/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ten,DiaChi,Phuong,Quan,LyDo,HinhAnh,TrangThai")] tbl_DeNghiKiemTraOnline applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.tbl_DeNghiKiemTraOnline.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Thêm mới không thành công!");
            }
            return View(applicationUser);
        }

        // GET: DeNghiKiemTraOnline/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DeNghiKiemTraOnline applicationUser = db.tbl_DeNghiKiemTraOnline.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: DeNghiKiemTraOnline/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ten,DiaChi,Phuong,Quan,LyDo,HinhAnh,TrangThai")] tbl_DeNghiKiemTraOnline applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: DeNghiKiemTraOnline/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DeNghiKiemTraOnline applicationUser = db.tbl_DeNghiKiemTraOnline.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: DeNghiKiemTraOnline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_DeNghiKiemTraOnline applicationUser = db.tbl_DeNghiKiemTraOnline.Find(id);
            db.tbl_DeNghiKiemTraOnline.Remove(applicationUser);
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
