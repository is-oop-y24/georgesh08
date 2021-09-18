using System.Collections.Generic;
using Isu.Services.Students;

namespace Isu.Services.Groups
{
    public class Group
    {
        private const int MaxCapacity = 3;
        private List<Student> _students = new List<Student>(MaxCapacity); // Max capacity equals 3 only for tests
        private GroupName _groupName;

        public Group(GroupName groupName)
        {
            _groupName = groupName;
        }

        public Group(GroupName groupName, List<Student> students)
        {
            _groupName = groupName;
            _students = students;
        }

        public GroupName GroupName => _groupName;

        public List<Student> Students => _students;

        public bool IsFull()
        {
            return _students.Count == MaxCapacity;
        }
    }
}