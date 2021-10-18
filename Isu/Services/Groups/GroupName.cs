using Isu.Tools;

namespace Isu.Services.Groups
{
    public class GroupName
    {
        private string _groupName;

        public GroupName(string groupName)
        {
            if (IsCorrectGroupName(groupName))
                _groupName = groupName;
            else
                throw new IsuException("Isn't correct group name");
        }

        public string Name
        {
            get => _groupName;
        }

        private bool IsCorrectGroupName(string groupName)
        {
            return ((int)char.GetNumericValue(groupName[Constants.CourseNumberPos]) >= Constants.MinCourseNumber &&
                    (int)char.GetNumericValue(groupName[Constants.CourseNumberPos]) <= Constants.MaxCourseNumber) &&
                   groupName.Length == Constants.GroupNameLength;
        }
    }
}