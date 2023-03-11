using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoExit.Models
{
    public abstract class SimpleEntity
    {
        [Key] public int Id { get; set; }

    }

}