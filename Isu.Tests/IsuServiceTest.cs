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
                Student newStudent = _isuService.AddStudent(newGroup, "George Shulyak");
                for (int i = 0; i < Constants.MaxGroupCapacity; ++i)
                {
                    newGroup.AddStudent(newStudent);
                }
                newGroup.AddStudent(newStudent);
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
                for (int i = 0; i < Constants.MaxGroupCapacity; ++i)
                {
                    newGroup.AddStudent(newStudent);
                }
                _isuService.ChangeStudentGroup(newStudent, newGroup);
            });
        }
    }
}