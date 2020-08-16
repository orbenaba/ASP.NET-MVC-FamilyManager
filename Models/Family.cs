using FamilyManagerWeb.Models.MyValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FamilyManagerWeb.Models
{
    public class Family
    {
        [StringLength(256)]
        [Required]
        [Key]
        public string fUsername { get; set; }

        [Display(Name ="Family name")]
        [Required]
        public string LastName { get; set; }

        //At the most-->>10 pepole in one family
        [Max10pepole]
        public byte counter { get; set; }

        public Family(string username)
        {
            this.fUsername = username;
            counter = 0;
        }
        public Family()
        { 
            counter = 0;
        }
    }
}