using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Isu.Services.Students;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class IsuExtraService : IIsuExtraService
    {
        private readonly List<Ognp> _ognpList = new List<Ognp>();

        public void AddStudentToGroup(StudyGroup group, AdvancedStudent student)
        {
            group.AddStudent(student);
            student.StudentTimetable = group.GetGroupTimetable();
        }

        public List<Student> GetStudentsWithoutOgnp(StudyGroup group)
        {
            List<Student> comparator = group.Students;

            return (from ognp in _ognpList
                from stream in ognp.GetStreamsList()
                select stream.GetStreamStudents()
                into streamStudents
                from groupStudent in comparator
                where !streamStudents.Contains(groupStudent)
                select groupStudent).ToList();
        }

        public void EnrollStudentToOgnp(Ognp ognp, AdvancedStudent student)
        {
            if (ognp.Megafaculty == student.StudentFaculty)
            {
                throw new OgnpException("Student can't enroll his faculty OGNP.");
            }

            foreach (Stream stream in ognp.GetStreamsList())
            {
                Timetable streamTimetable = stream.GetStreamTimetable();
                bool flag = true;
                for (int i = 0; i < Consts.WorkdayAmount; ++i)
                {
                    if (streamTimetable.GetWeekdayTimetable(i + 1).Count == 0)
                    {
                        continue;
                    }

                    List<Lesson> streamWeekdayTimetable = streamTimetable.GetWeekdayTimetable(i + 1);
                    for (int j = 0; j < streamWeekdayTimetable.Count; ++j)
                    {
                        Lesson lesson = streamWeekdayTimetable[j];
                        if (student.StudentTimetable.LessonIsInTimetable(i + 1, lesson.LessonConsecutiveNumber))
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (!flag)
                    {
                        break;
                    }
                }

                if (flag)
                {
                    for (int i = 0; i < Consts.WorkdayAmount; i++)
                    {
                        if (streamTimetable.GetWeekdayTimetable(i + 1).Count == 0)
                        {
                            continue;
                        }

                        student.StudentTimetable.GetWeekdayTimetable(i + 1)
                            .AddRange(streamTimetable.GetWeekdayTimetable(i + 1));
                    }
                }
            }

            student.AddOgnp(ognp);
        }

        public void DeleteStudentFromOgnp(Ognp ognp, AdvancedStudent student)
        {
            bool flag = false;
            Stream studentStream = null;
            foreach (Stream stream in ognp.GetStreamsList())
            {
                if (stream.GetStreamStudents().Contains(student))
                {
                    studentStream = stream;
                    flag = true;
                }
            }

            if (!flag)
            {
                throw new OgnpException("No such student in this OGNP.");
            }

            for (int i = 0; i < Consts.WorkdayAmount; ++i)
            {
                List<Lesson> weekdayTimtable = studentStream.GetStreamTimetable().GetWeekdayTimetable(i + 1);
                if (weekdayTimtable.Count == 0)
                {
                    continue;
                }

                foreach (Lesson lesson in weekdayTimtable)
                {
                    student.StudentTimetable.GetWeekdayTimetable(i + 1).Remove(lesson);
                }
            }

            student.DeleteOgnp(ognp);
        }

        public ReadOnlyCollection<Stream> GetOgnpStreams(Ognp ognp)
        {
            return ognp.GetStreamsList();
        }

        public Ognp AddNewOgnp(string faculty, string name)
        {
            var newOgnp = new Ognp(faculty, name);
            _ognpList.Add(newOgnp);
            return newOgnp;
        }

        public void AddNewMegaFaculty(string name, List<char> groupSymbols)
        {
            MegaFaculties.AddNewMegaFaculty(name, groupSymbols);
        }
    }
}