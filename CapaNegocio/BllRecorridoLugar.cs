using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllRecorridoLugar
    {
        public static string InsLugar(int IdRecorrido, int IdLugar)
        {
            
            try
            {
                
                DalRecorridoLugar.InsRecorridoLugar(IdRecorrido, IdLugar);
                return "Lugar agregado al recorrido";
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } // del INSERT

        
        public static string DelRecorridoLugar(int IdRecorridoLugar)
        {
            try
            {
                    DalRecorridoLugar.DelRecorridoLugar(IdRecorridoLugar);
                    return "1";
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        
        public static List<RecorridoLugarVO> GetLstRecorridoLugar(int IdRecorrido)
        {
            List<RecorridoLugarVO> Lst = new List<RecorridoLugarVO>();
            try
            {
                Lst = DalRecorridoLugar.GetListRecorridoLugar(IdRecorrido);
                return Lst;
            }
            catch (Exception)
            {
                return Lst; // Lista vacía en caso de error
            }
        }
    }
}
