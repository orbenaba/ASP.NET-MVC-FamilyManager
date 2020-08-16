using FamilyManagerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyManagerWeb.ViewModels
{
    public class ParentViewModel
    {
        public IEnumerable<Gender> genders { get; set; }
        public Parent parent { get; set; }
    }
}