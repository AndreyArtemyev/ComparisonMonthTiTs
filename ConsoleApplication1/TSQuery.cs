using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ConsoleApplication1
{
    class TSQuery: AbstractQuery
    {   /// <summary>
        /// 
        /// </summary>
        private string query = "select * from defts";
        /// <summary>
        /// метод формирования данных из бд для Телесигналов
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        override public List<string> getAll(SqlConnection conn)
        {
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            List<string> result = new List<string>();
            result.Add(@"""ID"";""Category"";""Name"";""Abbr"";""EObject"";""Inv"";""OutOfWork"";""Cert"";""RTUID"";""Addr"";""Mask"";""Grp"";""OIsrc"";""TProtocol"";""TSType"";""NFP"";""VFP"";""InLen"";""AdmissChngRate"";""FastChngLim"";""AdmissChngStep"";""NormalValue"";""Enable_IMTS"";""NormalStateMon"";""SqzTmax"";""StateMon"";""MRID"";""GIControl"";""Comment"";""rowguid""");

            string[] items = new string[30];

            while (reader.Read())
            {
                for (int i = 0; i < 30; i++)
                {
                    items[i] = '"' + GetNull(reader.GetValue(i)) + '"';
                    
                }
                result.Add(string.Join(";", items));
            }
            reader.Close();
            return result;
        }
    }
}
