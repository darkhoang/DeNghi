using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using denghikiemtra.Models;
using PagedList;

namespace denghikiemtra.Controllers
{
    public class DeNghiKiemTraOnlineController : Controller
    {
        private DeNghiEntities db = new DeNghiEntities();

        // GET: DeNghiKiemTraOnline
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.STTSortParm = sortOrder == "STT" ? "STT_desc" : "STT";
            //ViewBag.PhuongSortParm = sortOrder == "phuong" ? "phuong_desc" : "phuong";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var khachhangfind = from s in db.tbl_DeNghiKiemTraOnline
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                khachhangfind = khachhangfind.Where(s => s.Ten.Contains(searchString));
            //                           //|| s.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "STT_desc":
                    khachhangfind = khachhangfind.OrderByDescending(s => s.STT);
                    break;
                case "name_desc":
                    khachhangfind = khachhangfind.OrderByDescending(s => s.Ten);
                    break;

                //case "phuong":
                //   khachhangfind = khachhangfind.OrderBy(s => s.Phuong);
                //   break;
                //case "phuong_desc":
                //    khachhangfind = khachhangfind.OrderByDescending(s => s.Phuong);
                //    break;
                default:
                    khachhangfind = khachhangfind.OrderBy(s => s.Ten);
                    break;
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //return View(khachhangfind.ToList());
            return View(khachhangfind.ToPagedList(pageNumber, pageSize));
        }

        
        // GET: DeNghiKiemTraOnline/Details/5
        public ActionResult Details(int id)
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
        public ActionResult Edit(int id)
        {
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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "STT,Ten,DiaChi,Phuong,Quan,LyDo,HinhAnh,TrangThai")] tbl_DeNghiKiemTraOnline applicationUser)
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
        public ActionResult Delete(int id)
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
        public ActionResult DeleteConfirmed(int id)
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
