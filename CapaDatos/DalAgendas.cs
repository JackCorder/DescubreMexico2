using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalAgendas
    {
        public static List<AgendaVO> GetListAgendas(int? paramIdRecorrido, string paramEstado, DateTime? paramFechaDesde, DateTime? paramFechaHasta)
        {
            try
            {
                DataSet dsAgendas;
                // Armado dinámico de parámetros
                List<object> parametros = new List<object>();

                if (paramIdRecorrido.HasValue)
                {
                    parametros.Add("@IdRecorrido");
                    parametros.Add(paramIdRecorrido.Value);
                }

                if (!string.IsNullOrEmpty(paramEstado))
                {
                    parametros.Add("@Estado");
                    parametros.Add(paramEstado);
                }

                if (paramFechaDesde.HasValue)
                {
                    parametros.Add("@FechaDesde");
                    parametros.Add(paramFechaDesde.Value);
                }

                if (paramFechaHasta.HasValue)
                {
                    parametros.Add("@FechaHasta");
                    parametros.Add(paramFechaHasta.Value);
                }

                // Convertir a array y llamar al SP
                if (parametros.Count > 0) {
                    dsAgendas = MetodosDatos.ExecuteDataSet("sp_agendas_listar", parametros.ToArray());
                }
                else
                {
                    dsAgendas = MetodosDatos.ExecuteDataSet("sp_agendas_listar");
                }


                List<AgendaVO> listaAgendas = new List<AgendaVO>();

                foreach (DataRow dr in dsAgendas.Tables[0].Rows)
                {
                    listaAgendas.Add(new AgendaVO(dr));
                }

                return listaAgendas;
            }
            catch
            {
                throw;
            }
        }


        public static void InsAgenda(int paramIdRecorrido, DateTime paramFecha, DateTime paramHoraInicio)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_agenda_insertar",
                    "@IdRecorrido", paramIdRecorrido,
                    "@Fecha", paramFecha,
                    "@HoraInicio", paramHoraInicio
                );
            }
            catch
            {
                throw;
            }
        }

        public static void UpdAgenda(int paramIdAgenda, int paramIdRecorrido, DateTime paramFecha, DateTime paramHoraInicio, string paramEstado)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_agenda_actualizar",
                    "@IdAgenda", paramIdAgenda,
                    "@IdRecorrido", paramIdRecorrido,
                    "@Fecha", paramFecha,
                    "@HoraInicio", paramHoraInicio,
                    "@Estado", paramEstado
                );
            }
            catch
            {
                throw;
            }
        }

        public static void DelAgenda(int paramIdAgenda)
        {
            try
            {
                MetodosDatos.ExecuteNonQuery("sp_agenda_cancelar",
                    "@IdAgenda", paramIdAgenda
                );
            }
            catch
            {
                throw;
            }
        }

        public static AgendaVO GetAgendaById(int paramIdAgenda)
        {
            try
            {
                DataSet dsAgenda = MetodosDatos.ExecuteDataSet("sp_agenda_conseguir", "@IdAgenda", paramIdAgenda);

                if (dsAgenda.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsAgenda.Tables[0].Rows[0];
                    return new AgendaVO(dr);
                }
                else
                {
                    return new AgendaVO();
                }
            }
            catch
            {
                throw;
            }
        }
    }

}
