using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class UsuarioVO
    {
        private int _IdUsuario;
        private string _Nombre;
        private string _Email;
        private string _Contraseña;
        private string _Telefono;
        private DateTime _FechaRegistro;
        private string _TipoUsuario;
        private bool _Activo;

        public int IdUsuario
        {
            get => _IdUsuario; set => _IdUsuario = value;
        }
        public string Nombre
        {
            get => _Nombre; set => _Nombre = value;
        }

        public string Email
        {
            get => _Email; set => _Email = value;
        }

        public string Contraseña
        {
            get => _Contraseña; set => _Contraseña = value;
        }
        public string Telefono
        {
            get => _Telefono; set => _Telefono = value;
        }
        public DateTime FechaRegistro
        {
            get => _FechaRegistro; set => _FechaRegistro = value;
        }
        public string TipoUsuario
        {
            get => _TipoUsuario; set => _TipoUsuario = value;
        }
        public bool Activo
        {
            get => _Activo; set => _Activo = value;
        }

        public UsuarioVO(DataRow dr)
        {
            IdUsuario = int.Parse(dr["IdUsuario"].ToString());
            Nombre = dr["Nombre"].ToString();
            Email = dr["Email"].ToString();
            Contraseña = dr["Contrasena"].ToString();
            Telefono = dr["Telefono"].ToString();
            FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
            TipoUsuario = dr["TipoUsuario"].ToString();
            Activo = bool.Parse(dr["Activo"].ToString());
        }

        public UsuarioVO()
        {
            IdUsuario = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Contraseña = string.Empty;
            Telefono = string.Empty;
            FechaRegistro = DateTime.MinValue;
            TipoUsuario = string.Empty;
            Activo = false;
        }

    }
}
