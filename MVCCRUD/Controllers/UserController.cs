using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUD.Models; //importar el namespace
using MVCCRUD.Models.ViewModels;

namespace MVCCRUD.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<TablaUserViewModel> lst;
            using (CRUDEntities2 db = new CRUDEntities2())
            {
                 lst = (from d in db.usuarios
                           select new TablaUserViewModel
                           {
                               id = d.id,
                               nombre = d.nombre,
                               fechaNacimiento = d.fechaNacimiento,
                               correo = d.correo
                           }).ToList();
            }
            return View(lst);
        }

        //acciones para insert
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUDEntities2 db = new CRUDEntities2())
                    {
                        var oTabla = new usuarios();//nombre de la tabla en la BD
                        oTabla.correo = model.correo;
                        oTabla.fechaNacimiento = model.fechaNacimiento;
                        oTabla.nombre = model.nombre;

                        db.usuarios.Add(oTabla);
                        db.SaveChanges();

                    }
                    return Redirect("/User");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //Acciones para editar
        public ActionResult Editar(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (CRUDEntities2 db = new CRUDEntities2())
            {
                var oTabla = db.usuarios.Find(id);
                model.nombre = oTabla.nombre;
                model.correo = oTabla.correo;
                model.fechaNacimiento = oTabla.fechaNacimiento;
                model.id = oTabla.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUDEntities2 db = new CRUDEntities2())
                    {
                        var oTabla = db.usuarios.Find(model.id);
                        oTabla.correo = model.correo;
                        oTabla.fechaNacimiento = model.fechaNacimiento;
                        oTabla.nombre = model.nombre;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("/User");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Acciones para eliminar
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (CRUDEntities2 db = new CRUDEntities2())
            {
                var oTabla = db.usuarios.Find(id);
                db.usuarios.Remove(oTabla); //Elimino la entidad que encuentro
                db.SaveChanges();
            }
            return Redirect("~/User");
        }





    }//fin de la clase
}//fin del namespace