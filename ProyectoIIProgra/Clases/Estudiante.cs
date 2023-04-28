using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Security.Policy;

namespace ProyectoIIProgra.Clases
{
    public class Estudiante
    {

        public Estudiante() { }
        public static int StudentId { set; get; }
        public static int ClassId { set; get; }
        public static string StudentName { set; get; }
        public static string StudentNumber { set; get; }
        public static float TotalGrade { set; get; }
        public static string Address { set; get; }
        public static string Phone { set; get; }
        public static string EMail { set; get; }

        //Agregar Estudiante
        public static int AgregarEstudiante()
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_AddStudent", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ClassId", ClassId));
                    cmd.Parameters.Add(new SqlParameter("@StudentName", StudentName));
                    cmd.Parameters.Add(new SqlParameter("@StudentNumber", StudentNumber));
                    cmd.Parameters.Add(new SqlParameter("@TotalGrade", TotalGrade));
                    cmd.Parameters.Add(new SqlParameter("@Address", Address));
                    cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
                    cmd.Parameters.Add(new SqlParameter("@EMail", EMail));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return retorno;
        }

        //Borrar Estudiante
        public static int BorrarEstudiante()
        {

            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteStudent", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@StudentId", StudentId));

                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return retorno;

        }

        //Consultar Estudiante
        public static int ConsultarEstudiante()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetStudentById", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@StudentId", StudentId));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            retorno = 1;
                        }
                    }

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;

        }

        //Modificar Estudiante
        public static int ModificarEstudiante()
        {

            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateStudent", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@StudentId", StudentId));
                    cmd.Parameters.Add(new SqlParameter("@ClassId", ClassId));
                    cmd.Parameters.Add(new SqlParameter("@StudentName", StudentName));
                    cmd.Parameters.Add(new SqlParameter("@StudentNumber", StudentNumber));
                    cmd.Parameters.Add(new SqlParameter("@TotalGrade", TotalGrade));
                    cmd.Parameters.Add(new SqlParameter("@Address", Address));
                    cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
                    cmd.Parameters.Add(new SqlParameter("@EMail", EMail));

                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return retorno;
        }

    }
}