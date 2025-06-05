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
        private int _IdLugar;
        private string _Lugar;
        private string _ImagenUrl;

        public int IdRecorridoLugar
        {
            get => _IdRecorridoLugar; set => _IdRecorridoLugar = value;
        }

        public int IdRecorrido
        {
            get => _IdRecorrido;set => _IdRecorrido = value;
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

        public string ImagenUrl
        {
            get => _ImagenUrl;
            set => _ImagenUrl = value;
        }
        public RecorridoLugarVO(DataRow dr)
        {
            IdRecorridoLugar = int.Parse(dr["IdRecorridoLugar"].ToString());
            IdRecorrido = int.Parse(dr["IdRecorrido"].ToString());
            IdLugar = int.Parse(dr["IdLugar"].ToString());
            Lugar = dr["NombreLugar"].ToString();
            ImagenUrl = dr["ImagenUrl"].ToString();
        }

        public RecorridoLugarVO()
        {
            IdRecorridoLugar = 0;
            IdRecorrido = 0;
            IdLugar = 0;
            Lugar = string.Empty;
            ImagenUrl = string.Empty;
        }
    }

}
