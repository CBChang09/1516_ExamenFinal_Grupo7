using _1516_ExamenFinal_Grupo7.Models;
using System.Linq;
using System.Web.Mvc;

namespace _1516_ExamenFinal_Grupo7.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {

                var usuarios = context.Usuarios.ToList();
                return View(usuarios); 
            }
        }
    
// GET: Usuarios/Details/5
public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario nuevoUsuario)
        {
            try
            {
                using (TagliatoreDBEntities context = new TagliatoreDBEntities())
                {
                    nuevoUsuario.Activo = true;
                    context.Usuarios.Add(entity: nuevoUsuario);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuarioEditado)
        {
            try
            {
                using (TagliatoreDBEntities context = new TagliatoreDBEntities())
                {
                    var usuario = context.Usuarios.FirstOrDefault(u => u.Id == usuarioEditado.Id);
                    if (usuario != null)
                    {
                        usuario.Nombre = usuarioEditado.Nombre;
                        usuario.Apellidos = usuarioEditado.Apellidos;
                        usuario.Email = usuarioEditado.Email;
                        usuario.Telefono = usuarioEditado.Telefono;
                        context.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            using (TagliatoreDBEntities context = new TagliatoreDBEntities())
            {
                var usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
                if (usuario != null)
                {
                    usuario.Activo = false; 
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
    }
