using System;

namespace Campus.Domain.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int LessonId { get; set; }
        public int DayOfWeekId { get; set; }
        public int WeatherTypeId { get; set; }
        public int StudentsCount { get; set; }

        public Lesson Lesson { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public WeatherType WeatherType { get; set; }
    }
}
