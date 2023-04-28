using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoIIProgra.Clases;
using System.Drawing;

namespace ProyectoIIProgra
{
    public partial class School : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM SCHOOL"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridSchool.DataSource = dt;
                            GridSchool.DataBind();
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
                using (SqlCommand cmd = new SqlCommand("SP_GetSchoolById"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SchoolId", int.Parse(TSchoolId.Text));

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridSchool.DataSource = dt;
                            GridSchool.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TSchoolName.Text) || string.IsNullOrWhiteSpace(TDescription.Text) || string.IsNullOrWhiteSpace(TAddress.Text) ||
        string.IsNullOrWhiteSpace(TPhone.Text) || string.IsNullOrWhiteSpace(TPostCode.Text) || string.IsNullOrWhiteSpace(TPostAddress.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Escuela.SchoolName = TSchoolName.Text;
            Escuela.Description = TDescription.Text;
            Escuela.Address = TAddress.Text;
            Escuela.Phone = TPhone.Text;
            Escuela.PostCode = TPostCode.Text;
            Escuela.PostAddress = TPostAddress.Text;

            if (Escuela.IngresarEscuela() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Escuela fue registrada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Escuela no fue registrada con éxito**");
            }
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TSchoolId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de escuela es requerido**");
                return;
            }

            Escuela.SchoolId = int.Parse(TSchoolId.Text);

            if (Escuela.BorrarEscuela() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Escuela fue borrada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Escuela no fue borrada con éxito**");
            }
        }

        protected void BConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TSchoolId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de escuela es requerido**");
                return;
            }

            Escuela.SchoolId = int.Parse(TSchoolId.Text);

            if (Escuela.ConsultarEscuela() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Escuela fue consultada con éxito**");
                filtroLlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Escuela no fue consultada con éxito**");
            }
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TSchoolId.Text) || string.IsNullOrWhiteSpace(TSchoolName.Text) || string.IsNullOrWhiteSpace(TDescription.Text) || string.IsNullOrWhiteSpace(TAddress.Text) ||
        string.IsNullOrWhiteSpace(TPhone.Text) || string.IsNullOrWhiteSpace(TPostCode.Text) || string.IsNullOrWhiteSpace(TPostAddress.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Escuela.SchoolId = int.Parse(TSchoolId.Text);
            Escuela.SchoolName = TSchoolName.Text;
            Escuela.Description = TDescription.Text;
            Escuela.Address = TAddress.Text;
            Escuela.Phone = TPhone.Text;
            Escuela.PostCode = TPostCode.Text;
            Escuela.PostAddress = TPostAddress.Text;

            if (Escuela.ModificarEscuela() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Escuela fue modificada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Escuela no fue modificada con éxito**");
            }
        }
    }
}