using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class OpinionVO
    {
        private int _IdOpinion;
        private int _IdUsuario;
        private int _IdRecorrido;
        private int _Calificacion;
        private string _Comentario;
        private DateTime _FechaOpinion;

        public int IdOpinion
        {
            get => _IdOpinion; set => _IdOpinion = value;
        }
        public int IdUsuario
        {
            get => _IdUsuario;set => _IdUsuario = value;
        }
        public int IdRecorrido
        {
            get => _IdRecorrido; set => _IdRecorrido = value;
        }
        public int Calificacion
        {
            get => _Calificacion; set => _Calificacion = value;
        }
        public string Comentario
        {
            get => _Comentario; set => _Comentario = value;
        }
        public DateTime FechaOpinion
        {
            get => _FechaOpinion; set => _FechaOpinion = value;
        }
        public OpinionVO(DataRow dr)
        {
            IdOpinion = int.Parse(dr["IdOpinion"].ToString());
            IdUsuario = int.Parse(dr["IdUsuario"].ToString());
            IdRecorrido = int.Parse(dr["IdRecorrido"].ToString());
            Calificacion = int.Parse(dr["Calificacion"].ToString());
            Comentario = dr["Comentario"].ToString();
            FechaOpinion = DateTime.Parse(dr["FechaOpinion"].ToString());
        }

        public OpinionVO()
        {
            IdOpinion = 0;
            IdUsuario = 0;
            IdRecorrido = 0;
            Calificacion = 0;
            Comentario = string.Empty;
            FechaOpinion = DateTime.MinValue;
        }
    }

}
