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
    public partial class Usuario : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM USUARIO"))
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

            int resultado = Clases.Usuario.Agregar(tnombre.Text, tcorreo.Text, ttelefono.Text);
            if (resultado > 0)
            {
                alertas("Usuario ha sido ingresado con exito");
                tnombre.Text = string.Empty;
                tcorreo.Text = string.Empty;
                ttelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Usuario");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Usuario.BorrarUsuario(int.Parse(tid.Text));

            if (resultado > 0)
            {
                alertas("Usuario borrado con éxito");
                tid.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar usuario");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int UsuarioID = int.Parse(tid.Text);
            string nombre = tnombre.Text;
            string email = tcorreo.Text;
            string telefono = ttelefono.Text;

            int resultado = Clases.Usuario.Modificar(UsuarioID, nombre, email, telefono);
            if (resultado > 0)
            {
                alertas("Usuario ha sido actualizado con éxito");
                tid.Text = string.Empty;
                tnombre.Text = string.Empty;
                tcorreo.Text = string.Empty;
                ttelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al actualizar Usuario");
            }


        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            int UsuarioID = int.Parse(txtFiltro.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM USUARIO WHERE UsuarioID ='" + UsuarioID + "'"))


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
