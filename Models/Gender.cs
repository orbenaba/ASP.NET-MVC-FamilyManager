using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyManagerWeb.Models
{
    public class Gender
    {

        //0-male
        //1-female
        //2-transgender
        //3-other
        [Key]
        public byte id { get; set; }


        public string gender { get; set; }

    }
}