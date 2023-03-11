using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoExit.Models
{
    public class Quest: SimpleEntity
    {
        [Display(Name = "Время сеанса")]
        public DateTime DateTime { get; set; }

        public int Price { get; set; }
        public int QuestId { get; set; }
        public bool IsReserved { get; set; }

        [NotMapped]
        [Display(Name = "Квест")]
        public string QuestString
        {
            get
            {
                switch (QuestId)
                {
                    case 1:
                        return "Апокалипсис";
                    case 2:
                        return "Шизофрения";
                    case 3:
                        return "Сайлент-Хилл";
                }
                return "";
            }
        }
    }
}