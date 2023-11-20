using Examen2.clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Examen2.Clases
{
    public class Tecnico
    {
        public int TecnicoID { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        public Tecnico(int tecnicoID, string nombre, string especialidad)
        {
            TecnicoID = tecnicoID;
            Nombre = nombre;
            Especialidad = especialidad;

        }

        public Tecnico() { }

        public static int AgregarTecnico(string Nombre, string Especialidad)
        {
            int retorno = 0;

            using (SqlConnection conn = DBConn.obtenerConexion())
            {
                try
                {


                    SqlCommand cmd = new SqlCommand("AgregarTecnico", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50) { Value = Nombre });
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", SqlDbType.VarChar, 50) { Value = Especialidad });

                    retorno = cmd.ExecuteNonQuery();
                }

                catch (System.Data.SqlClient.SqlException ex)
                {
                    retorno = -1;
                }
                finally
                {
                    conn.Close();
                }

                return retorno;
            }
        }

        public static int BorrarTecnico(int id)
        {
            int retorno = 0;

            using (SqlConnection conn = DBConn.obtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("BorrarTecnico", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TecnicoID", id));

                    retorno = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    retorno = -1;
                    Console.WriteLine("Error SQL: " + ex.Message);
                }
            }

            return retorno;
        }
        public static int Modificar(int TecnicoID, string Nombre, string Especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarTecnico", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("TecnicoID", TecnicoID));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 50) { Value = Nombre });
                    cmd.Parameters.Add(new SqlParameter("@Especialidad", SqlDbType.VarChar, 50) { Value = Especialidad });

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }
        public static List<Tecnico> ConsultarEquipoConFiltro(int TecnicoID)
        {
            List<Tecnico> tipos = new List<Tecnico>();

            using (SqlConnection conn = DBConn.obtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ConsultarEquipoConFiltro", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TecnicooID", TecnicoID));

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tecnico tipo = new Tecnico
                            {
                                TecnicoID = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Especialidad = reader.GetString(2),

                            };

                            tipos.Add(tipo);
                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {

                }
            }

            return tipos;
        }

        public static List<Tecnico> ObtenerTipos()
        {
            List<Tecnico> tipos = new List<Tecnico>();

            using (SqlConnection conn = DBConn.obtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ConsultarEquipoConFiltro", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tecnico tipo = new Tecnico
                            {
                                TecnicoID = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Especialidad = reader.GetString(2),
                            };

                            tipos.Add(tipo);
                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {

                }
            }

            return tipos;
        }

    }
}