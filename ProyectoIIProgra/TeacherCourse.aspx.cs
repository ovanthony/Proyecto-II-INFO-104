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
    public partial class TeacherCourse : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TEACHER_COURSE"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridTeacherCourse.DataSource = dt;
                            GridTeacherCourse.DataBind();
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
                using (SqlCommand cmd = new SqlCommand("SP_GetAllTeacherCourse"))
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
                            GridTeacherCourse.DataSource = dt;
                            GridTeacherCourse.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TTeacherId.Text) || string.IsNullOrWhiteSpace(TCourseId.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            CursoProfesor.TeacherId = int.Parse(TTeacherId.Text);
            CursoProfesor.CourseId = int.Parse(TCourseId.Text);

            if (CursoProfesor.IngresarCursoProfesor() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso de profesor fue registrado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso de profesor no fue registrado con éxito**");
            }
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TTeacherId.Text) || string.IsNullOrWhiteSpace(TCourseId.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            CursoProfesor.TeacherId = int.Parse(TTeacherId.Text);
            CursoProfesor.CourseId = int.Parse(TCourseId.Text);

            if (CursoProfesor.BorrarCursoProfesor() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso de profesor fue borrado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso de profesor no fue borrado con éxito**");
            }
        }

        protected void BConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TTeacherId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de profesor es requerido**");
                return;
            }

            CursoProfesor.TeacherId = int.Parse(TTeacherId.Text);

            if (CursoProfesor.ConsultarCursoProfesor() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso de profesor fue consultado con éxito**");
                filtroLlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso de profesor no fue consultado con éxito**");
            }
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TTeacherId.Text) || string.IsNullOrWhiteSpace(TCourseId.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            CursoProfesor.TeacherId = int.Parse(TTeacherId.Text);
            CursoProfesor.CourseId = int.Parse(TCourseId.Text);

            if (CursoProfesor.ModificarCursoProfesor() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Curso de profesor fue modificado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Curso de profesor no fue modificado con éxito**");
            }
        }
    }
}