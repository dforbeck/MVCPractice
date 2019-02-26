using MySampleMVCWebsite.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static MySampleMVCWebsite.WebMVC.Models.Pet;

namespace MySampleMVCWebsite.WebMVC.Controllers
{
    public class PetController : Controller
    {
        private PetDBContext db = new PetDBContext();

        // GET: Pet
        public ActionResult Index()
        {
            return View(db.Pets.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST: Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetID,Name,AnimalType")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pet);
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pet pet = db.Pets.Find(id);

            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetID, Name, AnimalType")]Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pet);
        }

    }
}