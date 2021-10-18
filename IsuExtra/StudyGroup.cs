using System;
using Isu.Services.Groups;

namespace IsuExtra
{
    public class StudyGroup : Group
    {
        private Timetable _groupTimetable;
        public StudyGroup(GroupName groupName, Timetable groupTimetable)
            : base(groupName)
        {
            _groupTimetable = groupTimetable;
            GroupFaculty = new MegaFaculty().GetMegaFacultyByGroupName(groupName);
        }

        public string GroupFaculty { get; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((StudyGroup)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_groupTimetable, GroupFaculty);
        }

        public Timetable GetGroupTimetable()
        {
            return _groupTimetable;
        }

        protected bool Equals(StudyGroup other)
        {
            return Equals(_groupTimetable, other._groupTimetable) && GroupFaculty == other.GroupFaculty;
        }
    }
}