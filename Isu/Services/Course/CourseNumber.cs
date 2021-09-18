using Isu.Tools;

namespace Isu.Services.Course
{
    public abstract class CourseNumber
    {
        protected CourseNumber(int courseNumber)
        {
            if ((courseNumber < 1) || (courseNumber > 4))
            {
                throw new IsuException("Invalid course number");
            }
            else
            {
                Number = courseNumber;
            }
        }

        public int Number { get; }
    }
}