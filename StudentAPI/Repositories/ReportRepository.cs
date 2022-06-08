using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Entities.IdentityEntities;
using StudentAPI.Helper;

namespace StudentAPI.Repositories
{
    public class ReportRepository
    {
        private readonly StudentDataContext _db;
        private readonly UserManager<Person> _persons;
        private readonly IMapper _mapper;

        public ReportRepository(StudentDataContext db, IMapper mapper, UserManager<Person> persons)
        {
            _db = db;
            _mapper = mapper;
            _persons = persons;
        }
    }
}
