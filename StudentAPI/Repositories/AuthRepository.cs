using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Dto;
using StudentAPI.Entities;
using StudentAPI.Entities.IdentityEntities;
using StudentAPI.Helper;

namespace StudentAPI.Repositories
{
    public class AuthRepository
    {
        private readonly UserManager<Person> _persons;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly StudentDataContext _db;

        public AuthRepository(UserManager<Person> persons, IMapper mapper, IConfiguration configuration, StudentDataContext db)
        {
            _persons = persons;
            _mapper = mapper;
            _configuration = configuration;
            _db = db;
        }
        public async Task<AuthorizateResponse<TDto>> Login<TEntity, TDto>(string email, string password) where TEntity : Person
        {

            var findUser = await _persons.FindByEmailAsync(email);
            if (findUser is null)
            {
                throw new Exception("Account not found");
            }

            bool passwordValid = await _persons.CheckPasswordAsync(findUser, password);
            if (passwordValid)
            {
                  return JwtHelper.CreateToken<TEntity, TDto>(findUser as TEntity, false, _persons, _mapper, _configuration);
            }
            throw new Exception("Password is not valid");
        }

        public async Task<TDto> Get<TEntity, TDto>(string email) where TEntity : Person
        {
            var findUser = await _persons.FindByEmailAsync(email);
            if (findUser is null)
            {
                throw new Exception("Account not found");
            }

            return (findUser as TEntity).ToDto<TEntity, TDto>(_mapper);
        }

        public async Task<IEnumerable<FilterCourse>> FilterCourseAsync(string courseId)
        {
            return _db.Students.Select(s => new FilterCourse()
            {
                StudentDto = s.ToDto<Student, StudentDto>(_mapper),
                FilterCourseLessons = _db.StudentLessons.Include(i => i.Student).Include(i => i.Lesson).ThenInclude(i => i.Course).Where(f => f.Student.Id == s.Id && f.Lesson.Course.Id == Guid.Parse(courseId)).Select(ss => new FilterCourseLessons()
                {
                    LessonDto = ss.Lesson.ToDto<Lesson, LessonDto>(_mapper),
                    LessonVisit = ss.LessonVisit,
                }).ToList(),

            });
        }

        public async Task<IEnumerable<FilterCourse>> FilterGroupAsync(string groupId)
        {
            return _db.Students.Include(i => i.Group).Select(s => new FilterCourse()
            {
                StudentDto = s.ToDto<Student, StudentDto>(_mapper),
                FilterCourseLessons = _db.StudentLessons.Include(i => i.Student).Include(i => i.Lesson).ThenInclude(i => i.Course).Where(f => f.Student.Id == s.Id && f.Student.Group.Id == Guid.Parse(groupId)).Select(ss => new FilterCourseLessons()
                {
                    LessonDto = ss.Lesson.ToDto<Lesson, LessonDto>(_mapper),
                    LessonVisit = ss.LessonVisit,
                }).ToList(),

            });
        }

        public async Task<FilterCourse> FilterStudentAsync(string email)
        {
            var findUser = await _persons.FindByEmailAsync(email) as Student;
            if (findUser is null)
            {
                throw new Exception("Student not found");
            }

            //return _db.Students.Include(i => i.Group).FirstOrDefault(f => f.Id == findUser.Id)
            return new FilterCourse()
            {
                StudentDto = _db.Students.Include(i => i.Group).FirstOrDefault(f => f.Id == findUser.Id).ToDto<Student, StudentDto>(_mapper),
                FilterCourseLessons = _db.StudentLessons.Include(i => i.Student).Include(i => i.Lesson).ThenInclude(i => i.Course).Where(f => f.Student.Id == findUser.Id).Select(ss => new FilterCourseLessons()
                {
                    LessonDto = ss.Lesson.ToDto<Lesson, LessonDto>(_mapper),
                    LessonVisit = ss.LessonVisit,
                }).ToList(),
            };
        }
    }
}
