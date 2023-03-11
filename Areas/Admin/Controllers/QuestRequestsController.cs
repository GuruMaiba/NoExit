using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NoExit.Models;
using NoExit.Areas.Admin.Models;

namespace NoExit.Areas.Admin.Controllers
{
    [Authorize]
    public class QuestRequestsController : Controller
    {
        private DataEntity db = new DataEntity();

        // GET: Admin/QuestRequests
        public ActionResult Index()
        {
            var date = DateTime.Now;
            //var questRequests = db.QuestRequests.Include(q => q.Quest).Where(t => t.Quest.DateTime >= date).OrderByDescending(t => t.Id);

            var VM = new RequestsVM();
            var a = VM.TotalPages;
            return View(VM);
        }
        public virtual PartialViewResult RequestListPartial(RequestsVM viewModel)
        {
            var a = viewModel.CahedFiltredSet;
            return PartialView(viewModel);

        }
        // GET: Admin/QuestRequests/Details/5


        //// GET: Admin/QuestRequests/Create
        //public ActionResult Create()
        //{
        //    ViewBag.QuestId = new SelectList(db.Quests, "Id", "Id");
        //    return View();
        //}

        //// POST: Admin/QuestRequests/Create
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,FIO,Phone,Email,Comment,QuestId,Status,Count")] QuestRequest questRequest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.QuestRequests.Add(questRequest);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.QuestId = new SelectList(db.Quests, "Id", "Id", questRequest.QuestId);
        //    return View(questRequest);
        //}

        //// GET: Admin/QuestRequests/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    QuestRequest questRequest = await db.QuestRequests.FindAsync(id);
        //    if (questRequest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.QuestId = new SelectList(db.Quests, "Id", "Id", questRequest.QuestId);
        //    return View(questRequest);
        //}

        //// POST: Admin/QuestRequests/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,FIO,Phone,Email,Comment,QuestId,Status,Count")] QuestRequest questRequest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(questRequest).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.QuestId = new SelectList(db.Quests, "Id", "Id", questRequest.QuestId);
        //    return View(questRequest);
        //}

        //// GET: Admin/QuestRequests/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    QuestRequest questRequest = await db.QuestRequests.FindAsync(id);
        //    if (questRequest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(questRequest);
        //}

        //// POST: Admin/QuestRequests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    QuestRequest questRequest = await db.QuestRequests.FindAsync(id);
        //    db.QuestRequests.Remove(questRequest);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
