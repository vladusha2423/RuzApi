using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuzApi.Models
{
    public class List
    {
        public static List<Lesson> EditList(List<Lesson> lessons, List<Lesson> deleted)
        {
            List<Lesson> lessonsUse = new List<Lesson>();
            bool flag;
            foreach (var item in lessons)
            {
                flag = true;
                foreach (var itemDel in deleted)
                    if (item.Name == itemDel.Name && item.Date == itemDel.Date && item.NumLesson == itemDel.NumLesson)
                        flag = false;
                if (flag)
                    lessonsUse.Add(item);
            }
            return lessonsUse;
        }

        public static Lesson FindLesson(List<Lesson> lessons, Lesson lesson)
        {
            foreach (var item in lessons)
                if (item.Name == lesson.Name && item.Date == lesson.Date && item.NumLesson == lesson.NumLesson)
                    return item;
            return null;

        }
    }
}
