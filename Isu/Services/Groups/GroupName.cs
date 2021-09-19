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
            return groupName[Constants.DirectionLetterPos] == 'M' && groupName[Constants.DirectionNumPos] == '3' &&
                   (groupName[Constants.CourseNumberPos] >= '1' && groupName[Constants.CourseNumberPos] <= '4') &&
                   groupName.Length == Constants.GroupNameLength;
        }
    }
}