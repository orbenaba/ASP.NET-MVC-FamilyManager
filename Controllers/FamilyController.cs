using FamilyManagerWeb.Models;
using FamilyManagerWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyManagerWeb.Controllers
{
    [Authorize]
    public class FamilyController : Controller
    {
        //Fill all the details about the ****new family****
        private ApplicationDbContext _context;
        public static Child stcChild;//keeps the old child which handls the current error
        public static Parent stcParent;//Same reason



        public FamilyController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index(string uname)
        {
            var family = new Family(uname);
            return View(family);
        }

        public ActionResult Create(Family family)
        {
            if (ModelState.IsValid)
            {
                //Validate that the current family does not enter new Last name
                var currentlname = family.LastName;
                var oldname = _context.Family.SingleOrDefault(m => m.fUsername == family.fUsername);
                if (oldname == null)
                {
                    _context.Family.Add(family);
                    _context.SaveChanges();
                    return RedirectToAction("Home", "Family", new { username = family.fUsername });
                }
                else if(oldname.LastName==currentlname)
                    return RedirectToAction("Home", "Family", new { username = family.fUsername });
                else
                    return HttpNotFound();
            }
            return View("Index");//stay at the same view
        }


        //Display a partial view of new parent
        [Route("Family/DisplayNewParentForm/{username}/{flag}")]
        public ActionResult DisplayNewParentForm(string username, string flag)//flag stands for errors
        {
            var gendersInDb = _context.genders.ToList();
            if (flag == "f")
            {
                var pm = new ParentViewModel
                {
                    parent = new Parent(username),
                    genders = gendersInDb
                };
                return PartialView("newParent", pm);
            }
            var pm2 = new ParentViewModel
            {
                parent = stcParent,
                genders = gendersInDb
            };
            return PartialView("newParent", pm2);
        }

        //Display a partial view of new child
        [Route("Family/DisplayNewChildForm/{username}/{flag}")]
        public ActionResult DisplayNewChildForm(string username, string flag)//flag stands for errors
        {
            var gendersInDb = _context.genders.ToList();
            if (flag == "f")
            {
                var cm = new ChildViewModel
                {
                    child = new Child(username),
                    genders = gendersInDb,
                };
                return PartialView("newChild", cm);
            }

            var cm2 = new ChildViewModel
            {
                child = stcChild,
                genders = gendersInDb
            };
            return PartialView("newChild", cm2);
        }


        //First view after registerring to Family manager
        public ActionResult Home(string username)
        {
            var family = _context.Family.SingleOrDefault(m => m.fUsername == username);//identify the required family by its primary key
            if (family == null)
                return HttpNotFound();//This edge case is not possible
            var viewmodel = new FamilyViewModel
            {
                family = family,
                state = 0
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult newChildToFamily(ChildViewModel cvm)
        {
            //identify the current family by its username
            var familyInDb = _context.Family.SingleOrDefault(m => m.fUsername == cvm.child.fUsername);
            if (ModelState.IsValid)
            {
                ViewBag.ErrorMessages = "";
                /// 
                using (var db = new ApplicationDbContext())
                {
                    db.Family.Attach(familyInDb);
                    db.Entry(familyInDb).Property(x => x.counter).IsModified = true;
                    familyInDb.counter = (byte)(familyInDb.counter + 1);//update the amount of pepole
                    db.SaveChanges();
                }
                _context.Humen.Add(cvm.child);
                _context.SaveChanges();

                return RedirectToAction("Home", "Family", new { username = cvm.child.fUsername });
            }
            stcChild = cvm.child;
            var viewmodel = new FamilyViewModel
            {
                family=familyInDb,
                state=1
            };
            return View("Home", viewmodel);
        }
        [HttpPost]
        public ActionResult newParentToFamily(ParentViewModel pvm)
        {
            //identify the current family by its username
            var familyInDb = _context.Family.SingleOrDefault(m => m.fUsername == pvm.parent.fUsername);
            if (ModelState.IsValid)
            {
                /// 
                using (var db = new ApplicationDbContext())
                {
                    db.Family.Attach(familyInDb);
                    db.Entry(familyInDb).Property(x => x.counter).IsModified = true;
                    familyInDb.counter = (byte)(familyInDb.counter + 1);//update the amount of pepole
                    db.SaveChanges();
                }
                _context.Humen.Add(pvm.parent);
                _context.SaveChanges();
                return RedirectToAction("Home", "Family", new { username = pvm.parent.fUsername});
            }
            stcParent = pvm.parent;
            var viewmodel = new FamilyViewModel
            {
                family = familyInDb,
                state = 2
            };
            return View("Home", viewmodel);
        }


       // [HttpPost]
        public ActionResult LogOff()
        {
            return RedirectToAction("LogOff", "Account");
        }
    }
}