using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace CatalogoPrueba.Models
{
    
    public class Consultas
    {
        List<ClienteModel> CLIENTESLIST = new List<ClienteModel>();
        ClienteModel CLIENTE = new ClienteModel();

        List<ContactoModel> CONTACTOLIST = new List<ContactoModel>();
        ContactoModel CONTACTO = new ContactoModel();
        string CadenaConexion = @"Data Source = DESKTOP-DF840SR\SQLEXPRESS;" +
            "initial Catalog=Catalogo; Integrated Security=true";

        public List<ClienteModel> GetAllClients() {

            using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand("Listar_clientes", sqlcon);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    var c = new ClienteModel();
                    c._id = Convert.ToInt32(dr["_id"]);
                    c.Razon_social = dr["Razon_Social"].ToString();
                    c.Nombre_comercial = dr["Nombre_comercial"].ToString();
                    c.RFC = dr["RFC"].ToString();
                    c.CURP = dr["CURP"].ToString();
                    c.direccion = dr["direccion"].ToString();

                    CLIENTESLIST.Add(c);

                }
                sqlcon.Close(); ;
            }
            return CLIENTESLIST;
        }

        public List<ClienteModel> GetClientesByLike(string razon,string rfc)
        {

            using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand("Buscar_cliente", sqlcon);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@razon", razon);
                command.Parameters.AddWithValue("@rfc", rfc);
                SqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    var c = new ClienteModel();
                    c._id = Convert.ToInt32(dr["_id"]);
                    c.Razon_social = dr["Razon_Social"].ToString();
                    c.Nombre_comercial = dr["Nombre_comercial"].ToString();
                    c.RFC = dr["RFC"].ToString();
                    c.CURP = dr["CURP"].ToString();
                    c.direccion = dr["direccion"].ToString();

                   CLIENTESLIST.Add(c);

                }
                sqlcon.Close(); ;
            }
            return CLIENTESLIST;
        }

        public ClienteModel BuscarClienteByID(int? id)
        {
            using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand("Buscar_cliente_id", sqlcon);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {

                    CLIENTE._id = Convert.ToInt32(dr["_id"]);
                    CLIENTE.Razon_social = dr["Razon_Social"].ToString();
                    CLIENTE.Nombre_comercial = dr["Nombre_comercial"].ToString();
                    CLIENTE.RFC = dr["RFC"].ToString();
                    CLIENTE.CURP = dr["CURP"].ToString();
                    CLIENTE.direccion = dr["direccion"].ToString();

                    CLIENTESLIST.Add(CLIENTE);

                }
                
                sqlcon.Close();
            }

            return CLIENTE;
        }

        public string CreateCliente(ClienteModel cliente)
        {
            string estado = string.Empty;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand command = new SqlCommand("Insertar_cliente", sqlcon);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", cliente._id);
                    command.Parameters.AddWithValue("@razon", cliente.Razon_social);
                    command.Parameters.AddWithValue("@nombre", cliente.Nombre_comercial);
                    command.Parameters.AddWithValue("@RFC", cliente.RFC);
                    command.Parameters.AddWithValue("@CURP", cliente.CURP);
                    command.Parameters.AddWithValue("@direccion", cliente.direccion);

                    command.ExecuteNonQuery();
                    sqlcon.Close();
                }
                estado = "OK";
            }
            catch
            {
                estado = "ERROR";
            }

            return estado;
        }

        public string EditCliente(ClienteModel cliente)
        {
            string estado = string.Empty;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand command = new SqlCommand("Actualizar_cliente", sqlcon);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", cliente._id);
                    command.Parameters.AddWithValue("@razon", cliente.Razon_social);
                    command.Parameters.AddWithValue("@nombre", cliente.Nombre_comercial);
                    command.Parameters.AddWithValue("@RFC", cliente.RFC);
                    command.Parameters.AddWithValue("@CURP", cliente.CURP);
                    command.Parameters.AddWithValue("@direccion", cliente.direccion);

                    command.ExecuteNonQuery();
                    sqlcon.Close();
                }
                estado = "OK";
            }
            catch
            {
                estado = "ERROR";
            }
            return estado;
            }

        public string DeleteCliente(int id)
        {
            string estado = string.Empty;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand command = new SqlCommand("Eliminar_cliente", sqlcon);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    sqlcon.Close();
                }
                estado = "OK";
            }
            catch
            {
                estado = "ERROR";
            }

            return estado;
        }

        public List<ContactoModel> GetAllContacts()
        {
            using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand("Listar_contactos", sqlcon);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {

                    var c = new ContactoModel();
                    c._id = Convert.ToInt32(dr["_id"]);
                    c.Nombre = dr["Nombre"].ToString();
                    c.Apellido_paterno = dr["Apellido_paterno"].ToString();
                    c.Apellido_materno = dr["Apellido_materno"].ToString();
                    c.Telefono = dr["Telefono"].ToString();
                    c.id_cliente = Convert.ToInt32(dr["id_cliente"]);


                    CONTACTOLIST.Add(c);

                }
                sqlcon.Close(); ;
            }

            return CONTACTOLIST;
        }

        public List<ContactoModel> GetContactoByLike(string nombre, string apellido)
        {

            using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
            {
                    sqlcon.Open();
                    SqlCommand command = new SqlCommand("Buscar_contacto", sqlcon);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    SqlDataReader dr = command.ExecuteReader();


                    while (dr.Read())
                    {
                        var c = new ContactoModel();
                        c._id = Convert.ToInt32(dr["_id"]);
                        c.Nombre = dr["Nombre"].ToString();
                        c.Apellido_paterno = dr["Apellido_paterno"].ToString();
                        c.Apellido_materno = dr["Apellido_materno"].ToString();
                        c.Telefono = dr["Telefono"].ToString();
                        c.id_cliente = Convert.ToInt32(dr["id_cliente"]);

                        CONTACTOLIST.Add(c);

                    }
                
                sqlcon.Close(); ;
            }
            return CONTACTOLIST;
        }

        public List<ContactoModel> GetContactsByID(int id)
        {
            using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand("Listar_contactos_idcliente", sqlcon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {

                    var c = new ContactoModel();
                    c._id = Convert.ToInt32(dr["_id"]);
                    c.Nombre = dr["Nombre"].ToString();
                    c.Apellido_paterno = dr["Apellido_paterno"].ToString();
                    c.Apellido_materno = dr["Apellido_materno"].ToString();
                    c.Telefono = dr["Telefono"].ToString();



                    CONTACTOLIST.Add(c);

                }
                sqlcon.Close(); ;
            }

            return CONTACTOLIST;
        }


        public string CreateContacto(ContactoModel contacto)
        {
            string estado = string.Empty;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand command = new SqlCommand("Insertar_contacto", sqlcon);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", contacto._id);
                    command.Parameters.AddWithValue("@nombre", contacto.Nombre);
                    command.Parameters.AddWithValue("@paterno", contacto.Apellido_paterno);
                    command.Parameters.AddWithValue("@materno", contacto.Apellido_materno);
                    command.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    command.Parameters.AddWithValue("@id_cliente", contacto.id_cliente);

                    command.ExecuteNonQuery();
                    sqlcon.Close();
                }

                estado = "OK";
            }
            catch (Exception e)
            {
                estado = "ERROR";
            }
            return estado;
        }

        public ContactoModel GetContactByID(int? id)
        {
            using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand("Buscar_contacto_id", sqlcon);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = command.ExecuteReader();


                while (dr.Read())
                {
                    var c = new ContactoModel();
                    CONTACTO._id = Convert.ToInt32(dr["_id"]);
                    CONTACTO.Nombre = dr["Nombre"].ToString();
                    CONTACTO.Apellido_paterno = dr["Apellido_paterno"].ToString();
                    CONTACTO.Apellido_materno = dr["Apellido_materno"].ToString();
                    CONTACTO.Telefono = dr["Telefono"].ToString();


                    CONTACTOLIST.Add(c);

                }

                sqlcon.Close();
            }

            return CONTACTO;
        }


        public string EditContacto(ContactoModel contacto)
        {
            string estado = string.Empty;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand command = new SqlCommand("Actualizar_contacto", sqlcon);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", contacto._id);
                    command.Parameters.AddWithValue("@nombre", contacto.Nombre);
                    command.Parameters.AddWithValue("@paterno", contacto.Apellido_paterno);
                    command.Parameters.AddWithValue("@materno", contacto.Apellido_materno);
                    command.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    command.Parameters.AddWithValue("@id_cliente", contacto.id_cliente);


                    command.ExecuteNonQuery();
                    sqlcon.Close();
                }
                estado = "OK";
            }
            catch
            {
                estado = "ERROR";
            }
            return estado;
        }

        public string DeleteContacto(int id)
        {
            string estado = string.Empty;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand command = new SqlCommand("Eliminar_contacto", sqlcon);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    sqlcon.Close();
                }
                estado = "OK";
            }
            catch
            {
                estado = "ERROR";
            }

            return estado;
        }

    }
}