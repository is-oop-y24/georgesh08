using Isu.Services.Groups;
using IsuExtra.Tools;
using NUnit.Framework;

namespace IsuExtra.Tests
{
    public class Tests
    {
        private IIsuExtraService _isuExtraService;

        [SetUp]
        public void Setup()
        {
            _isuExtraService = new IsuExtraService();
        }

        [Test]
        public void AddStudentToHisFacultyOgnp_ThrowException()
        {
            Assert.Catch<IsuExtraException>(() =>
            {
                var newStudent = new AdvancedStudent("M3203", "George");
                var newStudyGroup = new StudyGroup(new GroupName("M3203"), new Timetable());
                _isuExtraService.AddStudentToGroup(newStudyGroup, newStudent);
                var newOgnp = new Ognp("TINT", "Programming");
                _isuExtraService.EnrollStudentToOgnp(newOgnp, newStudent);
            });
        }

        [Test]
        public void GetLessonCollision_ThrowException()
        {
            Assert.Catch<IsuExtraException>(() =>
            {
                var newStudent = new AdvancedStudent("M3203", "George");
                var newTimetable = new Timetable();
                var newLesson = new Lesson(2, 466, "Povyshev V.V.");
                newTimetable.AddLesson(1, newLesson);
                newTimetable.AddLesson(2, newLesson);
                var newStudyGroup = new StudyGroup(new GroupName("M3203"), newTimetable);
                _isuExtraService.AddStudentToGroup(newStudyGroup, newStudent);
                var newOgnp = new Ognp("TINT", "Programming");
                var newLesson2 = new Lesson(2, 322, "Vozianova A.V.");
                newOgnp.AddLessonToStream(1, newLesson2, 2);
                _isuExtraService.EnrollStudentToOgnp(newOgnp, newStudent);
            });
        }

        [Test]
        public void DeleteStudentFromOgnp_StudentDoesntBelongToOgn_ThrowException()
        {
            Assert.Catch<IsuExtraException>(() =>
            {
                var newStudent = new AdvancedStudent("M3203", "George");
                var newOgnp = new Ognp("Programming", "TINT");
                var newOgnp2 = new Ognp("Innovatics", "FTMI");
                _isuExtraService.EnrollStudentToOgnp(newOgnp, newStudent);
                _isuExtraService.DeleteStudentFromOgnp(newOgnp2, newStudent);
            });
        }

        [Test]
        public void CreateOgnpWithInvalidFaculty_ThrowException()
        {
            Assert.Catch<IsuExtraException>(() =>
            {
                var newOgnp = new Ognp("Programming", "LOLKEK");
            });
        }
    }
}