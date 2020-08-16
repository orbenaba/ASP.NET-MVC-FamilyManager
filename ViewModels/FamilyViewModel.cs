using FamilyManagerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyManagerWeb.ViewModels
{
    public class FamilyViewModel
    {
        public Family family { get; set; }
        /// <summary>
        ///state=0-->no errors
        ///state=1-->error in child model partial view
        ///state=2-->error in parent model partial view
        /// </summary>
        public byte state { get; set; }
    }
}