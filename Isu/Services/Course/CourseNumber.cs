using Isu.Tools;

namespace Isu.Services.Course
{
    public abstract class CourseNumber
    {
        protected CourseNumber(int courseNumber)
        {
            if ((courseNumber < Constants.MinCourseNumber) || (courseNumber > Constants.MaxCourseNumber))
            {
                throw new IsuException("Invalid course number");
            }

            Number = courseNumber;
        }

        public int Number { get; }
    }
}