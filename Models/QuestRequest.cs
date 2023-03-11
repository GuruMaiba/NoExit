using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoExit.Models
{
    public class QuestRequest: SimpleEntity
    {
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        [Display(Name = "Контактный телефон")]
        [Phone] public string Phone { get; set; }
        //[Display(Name = "Электронная почта")]
        //[EmailAddress] public string Email { get; set; }
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
        
        [ForeignKey("QuestId")]public Quest Quest { get; set; }
        public int QuestId { get; set; }
        //public int Status { get; set; }
        [Display(Name = "Кол-во человек")]
        public int Count { get; set; }

        [NotMapped]
        [Display(Name = "Квест")]
        public string QuestString {
            get
            {
                switch (Quest.QuestId)
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
        [NotMapped]
        [Display(Name = "Время")]
        public string DateTimeString
        {
            get
            {
                return Quest.DateTime.ToString("g");
            }
        }
        [NotMapped]
        [Display(Name = "Цена")]
        public string PriceString
        {
            get
            {
                return Quest.Price.ToString();
            }
        }


    }
}