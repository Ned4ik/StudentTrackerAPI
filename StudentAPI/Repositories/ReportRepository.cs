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

        //public IEnumerable<ReportResponse> GetStudentPassByGroup(string Id)
        //{
        //    var result = new List<ReportResponse>();
        //    foreach (var stlesson in _db.StudentLessons.Include(i => i.Student).ThenInclude(i => i.Group).Where(w => w.Gr.Id == Guid.Parse(Id)).ToList())
        //    {
        //        result.Add(new LessonResponse()
        //        {
        //            StudentLessonDto = _db.StudentLessons.Include(i => i.Student).Include(i => i.Lesson).FirstOrDefault(w => w.Id == stlesson.Id).ToDto<StudentLesson, StudentLessonDto>(_mapper),
        //            GroupDto = stlesson.Student.Group.ToDto<Group, GroupDto>(_mapper),
        //        });
        //    }
        //    return result;
        //}
    }
}
