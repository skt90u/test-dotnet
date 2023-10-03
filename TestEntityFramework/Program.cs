using Autofac;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.SqlClient;
using System.Linq;

namespace TestEntityFramework
{
    public class MyCommandInterceptor : IDbCommandInterceptor
    {

        public static void Log(string comm, string message)
        {
            Console.WriteLine("Intercepted: {0}, Command Text: {1} ", comm, message);
        }

        public void NonQueryExecuted(DbCommand command,
           DbCommandInterceptionContext<int> interceptionContext)
        {
            Log("NonQueryExecuted: ", command.CommandText);
        }

        public void NonQueryExecuting(DbCommand command,
           DbCommandInterceptionContext<int> interceptionContext)
        {
            Log("NonQueryExecuting: ", command.CommandText);
        }

        public void ReaderExecuted(DbCommand command,
           DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Log("ReaderExecuted: ", command.CommandText);
        }

        public void ReaderExecuting(DbCommand command,
           DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Log("ReaderExecuting: ", command.CommandText);
        }

        public void ScalarExecuted(DbCommand command,
           DbCommandInterceptionContext<object> interceptionContext)
        {
            Log("ScalarExecuted: ", command.CommandText);
        }

        public void ScalarExecuting(DbCommand command,
           DbCommandInterceptionContext<object> interceptionContext)
        {
            Log("ScalarExecuting: ", command.CommandText);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DbInterception.Add(new MyCommandInterceptor());

            var builder = CreateContainerBuilder();

            using (var container = builder.Build())
            {
                container.Resolve<DiExample>().Print();
            }
        }

        static ContainerBuilder CreateContainerBuilder()
        {
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-VQEUHM2\\SQLEXPRESS",
                InitialCatalog = "AdventureWorks2022",
                IntegratedSecurity = true,
            }.ConnectionString;

            var builder = new ContainerBuilder();

            // 順序可顛倒，但是相依的都必須要註冊到
            builder.RegisterType<DiExample>();

            builder.RegisterType<AdventureWorks2022>().WithParameter("connectionString", connectionString);

            return builder;
        }

        public class DiExample
        {
            private AdventureWorks2022 db;

            public DiExample(AdventureWorks2022 db)
            {
                this.db = db;
            }

            public void Print()
            {
                //var count = db.Sales_SpecialOffers.Count();

                //var x = db.ufnLeadingZeros(123);

                var items = db.Sales_SpecialOffers.Select(x => db.ufnLeadingZeros(x.MinQty)).ToList();
                
                foreach(var item in items)
                    Console.WriteLine(item);

                Console.WriteLine("DiExample");
                //Console.WriteLine($"db.Sales_SpecialOffers.Coun: {count}");
            }
        }
    }
}
