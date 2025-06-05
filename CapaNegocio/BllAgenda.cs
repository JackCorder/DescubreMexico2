using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllAgenda
    {
        public static string InsAgenda(int IdRecorrido, DateTime Fecha, DateTime HoraInicio)
        {
            // No se puede repetir la matricula
            try
            {
                List<AgendaVO> Lst = DalAgendas.GetListAgendas();
                bool Existe = false;

                foreach (AgendaVO item in Lst)
                {
                    if ((item.IdRecorrido != IdRecorrido) && (item.Fecha == Fecha) && (item.HoraInicio == HoraInicio))
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "Ya hay un recorrido para esta fecha";
                }
                else
                {

                    DalAgendas.InsAgenda(IdRecorrido, Fecha, HoraInicio);
                    return "Usuario agregado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // del INSERT

        public static string UpdGuia(int IdAgenda, int IdRecorrido, DateTime Fecha, DateTime HoraInicio, string Estado)
        {
            try
            {
                List<AgendaVO> Lst = DalAgendas.GetListAgendas();
                bool Existe = false;

                foreach (AgendaVO item in Lst)
                {
                    if ((item.IdAgenda != IdAgenda) && (item.Fecha == Fecha) && (item.HoraInicio == HoraInicio))
                    {
                        Existe = true;
                    }
                }

                if (Existe)
                {
                    return "Ya hay un recorrido para esta fecha";
                }
                else
                {
                    DalAgendas.UpdAgenda(IdAgenda, IdRecorrido, Fecha, HoraInicio, Estado);
                    return "Guia actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }  // Del Update

        public static string DelAgenda(int IdAgenda)
        {
            try
            {
                AgendaVO agenda = DalAgendas.GetAgendaById(IdAgenda);

                if (agenda != null && agenda.Estado == "cancelado")
                {
                    DalAgendas.DelAgenda(IdAgenda);
                    return "1";
                }
                else
                {
                    return "El evento ya está inactivo o no existe.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static AgendaVO GetAgendaById(int Agenda)
        {
            try
            {
                return DalAgendas.GetAgendaById(Agenda);
            }
            catch (Exception)
            {
                return new AgendaVO(); // Retorna objeto vacío en caso de error
            }
        }

        public static List<AgendaVO> GetLstAgendas()
        {
            List<AgendaVO> Lst = new List<AgendaVO>();
            try
            {
                Lst = DalAgendas.GetListAgendas();
                return Lst;
            }
            catch (Exception)
            {
                return Lst; // Lista vacía en caso de error
            }
        }
    }
}
