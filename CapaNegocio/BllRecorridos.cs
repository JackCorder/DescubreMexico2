using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllRecorridos
    {
        public static string InsRecorrido(string Titulo, string Descripcion, int IdTipo, int DuracionHoras, decimal Precio, string Dificultad, int MaxParticipantes, int IdGuia)
        {
            // No se puede repetir la matricula
            try
            {
                List<RecorridoVO> Lista = DalRecorridos.GetListRecorridos(null, null, null);

                bool Existe = false;

                foreach (RecorridoVO item in Lista.Take(1))
                {
                    if (item.Titulo == Titulo)
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "El titulo del recorrido ya fue utilizado con anterioridad";
                }
                else
                {
                    DalRecorridos.InsRecorrido(Titulo, Descripcion, IdTipo, DuracionHoras, Precio, Dificultad, MaxParticipantes, IdGuia);
                    return "Recorrido agregado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // del INSERT

        public static string UpdRecorrido(int IdRecorrido, string Titulo, string Descripcion, int IdTipo, int DuracionHoras, decimal Precio, string Dificultad, int MaxParticipantes, int IdGuia, bool Activo)
        {
            try
            {
                List<RecorridoVO> Lst = DalRecorridos.GetListRecorridos(null, null, null);
                bool Existe = false;

                foreach (RecorridoVO item in Lst)
                {
                    if ((item.IdRecorrido != IdRecorrido) && (item.Titulo == Titulo))
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "El titulo del recorrido ya fue utilizado con anterioridad";
                }
                else
                {
                    DalRecorridos.UpdRecorrido(IdRecorrido, Titulo, Descripcion, IdTipo, DuracionHoras, Precio, Dificultad, MaxParticipantes, IdGuia, Activo);
                    return "Recorrido actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }  // Del Update

        public static string DelRecorrido(int IdRecorrido)
        {
            try
            {
                RecorridoVO recorrido = DalRecorridos.GetRecorridoById(IdRecorrido);

                if (recorrido != null && recorrido.Activo)
                {
                    DalRecorridos.DelRecorrido(IdRecorrido);
                    return "1";
                }
                else
                {
                    return "El recorrido ya está inactivo o no existe.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static RecorridoVO GetRecorridoById(int IdRecorrido)
        {
            try
            {
                return DalRecorridos.GetRecorridoById(IdRecorrido);
            }
            catch (Exception)
            {
                return new RecorridoVO(); // Retorna objeto vacío en caso de error
            }
        }

        public static List<RecorridoVO> GetLstRecorridos(int paramIdGuia, int paramIdTipo, string paramDificultad)
        {
            List<RecorridoVO> Lst = new List<RecorridoVO>();
            try
            {
                System.Diagnostics.Debug.WriteLine("Llamando a DalRecorridos.GetListRecorridos");
                Lst = DalRecorridos.GetListRecorridos(paramIdGuia, paramIdTipo, paramDificultad);
                return Lst;
            }
            catch (Exception)
            {
                return Lst; // Lista vacía en caso de error
            }
        }
    }
}
