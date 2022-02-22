using System;
using System.Collections.Generic;

namespace Classes
{
    public abstract class DbConnection
    {
        private readonly string _connectionString;
        private readonly TimeSpan _timeout;

        public DbConnection(string connectionString)
        {
            if(String.IsNullOrEmpty(connectionString))
            {
                throw new NullReferenceException();
            }

            _connectionString = connectionString;
        }

        public abstract void Open();
        public abstract void Close();
    }

    public class SqlConnection : DbConnection
    {
        public SqlConnection(string connectionString)
            : base(connectionString) { }

        public override void Open()
        {
            Console.WriteLine("SQL Connection Open");
        }

        public override void Close()
        {
            Console.WriteLine("SQL Connection Close");
        }
    }

    public class OracleConnection : DbConnection
    {
        public OracleConnection(string connectionString)
            : base(connectionString) { }

        public override void Open()
        {
            Console.WriteLine("Oracle Connection Open");
        }

        public override void Close()
        {
            Console.WriteLine("Oracle Connection Close");
        }
    }

    public class DbCommand
    {
        private readonly DbConnection _connection;
        private readonly string _instruction;

        public DbCommand(DbConnection connection, string instruction)
        {
            _connection = connection;
            _instruction = instruction;
        }

        public void Execute()
        {
            _connection.Open();
            Console.WriteLine(_instruction);
            _connection.Close();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sqlConnection = new SqlConnection("tada");
            var oracleConnection = new OracleConnection("bada");
            var instruction = "Create a Table";
            var command1 = new DbCommand(sqlConnection, instruction);
            var command2 = new DbCommand(oracleConnection, instruction);

            command1.Execute();
            command2.Execute();
        }
    }
}

