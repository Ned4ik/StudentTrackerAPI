using StudentAPI.Dto;

namespace StudentAPI.Helper
{
    public class FilterCourse
    {
        public StudentDto StudentDto { get; set; }
        public IEnumerable<FilterCourseLessons> FilterCourseLessons { get; set; }
    }

    public class FilterCourseLessons {
        public LessonDto LessonDto { get; set; }
        public bool LessonVisit { get; set; }
    }


}
