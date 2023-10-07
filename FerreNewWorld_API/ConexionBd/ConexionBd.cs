namespace FerreNewWorld_API.ConexionBd
{
    public class ConexionBd
    {
        private readonly string connectionString = string.Empty;

        public ConexionBd()
        {
            var constructor = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = constructor.GetSection("ConnectionStrings:conexionmaestra").Value;
        }
        public string CadenaSQL()
        {
            return connectionString;
        }
    }
}
