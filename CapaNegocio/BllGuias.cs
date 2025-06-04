using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllGuias
    {
        public static string InsGuia(string Nombre, string Email, string Telefono, string Experiencia)
        {
            // No se puede repetir la matricula
            try
            {
                List<GuiaVO> ListaGuia = DalGuias.GetListGuias(null);

                bool Existe = false;

                foreach (GuiaVO item in ListaGuia.Take(1))
                {
                    if (item.Email == Email)
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "La correo electrónico ya fue utilizado con anterioridad";
                }
                else
                {
                    DalGuias.InsGuia(Nombre, Email, Telefono, Experiencia);
                    return "Usuario agregado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // del INSERT

        public static string UpdGuia(int IdGuia, string Nombre, string Email, string Telefono, string Experiencia, bool Activo)
        {
            try
            {
                List<GuiaVO> LstGuia = DalGuias.GetListGuias(null);
                bool Existe = false;

                foreach (GuiaVO item in LstGuia)
                {
                    if ((item.IdGuia != IdGuia) && (item.Email == Email))
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "El correo del guia ya fue utilizado con anterioridad";
                }
                else
                {
                    DalGuias.UpdGuia(IdGuia, Nombre, Email, Telefono, Experiencia, Activo);
                    return "Guia actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }  // Del Update

        public static string DelGuia(int IdGuia)
        {
            try
            {
                GuiaVO guia = DalGuias.GetGuiaById(IdGuia);

                if (guia != null && guia.Activo)
                {
                    DalGuias.DelGuia(IdGuia);
                    return "1";
                }
                else
                {
                    return "El guía ya está inactivo o no existe.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static GuiaVO GetGuiaById(int IdGuia)
        {
            try
            {
                return DalGuias.GetGuiaById(IdGuia);
            }
            catch (Exception)
            {
                return new GuiaVO(); // Retorna objeto vacío en caso de error
            }
        }

        public static List<GuiaVO> GetLstGuias(bool? Activo)
        {
            List<GuiaVO> LstGuias = new List<GuiaVO>();
            try
            {
                System.Diagnostics.Debug.WriteLine("Llamando a DalGuias.GetListGuias");
                LstGuias = DalGuias.GetListGuias(Activo);
                return LstGuias;
            }
            catch (Exception)
            {
                return LstGuias; // Lista vacía en caso de error
            }
        }
    }
}
