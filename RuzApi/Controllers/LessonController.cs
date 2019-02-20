using Microsoft.AspNetCore.Mvc;
using RuzApi.Models;
using RuzApi.Servise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuzApi.Controllers
{
    [Route("api/[controller]")]
    public class LessonController: Controller
    {
        private readonly ApiContext _context;

        public LessonController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("{email}&{date}")]
        public List<Lesson> Get(string email, string date)
        {
            List<Lesson> lessons = Mapper.Mapper.LessonRuzToLesson(Timetable.GetListLesson(Lesson.GetDateBegin(date), Lesson.GetDateEnd(date), email), email),
                deleted = _context.Lessons.Where(l => l.Status == "Delete").ToList();
            lessons = List.EditList(lessons, deleted);
            lessons.AddRange(_context.Lessons.Where(l => l.Status == "Add" && l.Email == email &&
                                                    DateTime.Parse(l.Date) >= Lesson.GetDateBegin(date) && DateTime.Parse(l.Date) <= Lesson.GetDateEnd(date)));
            return lessons;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Lesson item)
        {
            if (item == null)
                return BadRequest();
            var result = _context.Lessons.Add(item);
            _context.SaveChanges();
            return Ok(result.Entity);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Lesson item)
        {
            if (item == null)
                return BadRequest();
             List<Lesson> lessons = Mapper.Mapper.LessonRuzToLesson(Timetable.GetListLesson(Lesson.GetDateBegin(item.Date), Lesson.GetDateEnd(item.Date), item.Email), item.Email),
                 deleted = _context.Lessons.Where(l => l.Status == "Delete").ToList();
            lessons.AddRange(_context.Lessons.Where(l => l.Status == "Add"));
            Lesson lesson = List.FindLesson(lessons, item);
            if (lesson.Status == "FromJson")
                _context.Lessons.Add(new Lesson { Name = item.Name, Date = item.Date, NumLesson = item.NumLesson, Status = "Delete" });
            else
                _context.Lessons.Remove(lesson);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Lesson item)
        {
            if (item == null || item.Id == null || item.Id.ToString() == "00000000-0000-0000-0000-000000000000")
                return BadRequest();
            _context.Lessons.Update(item);
            _context.SaveChanges();
            return Ok();
        }

        private string GUIDToString(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
