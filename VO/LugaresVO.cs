using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class LugaresVO
    {
        private int _IdLugar;
        private string _Nombre;
        private string _Descripcion;
        private string _Ciudad;
        private decimal _Latitud;
        private decimal _Longitud;
        private string _ImagenUrl;
        private bool _Activo;

        public int IdLugar
        {
            get => _IdLugar; set => _IdLugar = value;
        }
        public string Nombre
        {
            get => _Nombre; set => _Nombre = value;
        }
        public string Descripcion
        {
            get => _Descripcion; set => _Descripcion = value;
        }
        public string Ciudad {
            get => _Ciudad; set => _Ciudad = value;
        }
        public decimal Latitud
        {
            get => _Latitud; set => _Latitud = value;
        }
        public decimal Longitud
        {
            get => _Longitud; set => _Longitud = value;
        }
        public string ImagenUrl
        {
            get => _ImagenUrl; set => _ImagenUrl = value;
        }
        public bool Activo
        {
            get => _Activo; set => _Activo = value;
        }
        public LugaresVO(DataRow dr)
        {
            IdLugar = int.Parse(dr["IdLugar"].ToString());
            Nombre = dr["Nombre"].ToString();
            Descripcion = dr["Descripcion"].ToString();
            Ciudad = dr["Ciudad"].ToString();
            Latitud = (decimal) dr["Latitud"];
            Longitud = (decimal) dr["Longitud"];
            ImagenUrl = dr["ImagenUrl"].ToString();
            Activo = bool.Parse(dr["Activo"].ToString());
        }

        public LugaresVO()
        {
            IdLugar = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Ciudad = string.Empty;
            Latitud = 0;
            Longitud= 0;
            ImagenUrl = string.Empty;
            Activo = false;
        }
    }
}
