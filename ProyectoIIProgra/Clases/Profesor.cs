using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoIIProgra.Clases
{
    public class Profesor
    {
        public Profesor() { }
        public static int TeacherId { set; get; }
        public static int SchoolId { set; get; }
        public static string TeacherName { set; get; }
        public static string Description { set; get; }

        //Agregar Profesor
        public static int AgregarProfesor()
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_AddTeacher", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@SchoolId", SchoolId));
                    cmd.Parameters.Add(new SqlParameter("@TeacherName", TeacherName));
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

        //Borrar Profesor
        public static int BorrarProfesor()
        {

            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteTeacher", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@TeacherId", TeacherId));

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

        //Consultar Profesor
        public static int ConsultarProfesor()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetTeacherById", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@TeacherId", TeacherId));

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

        //Modificar Profesor
        public static int ModificarProfesor()
        {

            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateTeacher", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@TeacherId", TeacherId));
                    cmd.Parameters.Add(new SqlParameter("@SchoolId", SchoolId));
                    cmd.Parameters.Add(new SqlParameter("@TeacherName", TeacherName));
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