using FamilyManagerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyManagerWeb.ViewModels
{
    public class ChildViewModel
    {
        public IEnumerable<Gender> genders { get; set; }
        public Child child { get; set; }
    }
}