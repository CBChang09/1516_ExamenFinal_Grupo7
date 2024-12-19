using _1516_ExamenFinal_Grupo7.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1516_ExamenFinal_Grupo7.Controllers
{
    public class OrdenesController : Controller
    {
        // GET: Ordenes
        public ActionResult Index()
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var ordenes = context.Ordenes.Include("Ordenes_Detalle").ToList();
                return View(ordenes);
            }
        }

        // GET: Ordenes/Details/5
        public ActionResult Details(int id)
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var orden = context.Ordenes.Include("Ordenes_Detalle").FirstOrDefault(o => o.Id == id);
                if (orden == null)
                    return HttpNotFound();

                return View(orden);
            }
        }

        // GET: Ordenes/Create
        public ActionResult Create()
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var platillos = context.Platillos.ToList();

                ViewBag.Platillos = new SelectList(platillos, "Id", "Nombre");

                return View();
            }
        }

        // POST: Ordenes/Create
        [HttpPost]
        public ActionResult Create(Ordenes orden)
        {
            try
            {
                using (TagliatoreDBEntities context = new TagliatoreDBEntities())
                {
                    if (ModelState.IsValid)
                    {
                        context.Ordenes.Add(orden);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al registrar la orden: {ex.Message}");
            }
            return View(orden);
        }

        // GET: Ordenes/Edit/5
        public ActionResult Edit(int id)
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var orden = context.Ordenes.FirstOrDefault(o => o.Id == id);
                if (orden == null)
                    return HttpNotFound();

                return View(orden);
            }
        }

        // POST: Ordenes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Ordenes orden)
        {
            try
            {
                using (TagliatoreDBEntities context = new TagliatoreDBEntities())
                {
                    if (ModelState.IsValid)
                    {
                        context.Entry(orden).State = EntityState.Modified;
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al actualizar la orden: {ex.Message}");
            }
            return View(orden);
        }

        // GET: Ordenes/Delete/5
        public ActionResult Delete(int id)
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var orden = context.Ordenes.FirstOrDefault(o => o.Id == id);
                if (orden == null)
                    return HttpNotFound();

                return View(orden);
            }
        }

        // POST: Ordenes/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (TagliatoreDBEntities context = new TagliatoreDBEntities())
                {
                    var orden = context.Ordenes.FirstOrDefault(o => o.Id == id);
                    if (orden != null)
                    {
                        context.Ordenes.Remove(orden);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al eliminar la orden: {ex.Message}");
                return RedirectToAction("Index");
            }
        }
    }
}