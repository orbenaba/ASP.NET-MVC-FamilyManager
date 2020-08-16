using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyManagerWeb.Models
{
    public class Parent: Human
    {
        public override void Draw1() { }

        [Display(Name="Job Name")]
        public string JobName { get; set; }
        
        public int Salary { get; set; }

        [Display(Name ="Total kids(number)")]
        public byte TotalKids { get; set; }

        public Parent(string username):base(username,"")
        {
            TotalKids = 0;
            Salary = 0;
        }
        public Parent():base()
        {
            TotalKids = 0;
            Salary = 0;
        }
        //Copy constructor
        public Parent(Parent other):base((Human)other)
        {
            this.Salary = other.Salary;
            this.TotalKids = other.TotalKids;
            this.JobName = other.JobName;
        }
    }
}