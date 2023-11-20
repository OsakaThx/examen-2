using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Examen2
{
    public partial class Tecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }

        }
        public void alertas(string texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TECNICOS"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Tecnico.AgregarTecnico(tnombre.Text, tespecialidad.Text);

            if (resultado > 0)
            {
                alertas("Tecnico ingresado con éxito");
                tnombre.Text = string.Empty;
                tespecialidad.Text = string.Empty;

                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Tecnico");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Tecnico.BorrarTecnico(int.Parse(tid.Text));

            if (resultado > 0)
            {
                alertas("Tecnico borrado con éxito");
                tid.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar Tecnico");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int UsuarioID = int.Parse(tid.Text);
            string nombre = tnombre.Text;
            string especialidad = tespecialidad.Text;


            int resultado = Clases.Tecnico.Modificar(UsuarioID, nombre, especialidad);
            if (resultado > 0)
            {
                alertas("Tecnico ha sido actualizado con éxito");
                tid.Text = string.Empty;
                tnombre.Text = string.Empty;
                tespecialidad.Text = string.Empty;

                LlenarGrid();
            }
            else
            {
                alertas("Error al actualizar Tecnico");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int TecnicoID = int.Parse(txtFiltro.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TECNICOS WHERE TecnicoID ='" + TecnicoID + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();
                    }

                }

            }

        }
    }
}