using System.Collections.Generic;
using System.Linq;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class Timetable
    {
        private Dictionary<int, List<Lesson>> _timetable = new Dictionary<int, List<Lesson>>();
        public Timetable()
        {
            for (int i = 0; i < Consts.WorkdayAmount; ++i)
            {
                _timetable.Add(i, new List<Lesson>());
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Timetable)obj);
        }

        public override int GetHashCode()
        {
            return _timetable != null ? _timetable.GetHashCode() : 0;
        }

        public void AddLesson(int weekday, Lesson lesson)
        {
            int index = weekday - 1;
            if (index > Consts.WorkdayAmount || weekday < 0)
            {
                throw new WeekdayException("Weekday out of range");
            }

            if (_timetable[index].Any(les => les.LessonConsecutiveNumber == lesson.LessonConsecutiveNumber))
            {
                throw new LessonException("Already have a lesson at this time");
            }

            _timetable[index].Add(lesson);
        }

        public List<Lesson> GetWeekdayTimetable(int weekday)
        {
            return _timetable[weekday - 1];
        }

        public bool LessonIsInTimetable(int weekday, int lessonNumber)
        {
            return GetWeekdayTimetable(weekday - 1).Any(lesson => lesson.LessonConsecutiveNumber == lessonNumber);
        }

        protected bool Equals(Timetable other)
        {
            return Equals(_timetable, other._timetable);
        }
    }
}