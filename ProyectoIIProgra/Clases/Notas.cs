using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoIIProgra.Clases
{
    public class Notas
    {

        public Notas() { }
        public static int GradeId { set; get; }
        public static int StudentId { set; get; }
        public static int CourseId { set; get; }
        public static float Grade { set; get; }
        public static string Comment { set; get; }

        //Agregar Notas
        public static int AgregarNotas()
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_AddGrade", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@StudentId", StudentId));
                    cmd.Parameters.Add(new SqlParameter("@CourseId", CourseId));
                    cmd.Parameters.Add(new SqlParameter("@Grade", Grade));
                    cmd.Parameters.Add(new SqlParameter("@Comment", Comment));


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

        //Borrar Notas
        public static int BorrarNotas()
        {

            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteGrade", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@GradeId", GradeId));

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

        //Consultar Notas
        public static int ConsultarNota()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllGrade", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@GradeId", GradeId));

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

        //Modificar Notas
        public static int ModificarNotas()
        {

            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateGrade", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@GradeId", CourseId));
                    cmd.Parameters.Add(new SqlParameter("@StudentId", StudentId));
                    cmd.Parameters.Add(new SqlParameter("@CourseId", CourseId));
                    cmd.Parameters.Add(new SqlParameter("@Grade", Grade));
                    cmd.Parameters.Add(new SqlParameter("@Comment", Comment));

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