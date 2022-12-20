using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Evenside.Models.EFModels;

namespace Evenside.Controllers
{
    public class Registers01Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: Registers01
        public ActionResult Index()
        {
            var data = db.Registers01.OrderBy(x => x.Name).ToList();

            return View(data);
           // return View(db.Registers01.ToList());
        }

        // GET: Registers01/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registers01 registers01 = db.Registers01.Find(id);
            if (registers01 == null)
            {
                return HttpNotFound();
            }
            return View(registers01);
        }

        // GET: Registers01/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registers01/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,CreateTime")] Registers01 registers01)
        {
            if (ModelState.IsValid)
            {
                db.Registers01.Add(registers01);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registers01);
        }

        // GET: Registers01/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registers01 registers01 = db.Registers01.Find(id);
            if (registers01 == null)
            {
                return HttpNotFound();
            }
            return View(registers01);
        }

        // POST: Registers01/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,CreateTime")] Registers01 registers01)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registers01).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registers01);
        }

        // GET: Registers01/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registers01 registers01 = db.Registers01.Find(id);
            if (registers01 == null)
            {
                return HttpNotFound();
            }
            return View(registers01);
        }

        // POST: Registers01/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registers01 registers01 = db.Registers01.Find(id);
            db.Registers01.Remove(registers01);
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
