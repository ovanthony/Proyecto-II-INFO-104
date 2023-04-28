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
    public partial class Student : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM STUDENT"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridStudent.DataSource = dt;
                            GridStudent.DataBind();
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
                using (SqlCommand cmd = new SqlCommand("SP_GetStudentById"))
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
                            GridStudent.DataSource = dt;
                            GridStudent.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TClassId.Text) || string.IsNullOrWhiteSpace(TStudentName.Text) || string.IsNullOrWhiteSpace(TStudentNumber.Text) ||
                string.IsNullOrWhiteSpace(TTotalGrade.Text) || string.IsNullOrWhiteSpace(TAddress.Text) || string.IsNullOrWhiteSpace(TPhone.Text) || string.IsNullOrWhiteSpace(TEMail.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Estudiante.ClassId = int.Parse(TClassId.Text);
            Estudiante.StudentName = TStudentName.Text;
            Estudiante.StudentNumber = TStudentNumber.Text;
            Estudiante.TotalGrade = float.Parse(TTotalGrade.Text);
            Estudiante.Address = TAddress.Text;
            Estudiante.Phone = TPhone.Text;
            Estudiante.EMail = TEMail.Text;

            if (Estudiante.AgregarEstudiante() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Estudiante fue agregado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Estudiante no fue agregado con éxito**");
            }
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TStudentId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de estudiante es requerido**");
                return;
            }

            Estudiante.StudentId = int.Parse(TStudentId.Text);

            if (Estudiante.BorrarEstudiante() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Estudiante fue borrado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Estudiante no fue borrado con éxito**");
            }
        }

        protected void BConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TStudentId.Text))
            {
                DBConn.RegistrarAlerta(this, "**El código de estudiante es requerido**");
                return;
            }

            Estudiante.StudentId = int.Parse(TStudentId.Text);

            if (Estudiante.ConsultarEstudiante() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Estudiante fue consultado con éxito**");
                filtroLlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Estudiante no fue consultado con éxito**");
            }
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TStudentId.Text) || string.IsNullOrWhiteSpace(TClassId.Text) || string.IsNullOrWhiteSpace(TStudentName.Text) || string.IsNullOrWhiteSpace(TStudentNumber.Text) || 
                string.IsNullOrWhiteSpace(TTotalGrade.Text) || string.IsNullOrWhiteSpace(TAddress.Text) || string.IsNullOrWhiteSpace(TPhone.Text) || string.IsNullOrWhiteSpace(TEMail.Text))
            {
                DBConn.RegistrarAlerta(this, "**Ingrese todos los campos requeridos**");
                return;
            }

            Estudiante.StudentId = int.Parse(TStudentId.Text);
            Estudiante.ClassId = int.Parse(TClassId.Text);
            Estudiante.StudentName = TStudentName.Text;
            Estudiante.StudentNumber = TStudentNumber.Text;
            Estudiante.TotalGrade = float.Parse(TTotalGrade.Text);
            Estudiante.Address = TAddress.Text;
            Estudiante.Phone = TPhone.Text;
            Estudiante.EMail = TEMail.Text;

            if (Estudiante.ModificarEstudiante() > 0)
            {
                DBConn.RegistrarAlerta(this, "**Estudiante fue modificado con éxito**");
                LlenarGrid();
            }
            else
            {
                DBConn.RegistrarAlerta(this, "**Estudiante no fue modificado con éxito**");
            }
        }
    }
}