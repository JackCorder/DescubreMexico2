using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllUsuarios
    {
        public static string InsUsuario(string Nombre, string Email, string Contrasena, string Telefono, string TipoUsuario)
        {
            // No se puede repetir la matricula
            try
            {
                List<UsuarioVO> LstUsuarios = DalUsuarios.GetListUsuarios(null);

                bool Existe = false;

                foreach (UsuarioVO item in LstUsuarios.Take(1))
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
                    DalUsuarios.InsUsuario(Nombre, Email, Contrasena, Telefono, TipoUsuario);
                    return "Usuario agregado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // del INSERT

        public static string UpdUsuario(int IdUsuario, string Nombre, string Email, string Telefono, bool Activo)
        {
            try
            {
                List<UsuarioVO> LstUsuarios = DalUsuarios.GetListUsuarios(null);
                bool Existe = false;

                foreach (UsuarioVO item in LstUsuarios)
                {
                    if ((item.IdUsuario != IdUsuario) && (item.Email == Email))
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "El correo del camión ya fue utilizado con anterioridad";
                }
                else
                {
                    DalUsuarios.UpdUsuario(IdUsuario, Nombre, Email, Telefono, Activo);
                    return "Usuario actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }  // Del Update

        public static string DelUsuario(int IdUsuario)
        {
            try
            {
                UsuarioVO UsuarioVO = DalUsuarios.GetUsuarioById(IdUsuario);

                if (UsuarioVO.Activo)
                {
                    DalUsuarios.DelUsuario(IdUsuario);
                    return "1";
                }
                else
                {
                    return "El usuario se encuentra inactivo";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // del DELETE

        public static UsuarioVO GetUsuarioById(int IdUsuario)
        {
            try
            {
                return DalUsuarios.GetUsuarioById(IdUsuario);
            }
            catch (Exception)
            {
                return new UsuarioVO();
            }
        } // del GetCamionById


        public static string GetUsuarioByEmail(string Email)
        {
            try
            {
                string pass = DalUsuarios.GetUsuarioByEmail(Email);
                return pass;
            }
            catch (Exception)
            {
                return "";
            }
        } 

        public static List<UsuarioVO> GetLstUsuarios(bool? Activo)
        {
            List<UsuarioVO> LstUsuarios = new List<UsuarioVO>();
            try
            {
                System.Diagnostics.Debug.WriteLine("voy a llamar a DalUsuarios.GetLstUsuarios");
                LstUsuarios = DalUsuarios.GetListUsuarios(Activo);
                return LstUsuarios;
            }
            catch (Exception)
            {
                return LstUsuarios;
            }
        }
    }
}
