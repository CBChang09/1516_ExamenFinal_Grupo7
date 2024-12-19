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
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var clientes = context.Clientes.ToList(); 

                return View(clientes);
            }
        }



        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var cliente = context.Clientes.FirstOrDefault(c => c.Id == id);
                if (cliente == null)
                    return HttpNotFound();

                return View(cliente);
            }
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Clientes cliente)
        {
            try
            {
                using (TagliatoreDBEntities context = new TagliatoreDBEntities())
                {
                    if (ModelState.IsValid)
                    {
                        context.Clientes.Add(cliente);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al registrar el cliente: {ex.Message}");
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var cliente = context.Clientes.FirstOrDefault(c => c.Id == id);
                if (cliente == null)
                    return HttpNotFound();

                return View(cliente);
            }
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Clientes cliente)
        {
            try
            {
                using (TagliatoreDBEntities context = new TagliatoreDBEntities())
                {
                    if (ModelState.IsValid)
                    {
                        context.Entry(cliente).State = EntityState.Modified;
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al actualizar el cliente: {ex.Message}");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var cliente = context.Clientes.FirstOrDefault(c => c.Id == id);
                if (cliente == null)
                    return HttpNotFound();

                return View(cliente);
            }
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (TagliatoreDBEntities context = new TagliatoreDBEntities())
                {
                    var cliente = context.Clientes.FirstOrDefault(c => c.Id == id);
                    if (cliente != null)
                    {
                        context.Clientes.Remove(cliente);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al eliminar el cliente: {ex.Message}");
                return RedirectToAction("Index");
            }
        }
    }
}