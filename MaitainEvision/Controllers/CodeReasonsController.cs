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
using MaintainEvision.ViewModel;

namespace MaintainEvision.Controllers
{
    public class CodeReasonsController : Controller
    {
        private EvisionConnectionString db = new EvisionConnectionString();

        // GET: CodeReasons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CodeReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vender,ProductType,ReasonCode,CodeType,AllowShip,ProcessType,EngDesc,ChtDesc,ChsDesc,Duty,Outsourcing,DefaultUsed,DefaultEcn,RequireRemark,RequireRelabel,RequireSwapInfo,RequireCustSn,RequireMfgSn,RequireBios,RequierAttn")] CodeReasonCreateViewModel codeReasonViewModel)
        {
            if (ModelState.IsValid)
            {
                CodeReason codeReason = new CodeReason()
                {
                    Vender = codeReasonViewModel.Vender,
                    ProductType = codeReasonViewModel.ProductType,
                    ReasonCode = codeReasonViewModel.ReasonCode,
                    CodeType = codeReasonViewModel.CodeType,
                    AllowShip = codeReasonViewModel.AllowShip,
                    ProcessType = codeReasonViewModel.ProcessType,
                    EngDesc = codeReasonViewModel.EngDesc,
                    ChtDesc = codeReasonViewModel.ChsDesc,
                    ChsDesc = codeReasonViewModel.ChsDesc,
                    Duty = codeReasonViewModel.Duty,
                    Outsourcing = codeReasonViewModel.Outsourcing,
                    DefaultUsed = codeReasonViewModel.DefaultUsed,
                    DefaultEcn = codeReasonViewModel.DefaultEcn,
                    RequireRemark = codeReasonViewModel.RequireRemark,
                    RequireRelabel = codeReasonViewModel.RequireRelabel,
                    RequireSwapInfo = codeReasonViewModel.RequireSwapInfo,
                    RequireCustSn = codeReasonViewModel.RequireCustSn,
                    RequireMfgSn = codeReasonViewModel.RequireMfgSn,
                    RequireBios = codeReasonViewModel.RequireBios,
                    RequierAttn = codeReasonViewModel.RequierAttn,
                    Active = "Y",
                    CreateDate = DateTime.Now,
                    CreateUser = "AcctonJu"
                };

                db.CodeReason.Add(codeReason);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: CodeReasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeReason codeReason = db.CodeReason
                .Where(p => p.SysId == id)
                .FirstOrDefault();
            if (codeReason == null)
            {
                return HttpNotFound();
            }
            return View(codeReason);
        }

        // POST: CodeReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            CodeReason codeReason = db.CodeReason
                .Where(p => p.SysId == id)
                .FirstOrDefault();
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