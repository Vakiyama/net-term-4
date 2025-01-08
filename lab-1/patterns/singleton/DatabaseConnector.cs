namespace Lab1
{
    public class DatabaseConnector
    {
        private DatabaseConnector() { }

        private static Lazy<DatabaseConnector> _databaseConnector = new Lazy<DatabaseConnector>(
            () => new DatabaseConnector()
        );

        public static DatabaseConnector GetInstance() => _databaseConnector.Value;
    }
}
