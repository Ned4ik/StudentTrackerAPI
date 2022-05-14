using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StudentAPI.Data;
using StudentAPI.Dto;
using StudentAPI.Entities;
using StudentAPI.Entities.IdentityEntities;
using StudentAPI.Helper;

namespace StudentAPI.Repositories
{
    public class SearchRepository
    {
        private readonly StudentDataContext _db;
        private readonly UserManager<Person> _persons;
        private readonly IMapper _mapper;

        public SearchRepository(StudentDataContext db, IMapper mapper, UserManager<Person> persons)
        {
            _db = db;
            _mapper = mapper;
            _persons = persons;
        }

        public IEnumerable<CourseDto> GetAllCourse()
        {
            return _db.Courses.ToList().ToListDto<Course, CourseDto>(_mapper);
        }

        public IEnumerable<GroupDto> GetAllGroup()
        {
            return _db.Groups.ToList().ToListDto<Group, GroupDto>(_mapper);
        }

        public IEnumerable<LessonDto> GetAllLessons()
        {
            return _db.Lessons.ToList().ToListDto<Lesson, LessonDto>(_mapper);
        }
    }
}
