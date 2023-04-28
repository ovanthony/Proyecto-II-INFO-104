using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;

namespace ProyectoIIProgra.Clases
{
    public class Escuela
    {
        public Escuela() { }
        public static int SchoolId { set; get; }
        public static string SchoolName { set; get; }
        public static string Description { set; get; }
        public static string Address { set; get; }
        public static string Phone { set; get; }
        public static string PostCode { set; get; }
        public static string PostAddress { set; get; }

        //Ingresar Escuela
        public static int IngresarEscuela()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_AddSchool", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@SchoolName", SchoolName));
                    cmd.Parameters.Add(new SqlParameter("@Description", Description));
                    cmd.Parameters.Add(new SqlParameter("@Address", Address));
                    cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
                    cmd.Parameters.Add(new SqlParameter("@PostCode", PostCode));
                    cmd.Parameters.Add(new SqlParameter("@PostAddress", PostAddress));

                    retorno = cmd.ExecuteNonQuery();

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

        //Borrar Escuela
        public static int BorrarEscuela()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_DeleteSchool", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@SchoolId", SchoolId));

                    retorno = cmd.ExecuteNonQuery();

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

        //Consultar Escuela
        public static int ConsultarEscuela()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetSchoolById", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@SchoolId", SchoolId));

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

        //Modificar Escuela
        public static int ModificarEscuela()
        {

            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateSchool", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@SchoolId", SchoolId));
                    cmd.Parameters.Add(new SqlParameter("@SchoolName", SchoolName));
                    cmd.Parameters.Add(new SqlParameter("@Description", Description));
                    cmd.Parameters.Add(new SqlParameter("@Address", Address));
                    cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
                    cmd.Parameters.Add(new SqlParameter("@PostCode", PostCode));
                    cmd.Parameters.Add(new SqlParameter("@PostAddress", PostAddress));

                    retorno = cmd.ExecuteNonQuery();

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

    }
}