using System;

using MediatR;

namespace Campus.Application.Attendances.Commands.CreateAttendance
{
    public class CreateAttendanceCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int GroupId { get; set; }
        public int LectorSubjectId { get; set; }
        public int DayOfWeekId { get; set; }
        public int WeatherTypeId { get; set; }
        public int StudentsCount { get; set; }

        public CreateAttendanceCommand()
        {
            if(Date == default)
            {
                Date = DateTime.Now;
            }
        }
    }
}
