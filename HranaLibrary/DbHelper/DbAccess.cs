using System.Configuration;
using System.Data.SqlClient;

namespace HranaLibrary.DbHelper
{
    public class DbAccess
    {
        public static SqlConnection GetOpenConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FoodRecipeManagementSystem"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            return conn;
        }
    }
}
