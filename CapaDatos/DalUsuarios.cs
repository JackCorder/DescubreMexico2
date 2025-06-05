using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalUsuarios
    {
        public static List<UsuarioVO> GetListUsuarios(bool? paramActivo)
        {
            try
            {
                DataSet dsUsuarios;
                if (paramActivo == null)
                {
                    dsUsuarios = MetodosDatos.ExecuteDataSet("sp_usuarios_listar");
                }
                else
                {
                    dsUsuarios = MetodosDatos.ExecuteDataSet("sp_usuarios_listar", "@Activo", paramActivo);
                }

                List<UsuarioVO> ListarUsuarios = new List<UsuarioVO>();

                foreach (DataRow dr in dsUsuarios.Tables[0].Rows)
                {
                    ListarUsuarios.Add(new UsuarioVO(dr));
                }

                return ListarUsuarios;
            }
            catch (Exception) {
                throw;
            }
        }

        public static void InsUsuario(string paramNombre, string paramEmail, string paramContraseña, string paramTelefono, string paramTipoUsuario)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_usuario_insertar",
                    "@Nombre", paramNombre,
                    "@Email", paramEmail,
                    "@Contrasena", paramContraseña,
                    "@Telefono", paramTelefono,
                    "@TipoUsuario", paramTipoUsuario
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void UpdUsuario(int paramIdUsuario, string paramNombre, string paramEmail, string paramTelefono, bool? paramActivo)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_usuario_actualizar",
                    "@IdUsuario", paramIdUsuario,
                    "@Nombre", paramNombre,
                    "@Email", paramEmail,
                    "@Telefono", paramTelefono,
                    "@Activo", paramActivo
                );
            }
            catch { throw; }
        }

        public static void DelUsuario(int paramIdUsuario)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_usuario_deshabilitiar",
                    "@IdUsuario", paramIdUsuario
                    );
            }
            catch { throw;}
        }

        public static UsuarioVO GetUsuarioById(int paramIdUsuario)
        {

            try
            {
                DataSet dsUsuario = MetodosDatos.ExecuteDataSet("sp_usuario_conseguir", "@IdUsuario", paramIdUsuario);

                if (dsUsuario.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsUsuario.Tables[0].Rows[0];
                    UsuarioVO usuario = new UsuarioVO(dr);
                    return usuario;
                }
                else
                {
                    UsuarioVO usuario = new UsuarioVO();
                    return usuario;
                }
            }
            catch { throw; }
        }


        public static string GetUsuarioByEmail(string paramEmail)
        {

            try
            {
                DataSet dsUsuario = MetodosDatos.ExecuteDataSet("sp_usuario_conseguir_Email", "@Email", paramEmail);

                if (dsUsuario.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsUsuario.Tables[0].Rows[0];
                    UsuarioVO usuario = new UsuarioVO(dr);

                    return usuario.Contraseña;
                }
                else
                {
                    UsuarioVO usuario = new UsuarioVO();
                    return usuario.Contraseña;
                }
            }
            catch { throw; }
        }

    }
}
