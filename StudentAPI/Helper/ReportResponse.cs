using StudentAPI.Dto;

namespace StudentAPI.Helper
{
    public class ReportResponse
    {
        public StudentLessonDto StudentLessonDto { get; set; }
        public GroupDto GroupDto { get; set; }
        public CourseDto CourseDto { get; set; }
    }
}
