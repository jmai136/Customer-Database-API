namespace CustomerDatabaseAPI.Server.Utilities
{
    public static class LocalConfigurationManager
    {
        public static string GetConnectionString()
        {
            return "Data Source=LAPTOP-BV5279C2\\SQLEXPRESS;Initial Catalog=CustomerDatabase;Integrated Security=True;Trust Server Certificate=True";
        }
    }
}
