using Microsoft.Data.SqlClient;
using DbDataReaderMapper;

namespace TravelMasterAppBackend.Services.Common
{
    public class CommonService
    {
        private SqlConnection Connection;
        public CommonService(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (Connection != null && Connection.State != System.Data.ConnectionState.Closed)
            {
                Connection.Close();
            }

            if (Connection != null && Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
            }
            Connection.Close();
            Connection.Open();
        }

        public void CloseConnection()
        {
            Connection.Close();
        }

        public void ExecuteCommand(string sql)
        {
            OpenConnection();

            var command = new SqlCommand(sql, Connection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public T GetOne<T>(string sql) where T : class
        {

            OpenConnection();

            T obj = (T)Activator.CreateInstance(typeof(T));

            var command = new SqlCommand(sql, Connection);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                obj = reader.MapToObject<T>();
            }

            CloseConnection();

            return obj;
        }

        public List<T> GetMany<T>(string sql) where T : class
        {
            OpenConnection();

            var list = new List<T>();

            var command = new SqlCommand(sql, Connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var obj = reader.MapToObject<T>();
                list.Add(obj);
            }

            CloseConnection();

            return list;
        }

        public void Create<T>(string sql)
        {
            ExecuteCommand(sql);
        }

        public T Read<T>(string sql) where T : class
        {
            return GetOne<T>(sql);
        }

        public List<T> ReadMany<T>(string sql) where T : class
        {
            return GetMany<T>(sql);
        }

        public void Update(string sql)
        {
            ExecuteCommand(sql);
        }

        public void Delete(string sql)
        {
            ExecuteCommand(sql);
        }
    }
}
