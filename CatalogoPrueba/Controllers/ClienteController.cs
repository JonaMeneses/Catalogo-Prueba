using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using CatalogoPrueba.Models;


namespace CatalogoPrueba.Controllers
{
    public class ClienteController : Controller
    {
        
        Consultas consultas = new Consultas();
   
        // GET: Cliente
        public ActionResult Index(string razon, string rfc)
        {
            if (razon == null && rfc == null)
            {
                return View(consultas.GetAllClients());
            }
            else
            {
                if (razon == null) razon = string.Empty;
                if (rfc == null) rfc = string.Empty;
                
                return View(consultas.GetClientesByLike(razon, rfc));
            }

            
            
        }

        public void PruebaGIT()
        {

        }
       
        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Cliente/Create
       [HttpPost]
        public ActionResult Create(ClienteModel cliente)
        {
            if(consultas.CreateCliente(cliente)=="OK")
                return RedirectToAction("Index");
            else
                return View();
            
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
          
            return View(consultas.BuscarClienteByID(id));
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id,ClienteModel cliente)
        {

            if(consultas.EditCliente(cliente)=="OK")
                return RedirectToAction("Index");
                   else
                return View();
                   
}

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            consultas.DeleteCliente(id);
            return RedirectToAction("Index");


        }

          

    }
}
