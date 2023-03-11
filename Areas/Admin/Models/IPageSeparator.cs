using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoExit.Areas.Admin.Models
{
    
        public interface IPageSeparator
        {
            int CurrPageNumber { get; set; }
            int TotalPages { get; }
            int MaxRecordOnPage { get; }
            string AjaxFormName { get; }
        }
    

}