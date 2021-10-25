using System.Collections.Generic;
using System.Linq;
using Isu.Services;
using Isu.Services.Groups;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class MegaFaculties
    {
        private static Dictionary<string, List<char>> _itmoMegafaculties = new Dictionary<string, List<char>>();
        public static string GetMegaFacultyByGroupName(GroupName name)
        {
            foreach (KeyValuePair<string, List<char>> faculty in _itmoMegafaculties)
            {
                if (faculty.Value.Contains(name.Name[Constants.FacultySymbolPos]))
                {
                    return faculty.Key;
                }
            }

            throw new MegaFacultyExistenceException("No such megafaculty.");
        }

        public static List<string> GetItmoMegaFaculties()
        {
            return _itmoMegafaculties.Select(faculty => faculty.Key).ToList();
        }

        public static void AddNewMegaFaculty(string newFaculty, List<char> groupNameAvailableChars)
        {
            _itmoMegafaculties.Add(newFaculty, groupNameAvailableChars);
        }
    }
}