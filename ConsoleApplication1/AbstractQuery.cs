using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApplication1
{  

    abstract class AbstractQuery
    {
        /// <summary>
        /// Метод присаиваивающий пустым строкам NULL
        /// </summary>
        /// <param name="Value"></param>
        /// <returns>строка или NULL</returns>
        protected string GetNull(object Value)
        {

            if (Value is DBNull)
            {
                return "NULL";
            }
            else
            {
                return Value.ToString();
            }
        }
        /// <summary>
        /// Метод формирует массив данных полученных из БД
        /// </summary>
        /// <param name="conn">поток соединения с БД</param>
        /// <returns></returns>
        public abstract List<string> getAll(SqlConnection conn);
    }
}
