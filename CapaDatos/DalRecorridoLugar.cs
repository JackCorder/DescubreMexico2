using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalRecorridoLugar
    {
        public static List<RecorridoLugarVO> GetListRecorridoLugar(int IdRecorrido)
        {
            try
            {
                // Llama la vista filtrando por IdRecorrido
                DataSet ds = MetodosDatos.ExecuteDataSet("sp_recorrido_lugares_recorrido", "@IdRecorrido", IdRecorrido);

                List<RecorridoLugarVO> lista = new List<RecorridoLugarVO>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lista.Add(new RecorridoLugarVO(dr));
                }

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void InsRecorridoLugar(int IdRecorrido, int IdLugar)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_recorrido_lugar_insertar",
                    "@IdRecorrido", IdRecorrido,
                    "@IdLugar", IdLugar
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DelRecorridoLugar(int IdRecorridoLugar)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_recorrido_lugar_eliminar", "@IdRecorridoLugar", IdRecorridoLugar);
            }
            catch
            {

            }
        }

    }
}
