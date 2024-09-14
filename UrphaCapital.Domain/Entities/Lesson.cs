﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrphaCapital.Domain.Entities
{
    public class Lesson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string HomeworkDescription { get; set; }
        public string Video { get; set; }
        public Guid CourseId { get; set; }


        public Course Course { get; set; }
    }
}
