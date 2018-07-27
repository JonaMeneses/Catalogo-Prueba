using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CatalogoPrueba.Models;
using System.Web.Script.Serialization;
using System.Web.Http.Results;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;

namespace CatalogoPrueba.Controllers
{
    public class ClienteRestController : ApiController
    {
        Consultas consultas = new Consultas();

        // GET: api/ClienteRest
        public List<ClienteModel> GetAll()
        {
            return (consultas.GetAllClients());
        }

        // GET: api/ClienteRest/5
        public string Get(int id)
        {
           var json = JsonConvert.SerializeObject(consultas.BuscarClienteByID(id));
            return json;
        }

        // POST: api/ClienteRest
        public void Post([FromBody]ClienteModel cliente)
        {
            if (cliente != null){
                
                consultas.CreateCliente(cliente);
            }


        }

        // PUT: api/ClienteRest/5
        public string Put(int id, [FromBody]ClienteModel cliente)
        {
            if (consultas.BuscarClienteByID(id) == null)
            {
                return "No Existe el recurso "+id;
            }
            else
            {
                return (consultas.EditCliente(cliente));
            }
        }

        // DELETE: api/ClienteRest/5
        public string Delete(int id)
        {
            return (consultas.DeleteCliente(id));
        }
    }
}
