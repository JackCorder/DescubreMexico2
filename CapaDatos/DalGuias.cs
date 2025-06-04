using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalGuias
    {
        public static List<GuiaVO> GetListGuias(bool? paramActivo)
        {
            try
            {
                DataSet dsGuias;
                if (paramActivo == null)
                {
                    dsGuias = MetodosDatos.ExecuteDataSet("sp_guias_listar");
                }
                else
                {
                    dsGuias = MetodosDatos.ExecuteDataSet("sp_guias_listar", "@Activo", paramActivo);
                }

                List<GuiaVO> ListarGuias = new List<GuiaVO>();

                foreach (DataRow dr in dsGuias.Tables[0].Rows)
                {
                    ListarGuias.Add(new GuiaVO(dr));
                }

                return ListarGuias;
            }
            catch (Exception) {
                throw;
            }
        }

        public static void InsGuia(string paramNombre, string paramEmail, string paramTelefono, string paramExperiencia)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_guia_insertar",
                    "@Nombre", paramNombre,
                    "@Email", paramEmail,
                    "@Telefono", paramTelefono,
                    "@Experiencia", paramExperiencia
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdGuia(int paramIdGuia, string paramNombre, string paramEmail, string paramTelefono, string paramExperiencia, bool? paramActivo)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_guia_actualizar",
                    "@IdGuia", paramIdGuia,
                    "@Nombre", paramNombre,
                    "@Email", paramEmail,
                    "@Telefono", paramTelefono,
                    "@Experiencia", paramExperiencia,
                    "@Activo", paramActivo
                );
            }
            catch { throw; }
        }

        public static void DelGuia(int paramIdGuia)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_guia_deshabilitar",
                    "@IdGuia", paramIdGuia
                    );
            }
            catch { throw;}
        }

        public static GuiaVO GetGuiaById(int paramIdGuia)
        {

            try
            {
                DataSet dsGuia = MetodosDatos.ExecuteDataSet("sp_guia_conseguir", "@IdGuia", paramIdGuia);

                if (dsGuia.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsGuia.Tables[0].Rows[0];
                    GuiaVO guia = new GuiaVO(dr);
                    return guia;
                }
                else
                {
                    GuiaVO guia = new GuiaVO();
                    return guia;
                }
            }
            catch { throw; }
        }
    }
}
