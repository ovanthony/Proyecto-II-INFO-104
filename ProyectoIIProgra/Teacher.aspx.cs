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

namespace ProyectoIIProgra
{
    public partial class Teacher : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TEACHER"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridTeacher.DataSource = dt;
                            GridTeacher.DataBind();
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
                using (SqlCommand cmd = new SqlCommand("SP_GetTeacherById"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeacherId", int.Parse(TTeacherId.Text));

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridTeacher.DataSource = dt;
                            GridTeacher.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TSchoolId.Text) || string.IsNullOrWhiteSpace(TTeacherName.Text) || string.IsNullOrWhiteSpace(TDescription.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Profesor.SchoolId = int.Parse(TSchoolId.Text);
            Profesor.TeacherName = TTeacherName.Text;
            Profesor.Description = TDescription.Text;

            if (Profesor.AgregarProfesor() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Profesor fue agregado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Profesor no fue agregado con éxito**");
            }
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TTeacherId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de profesor es requerido**");
                return;
            }

            Profesor.TeacherId = int.Parse(TTeacherId.Text);

            if (Profesor.BorrarProfesor() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Profesor fue borrado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Profesor no fue borrado con éxito**");
            }
        }

        protected void BConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TTeacherId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de profesor es requerido**");
                return;
            }

            Profesor.TeacherId = int.Parse(TTeacherId.Text);

            if (Profesor.ConsultarProfesor() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Profesor fue consultado con éxito**");
                filtroLlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Profesor no fue consultado con éxito**");
            }
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TTeacherId.Text) || string.IsNullOrWhiteSpace(TSchoolId.Text) || string.IsNullOrWhiteSpace(TTeacherName.Text) || string.IsNullOrWhiteSpace(TDescription.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Profesor.TeacherId = int.Parse(TTeacherId.Text);
            Profesor.SchoolId = int.Parse(TSchoolId.Text);
            Profesor.TeacherName = TTeacherName.Text;
            Profesor.Description = TDescription.Text;

            if (Profesor.ModificarProfesor() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Profesor fue modificado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Profesor no fue modificado con éxito**");
            }
        }

    }
}