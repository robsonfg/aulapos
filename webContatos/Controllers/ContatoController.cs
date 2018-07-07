using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webContatos.Controllers
{
    public class ContatoController : Controller
    {
        private SqlConnection conn = new SqlConnection("Server=tcp:bdposrb.database.windows.net,1433;Initial Catalog=aulapos;Persist Security Info=False;User ID={robson};Password={270964Rb};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        // GET: Contato
        public List<Contato> Get()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM CONTATO FRO JSON auto";
            SqlDataReader reader = cmd.ExecuteReader();
            var lista = new List<Contato>();

            while (reader.Read())
            {
                Contato c = new Contato
                {
                    Nome = (string)reader["Nome"],
                    Email = (string)reader["Email"]
                };
                lista.Add(c);
            }

            
            return lista;
        }

        public class Contato
        {
            public int ContatoId { get; set; }
            public String Nome { get; set; }
            public String Email { get; set; }
        }

    }
}