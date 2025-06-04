using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllTiposRecorridos
    {
        
        public static List<TipoRecorridoVO> GetLstTiposR()
        {
            List<TipoRecorridoVO> Lst = new List<TipoRecorridoVO>();
            try
            {
                Lst = DalTiposRecorridos.GetListTiposR();
                return Lst;
            }
            catch (Exception)
            {
                return Lst; // Lista vacía en caso de error
            }
        }
    }
}
