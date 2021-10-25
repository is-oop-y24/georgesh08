using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IsuExtra
{
    public class Stream
    {
        private readonly List<AdvancedStudent> _streamStudents = new List<AdvancedStudent>();
        private Timetable _timetable;
        public Stream(Timetable timetable)
        {
            _timetable = timetable;
            StreamNumber = StreamNumberGenerator.GenerateNewStreamNumber();
        }

        public int StreamNumber { get; }

        public ReadOnlyCollection<AdvancedStudent> GetStreamStudents()
        {
            return _streamStudents.AsReadOnly();
        }

        public Timetable GetStreamTimetable()
        {
            return _timetable;
        }

        public void AddLesson(int weekday, Lesson lesson)
        {
            _timetable.AddLesson(weekday, lesson);
        }

        public bool IsFull()
        {
            return _streamStudents.Count == Consts.MaxStudentsPerStream;
        }
    }
}