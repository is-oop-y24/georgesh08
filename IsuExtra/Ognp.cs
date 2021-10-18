using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class Ognp
    {
        private readonly List<Stream> _streamsList = new List<Stream>();

        public Ognp(string name, string megafaculty)
        {
            if (!Consts.ItmoMegafaculties.Contains(megafaculty))
            {
                throw new MegaFacultyExistenceException("No such megafaculty.");
            }

            OgnpName = name;
            Megafaculty = megafaculty;
            for (int i = 0; i < Consts.MaxStreamsAmount; ++i)
            {
                _streamsList.Add(new Stream(new Timetable()));
            }
        }

        public string Megafaculty { get; }
        public string OgnpName { get; }

        public void AddLessonToStream(int streamNumber, Lesson lesson, int weekday)
        {
            _streamsList[streamNumber - 1].AddLesson(weekday, lesson);
        }

        public ReadOnlyCollection<Stream> GetStreamsList()
        {
            return _streamsList.AsReadOnly();
        }
    }
}