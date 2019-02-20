using RuzApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuzApi.Mapper
{
    public class Mapper
    {
        public static List<Lesson> LessonRuzToLesson(List<RuzLesson> lessons, string email)
        {
            List <Lesson> Lessons = new List<Lesson>();
            foreach (var item in lessons)
                Lessons.Add(new Lesson
                {
                    Auditorium = item.auditorium,
                    NumLesson = GetNumLesson(item.beginLesson),
                    Date = DateTime.Parse(item.date).ToString("d"),
                    Lecturer = item.lecturer,
                    Name = item.discipline,
                    Status = "FromJson",
                    Type = item.kindOfWork,
                    Email = email
                });
            return Lessons;
        }

        private static int GetNumLesson(string beginLesson)
        {
            string[] time = new string[] {  "09:00" , "10:30", "12:10", "13:40", "15:10", "16:40", "18:10", "19:40" };
            for (var i = 0; i < 8; i++)
                if (beginLesson == time[i])
                    return i - 1;
            return 0;
        }
    }
}
