using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllLugares
    {
        public static string InsLugar(string Nombre, string Descripcion, string Ciudad, decimal Latitud, decimal Longitud, string ImagenUrl)
        {
            // No se puede repetir la matricula
            try
            {
                List<LugaresVO> Lista = DalLugares.GetListLugares(null);

                bool Existe = false;

                foreach (LugaresVO item in Lista.Take(1))
                {
                    if (item.Nombre == Nombre)
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "El lugar ya fue registrado con anterioridad";
                }
                else
                {
                    DalLugares.InsLugar(Nombre, Descripcion, Ciudad, Latitud, Longitud, ImagenUrl);
                    return "Lugar agregado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // del INSERT

        public static string UpdLugar(int IdLugar, string Nombre, string Descripcion, string Ciudad, decimal Latitud, decimal Longitud, string ImagenUrl, bool Activo)
        {
            try
            {
                List<LugaresVO> LstLugar = DalLugares.GetListLugares(null);
                bool Existe = false;

                foreach (LugaresVO item in LstLugar)
                {
                    if ((item.IdLugar != IdLugar) && (item.Nombre == Nombre))
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "El nombre del lugar ya fue utilizado con anterioridad";
                }
                else
                {
                    DalLugares.UpdLugar(IdLugar, Nombre, Descripcion, Ciudad, Latitud, Longitud, ImagenUrl, Activo);
                    return "Lugar actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }  // Del Update

        public static string DelLugar(int IdLugar)
        {
            try
            {
                LugaresVO lugar = DalLugares.GetLugarById(IdLugar);

                if (lugar != null && lugar.Activo)
                {
                    DalLugares.DelLugar(IdLugar);
                    return "1";
                }
                else
                {
                    return "El lugar ya está inactivo o no existe.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static LugaresVO GetLugarById(int Id)
        {
            try
            {
                return DalLugares.GetLugarById(Id);
            }
            catch (Exception)
            {
                return new LugaresVO(); // Retorna objeto vacío en caso de error
            }
        }

        public static List<LugaresVO> GetLstLugares(string Ciudad)
        {
            List<LugaresVO> LstLugares = new List<LugaresVO>();
            try
            {
                System.Diagnostics.Debug.WriteLine("Llamando a DalGuias.GetListGuias");
                LstLugares = DalLugares.GetListLugares(Ciudad);
                return LstLugares;
            }
            catch (Exception)
            {
                return LstLugares; // Lista vacía en caso de error
            }
        }
    }
}
