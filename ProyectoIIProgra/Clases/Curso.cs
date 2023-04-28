using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoIIProgra.Clases
{
    public class Curso
    {

        public Curso() { }
        public static int CourseId { set; get; }
        public static int SchoolId { set; get; }
        public static string CourseName { set; get; }
        public static string Description { set; get; }

        //Agregar Curso
        public static int AgregarCurso()
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_AddCourse", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@CourseName", CourseName));
                    cmd.Parameters.Add(new SqlParameter("@SchoolId", SchoolId));
                    cmd.Parameters.Add(new SqlParameter("@Description", Description));


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

        //Borrar Curso
        public static int BorrarCurso()
        {

            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteCourse", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@CourseId", CourseId));

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

        //Consultar Curso
        public static int ConsultarCurso()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetCourseById", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@CourseId", CourseId));

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

        //Modificar Curso
        public static int ModificarCurso()
        {

            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateCourse", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@CourseId", CourseId));
                    cmd.Parameters.Add(new SqlParameter("@CourseName", CourseName));
                    cmd.Parameters.Add(new SqlParameter("@SchoolId", SchoolId));
                    cmd.Parameters.Add(new SqlParameter("@Description", Description));



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