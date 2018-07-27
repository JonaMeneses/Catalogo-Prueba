using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CatalogoPrueba.Models;

namespace CatalogoPrueba.Controllers
{
    
    public class ContactoRestController : ApiController
    {
        Consultas consultas = new Consultas();

        public List<ContactoModel> GetAll()
        {
            return (consultas.GetAllContacts());
        }

        // GET: api/ClienteRest/5
        public ContactoModel Get(int id)
        {

            return consultas.GetContactByID(id);
        }

        // POST: api/ClienteRest
        public void Post([FromBody]ContactoModel contacto)
        {
            if (contacto!= null)
            {

                consultas.CreateContacto(contacto);
            }


        }

        // PUT: api/ClienteRest/5
        public string Put(int id, [FromBody]ContactoModel contacto)
        {
            if (consultas.GetContactByID(id) == null)
            {
                return "No Existe el recurso " + id;
            }
            else
            {
                return (consultas.EditContacto(contacto));
            }
        }

        // DELETE: api/ClienteRest/5
        public string Delete(int id)
        {
            return (consultas.DeleteContacto(id));
        }
    }
}

