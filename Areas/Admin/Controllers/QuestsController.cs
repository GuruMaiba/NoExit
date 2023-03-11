using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NoExit.Models;
using System.Net.Mail;

namespace NoExit.Areas.Admin.Controllers
{
    [Authorize]
    public class QuestsController : Controller
    {
        private DataEntity db = new DataEntity();

        // GET: Admin/Quests
        public ActionResult Index(int questId, DateTime? date)
        {
            ViewBag.questId = questId;
            var date1 = date ?? DateTime.Now.Date;
            var date2 = date1.AddDays(7);
            ViewBag.Date = date1;
            return View(db.Quests.ToList().Where(t => t.QuestId == questId && t.DateTime >= date1 && t.DateTime <= date2));
        }


        public void AddSeans(int questId, DateTime date, int price)
        {
            if (!db.Quests.Where(q=>q.QuestId==questId).Any(t => t.DateTime == date))
            {
                db.Quests.Add(new Quest() { DateTime = date, IsReserved = false, QuestId = questId, Price = price });
                db.SaveChanges();
            }

        }

        public void ToDefaultDate(int questId, DateTime date)
        {
            var length = 10;
            var time = 80;
            switch (date.DayOfWeek)
            {
                case (DayOfWeek.Monday):
                    {
                        if (questId == 1)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(20);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 19)
                                    AddSeans(questId, date19, 2000);
                                else
                                    AddSeans(questId, date19, 2500);
                            }
                        }
                        if (questId == 2)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(40);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 18)
                                    AddSeans(questId, date19, 1000);
                                else
                                    AddSeans(questId, date19, 1500);
                            }
                        }
                        if (questId == 3)
                        {
                            var date10 = date.Date.AddHours(10);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 19)
                                    AddSeans(questId, date19, 3000);
                                else
                                    AddSeans(questId, date19, 3500);
                            }
                        }
                        break;
                    }
                case (DayOfWeek.Tuesday):
                    {
                        if (questId == 1)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(20);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 19)
                                    AddSeans(questId, date19, 2000);
                                else
                                    AddSeans(questId, date19, 2500);
                            }
                        }
                        if (questId == 2)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(40);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 18)
                                    AddSeans(questId, date19, 1000);
                                else
                                    AddSeans(questId, date19, 1500);
                            }
                        }
                        if (questId == 3)
                        {
                            var date10 = date.Date.AddHours(10);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 19)
                                    AddSeans(questId, date19, 3000);
                                else
                                    AddSeans(questId, date19, 3500);
                            }
                        }
                        break;
                    }
                case (DayOfWeek.Wednesday):
                    {
                        if (questId == 1)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(20);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 19)
                                    AddSeans(questId, date19, 2000);
                                else
                                    AddSeans(questId, date19, 2500);
                            }
                        }
                        if (questId == 2)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(40);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 18)
                                    AddSeans(questId, date19, 1000);
                                else
                                    AddSeans(questId, date19, 1500);
                            }
                        }
                        if (questId == 3)
                        {
                            var date10 = date.Date.AddHours(10);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 19)
                                    AddSeans(questId, date19, 3000);
                                else
                                    AddSeans(questId, date19, 3500);
                            }
                        }
                        break;
                    }
                case (DayOfWeek.Thursday):
                    {
                        if (questId == 1)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(20);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 19)
                                    AddSeans(questId, date19, 2000);
                                else
                                    AddSeans(questId, date19, 2500);
                            }
                        }
                        if (questId == 2)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(40);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 18)
                                    AddSeans(questId, date19, 1000);
                                else
                                    AddSeans(questId, date19, 1500);
                            }
                        }
                        if (questId == 3)
                        {
                            var date10 = date.Date.AddHours(10);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 19)
                                    AddSeans(questId, date19, 3000);
                                else
                                    AddSeans(questId, date19, 3500);
                            }
                        }
                        break;
                    }
                case (DayOfWeek.Friday):
                    {
                        if (questId == 1)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(20);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 19)
                                    AddSeans(questId, date19, 2000);
                                else
                                    AddSeans(questId, date19, 2500);
                            }
                        }
                        if (questId == 2)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(40);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 18)
                                    AddSeans(questId, date19, 1000);
                                else
                                    AddSeans(questId, date19, 1500);
                            }
                        }
                        if (questId == 3)
                        {
                            var date10 = date.Date.AddHours(10);
                            for (int i = 0; i < length; i++)
                            {
                                var date19 = date10.AddMinutes(i * time);
                                if (date19.Hour < 19)
                                    AddSeans(questId, date19, 3000);
                                else
                                    AddSeans(questId, date19, 3500);
                            }
                        }
                        break;
                    }
                case (DayOfWeek.Saturday):
                    {
                        if (questId == 1)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(20);
                            for (int i = 0; i < length; i++)
                            {
                                AddSeans(questId, date10.AddMinutes(i * time), 2500);
                            }
                        }
                        if (questId == 2)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(40);
                            for (int i = 0; i < length; i++)
                            {
                                AddSeans(questId, date10.AddMinutes(i * time), 1500);
                            }
                        }
                        if (questId == 3)
                        {
                            var date10 = date.Date.AddHours(10);
                            for (int i = 0; i < length; i++)
                            {
                                AddSeans(questId, date10.AddMinutes(i * time), 3500);
                            }
                        }
                        break;
                    }
                case (DayOfWeek.Sunday):
                    {
                        if (questId == 1)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(20);
                            for (int i = 0; i < length; i++)
                            {
                                AddSeans(questId, date10.AddMinutes(i * time), 2500);
                            }
                        }
                        if (questId == 2)
                        {
                            var date10 = date.Date.AddHours(10).AddMinutes(40);
                            for (int i = 0; i < length; i++)
                            {
                                AddSeans(questId, date10.AddMinutes(i * time), 1500);
                            }
                        }
                        if (questId == 3)
                        {
                            var date10 = date.Date.AddHours(10);
                            for (int i = 0; i < length; i++)
                            {
                                AddSeans(questId, date10.AddMinutes(i * time), 3500);
                            }
                        }
                        break;
                    }
            }

        }

        public ActionResult DefaultDay(int questId, DateTime date, DateTime toDate)
        {
            ToDefaultDate(questId, date);
            return RedirectToAction("Index",new {questId=questId, date=toDate});
        }
        public ActionResult DefaultWeek(int questId, DateTime date, DateTime toDate)
        {
            for (int i = 0; i <= 6; i++)
            {
                ToDefaultDate(questId, date.AddDays(i));
            }
            return RedirectToAction("Index", new { questId = questId, date = toDate });
        }
        // GET: Admin/Quests/Create


        // POST: Admin/Quests/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.


        public void Create(int questId, DateTime datetime, int price)
        {
            if (ModelState.IsValid)
            {
                db.Quests.Add(new Quest() {DateTime = datetime, IsReserved = false, QuestId = questId, Price = price});
                db.SaveChanges();
            }
        }


        public void Reserve(int Id, string FIO, string Phone, int Count, string Comment)
        {
            var req = new QuestRequest()
            {
                Count = Count,
                FIO = FIO,
                Phone = Phone,
                Comment = Comment,
                QuestId = Id
            };
            db.QuestRequests.Add(req);
            var quest = db.Quests.Find(Id);

            quest.IsReserved = true;
            db.SaveChanges();
        }

        public void UnReserve(int Id)
        {
            var quest = db.Quests.Find(Id);
            var reqs = db.QuestRequests.Where(t => t.QuestId == Id);
            quest.IsReserved = false;
            db.QuestRequests.RemoveRange(reqs);
            
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var quest = db.Quests.Find(Id);
            var reqs = db.QuestRequests.Where(t => t.QuestId == Id);
            db.QuestRequests.RemoveRange(reqs);
            db.Quests.Remove(quest);
            db.SaveChanges();
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
