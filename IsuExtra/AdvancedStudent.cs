using System.Collections.Generic;
using System.Collections.ObjectModel;
using Isu.Services.Groups;
using Isu.Services.Students;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class AdvancedStudent : Student
    {
        private List<Ognp> _studentOgnp = new List<Ognp>();
        public AdvancedStudent(string groupName, string name)
            : base(groupName, name)
        {
            StudentFaculty = MegaFaculties.GetMegaFacultyByGroupName(new GroupName(groupName));
        }

        public string StudentFaculty { get; }
        public Timetable StudentTimetable { get; set; }

        public ReadOnlyCollection<Ognp> GetStudentOgnp()
        {
            return _studentOgnp.AsReadOnly();
        }

        public void AddOgnp(Ognp ognp)
        {
            if (_studentOgnp.Count == Consts.OgnpAmountPerStudent)
            {
                throw new OgnpException("Reached maximum amount of OGNP for student.");
            }

            _studentOgnp.Add(ognp);
        }

        public void DeleteOgnp(Ognp ognp)
        {
            _studentOgnp.Remove(ognp);
        }
    }
}