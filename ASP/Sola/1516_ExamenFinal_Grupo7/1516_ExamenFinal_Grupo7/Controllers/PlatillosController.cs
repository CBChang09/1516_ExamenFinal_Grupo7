using _1516_ExamenFinal_Grupo7.Models;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using _1516_ExamenFinal_Grupo7.Models;

namespace _1516_ExamenFinal_Grupo7.Controllers
{
    public class PlatillosController : Controller
    {
        // GET: Platillos
        public ActionResult Index()
        {
            using (var context = new TagliatoreDBEntities())
            {
                var platillos = context.Platillos.ToList();
                return View(platillos); 
            }
        }
    


// GET: Platillos/Details/5
public ActionResult Details(int id)
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var platillo = context.Platillos.FirstOrDefault(p => p.Id == id);
                if (platillo == null)
                    return HttpNotFound();

                return View(platillo);
            }
        }

        // GET: Platillos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Platillos/Create
        [HttpPost]
        public ActionResult Create(Platillos platillo)
        {
            try
            {
                using (TagliatoreDBEntities context = new TagliatoreDBEntities())
                {
                    if (ModelState.IsValid)
                    {
                        context.Platillos.Add(platillo);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al registrar el platillo: {ex.Message}");
            }
            return View(platillo);
        }

        // GET: Platillos/Edit/5
        public ActionResult Edit(int id)
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var platillo = context.Platillos.FirstOrDefault(p => p.Id == id);
                if (platillo == null)
                    return HttpNotFound();

                return View(platillo);
            }
        }

        // POST: Platillos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Platillos platillo)
        {
            try
            {
                using (TagliatoreDBEntities context = new TagliatoreDBEntities())
                {
                    if (ModelState.IsValid)
                    {
                        context.Entry(platillo).State = EntityState.Modified;
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al actualizar el platillo: {ex.Message}");
            }
            return View(platillo);
        }

        // GET: Platillos/Delete/5
        public ActionResult Delete(int id)
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var platillo = context.Platillos.FirstOrDefault(p => p.Id == id);
                if (platillo == null)
                    return HttpNotFound();

                return View(platillo);
            }
        }

        // POST: Platillos/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (TagliatoreDBEntities context = new TagliatoreDBEntities())
                {
                    var platillo = context.Platillos.FirstOrDefault(p => p.Id == id);
                    if (platillo != null)
                    {
                        context.Platillos.Remove(platillo);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al eliminar el platillo: {ex.Message}");
                return RedirectToAction("Index");
            }
        }
    }
}
