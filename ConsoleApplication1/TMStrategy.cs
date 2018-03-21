using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Configuration;

namespace ConsoleApplication1
{
    class TMStrategy
    {
        /// <summary>
        /// SQL скрипт
        /// </summary>
        private string SqlExpression { get; set; }
        /// <summary>
        /// Путь к исходному файлу
        /// </summary>
        public string SpecifiedPath { get; set; }
        /// <summary>
        /// Имя файла
        /// </summary>
        public string NameFile { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="specifiedPath">Путь к исходному файлу</param>
        public TMStrategy (string specifiedPath)
        {
            SpecifiedPath = specifiedPath;
        }
        
        /// <summary>
        /// Присвоение переменнной даты создания
        /// </summary>
        public string GetDate
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMdd");
            }
        }
        /// <summary>
        /// Метод формирования архива с исходным файлом
        /// </summary>
        /// <param name="toStore">Массив данных для записи в файл</param>
        /// <param name="namefile">Имя файла</param>
        public void store(List<string> getAll, string NameFile)
        {
            using (FileStream zipToOpen = new FileStream(ConfigurationManager.AppSettings["specifiedPath"] + NameFile + GetDate + ".zip", FileMode.Create))
            {
                // Инициализирует новый экземпляр ZipArchive класса из указанного потока
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    //Создает пустую запись, которая имеет указанные путь и имя записи в ZIP архиве.
                    ZipArchiveEntry readmeEntry = archive.CreateEntry(NameFile + GetDate + ".csv");

                    //Поток для записи 
                    using (StreamWriter fileWriter = new StreamWriter(readmeEntry.Open(), Encoding.Default))
                    {

                        foreach (string str in getAll)
                        {
                            fileWriter.WriteLine(str);
                        }
 
                        fileWriter.Close();
                    }
                }
                zipToOpen.Close();
            }
        }
    }
}
