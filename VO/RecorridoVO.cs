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
        private int _IdRecorrido;
        private string _Titulo;
        private string _Descripcion;
        private int _IdTipo;
        private int _DuracionHoras;
        private decimal _Precio;
        private string _Dificultad;
        private int _MaxParticipantes;
        private int _IdGuia;
        private bool _Activo;

        public int IdRecorrido
        {
            get => _IdRecorrido; set => _IdRecorrido = value;
        }

        public string Titulo
        {
            get => _Titulo; set => _Titulo = value;
        }

        public string Descripcion
        {
            get => _Descripcion; set => _Descripcion = value;
        }

        public int IdTipo
        {
            get => _IdTipo; set => _IdTipo = value;
        }

        public int DuracionHoras
        {
            get => _DuracionHoras; set => _DuracionHoras = value;
        }

        public decimal Precio
        {
            get => _Precio; set => _Precio = value;
        }

        public string Dificultad
        {
            get => _Dificultad; set => _Dificultad = value;
        }

        public int MaxParticipantes
        {
            get => _MaxParticipantes; set => _MaxParticipantes = value;
        }

        public int IdGuia
        {
            get => _IdGuia; set => _IdGuia = value;
        }

        public bool Activo
        {
            get => _Activo; set => _Activo = value;
        }

        public RecorridoVO(DataRow dr)
        {
            IdRecorrido = int.Parse(dr["IdRecorrido"].ToString());
            Titulo = dr["Titulo"].ToString();
            Descripcion = dr["Descripcion"].ToString();
            IdTipo = int.Parse(dr["IdTipo"].ToString());
            DuracionHoras = int.Parse(dr["DuracionHoras"].ToString());
            Precio = decimal.Parse(dr["Precio"].ToString());
            Dificultad = dr["Dificultad"].ToString();
            MaxParticipantes = int.Parse(dr["MaxParticipantes"].ToString());
            IdGuia = int.Parse(dr["IdGuia"].ToString());
            Activo = bool.Parse(dr["Activo"].ToString());
        }

        public RecorridoVO()
        {
            IdRecorrido = 0;
            Titulo = string.Empty;
            Descripcion = string.Empty;
            IdTipo = 0;
            DuracionHoras = 0;
            Precio = 0m;
            Dificultad = string.Empty;
            MaxParticipantes = 0;
            IdGuia = 0;
            Activo = false;
        }


    }
}
