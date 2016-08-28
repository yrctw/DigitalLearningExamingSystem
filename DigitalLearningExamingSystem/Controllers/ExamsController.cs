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
    public class ExamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exams
        //public ActionResult Index()
        //{
        //    return View(db.Exams.ToList());
        //}
        public ActionResult Index(string questionsSubject, string searchString)
        {
            //var TypeLst = new List<string>();
            //var TypeQry = from d in db.Exams
            //              orderby d.QTyoe
            //              select d.QTyoe;

            var SubjectLst = new List<string>();

            var SubjectQry = from d in db.Exams
                             orderby d.Subject
                             select d.Subject;

            //TypeLst.AddRange(TypeQry.Distinct());
            SubjectLst.AddRange(SubjectQry.Distinct());

            //ViewBag.questionsType = new SelectList(TypeLst);
            ViewBag.questionsSubject = new SelectList(SubjectLst);

            var questions = from m in db.Exams
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                questions = questions.Where(s => s.Question.Contains(searchString));
            }

            //if (!string.IsNullOrEmpty(questionsType))
            //{
            //    questions = questions.Where(a => a.QTyoe == questionsType);
            //}

            if (!string.IsNullOrEmpty(questionsSubject))
            {
                questions = questions.Where(x => x.Subject == questionsSubject);
            }

            return View(questions);
        }
        // GET: Exams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exams/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Question,Answer,Choice1,Choice2,Choice3,Choice4,SolveTimes,CorrectTimes,CoreectRate,Subject")] Exam exam)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Exams.Add(exam);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(exam);

            if (ModelState.IsValid)
            {
                //exam.Id = Guid.NewGuid().ToString();
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                string tmpQuestionId = "";
                bool duplicate = true;
                do
                {
                    tmpQuestionId = rnd.Next(0, 9999999).ToString().PadLeft(7, '0');
                    var existQuestionId = db.Exams.Where(p => p.Id == tmpQuestionId);
                    duplicate = (existQuestionId.Count() == 0) ? false : true;
                }
                while (duplicate);                
                exam.Id = tmpQuestionId;
                exam.FromTeacher = User.Identity.Name;
                exam.SolveTimes = 0;
                exam.CoreectRate = 0;
                exam.CorrectTimes = 0;
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,Answer,Choice1,Choice2,Choice3,Choice4,SolveTimes,CorrectTimes,CoreectRate,Subject")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
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
