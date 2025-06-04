using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class AgendaVO
    {
        private int _IdAgenda;
        private int _IdRecorrido;
        private string _Recorrido;
        private DateTime _Fecha;
        private DateTime _HoraInicio;
        private string _Estado;

        public int IdAgenda
        {
            get => _IdAgenda;
            set => _IdAgenda = value;
        }

        public int IdRecorrido
        {
            get => _IdRecorrido;
            set => _IdRecorrido = value;
        }

        public string Recorrido
        {
            get => _Recorrido; set => _Recorrido = value;
        }

        public DateTime Fecha
        {
            get => _Fecha;
            set => _Fecha = value;
        }

        public DateTime HoraInicio
        {
            get => _HoraInicio;
            set => _HoraInicio = value;
        }

        public string Estado
        {
            get => _Estado;
            set => _Estado = value;
        }

        public AgendaVO(DataRow dr)
        {
            IdAgenda = int.Parse(dr["IdAgenda"].ToString());
            IdRecorrido = int.Parse(dr["IdRecorrido"].ToString());
            Recorrido = dr["Recorrido"].ToString();
            Fecha = DateTime.Parse(dr["Fecha"].ToString());
            HoraInicio = DateTime.Parse(dr["HoraInicio"].ToString());
            Estado = dr["Estado"].ToString();
        }

        public AgendaVO()
        {
            IdAgenda = 0;
            IdRecorrido = 0;
            Recorrido = string.Empty;
            Fecha = DateTime.MinValue;
            HoraInicio = DateTime.MinValue;
            Estado = string.Empty;
        }
    }

}
