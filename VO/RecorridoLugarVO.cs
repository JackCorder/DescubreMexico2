using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class RecorridoLugarVO
    {
        private int _IdRecorridoLugar;
        private int _IdRecorrido;
        private string _Recorrido;
        private int _IdLugar;
        private string _Lugar;

        public int IdRecorridoLugar
        {
            get => _IdRecorridoLugar; set => _IdRecorridoLugar = value;
        }

        public int IdRecorrido
        {
            get => _IdRecorrido;set => _IdRecorrido = value;
        }

        public string Recorrido
        {
            get => _Recorrido; set => _Recorrido = value;
        }
        public int IdLugar
        {
            get => _IdLugar; set => _IdLugar = value;
        }
        public string Lugar
        {
            get => _Lugar;
            set => _Lugar = value;
        }

        public RecorridoLugarVO(DataRow dr)
        {
            IdRecorridoLugar = int.Parse(dr["IdRecorridoLugar"].ToString());
            IdRecorrido = int.Parse(dr["IdRecorrido"].ToString());
            Recorrido = dr["Recorrido"].ToString();
            IdLugar = int.Parse(dr["IdLugar"].ToString());
            Lugar = dr["Lugar"].ToString();
        }

        public RecorridoLugarVO()
        {
            IdRecorridoLugar = 0;
            IdRecorrido = 0;
            Recorrido = string.Empty;
            IdLugar = 0;
            Lugar = string.Empty;
        }
    }

}
