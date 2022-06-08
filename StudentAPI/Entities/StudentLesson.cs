using StudentAPI.Entities.IdentityEntities;

namespace StudentAPI.Entities
{
    public class StudentLesson : BaseModel<Guid>
    {
        //Инициализация таблицы StudentLesson

        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public bool LessonVisit { get; set; }
        public DateTime DateLose { get; set; }
    }
}
