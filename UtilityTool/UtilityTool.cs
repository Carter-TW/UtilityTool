using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityTool
{
    public static class UtilityTool
    {
        public static T? CType<T>(object value) where T : struct
        {
            if (Convert.IsDBNull(value))
            {
                return null;
            }

            return (T?)Convert.ChangeType(value, typeof(T));
        }

        public static string CStr(object value)
        {
            if (Convert.IsDBNull(value))
            {
                return null;
            }

            return value.ToString();
        }

        public static object CNull(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            return value;
        }

        public static object CNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return DBNull.Value;
            }

            return value;
        }

        /// <summary>
        /// 轉民國年
        /// 預設格式為yyy/MM/dd
        /// 字串傳入空值 or null 會直接回傳
        /// </summary>
        /// <param name="value">輸入</param>
        /// <param name="format">想要的輸出格式</param>
        /// <returns></returns>
        public static string CTW(string value, string format = "yyy/MM/dd")
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("zh-tw");
            cultureInfo.DateTimeFormat.Calendar = new System.Globalization.TaiwanCalendar();
            return DateTime.Parse(value).ToString(format, cultureInfo);
        }


        /// <summary>
        /// 轉民國年
        /// 字串傳入空值 or null 會直接回傳
        /// 使用ParseExact轉換格式
        /// </summary>
        /// <param name="value">輸入</param>
        /// <param name="inputFormat">輸入的日期格是非一般DateTime 可以轉換，可以特別註明格式</param>
        /// <param name="outputFormat">想要的輸出格式</param>
        /// <returns></returns>
        public static string CTW(string value, string inputFormat, string outputFormat )
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("zh-tw");
            cultureInfo.DateTimeFormat.Calendar = new System.Globalization.TaiwanCalendar();
            return DateTime.ParseExact(value, inputFormat, null).ToString(outputFormat, cultureInfo);

        }

        /// <summary>
        /// 轉民國年
        /// 預設格式為yyy/MM/dd
        /// </summary>
        /// <param name="value"></param>
        /// <param name="outputFormat"></param>
        /// <returns></returns>
        public static string CTW(DateTime value, string outputFormat = "yyy/MM/dd")
        {
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("zh-tw");
            cultureInfo.DateTimeFormat.Calendar = new System.Globalization.TaiwanCalendar();
            return value.ToString(outputFormat, cultureInfo);

        }

        /// <summary>
        /// 民國轉西元年
        /// inputFormatut 有輸入 會用ParseExact轉換格式
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputFormat"></param>
        /// <returns></returns>
        public static DateTime CAD(string value, string inputFormat = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("傳入參數為空值");
            }

            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("zh-tw");
            cultureInfo.DateTimeFormat.Calendar = new System.Globalization.TaiwanCalendar();
            if (string.IsNullOrEmpty(inputFormat))
            {
                return DateTime.Parse(value, cultureInfo);
            }
            else
            {
                return DateTime.ParseExact(value, inputFormat, cultureInfo);
            }

        }



    }
}
