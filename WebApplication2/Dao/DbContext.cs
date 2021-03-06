﻿using System;
using System.Data;
using Dapper;
using Npgsql;

namespace WebApplication2.Dao
{
    public class DbContext : IDisposable
    {
        private NpgsqlConnection _connection;

        public DbContext(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
        }

        internal IDbConnection GetConnection()
        {
            return _connection;
        }       


        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }
}