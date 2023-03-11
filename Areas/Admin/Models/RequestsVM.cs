using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoExit.Models;
namespace NoExit.Areas.Admin.Models
{
    public class RequestsVM: IPageSeparator
    {
        public string CookiesFormName => $"Cucki";
        public string AjaxFormName { get; set; } = "FilterForm";

        private int _maxRecordOnPage = -1;
        public int MaxRecordOnPage
        {
            get
            {
                const int maxRecordOnPageDefault = 50;
                if (_maxRecordOnPage <= 0)
                {
                    if (HttpContext.Current.Request.Cookies.AllKeys.Contains(CookiesFormName))
                    {
                        HttpCookie cookie = HttpContext.Current.Request.Cookies[CookiesFormName];

                        int listCount;
                        if (cookie == null || string.IsNullOrWhiteSpace(cookie.Value) ||
                            !int.TryParse(cookie.Value, out listCount))
                        {
                            return (_maxRecordOnPage = maxRecordOnPageDefault);
                        }

                        return (_maxRecordOnPage = listCount);
                    }
                }
                else
                {
                    return _maxRecordOnPage;
                }
                return (_maxRecordOnPage = maxRecordOnPageDefault);
            }
            set
            {
                if (HttpContext.Current.Request.Cookies.AllKeys.Contains(CookiesFormName))
                {
                    HttpContext.Current.Request.Cookies[CookiesFormName].Value = value.ToString();
                }
                else
                {
                    var cookie = new HttpCookie(CookiesFormName)
                    {
                        Value = value.ToString(),
                        Expires = DateTime.Now.AddMonths(1)
                    };
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                _maxRecordOnPage = value;
            }
        }
        public int CurrPageNumber { get; set; }

        public int _totalPages = -1;
        public string Filter { get; set; }
       
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }

        public int QuestsId { get; set; }

        public int OrderId { get; set; }


        public RequestsVM()
        {
            //FilterPeriod = 1;
        }

       

       
        

        

        

        private List<QuestRequest> _cashedlist;

        public int TotalPages
        {
            get
            {
                var result = _totalPages != -1 ?
                    _totalPages :
                    (_totalPages = (int)Math.Ceiling((double)AllFilteredSet.Count() / MaxRecordOnPage));
                if (CurrPageNumber > _totalPages)
                    CurrPageNumber = 0;
                return result;
            }
        }


        private IEnumerable<QuestRequest> _allFilteredSet;


        private IEnumerable<QuestRequest> AllFilteredSet
        {
            get
            {
                //return new List<QuestRequest>() { new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, new QuestRequest() { Quest = new Quest() { Id = 1 }, FIO = "sdfsf" }, };
                using (var db = new DataEntity())
                {
                    var result = _allFilteredSet = _allFilteredSet ?? (Filter == null
                        ? db.QuestRequests.Include("Quest").ToList()
                        : db.QuestRequests.Include("Quest").ToList()
                                .Where(
                                    t =>
                                        t.FIO.ToLower().Contains(Filter.ToLower()) ||
                                        t.Phone.ToLower().Contains(Filter.ToLower()) ||
                                        t.Comment.ToLower().Contains(Filter.ToLower()) ||
                                        //t.QuestString.ToLower().Contains(Filter.ToLower()) ||
                                        //t.DateTimeString.ToLower().Contains(Filter.ToLower()) ||
                                        t.PriceString.ToLower().Contains(Filter.ToLower())


                                        ).ToList());
                    if (QuestsId != 0)
                    {
                        result = result.Where(t => t.Quest.QuestId==QuestsId).ToList();
                    }
                    if (startDate.Year!=1) {
                        result = result.Where(t => t.Quest.DateTime >= startDate).ToList();
                    }
                    if (endDate.Year != 1)
                    {
                        result = result.Where(t => t.Quest.DateTime <= endDate).ToList();
                    }
                    if (startTime!= new TimeSpan(00, 00, 00))
                    {
                        result = result.Where(t => t.Quest.DateTime.TimeOfDay >= startTime).ToList();
                    }
                    if (endTime != new TimeSpan(00,00,00))
                    {
                        result = result.Where(t => t.Quest.DateTime.TimeOfDay <= endTime).ToList();
                    }
                    switch (OrderId)
                    {
                        case 0:
                            result = result.OrderByDescending(t => t.Id).ToList();
                            break;
                        case 1:
                            result = result.OrderByDescending(t => t.Quest.DateTime).ToList();
                            break;
                    }
                    return result;
                }
            }
        }

        public IEnumerable<QuestRequest> CahedFiltredSet
        {
            get
            {

                var list = AllFilteredSet.Skip(CurrPageNumber * MaxRecordOnPage).Take(MaxRecordOnPage);

                //TotalPages = (int)Math.Ceiling((double)list.Count() / MaxRecordOnPage);




                
                return list;
            }
        }
    

    }
}