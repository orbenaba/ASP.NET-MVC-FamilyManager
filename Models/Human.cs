using FamilyManagerWeb.Models.MyValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyManagerWeb.Models
{
    public class Human
    {
        //declaring polymophism
        public virtual void Draw1() { }
        //declaring polymophism

        [Key]
        [Required]
        public int id { get; set; }

        [StringLength(256)]
        public string fUsername { get; set; }

        [Display(Name ="Birthdate")]
        [Min18Yearsold]
        public DateTime?BirthDate { get; set; }

        [Display(Name ="First name")]
        [Required(ErrorMessage ="First name field is required.")]
        public string FirstName { get; set; }


        ///In our days there are more then two genders
        [Required(ErrorMessage = "Gender field is required.")]
        public byte gender { get; set; }

        public Human(string fUsername, string fname)
        {
            this.fUsername = fUsername;
            this.FirstName = fname;
        }
        public Human()
        {
        }
        //Copy constructor
        public Human(Human other)
        {
            this.BirthDate = other.BirthDate;
            this.FirstName = other.FirstName;
            this.fUsername = other.fUsername;
            this.gender = other.gender;
            this.id = other.id;
        }

    }
}