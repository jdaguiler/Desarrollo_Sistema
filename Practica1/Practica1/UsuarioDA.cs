using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class UsuarioDA
    {
        private string cadenaDeConexion;
        public UsuarioDA()
        {
            cadenaDeConexion = System.Configuration.ConfigurationSettings.AppSettings["MiProyecto"];
        }
        List<Usuario> listUsuario = new List<Usuario>();
        public List<Usuario> GetList()
        {
            
            Usuario l1 = new Usuario();
            l1.IdUsuario = 1;
            l1.NombreUsuario = "David";
            listUsuario.Add(l1);
            Usuario l2 = new Usuario();
            l2.IdUsuario = 2;
            l2.NombreUsuario = "Juan";
            listUsuario.Add(l2);
            return listUsuario;
        }
        public Usuario ValidaLogin(String NombreUsuario, string Clave)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.IdUsuario = 0;
            foreach (Usuario objList in listUsuario)
            {
                if (objList.NombreUsuario == NombreUsuario && objList.Clave == Clave)
                {
                    oUsuario.IdUsuario = objList.IdUsuario;
                    oUsuario.Salt = objList.Salt;

                }
                
            }
            return oUsuario;
        }
        public List<Usuario> GetList1()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            Usuario l;
            using (SqlConnection conn = new SqlConnection(cadenaDeConexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from trnUsuario; ", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        l = new Usuario();
                        l.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        l.NombreUsuario = Convert.ToString(reader["NombreUsuario"]);
                        l.Clave = Convert.ToString(reader["Clave"]);
                        listaUsuario.Add(l);
                    }

                }
            }
            return listUsuario;
        }
       

    }
}
