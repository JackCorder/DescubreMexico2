using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class MetodosDatos
    {
        //Metodo que regresa una tabla de información realizada por consulta
        public static DataSet ExecuteDataSet(string sp, params object[] parametros)
        {
            DataSet ds = new DataSet();

            string cadenaConexion = Configuracion.CadenaConexion;

            SqlConnection conn = new SqlConnection(cadenaConexion);

            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                SqlCommand cmd = new SqlCommand(sp, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null && parametros.Length % 2 != 0)
                {
                    throw new ApplicationException("Los parametros deben venir en pares");
                }
                else
                {
                    for (int i = 0; i < parametros.Length; i = i + 2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }

                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(ds);

                    conn.Close();

                }
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        //Metodo que ejecuta consultas que regresan un valor (INSERT)
        public static int ExecuteNonQuery(string sp, params object[] parametros)
        {
            int exitoso = 0;

            string cadenaConexion = Configuracion.CadenaConexion;

            SqlConnection conn = new SqlConnection(cadenaConexion);

            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                SqlCommand cmd = new SqlCommand(sp, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null && parametros.Length % 2 != 0)
                {
                    throw new ApplicationException("Los parametros deben venir en pares");
                }
                else
                {
                    for (int i = 0; i < parametros.Length; i = i + 2)
                    {
                        string nombreParametro = parametros[i].ToString();
                        object valorParametro = parametros[i + 1] ?? DBNull.Value; // Usa DBNull para valores nulos
                        cmd.Parameters.AddWithValue(nombreParametro, valorParametro);
                    }

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    exitoso = 1;

                    conn.Close();
                }
                return exitoso;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                return exitoso;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        //Metodo para ejecutar un escalar
        public static int ExecuteEscalar(string sp, params object[] parametros)
        {
            int id = 0;

            string cadenaConexion = Configuracion.CadenaConexion;

            SqlConnection conn = new SqlConnection(cadenaConexion);
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                SqlCommand cmd = new SqlCommand(sp, conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;

                for (int i = 0; i < parametros.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                }

                conn.Open();

                id = int.Parse(cmd.ExecuteScalar().ToString());

                conn.Close();

                return id;

            }
            catch (Exception) {
                return id;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        //Llamar una Vista
        public static DataSet ExecuteView(string viewName)
        {
            DataSet ds = new DataSet();
            string cadenaConexion = Configuracion.CadenaConexion;

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    string query = $"SELECT * FROM {viewName}";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    conn.Open();
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }

            return ds;
        }


        


    }
}
