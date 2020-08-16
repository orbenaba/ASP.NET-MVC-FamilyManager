using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyManagerWeb.Models
{
    public class Child:Human
    {
        public override void Draw1() { }
        
        [Required]
        public string Status { get; set; }
        
        [Required]
        [Display(Name ="Are U single?")]
        public bool IsSingle { get; set; }
        public Child(string username):base(username,"")
        {
        }
        public Child():base()
        {
        }
        //Copy constructor
        public Child(Child other):base((Human)other)
        {
            this.IsSingle = other.IsSingle;
            this.Status = other.Status;
        }

    }
}