using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class RecorridoVO
    {
        public int IdRecorrido { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdTipo { get; set; }
        public string TipoRecorrido { get; set; }
        public int DuracionHoras { get; set; }
        public decimal Precio { get; set; }
        public string Dificultad { get; set; }
        public int MaxParticipantes { get; set; }
        public int IdGuia { get; set; }
        public string GuiaNombre { get; set; }
        public bool Activo { get; set; }
        public RecorridoVO(DataRow dr)
        {
            IdRecorrido = int.Parse(dr["IdRecorrido"].ToString());
            Titulo = dr["Titulo"].ToString();
            Descripcion = dr["Descripcion"].ToString();
            IdTipo = int.Parse(dr["IdTipo"].ToString());
            TipoRecorrido = dr["TipoRecorrido"].ToString();
            DuracionHoras = int.Parse(dr["DuracionHoras"].ToString());
            Precio = decimal.Parse(dr["Precio"].ToString());
            Dificultad = dr["Dificultad"].ToString();
            MaxParticipantes = int.Parse(dr["MaxParticipantes"].ToString());
            IdGuia = int.Parse(dr["IdGuia"].ToString());
            GuiaNombre = dr["GuiaNombre"].ToString();
            Activo = bool.Parse(dr["Activo"].ToString());
        }

        public RecorridoVO()
        {
            IdRecorrido = 0;
            Titulo = string.Empty;
            Descripcion = string.Empty;
            IdTipo = 0;
            TipoRecorrido = string.Empty;
            DuracionHoras = 0;
            Precio = 0m;
            Dificultad = string.Empty;
            MaxParticipantes = 0;
            IdGuia = 0;
            GuiaNombre = string.Empty;
            Activo = false;
        }


    }
}
