using NTierConsoleAppp.Data.Entities;
using Pluralize;
using Pluralize.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NTierConsoleAppp.Data.Repositories
{
    public class ADONetRepository<T> : IRepository<T> where T : class
    {

        public void Add(T item)
        {
            using (var connection = DbContext.OpenConneciton())
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO {GetPluralized(word: typeof(T).Name)} ({GetPropertiesWithout(typeof(T))}) VALUES ({GetProperties(typeof(T))})";
                    Console.WriteLine(cmd.CommandText);

                    foreach (var property in typeof(T).GetProperties())
                    {
                        var keyAttribute = property.GetCustomAttribute<KeyAttribute>();
                        if (keyAttribute != null) continue;

                        var paramName = $"@{property.Name}";
                        var paramValue = property.GetValue(item) ?? DBNull.Value;
                        cmd.Parameters.AddWithValue(paramName, paramValue);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void GetAll()
        {
            try
            {
                var connection = DbContext.OpenConneciton();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = $"SELECT * FROM {GetPluralized(word: typeof(T).Name)}";
                    using (var reader = cmd.ExecuteReader())
                    {
                        string result = string.Empty;

                        while (reader.Read())
                        {
                            foreach (var property in GetPropertiesWithout(typeof(T)).Split(','))
                            {
                                result += $"{property}: {reader[property]}\n";
                            }
                        }
                        Console.WriteLine(result);
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void Delete(T item)
        {
            throw new NotImplementedException();
        }


        public void Update(T item)
        {
            throw new NotImplementedException();
        }
        public static string GetPluralized(string word)
        {
            Pluralizer pluralizer
                = new Pluralizer();
            return pluralizer.Pluralize(word);
        }

        public static string GetProperties(Type type)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var property in type.GetProperties())
            {
                var keyAttribute = property.GetCustomAttribute<KeyAttribute>();
                if (keyAttribute != null) continue;
                sb.Append($" @{property.Name}");
                sb.Append(",");
            }
            return sb.ToString().TrimEnd(',').Trim();
        }
        public static string GetPropertiesWithout(Type type)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var property in type.GetProperties())
            {
                var keyAttribute = property.GetCustomAttribute<KeyAttribute>();
                if (keyAttribute != null) continue;
                sb.Append($"{property.Name}");
                sb.Append(",");
            }

            return sb.ToString().TrimEnd(',').Trim();
        }
    }

}
