using System;
using System.Linq.Expressions;

using Campus.Domain.Entities;

namespace Campus.Application.Lessons.Queries.DataTransferObjects
{
    public class LessonDto
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int LectorId { get; set; }
        public string LectorName { get; set; }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public string LessonTypeName { get; set; }

        public static Expression<Func<Lesson,LessonDto>> Projection
        {
            get
            {   
                return x => new LessonDto
                {
                    Id = x.Id,
                    GroupId = x.GroupId,
                    GroupName = x.Group !=null?x.Group.Name:string.Empty,
                    LectorId = x.LectorSubject !=null?x.LectorSubject.LectorId:default,
                    LectorName = x.LectorSubject != null ? (x.LectorSubject.Lector != null ? 
                                $"{x.LectorSubject.Lector.LastName} {x.LectorSubject.Lector.FirstName} {x.LectorSubject.Lector.FirstName}"
                                : string.Empty) 
                                : string.Empty,
                    LessonTypeName = x.LectorSubject!=null ? (x.LectorSubject.LessonType!=null? x.LectorSubject.LessonType.Name : string.Empty) : string.Empty,
                    SubjectId = x.LectorSubject != null ? x.LectorSubject.SubjectId : default,
                    SubjectName = x.LectorSubject != null ? (x.LectorSubject.Subject != null ?
                                x.LectorSubject.Subject.Name : string.Empty)
                                : string.Empty
                };
            }
        }
    }
}
