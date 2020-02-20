using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepositoryCodes.Models;
using PagedList;

namespace RepositoryCodes.Controllers
{
    public class NewCodesController : Controller
    {
        private Contexto db = new Contexto();

        #region AllAction

        #region Index

        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            try
            {

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                var repositorios = from r in db.Codes
                                   select r;

                ViewBag.currentFilter = searchString;

                if (!String.IsNullOrEmpty(searchString))
                {
                    repositorios = repositorios.Where(s => s.Name.Contains(searchString)
                                               || s.Language.Contains(searchString)
                                               || s.Title.Contains(searchString));
                }

                int pageSize = 25;
                int pageNumber = (page ?? 1);
                return View(repositorios.OrderByDescending(s => s.Id).ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Erro", ex.Message);
            }
        }

        #endregion

        #region Create

        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Erro", ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,Name,Language,Utilization,Link,Date")] NewCode newCode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Codes.Add(newCode);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(newCode);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Erro", ex.Message);
            }
        }

        #endregion

        #region Edit

        public ActionResult Edit(int? id)
        {
            try
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                NewCode newCode = db.Codes.Find(id);
                if (newCode == null)
                {
                    return HttpNotFound();
                }
                return View(newCode);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Erro", ex.Message);
            }
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditConfirmed([Bind(Include = "Id,Title,Name,Language,Utilization,Link,Date")] NewCode newCode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(newCode).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(newCode);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Erro", ex.Message);
            }
        }

        #endregion

        #region Delete

        public ActionResult DeleteConfirmed(int id)
        {
            try
            {

                NewCode newCode = db.Codes.Find(id);
                db.Codes.Remove(newCode);
                db.SaveChanges();
                return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Erro", ex.Message);
            }
        }

        #endregion

        #region Erro
        public ActionResult Erro()
        {
            return View();
        }

        #endregion

        #region Visualizar

        public ActionResult ToView(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                NewCode code = db.Codes.Find(id);
                if (code == null)
                {
                    return HttpNotFound();
                }
                return PartialView(code);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Erro", ex.Message);
            }
        }

        #endregion

        #endregion

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