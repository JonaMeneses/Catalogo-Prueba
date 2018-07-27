using CatalogoPrueba.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatalogoPrueba.Controllers
{
    public class ContactoController : Controller
    {
        Consultas consultas = new Consultas();

        // GET: contacto
        public ActionResult ListaContactos(string nombre,string apellido)
        {
            if (nombre == null && apellido == null)
            {
                return View(consultas.GetAllContacts());
            }
            else
            {
                if (nombre == null) nombre = string.Empty;
                if (apellido == null) apellido = string.Empty;

                return View(consultas.GetContactoByLike(nombre,apellido));

            }
          }

            

            
        

        // GET: contacto
        public ActionResult ListaContactosByID(int id)
        {

            
            return View(consultas.GetContactsByID(id));
        }



        // GET: Contacto/Create
        public ActionResult Create()
        {
          
            return View();

        }

        //POST: Contacto/Create
        [HttpPost]
        public ActionResult Create(ContactoModel contacto)
        {
           if (consultas.CreateContacto(contacto)=="OK")
                return RedirectToAction("ListaContactos", "Contacto");
           else           
                return View();
            
        }

        // GET: Contacto/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(consultas.GetContactByID(id));
        }

        // POST: Contacto/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, ContactoModel contacto)
        {

        if(consultas.EditContacto(contacto) == "OK")
            return RedirectToAction("listaContactos");
            else
                return View();

            
        }

        // GET: Contacto/Delete/5
        public ActionResult Delete(int id)
        {
            consultas.DeleteContacto(id);
            return RedirectToAction("ListaContactos");
        }
    }
}