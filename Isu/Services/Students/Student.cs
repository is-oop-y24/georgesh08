namespace Isu.Services.Students
{
    public class Student
    {
        private readonly string _name;
        private string _studentGroup;
        private int _id;
        public Student(string groupName, string name)
        {
            _studentGroup = groupName;
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public string GroupName
        {
            get { return _studentGroup; }
            set { _studentGroup = value; }
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }
    }
}