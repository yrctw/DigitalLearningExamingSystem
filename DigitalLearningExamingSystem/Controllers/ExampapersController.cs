using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DigitalLearningExamingSystem.Models;

namespace DigitalLearningExamingSystem.Controllers
{
    public class ExampapersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ShowExamPaper(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exampaper exampaper = db.Exampapers.Find(id);
            var ExamLst = new List<object>();
            //var ExamList = db.Exams.ToList();

            var qry = db.Exampapers.Where(p => p.Id == id).FirstOrDefault();
            if (qry != null)
            {
                string[] arr = qry.QuestionIds.Split(',');
                foreach (var ques in arr)
                {
                    var ExamQry = db.Exams.Where(p => p.Id == ques).FirstOrDefault();
                    {
                        ExamLst.Add(ExamQry);
                    }                    
                }

            }
            ViewBag.examPaperList = ExamLst;
            if (exampaper == null)
            {
                return HttpNotFound();
            }
            return View(exampaper);
        }

        public ActionResult ShowExamPaperWithAnswer(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exampaper exampaper = db.Exampapers.Find(id);
            var ExamLst = new List<object>();
            //var ExamList = db.Exams.ToList();

            var qry = db.Exampapers.Where(p => p.Id == id).FirstOrDefault();
            if (qry != null)
            {
                string[] arr = qry.QuestionIds.Split(',');
                foreach (var ques in arr)
                {
                    var ExamQry = db.Exams.Where(p => p.Id == ques).FirstOrDefault();
                    {
                        ExamLst.Add(ExamQry);
                    }
                }

            }
            ViewBag.examPaperList = ExamLst;
            if (exampaper == null)
            {
                return HttpNotFound();
            }
            return View(exampaper);
        }

        // GET: Exampapers
        public ActionResult Index()
        {
            return View(db.Exampapers.ToList());
        }

        // GET: Exampapers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exampaper exampaper = db.Exampapers.Find(id);
            if (exampaper == null)
            {
                return HttpNotFound();
            }
            return View(exampaper);
        }

        // GET: Exampapers/Create
        public ActionResult Create()
        {
            var ExamLst = new List<object>();
            var ExamList = db.Exams.ToList();
            foreach (var items in ExamList)
            {
                ExamLst.Add(items);
            }
            ViewBag.examList = ExamLst;
            return View();
        }

        // POST: Exampapers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExampapaerName,TeacherId,Subject,Num,MeanGrade,QuestionIds")] Exampaper exampaper)
        {
            if (ModelState.IsValid)
            {
                exampaper.Id = Guid.NewGuid().ToString();
                exampaper.TeacherId = User.Identity.Name;
                db.Exampapers.Add(exampaper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exampaper);
        }

        // GET: Exampapers/Edit/5
        public ActionResult Edit(string id)
        {
            var ExamLst = new List<object>();
            var ExamList = db.Exams.ToList();
            foreach (var items in ExamList)
            {
                ExamLst.Add(items);
            }
            ViewBag.examList = ExamLst;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exampaper exampaper = db.Exampapers.Find(id);
            if (exampaper == null)
            {
                return HttpNotFound();
            }
            return View(exampaper);
        }

        // POST: Exampapers/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExampapaerName,TeacherId,Subject,Num,MeanGrade,QuestionIds")] Exampaper exampaper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exampaper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exampaper);
        }

        // GET: Exampapers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exampaper exampaper = db.Exampapers.Find(id);
            if (exampaper == null)
            {
                return HttpNotFound();
            }
            return View(exampaper);
        }

        // POST: Exampapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Exampaper exampaper = db.Exampapers.Find(id);
            db.Exampapers.Remove(exampaper);
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
