using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalRecorridos
    {
        public static List<RecorridoVO> GetListRecorridos(int? paramIdGuia, int? paramIdTipo, string paramDificultad)
        {
            try
            {
                List<object> parametros = new List<object>();

                if (paramIdGuia.HasValue)
                {
                    parametros.Add("@IdGuia");
                    parametros.Add(paramIdGuia.Value);
                }

                if (paramIdTipo.HasValue)
                {
                    parametros.Add("@IdTipo");
                    parametros.Add(paramIdTipo.Value);
                }

                if (!string.IsNullOrEmpty(paramDificultad))
                {
                    parametros.Add("@Dificultad");
                    parametros.Add(paramDificultad);
                }

                DataSet dsRecorridos;

                if (parametros.Count > 0)
                {
                    dsRecorridos = MetodosDatos.ExecuteDataSet("sp_recorridos_listar", parametros.ToArray());
                }
                else
                {
                    dsRecorridos = MetodosDatos.ExecuteDataSet("sp_recorridos_listar");
                }

                List<RecorridoVO> listaRecorridos = new List<RecorridoVO>();

                foreach (DataRow dr in dsRecorridos.Tables[0].Rows)
                {
                    listaRecorridos.Add(new RecorridoVO(dr));
                }

                return listaRecorridos;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static void InsRecorrido(string titulo, string descripcion, int idTipo, int duracionHoras, decimal precio, string dificultad, int maxParticipantes, int idGuia)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_recorrido_insertar",
                    "@Titulo", titulo,
                    "@Descripcion", descripcion,
                    "@IdTipo", idTipo,
                    "@DuracionHoras", duracionHoras,
                    "@Precio", precio,
                    "@Dificultad", dificultad,
                    "@MaxParticipantes", maxParticipantes,
                    "@IdGuia", idGuia
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdRecorrido(int idRecorrido, string titulo, string descripcion, int idTipo, int duracionHoras, decimal precio, string dificultad, int maxParticipantes, int idGuia, bool? activo)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_recorrido_actualizar",
                    "@IdRecorrido", idRecorrido,
                    "@Titulo", titulo,
                    "@Descripcion", descripcion,
                    "@IdTipo", idTipo,
                    "@DuracionHoras", duracionHoras,
                    "@Precio", precio,
                    "@Dificultad", dificultad,
                    "@MaxParticipantes", maxParticipantes,
                    "@IdGuia", idGuia,
                    "@Activo", activo
                );
            }
            catch
            {
                throw;
            }
        }

        public static void DelRecorrido(int idRecorrido)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_recorrido_deshabilitar",
                    "@IdRecorrido", idRecorrido
                );
            }
            catch
            {
                throw;
            }
        }

        public static RecorridoVO GetRecorridoById(int idRecorrido)
        {
            try
            {
                DataSet dsRecorrido = MetodosDatos.ExecuteDataSet("sp_recorrido_conseguir", "@IdRecorrido", idRecorrido);

                if (dsRecorrido.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsRecorrido.Tables[0].Rows[0];
                    return new RecorridoVO(dr);
                }
                else
                {
                    return new RecorridoVO();
                }
            }
            catch
            {
                throw;
            }
        }
    }

}
