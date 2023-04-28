using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices.Internal;
using ProyectoIIProgra.Clases;
using System.Net;

namespace ProyectoIIProgra
{
    public partial class Class : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["UHProyecto"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CLASS"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridClass.DataSource = dt;
                            GridClass.DataBind();
                        }
                    }
                }
            }
        }

        protected void filtroLlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["UHProyecto"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetClassById"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClassId", int.Parse(TClassId.Text));

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridClass.DataSource = dt;
                            GridClass.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TSchoolId.Text) || string.IsNullOrWhiteSpace(TClassName.Text) || string.IsNullOrWhiteSpace(TDescription.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Clase.SchoolId = int.Parse(TSchoolId.Text);
            Clase.ClassName = TClassName.Text;
            Clase.Description = TDescription.Text;

            if (Clase.IngresarClase() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Clase fue registrada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Clase no fue registrada con éxito**");
            }
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TClassId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de clase es requerido**");
                return;
            }

            Clase.ClassId = int.Parse(TClassId.Text);

            if (Clase.BorrarClase() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Clase fue borrada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Clase no fue borrada con éxito**");
            }
        }

        protected void BConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TClassId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de clase es requerido**");
                return;
            }

            Clase.ClassId = int.Parse(TClassId.Text);

            if (Clase.ConsultarClase() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Clase fue consultada con éxito**");
                filtroLlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Clase no fue consultada con éxito**");
            }
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TClassId.Text) || string.IsNullOrWhiteSpace(TSchoolId.Text) || string.IsNullOrWhiteSpace(TClassName.Text) || string.IsNullOrWhiteSpace(TDescription.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Clase.ClassId = int.Parse(TClassId.Text);
            Clase.SchoolId = int.Parse(TSchoolId.Text);
            Clase.ClassName = TClassName.Text;
            Clase.Description = TDescription.Text;

            if (Clase.ModificarClase() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Clase fue modificada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Clase no fue modificada con éxito**");
            }
        }
    }
}