namespace StudentAPI.Entities.IdentityEntities
{
    public class Teacher : Person
    {
        //Инициализация таблицы Teacher
        public ICollection<ScheduleCourse> ScheduleCourses { get; set; }
    }
}
