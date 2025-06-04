using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalTiposRecorridos
    {
        public static List<TipoRecorridoVO> GetListTiposR()
        {
            try
            {
                DataSet dsTiposRecorridos;
                
                dsTiposRecorridos = MetodosDatos.ExecuteView("TiposDeRecorridos");
                

                List<TipoRecorridoVO> listaTipos = new List<TipoRecorridoVO>();

                foreach (DataRow dr in dsTiposRecorridos.Tables[0].Rows)
                {
                    listaTipos.Add(new TipoRecorridoVO(dr));
                }

                return listaTipos;
            }
            catch
            {
                throw;
            }
        }

    }

}
