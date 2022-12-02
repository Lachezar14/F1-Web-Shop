using MySql.Data.MySqlClient;
using Dapper;
namespace DBConnect
{
    public class DBConnect
    {
        public static void sql(string query)
        {
            MySqlConnection msql = new MySqlConnection("server=localhost;database=websitedb;uid=luc;pwd=lucho;");
            try
            {
                msql.Open();

                msql.Execute(query);
            }
            finally
            {
                msql.Close();
            }
        }
    }
}