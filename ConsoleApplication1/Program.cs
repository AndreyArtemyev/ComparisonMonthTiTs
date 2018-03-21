using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


           DbContext ConnectWithOikedit = new DbContext(ConfigurationManager.ConnectionStrings
                                ["ConsoleApplication1.Properties.Settings.ConnectionString"].ConnectionString);
            ConnectWithOikedit.openConnect();
            AbstractQuery query = new TIQuery();
            TMStrategy tms = new TMStrategy((ConfigurationManager.AppSettings["specifiedPath"]));
            Console.WriteLine("Начало записи ТИ");
            tms.store(query.getAll(ConnectWithOikedit.conn), ConfigurationManager.AppSettings["nameFileTI"]);
            Console.WriteLine("Конец записи ТИ");
            Console.WriteLine("Начало записи ТС");
            query = new TSQuery();
            tms.store(query.getAll(ConnectWithOikedit.conn), ConfigurationManager.AppSettings["nameFileTS"]);
            Console.WriteLine("Конец записи ТС");
            ConnectWithOikedit.closeConnect();

        }
    }
}
