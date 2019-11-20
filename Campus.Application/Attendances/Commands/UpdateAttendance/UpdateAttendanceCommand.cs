using System;

using MediatR;

namespace Campus.Application.Attendances.Commands.UpdateAttendance
{
    public class UpdateAttendanceCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int LessonId { get; set; }
        public int DayOfWeekId { get; set; }
        public int WeatherTypeId { get; set; }
        public int StudentsCount { get; set; }

        public UpdateAttendanceCommand()
        {
            if (Date == default)
            {
                Date = DateTime.Now;
            }
        }
    }
}
