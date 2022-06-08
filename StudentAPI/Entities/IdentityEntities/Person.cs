using Microsoft.AspNetCore.Identity;


namespace StudentAPI.Entities.IdentityEntities
{
    public abstract class Person : IdentityUser<Guid>
    {
        //Инициализация таблицы Person

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Create { get; set; } = DateTime.Now;
    }
}
