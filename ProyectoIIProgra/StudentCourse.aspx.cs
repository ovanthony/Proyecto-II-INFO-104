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
    public partial class StudentCourse : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM STUDENT_COURSE"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridStudentCourse.DataSource = dt;
                            GridStudentCourse.DataBind();
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
                using (SqlCommand cmd = new SqlCommand("SP_GetAllStudentCourse"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", int.Parse(TStudentId.Text));

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridStudentCourse.DataSource = dt;
                            GridStudentCourse.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TStudentId.Text) || string.IsNullOrWhiteSpace(TCourseId.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            CursoEstudiante.StudentId = int.Parse(TStudentId.Text);
            CursoEstudiante.CourseId = int.Parse(TCourseId.Text);

            if (CursoEstudiante.IngresarCursoEstudiante() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso de estudiante fue registrado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso de estudiante no fue registrado con éxito**");
            }
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TStudentId.Text) || string.IsNullOrWhiteSpace(TCourseId.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            CursoEstudiante.StudentId = int.Parse(TStudentId.Text);
            CursoEstudiante.CourseId = int.Parse(TCourseId.Text);

            if (CursoEstudiante.BorrarCursoEstudiante() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso de estudiante fue borrado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso de estudiante no fue borrado con éxito**");
            }
        }

        protected void BConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TStudentId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de estudiante es requerido**");
                return;
            }

            CursoEstudiante.StudentId = int.Parse(TStudentId.Text);

            if (CursoEstudiante.ConsultarCursoEstudiante() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso de estudiante fue consultado con éxito**");
                filtroLlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso de estudiante no fue consultado con éxito**");
            }
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TStudentId.Text) || string.IsNullOrWhiteSpace(TCourseId.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            CursoEstudiante.StudentId = int.Parse(TStudentId.Text);
            CursoEstudiante.CourseId = int.Parse(TCourseId.Text);

            if (CursoEstudiante.ModificarCursoEstudiante() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso de estudiante fue modificado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso de estudiante no fue modificado con éxito**");
            }
        }
    }
}