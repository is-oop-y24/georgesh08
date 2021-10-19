using System.Collections.Generic;
using System.Linq;
using Isu.Services;
using Isu.Services.Groups;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class MegaFaculties
    {
        private static List<string> _itmoMegafaculties = new List<string> { "FTF", "TINT", "KTU", "BTINS", "FTMI" };
        public static string GetMegaFacultyByGroupName(GroupName name)
        {
            char facultySymbol = name.Name[Constants.FacultySymbolPos];
            switch (facultySymbol)
            {
                case 'B':
                case 'V':
                case 'Z':
                    return "FTF";
                case 'K':
                case 'M':
                    return "TINT";
                case 'L':
                case 'W':
                    return "BTINS";
                case 'N':
                case 'P':
                case 'R':
                case 'T':
                    return "KTU";
                case 'U':
                    return "FTMI";
            }

            throw new MegaFacultyExistenceException("No such megafaculty in ITMO.");
        }

        public static List<string> GetItmoMegaFaculties()
        {
            return _itmoMegafaculties;
        }

        public void AddNewMegaFaculty(string newFaculty)
        {
            _itmoMegafaculties.Add(newFaculty);
        }
    }
}