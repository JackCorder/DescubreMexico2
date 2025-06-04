using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalLugares
    {
        public static List<LugaresVO> GetListLugares(string paramCiudad)
        {
            try
            {
                DataSet dsLugares;
                if (paramCiudad != null)
                {
                    dsLugares = MetodosDatos.ExecuteDataSet("sp_lugares_listar", "@Ciudad", paramCiudad);
                }
                else
                {
                    dsLugares = MetodosDatos.ExecuteDataSet("sp_lugares_listar");
                }

                List<LugaresVO> listaLugares = new List<LugaresVO>();

                foreach (DataRow dr in dsLugares.Tables[0].Rows)
                {
                    listaLugares.Add(new LugaresVO(dr));
                }

                return listaLugares;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void InsLugar(string paramNombre, string paramDescripcion, string paramCiudad, decimal paramLatitud, decimal paramLongitud, string paramImagenUrl)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_lugar_insertar",
                    "@Nombre", paramNombre,
                    "@Descripcion", paramDescripcion,
                    "@Ciudad", paramCiudad,
                    "@Latitud", paramLatitud,
                    "@Longitud", paramLongitud,
                    "@ImagenUrl", paramImagenUrl
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdLugar(int paramIdLugar, string paramNombre, string paramDescripcion, string paramCiudad, decimal paramLatitud, decimal paramLongitud, string paramImagenUrl, bool? paramActivo)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_lugar_actualizar",
                    "@IdLugar", paramIdLugar,
                    "@Nombre", paramNombre,
                    "@Descripcion", paramDescripcion,
                    "@Ciudad", paramCiudad,
                    "@Latitud", paramLatitud,
                    "@Longitud", paramLongitud,
                    "@ImagenUrl", paramImagenUrl,
                    "@Activo", paramActivo
                );
            }
            catch
            {
                throw;
            }
        }

        public static void DelLugar(int paramIdLugar)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_lugar_deshabilitar",
                    "@IdLugar", paramIdLugar
                );
            }
            catch
            {
                throw;
            }
        }

        public static LugaresVO GetLugarById(int paramIdLugar)
        {
            try
            {
                DataSet dsLugar = MetodosDatos.ExecuteDataSet("sp_lugar_conseguir", "@IdLugar", paramIdLugar);

                if (dsLugar.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsLugar.Tables[0].Rows[0];
                    return new LugaresVO(dr);
                }
                else
                {
                    return new LugaresVO();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
