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
using System.Net;

namespace ProyectoIIProgra
{
    public partial class Course : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM COURSE"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridCourse.DataSource = dt;
                            GridCourse.DataBind();
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
                using (SqlCommand cmd = new SqlCommand("SP_GetCourseById"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseId", int.Parse(TCourseId.Text));

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridCourse.DataSource = dt;
                            GridCourse.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TSchoolId.Text) || string.IsNullOrWhiteSpace(TCourseName.Text) || string.IsNullOrWhiteSpace(TDescription.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Curso.SchoolId = int.Parse(TSchoolId.Text);
            Curso.CourseName = TCourseName.Text;
            Curso.Description = TDescription.Text;

            if (Curso.AgregarCurso() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso fue agregado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso no fue agregado con éxito**");
            }
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TCourseId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de curso es requerido**");
                return;
            }

            Curso.CourseId = int.Parse(TCourseId.Text);

            if (Curso.BorrarCurso() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso fue borrado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso no fue borrado con éxito**");
            }
        }

        protected void BConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TCourseId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de curso es requerido**");
                return;
            }

            Curso.CourseId = int.Parse(TCourseId.Text);

            if (Curso.ConsultarCurso() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso fue consultado con éxito**");
                filtroLlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso no fue consultado con éxito**");
            }
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TCourseId.Text) || string.IsNullOrWhiteSpace(TSchoolId.Text) || string.IsNullOrWhiteSpace(TCourseName.Text) || string.IsNullOrWhiteSpace(TDescription.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Curso.CourseId = int.Parse(TCourseId.Text);
            Curso.SchoolId = int.Parse(TSchoolId.Text);
            Curso.CourseName = TCourseName.Text;
            Curso.Description = TDescription.Text;

            if (Curso.ModificarCurso() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso fue modificado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso no fue modificado con éxito**");
            }
        }
    }
}