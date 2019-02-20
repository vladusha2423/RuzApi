using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RuzApi.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Auditorium { get; set; }
        public int NumLesson { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Lecturer { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }

        
        public static bool IsEq(Lesson a, Lesson b)
        {
            if (a.Date == b.Date && a.Name == b.Name && a.NumLesson == b.NumLesson)
            {
                return true;
            }
            return false;
        }

        public static DateTime GetDateEnd(string date)
        {
            return DateTime.Parse(IsDate(date)).AddDays(6 - (int)DateTime.Now.DayOfWeek);
        }
        public static DateTime GetDateBegin(string date)
        {
            return DateTime.Parse(IsDate(date)).AddDays(1 - (int)DateTime.Now.DayOfWeek);
        }
        public static string IsDate(string date)
        {
            if (date == null || !TextIsDate(date))
                return DateTime.Now.ToString("d");
            else return date;
        }

        static bool TextIsDate(string text)
        {
            DateTime scheduleDate;

            if (DateTime.TryParse(text, out scheduleDate))
            {
                return true;
            }
            return false;
        }

    }
}
