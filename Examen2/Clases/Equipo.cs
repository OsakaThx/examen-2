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
    public class Equipo
    {
        public int EquipoID { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }
        public int UsuarioID { get; set; }

        public Equipo(int equipoID, string tipoEquipo, string modelo, int usuarioID)
        {
            EquipoID = equipoID;
            TipoEquipo = tipoEquipo;
            Modelo = modelo;
            UsuarioID = usuarioID;

        }

        public Equipo() { }

        public static int AgregarEquipo(string TipoEquipo, string Modelo, string UsuarioID)
        {
            int retorno = 0;

            using (SqlConnection conn = DBConn.obtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AgregarEquipo", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", SqlDbType.VarChar, 50) { Value = TipoEquipo });
                    cmd.Parameters.Add(new SqlParameter("@Modelo", SqlDbType.VarChar, 50) { Value = Modelo });
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", SqlDbType.Int) { Value = Convert.ToInt32(UsuarioID) });

                    retorno = cmd.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {

                    retorno = -1;
                }
            }

            return retorno;
        }


        public static int BorrarEquipo(int id)
        {
            int retorno = 0;

            using (SqlConnection conn = DBConn.obtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("BorrarEquipo", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EquipoID", id));

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
        public static int Modificar(int EquipoID, string TipoEquipo, string Modelo, int UsuarioID)
        {
            int retorno = 0;

            using (SqlConnection conn = DBConn.obtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ModificarEquipo", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EquipoID", EquipoID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", SqlDbType.VarChar, 50) { Value = TipoEquipo });
                    cmd.Parameters.Add(new SqlParameter("@Modelo", SqlDbType.VarChar, 50) { Value = Modelo });
                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", UsuarioID));

                    retorno = cmd.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {

                    retorno = -1;
                }

            }
            return retorno;
        }
        public static List<Equipo> ConsultarEquipoConFiltro(int EquipoID)
        {
            List<Equipo> tipos = new List<Equipo>();

            using (SqlConnection conn = DBConn.obtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ConsultarEquipoConFiltro", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EquipoID", EquipoID));

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Equipo tipo = new Equipo
                            {
                                EquipoID = reader.GetInt32(0),
                                TipoEquipo = reader.GetString(1),

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

        public static List<Equipo> ObtenerTipos()
        {
            List<Equipo> tipos = new List<Equipo>();

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
                            Equipo tipo = new Equipo
                            {
                                EquipoID = reader.GetInt32(0),
                                TipoEquipo = reader.GetString(1),

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


