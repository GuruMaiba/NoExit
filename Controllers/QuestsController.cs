using System;
using System.Collections.Generic;

using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NoExit.Models;
using SMSAERO_PROJECT;


namespace NoExit.Controllers
{
    public class QuestsController : Controller
    {
        private DataEntity db = new DataEntity();

        // GET: Admin/Quests
        public ActionResult Index(DateTime? date)
        {
            //ViewBag.questId = questId;
            ViewBag.Date = date ?? DateTime.Now.AddHours(2).AddMinutes(10);
            var date1 = date ?? DateTime.Now.AddHours(2).Date;
            var date2 = date1.AddDays(16);
            return View(db.Quests.ToList().Where(t => t.DateTime >= date1 && t.DateTime <= date2));
            //return View(new List<Quest>() { new Quest() { DateTime = DateTime.Now, Price = 444, QuestId = 2, Id = 1 }, new Quest() { DateTime = DateTime.Now, Price = 444, QuestId = 1, IsReserved = true, Id = 2 }, new Quest() { DateTime = DateTime.Now, Price = 444, QuestId = 1, Id = 3 }, new Quest() { DateTime = DateTime.Now, Price = 444, QuestId = 1, Id = 4 }, new Quest() { DateTime = DateTime.Now, Price = 444, QuestId = 1, Id = 5 }, new Quest() { DateTime = DateTime.Now, Price = 444, QuestId = 1, Id = 6 }, new Quest() { DateTime = DateTime.Now.AddDays(1), Price = 444, QuestId = 1, Id = 7 }, new Quest() { DateTime = DateTime.Now, Price = 449, QuestId = 1, Id = 8 }, new Quest() { DateTime = DateTime.Now, Price = 448, QuestId = 1, Id = 9 }, });
        }
        // GET: Admin/Quests/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Quest quest = db.Quests.Find(id);
        //    if (quest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(quest);
        //}

        // GET: Admin/Quests/Create


        // POST: Admin/Quests/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public void Create(int questId, DateTime datetime, int price)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Quests.Add(new Quest() {DateTime = datetime, IsReserved = false, QuestId = questId, Price = price});
        //        db.SaveChanges();

        //        //return RedirectToAction("Index");
        //    }

        //    //return View(quest);
        //}

        
        public ActionResult Reserve (int Id, string FIO, string Phone, int Count, string Comment)
        {
            try
            {
                var phone = Phone.Split('-').Aggregate((cur, t) => cur + t).Split('(').Aggregate((cur, t) => cur + t).Split(')').Aggregate((cur, t) => cur + t);
                phone = phone.Remove(0,1);
                phone = "7" + phone;

                var req = new QuestRequest()
                {
                    Count = Count,
                    FIO = FIO,
                    Phone = Phone,
                    Comment = Comment,
                    QuestId = Id,

                };

                db.QuestRequests.Add(req);
                var quest = db.Quests.Find(Id);

                quest.IsReserved = true;
                db.SaveChanges();

                //var quest = new Quest() { DateTime = DateTime.Now, QuestId = 1, Price = 32543 };
                //MailSender.SendMail("Заявка Имя:" + req.FIO + " Телефон:" + req.Phone + " Комментарий:" + req.Comment + " Кол-во человек:" + req.Count + " Квест:" + quest.QuestString + " Время:" + quest.DateTime.ToString("d MMMM hh:mm"));

                SMSAERO smsc = new SMSAERO();
                var s = smsc.send_sms_now(phones: phone, message: FIO + ", вы забронировали квест " + quest.QuestString + " на " + quest.DateTime.ToString("d MMMM HH:mm") +
                    ". Ждем вас по адресу пр-т Мира 1, вход со двора. С уважением, команда \"Выхода нет\".", digital: 0, type: 3);
                var s1 = smsc.send_sms_now(phones: "89128175503", message: FIO + " забронировал квест " + quest.QuestString + " на " + quest.DateTime.ToString("d MMMM HH:mm") +
                    ". Номер:" + phone + ". Коммент: " + Comment, digital: 0, type: 3);
                var s2 = smsc.send_sms_now(phones: "89324385114", message: FIO + " забронировал квест " + quest.QuestString + " на " + quest.DateTime.ToString("d MMMM HH:mm") +
                    ". Номер:" + phone + ". Коммент: " + Comment, digital: 0, type: 3);

                /*smsc.status(34339417);*/





                return Content("Вы забронировали квест " + quest.QuestString + " на " + quest.DateTime.ToString("d MMMM HH:mm") + ". Информация отправлена вам на контактный номер.", "text/html");
            }
            catch
            {
                return Content("Что-то пошло не так, пожалуйста, позвоните нам по номеру +7 (3462) 67-55-03 для записи", "text/html");
            }
        }
        // GET: Admin/Quests/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Quest quest = db.Quests.Find(id);
        //    if (quest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(quest);
        //}

        //// POST: Admin/Quests/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id")] Quest quest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(quest).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(quest);
        //}

        //// GET: Admin/Quests/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Quest quest = db.Quests.Find(id);
        //    if (quest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(quest);
        //}

        //// POST: Admin/Quests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Quest quest = db.Quests.Find(id);
        //    db.Quests.Remove(quest);
        //    db.SaveChanges();
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
