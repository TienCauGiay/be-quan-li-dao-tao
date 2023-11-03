using be_quan_li_dao_tao.BL.Interfaces.DL;
using be_quan_li_dao_tao.BL.Interfaces.UnitOfWork;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace be_quan_li_dao_tao.DL.DL
{
    public abstract class BaseDL<TEntity> : IBaseDL<TEntity>
    {
        protected readonly IUnitOfWork _unitOfWork;

        private string tableName = typeof(TEntity).Name.ToLower();

        public BaseDL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using (var connection = _unitOfWork.Connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                var deleteQuery = $"DELETE FROM {tableName} WHERE {tableName}_id = @Id"; 

                var parameters = new { Id = id };

                var result = await connection.ExecuteAsync(deleteQuery, parameters);

                return result;
            }
        }

        public async Task<IEnumerable<TEntity>?> GetAllAsync()
        {
            using (var connection = _unitOfWork.Connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                var command = new NpgsqlCommand($"SELECT * FROM {tableName}", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    var results = new List<TEntity>();

                    while (await reader.ReadAsync())
                    {
                        var entity = MapFromDataReader(reader);

                        results.Add(entity);
                    }

                    return results;
                }
            }
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            using (var connection = _unitOfWork.Connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                var parameters = new DynamicParameters();
                var propertyNames = string.Empty;
                var parameterNames = string.Empty;

                foreach (var prop in entity.GetType().GetProperties())
                {
                    var propName = prop.Name;
                    var paramName = "@" + propName;

                    if (propName.Contains($"{tableName}_id"))
                    {
                        parameters.Add(paramName, Guid.NewGuid());
                    }
                    else if (propName.Contains("created_date"))
                    {
                        parameters.Add(paramName, DateTime.Now);
                    }
                    else
                    {
                        parameters.Add(paramName, prop.GetValue(entity));
                    }

                    propertyNames += $"{propName}, ";
                    parameterNames += $"{paramName}, ";
                }

                propertyNames = propertyNames.TrimEnd(',', ' ');
                parameterNames = parameterNames.TrimEnd(',', ' ');

                var insertQuery = $"INSERT INTO {tableName} ({propertyNames}) VALUES ({parameterNames})";

                var result = await connection.ExecuteAsync(insertQuery, parameters);

                return result;
            }
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            using (var connection = _unitOfWork.Connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                var parameters = new DynamicParameters();
                var updateQuery = $"UPDATE {tableName} SET ";

                foreach (var prop in entity.GetType().GetProperties())
                {
                    var propName = prop.Name;
                    var paramName = "@" + propName;

                    if (propName.Contains("modified_date"))
                    {
                        parameters.Add(paramName, DateTime.Now);
                        updateQuery += $"{propName} = {paramName}, ";
                    }
                    else if (propName == $"{tableName}_id")
                    {
                        // Assuming the primary key column has the same name as tableName_id
                        parameters.Add(paramName, prop.GetValue(entity));
                    }
                    else
                    {
                        parameters.Add(paramName, prop.GetValue(entity));
                        updateQuery += $"{propName} = {paramName}, ";
                    }
                }

                updateQuery = updateQuery.TrimEnd(',', ' ');

                // Add a WHERE clause to specify the condition for the update
                updateQuery += $" WHERE {tableName}_id = @{tableName}_id"; // Use the same parameter name for the primary key

                var result = await connection.ExecuteAsync(updateQuery, parameters);

                return result;
            }
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            using (var connection = _unitOfWork.Connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                var selectQuery = $"SELECT * FROM {tableName} WHERE {tableName}_id = @Id";

                var parameters = new { Id = id };

                var result = await connection.QueryFirstOrDefaultAsync<TEntity>(selectQuery, parameters);

                return result;
            }
        }


        private TEntity MapFromDataReader(NpgsqlDataReader reader)
        {
            var entity = Activator.CreateInstance<TEntity>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                var propertyName = reader.GetName(i);
                var property = typeof(TEntity).GetProperty(propertyName);

                if (property != null && !reader.IsDBNull(i))
                {
                    var value = reader.GetValue(i);
                    property.SetValue(entity, value);
                }
            }

            return entity;
        }
    }
}
