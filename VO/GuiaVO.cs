using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class GuiaVO
    {
        private int _IdGuia;
        private string _Nombre;
        private string _Email;
        private string _Telefono;
        private string _Experiencia;
        private bool _Activo;

        public int IdGuia
        {
            get =>_IdGuia; set => _IdGuia = value;
        }

        public string Nombre
        {
            get => _Nombre; set => _Nombre = value;
        }

        public string Email
        {
            get => _Email; set => _Email = value;
        }

        public string Telefono
        {
            get => _Telefono; set => _Telefono = value;
        }

        public string Experiencia
        {
            get => _Experiencia; set => _Experiencia = value;
        }

        public bool Activo
        {
            get => _Activo; set => _Activo = value;
        }

        public GuiaVO(DataRow dr)
        {
            IdGuia = int.Parse(dr["IdGuia"].ToString());
            Nombre = dr["Nombre"].ToString();
            Email = dr["Email"].ToString();
            Telefono = dr["Telefono"].ToString();
            Experiencia = dr["Experiencia"].ToString();
            Activo = bool.Parse(dr["Activo"].ToString());
        }

        public GuiaVO()
        {
            IdGuia = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Experiencia = string.Empty;
            Activo = false;
        }
    }
}
