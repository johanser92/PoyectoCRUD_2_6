using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoyectoCRUD_2_6.Models;

namespace PoyectoCRUD_2_6.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            RegistroProducto rp = new RegistroProducto();
            return View(rp.RecuperarTodos());
        }

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            RegistroProducto rp = new  RegistroProducto();
            Producto pro = new Producto
            {
                Id=int.Parse(collection["Id"].ToString()),
                Descripcion = collection["Descripcion"],
                Tipo = collection["Tipo"],
                Precio = float.Parse(collection["Precio"].ToString())
            };
            rp.Alta(pro);
            return RedirectToAction("Index");
        }
        //Borrar de la base de Datos
        public ActionResult Baja(int cod)
        {
            RegistroProducto rp = new RegistroProducto();
            rp.Borrar(cod);
            return RedirectToAction("Index");
        }
        public ActionResult Modificacion(int cod)
        {
            RegistroProducto rp = new RegistroProducto();
            Producto pro = rp.Recuperar(cod);
            return View(pro);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            RegistroProducto rp = new RegistroProducto();
            Producto pro = new Producto
            {
                Id = int.Parse(collection["Id"].ToString()),
                Descripcion = collection["Descripcion"].ToString(),
                Tipo = collection["Tipo"].ToString(),
                Precio = float.Parse(collection["Precio"].ToString())
            };
            rp.Modificar(pro);
            return RedirectToAction("Index");
        }
    }
}