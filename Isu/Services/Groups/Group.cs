using System.Collections.Generic;
using Isu.Services.Students;
using Isu.Tools;

namespace Isu.Services.Groups
{
    public class Group
    {
        private readonly GroupName _groupName;
        private List<Student> _students = new List<Student>();

        public Group(GroupName groupName)
        {
            _groupName = groupName;
        }

        public GroupName GroupName => _groupName;

        public List<Student> Students => _students;

        public bool IsFull()
        {
            return _students.Count == Constants.MaxGroupCapacity;
        }

        public void AddStudent(Student student)
        {
            if (IsFull())
            {
                throw new IsuException("Group is full. Unable to add new student.");
            }

            _students.Add(student);
        }
    }
}