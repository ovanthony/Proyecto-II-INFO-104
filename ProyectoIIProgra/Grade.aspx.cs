using ProyectoIIProgra.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoIIProgra
{
    public partial class Grade : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM GRADE"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridGrade.DataSource = dt;
                            GridGrade.DataBind();
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
                using (SqlCommand cmd = new SqlCommand("SP_GetAllGrade"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GradeId", int.Parse(TGradeId.Text));

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridGrade.DataSource = dt;
                            GridGrade.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TStudentId.Text) || string.IsNullOrWhiteSpace(TCourseId.Text) || string.IsNullOrWhiteSpace(TGrade.Text) || string.IsNullOrWhiteSpace(TComment.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Notas.StudentId = int.Parse(TStudentId.Text);
            Notas.CourseId = int.Parse(TCourseId.Text);
            Notas.Grade = float.Parse(TGrade.Text);
            Notas.Comment = TComment.Text;

            if (Notas.AgregarNotas() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Nota fue agregada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "***Nota no fue agregada con éxito**");
            }
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TGradeId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de nota es requerido**");
                return;
            }

            Notas.GradeId = int.Parse(TGradeId.Text);

            if (Notas.BorrarNotas() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Nota fue borrada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Nota no fue borrada con éxito**");
            }
        }

        protected void BConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TGradeId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de nota es requerido**");
                return;
            }

            Notas.GradeId = int.Parse(TGradeId.Text);

            if (Notas.ConsultarNota() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Nota fue consultada con éxito**");
                filtroLlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Nota no fue consultada con éxito**");
            }
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TGradeId.Text) || string.IsNullOrWhiteSpace(TStudentId.Text) || string.IsNullOrWhiteSpace(TCourseId.Text) || string.IsNullOrWhiteSpace(TGrade.Text) || string.IsNullOrWhiteSpace(TComment.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Notas.GradeId = int.Parse(TGradeId.Text);
            Notas.StudentId = int.Parse(TStudentId.Text);
            Notas.CourseId = int.Parse(TCourseId.Text);
            Notas.Grade = float.Parse(TGrade.Text);
            Notas.Comment = TComment.Text;

            if (Notas.ModificarNotas() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Nota fue modificada con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "***Nota no fue modificada con éxito**");
            }
        }
    }
}