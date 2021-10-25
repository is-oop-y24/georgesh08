namespace IsuExtra
{
    public static class StreamNumberGenerator
    {
        private static int _streamNumber = 1;
        public static int GenerateNewStreamNumber()
        {
            return _streamNumber++;
        }
    }
}