using System;
using System.Collections.Generic;
using Isu.Services.Course;
using Isu.Services.Groups;
using Isu.Services.Students;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService :
        IIsuService
    {
        private readonly List<Group> _isuStruct = new List<Group>();

        public Student AddStudent(Group group, string name)
        {
            if (_isuStruct[_isuStruct.IndexOf(group)].IsFull())
            {
                throw new IsuException("Group is full. Unable to add new student.");
            }

            var newStudent = new Student(group.GroupName.Name, name)
            {
                Id = CreateNewId(name),
            };
            _isuStruct[_isuStruct.IndexOf(group)].Students.Add(newStudent);

            return newStudent;
        }

        public Student GetStudent(int id)
        {
            foreach (Group group in _isuStruct)
            {
                foreach (Student student in group.Students)
                {
                    if (student.Id == id)
                    {
                        return student;
                    }
                }
            }

            throw new IsuException("Can't get student with such ID");
        }

        public List<Student> FindStudents(GroupName groupName)
        {
            foreach (Group group in _isuStruct)
            {
                if (group.GroupName.Name == groupName.Name)
                {
                    return group.Students;
                }
            }

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var students = new List<Student>();
            foreach (Group group in _isuStruct)
            {
                if ((int)char.GetNumericValue(group.GroupName.Name[2]) == courseNumber.Number)
                {
                    students.AddRange(group.Students);
                }
            }

            return students;
        }

        public Student FindStudent(string name)
        {
            foreach (Group group in _isuStruct)
            {
                foreach (Student student in group.Students)
                {
                    if (student.Name == name)
                    {
                        return student;
                    }
                }
            }

            return null;
        }

        public Group AddGroup(string name)
        {
            var newGroupName = new GroupName(name);
            var newGroup = new Group(newGroupName);
            _isuStruct.Add(newGroup);
            return newGroup;
        }

        public Group FindGroup(GroupName groupName)
        {
            foreach (Group group in _isuStruct)
            {
                if (group.GroupName.Name == groupName.Name)
                {
                    return group;
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var groups = new List<Group>();
            foreach (Group group in _isuStruct)
            {
                if ((int)char.GetNumericValue(group.GroupName.Name[2]) == courseNumber.Number)
                {
                    groups.Add(group);
                }
            }

            return groups;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            if (_isuStruct[_isuStruct.IndexOf(newGroup)].IsFull())
            {
                throw new IsuException("Unable to change student's group. Group is full.");
            }

            foreach (Group group in _isuStruct)
            {
                if (group.GroupName.Name == student.GroupName)
                {
                    group.Students.Remove(student);
                }
                else if (group.GroupName.Name == newGroup.GroupName.Name)
                {
                    group.Students.Add(student);
                }
            }

            student.GroupName = newGroup.GroupName.Name;
        }

        private int CreateNewId(string name)
        {
            int id = 0;
            var rand = new Random();
            for (int i = 0; i < name.Length - 1; ++i)
            {
                id += (int)char.GetNumericValue(name[i]) + (int)char.GetNumericValue(name[i + 1]) +
                      rand.Next(1000, 100000);
            }

            return id + rand.Next(100000, 900000);
        }
    }
}