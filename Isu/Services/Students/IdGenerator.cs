namespace Isu.Services.Students
{
    public class IdGenerator
    {
        private static int _studentId = 100000;

        public int GenerateNewId()
        {
            return _studentId++;
        }
    }
}