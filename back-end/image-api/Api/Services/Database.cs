using MySql.Data.MySqlClient;

namespace ImageApi.Services
{
    public class Database
    {
        public MySqlConnection Connection;

        // Set your connection details here
        private string Server = "localhost";
        private string User = "root";
        private string Password = "";
        private string Db = "image_tool";

        public Database()
        {
            Connection = new MySqlConnection($"server={Server};user={User};password={Password};database={Db}");
            this.Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
