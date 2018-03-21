using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.IO.Compression;


namespace ConsoleApplication1
{   /// <summary>
    /// Класс отвечающий за подключение к БД
    /// </summary>
    class DbContext
    {
        /// <summary>
        /// Строка подключения
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SqlConnection conn { get; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectionString"></param>
        public DbContext(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }
        /// <summary>
        /// Открытие соединения с БД
        /// </summary>
        public void openConnect()
        {
          conn.Open();
          Console.WriteLine("Подключение Открыто");
        }
        /// <summary>
        /// Закрытие соединения с БД
        /// </summary>
        public void closeConnect()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
               conn.Close();
               Console.WriteLine("Подключение Закрыто");
            }
        }
    }
    }

  


