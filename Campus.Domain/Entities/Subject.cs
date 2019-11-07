﻿using System.Collections.Generic;

namespace Campus.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<LectorSubject> LectorSubjects { get; set; }
    }
}
