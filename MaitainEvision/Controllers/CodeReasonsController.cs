using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaintainEvision.Models;
using X.PagedList;

namespace MaintainEvision.Controllers
{
    public class CodeReasonsController : Controller
    {
        private EvisionConnectionString db = new EvisionConnectionString();

        // GET: CodeReasons/Create
        public ActionResult Create()
        {
            var list = new List<SelectListItem>()
                { new SelectListItem() { Text = "Y", Value = "Y", Selected = true }
                , new SelectListItem() { Text = "N", Value = "N", Selected = false } };
            ViewBag.Drop = list;

            return View();
        }

        // POST: CodeReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SysId,Vender,ProductType,ReasonCode,CodeType,AllowShip,ProcessType,EngDesc,ChtDesc,ChsDesc,Duty,Outsourcing,DefaultUsed,DefaultEcn,RequireRemark,RequireRelabel,RequireSwapInfo,RequireCustSn,RequireMfgSn,RequireBios,RequierAttn,Active,CreateDate,CreateUser,ModiDate,ModiUser")] CodeReason codeReason)
        {
            codeReason.Active = "Y";
            codeReason.CreateDate = DateTime.Now;
            codeReason.CreateUser = "AcctonJu";
            if (ModelState.IsValid)
            {
                db.CodeReason.Add(codeReason);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: CodeReasons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeReason codeReason = db.CodeReason.Find(id);
            if (codeReason == null)
            {
                return HttpNotFound();
            }
            return View(codeReason);
        }

        // POST: CodeReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CodeReason codeReason = db.CodeReason.Find(id);
            db.CodeReason.Remove(codeReason);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CodeReasons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeReason codeReason = db.CodeReason.Find(id);
            if (codeReason == null)
            {
                return HttpNotFound();
            }
            return View(codeReason);
        }

        // GET: CodeReasons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeReason codeReason = db.CodeReason.Find(id);
            if (codeReason == null)
            {
                return HttpNotFound();
            }
            return View(codeReason);
        }

        // POST: CodeReasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SysId,Vender,ProductType,ReasonCode,CodeType,AllowShip,ProcessType,EngDesc,ChtDesc,ChsDesc,Duty,Outsourcing,DefaultUsed,DefaultEcn,RequireRemark,RequireRelabel,RequireSwapInfo,RequireCustSn,RequireMfgSn,RequireBios,RequierAttn,Active,CreateDate,CreateUser,ModiDate,ModiUser")] CodeReason codeReason)
        {
            if (ModelState.IsValid)
            {
                db.Entry(codeReason).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(codeReason);
        }

        // GET: CodeReasons
        public ActionResult Index(int page = 1)
        {
            var PageList = db.CodeReason
                .OrderByDescending(p => p.CreateDate)
                .ToPagedList(pageNumber: page, pageSize: 10);
            return View(PageList);
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