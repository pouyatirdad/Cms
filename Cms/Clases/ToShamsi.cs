using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;


namespace Cms
{
    public static class ToShamsi
    {
        public static string toShamsi(this DateTime time)
        {
            PersianCalendar persian = new PersianCalendar();
            return persian.GetYear(time) + "/" + persian.GetMonth(time).ToString("00") + "/" + persian.GetDayOfMonth(time).ToString("00");
        }
    }
}