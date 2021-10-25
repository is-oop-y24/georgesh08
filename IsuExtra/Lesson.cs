namespace IsuExtra
{
    public class Lesson
    {
        public Lesson(int lessonConsecutiveNumber, int classroomNumber, string teacher)
        {
            LessonConsecutiveNumber = lessonConsecutiveNumber;
            ClassroomNumber = classroomNumber;
            Teacher = teacher;
        }

        public string Teacher { get; }
        public int ClassroomNumber { get; }
        public int LessonConsecutiveNumber { get; }
    }
}