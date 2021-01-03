using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace MISA.BTL.Database
{
    public class DbConnector
    {
        protected string connectionString = "User Id=nvmanh; Host=103.124.92.43; Database=MS4_14_NNSon_CukCuk; port=3306; password=12345678; Character Set=utf8;";
        protected IDbConnection dbConnection;

        public DbConnector()
        {
            dbConnection = new MySqlConnection(connectionString);
        }

        public virtual IEnumerable<T> GetAllData<T>()
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}s";
            var entity = dbConnection.Query<T>(storeName, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public IEnumerable<T> GetDataById<T>(string id)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);
            var entity = dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public IEnumerable<T> GetDataByCode<T>(string code)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Get{tableName}ByCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Code", code);
            var entity = dbConnection.Query<T>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public int Insert<T>(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Insert{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();

            // Đọc các properties:
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affectRows = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affectRows;
        }

        public int Update<T>(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Update{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();

            // Đọc các properties:
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affectRows = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affectRows;
        }
        public int Delete<T>(T entity)
        {
            var tableName = typeof(T).Name;
            var storeName = $"Proc_Delete{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();

            // Đọc các properties:
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affectRows = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return affectRows;
        }    
    }
}
