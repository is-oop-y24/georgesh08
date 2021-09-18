using Isu.Services;
using Isu.Services.Groups;
using Isu.Services.Students;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            string groupName = "M3203";
            Group newGroup = _isuService.AddGroup(groupName);
            Student newStudent = _isuService.AddStudent(newGroup, "George Shulyak");
            if (newStudent.GroupName != groupName && newGroup.Students.IndexOf(newStudent) == -1)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group newGroup = _isuService.AddGroup("M3203"); 
                _isuService.AddStudent(newGroup, "George Shulyak");
                _isuService.AddStudent(newGroup, "Kate Klimacheva");
                _isuService.AddStudent(newGroup, "Denis Kholopov");
                _isuService.AddStudent(newGroup, "Alsu Sadykova");
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group newGroup = _isuService.AddGroup("N3203");
                _isuService.AddStudent(newGroup, "George Shulyak");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group currentStudentGroup = _isuService.AddGroup("M3203");
                Student newStudent = _isuService.AddStudent(currentStudentGroup, "George Shulyak");
                Group newGroup = _isuService.AddGroup("M3204");
                _isuService.AddStudent(newGroup, "Kate Klimacheva");
                _isuService.AddStudent(newGroup, "Denis Kholopov");
                _isuService.AddStudent(newGroup, "Alsu Sadykova");
                _isuService.ChangeStudentGroup(newStudent, newGroup);
            });
        }
    }
}