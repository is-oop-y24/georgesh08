using Reports.Server.Database;

namespace Reports.Server
{
    public sealed class DatabaseInitializer
    {
        private DatabaseInitializer() { }
        private static DatabaseInitializer _instance;

        public static DatabaseInitializer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseInitializer();
            }

            return _instance;
        }
        
        public void InitDatabaseContext(IDatabaseContext context)
        {
            Context = context;
        }
        
        public IDatabaseContext Context { get; private set; }
    }
}