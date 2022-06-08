namespace StudentAPI.Entities
{
    public class Schedule : BaseModel<Guid>
    {
        //Инициализация таблицы Schedule

        public DateTime Date { get; set; }
        public ICollection<ScheduleCourse> ScheduleCourses { get; set; }
    }
}
