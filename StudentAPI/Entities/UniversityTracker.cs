using StudentAPI.Entities.IdentityEntities;

namespace StudentAPI.Entities
{
    public class UniversityTracker : BaseModel<Guid>
    {
        public bool Visit { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
