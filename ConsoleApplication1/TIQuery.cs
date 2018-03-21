using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class TIQuery: AbstractQuery
    {
        /// <summary>
        /// Скрипт для БД
        /// </summary>
        private string query = "select * from allti";

        /// <summary>
        /// метод формирования данных из бд для Телеизмерений
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        override public List<string> getAll(SqlConnection conn)
        {
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            List<string> result = new List<string>();
            result.Add(@"""ID"";""Category"";""OutOfWork"";""EObject"";""Name"";""Abbr"";""Type"";""Unit"";""NFP"";""VFP"";""NAP"";""VAP"";""NPP"";""VPP"";""CutOffTS"";""SFactor"";""TRenewalTime"";""TPlanDev"";""TEstimeDev"";""TDubldev"";""RenEn"";""LeapEn"";""PDevEn"";""EstimDevEn"";""CutOffEn"";""DDiscrEn"";""FBoundEn"";""RDup1"";""SDup1"";""RDup2"";""SDup2"";""RDup3"";""SDup3"";""DRepID"";""SRepID"";""EstimID"";""PlanID"";""FcastID"";""DRepEn"";""EctimEn"";""PlanEn"";""FcastEn"";""Signif"";""Aperture"";""TleapE"";""TleapQ"";""Scale"";""LeapTI1"";""LeapTI2"";""LeapTI3"";""TNAP"";""TVAP"";""TNPP"";""TVPP"";""OIsrc"";""TProtocol"";""DNAP"";""DVAP"";""DNPP"";""DVPP"";""NormalValue"";""EnableIntegDeadBand"";""Enable_IMTS"";""Sqz"";""SqzPercentOn"";""SqzTMin"";""SqzWidthPercent"";""SqzTMax"";""MRID"";""Comment"";""rowguid""");
            string[] items = new string[71];

            while (reader.Read())
            {
                for (int i = 0; i < 71; i++)
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
