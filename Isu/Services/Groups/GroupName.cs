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
            return groupName[0] == 'M' && groupName[1] == '3' && (groupName[2] >= '1' && groupName[2] <= '4') &&
                   groupName.Length <= 5;
        }
    }
}