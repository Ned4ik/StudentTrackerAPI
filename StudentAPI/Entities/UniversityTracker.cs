using StudentAPI.Entities.IdentityEntities;

namespace StudentAPI.Entities
{
    public class UniversityTracker : BaseModel<Guid>
    {
        //Инициализация таблицы StudentLesson
        public bool Visit { get; set; }
        public DateTime visitDate { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
