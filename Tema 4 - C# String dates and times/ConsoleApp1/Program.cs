using System;
using System.Globalization;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Text to modify !";
            Console.WriteLine(s);
            Console.WriteLine(s.Replace('o', '0'));
            string sup = s.ToUpper();
            Console.WriteLine(sup);
            //--------------------------
            StringBuilder sb = new StringBuilder("String builder text");
            Console.WriteLine(sb);
            sb.Replace('i', '1');
            Console.WriteLine(sb);
            //--------------------------------
            string colors = "green,white,blue,yellow,red";
            var colorArr = colors.Split(',');
            foreach(var color in colorArr)
            {
                Console.WriteLine(color);
            }
            string newColors = string.Join(", ", colorArr);
            Console.WriteLine(newColors);

            TimeSpan ts = new TimeSpan(7, 30, 0);
            Console.WriteLine(ts.TotalMilliseconds);

            DateTime dt = new DateTime(2021, 6, 6);
            Console.WriteLine(dt.DayOfWeek);

            DateTimeOffset dtoff = new DateTimeOffset(dt);
            Console.WriteLine(dtoff);
            Console.WriteLine(dtoff.LocalDateTime + " " + dtoff.LocalDateTime.Kind);

            TimeZone tz = TimeZone.CurrentTimeZone;
            Console.WriteLine(tz.IsDaylightSavingTime(dt));

            CultureInfo us = CultureInfo.GetCultureInfo("en-US");
            CultureInfo ru = CultureInfo.GetCultureInfo("ru-RU");
            Console.WriteLine(1024.ToString("C", us));
            Console.WriteLine(1024.ToString("C", ru));
        }
    }
}
