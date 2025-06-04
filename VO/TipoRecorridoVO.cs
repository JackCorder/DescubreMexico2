using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class TipoRecorridoVO
    {
        public int IdTipoRecorrido { get; set; }
        public string Nombre { get; set; }
        

        
        public TipoRecorridoVO(DataRow dr)
        {
            IdTipoRecorrido = int.Parse(dr["IdTipo"].ToString());
            Nombre = dr["Nombre"].ToString();
        }

        public TipoRecorridoVO()
        {
            IdTipoRecorrido = 0;
            Nombre = string.Empty;
        }
    }
}
