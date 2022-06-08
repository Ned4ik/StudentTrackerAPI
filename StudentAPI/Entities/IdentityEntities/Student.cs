﻿using Microsoft.AspNetCore.Identity;

namespace StudentAPI.Entities.IdentityEntities
{
    public class Student : Person
    {
        //Инициализация таблицы Student

        public int TimePass { get; set; }
        public string StudentCard { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }


        public ICollection<StudentLesson> StudentLessons { get; set; }
        public ICollection<UniversityTracker> UniversityTrackers { get; set; }

    }
}
