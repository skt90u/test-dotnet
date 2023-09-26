using Autofac;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace TestEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                var count = db.Sales_SpecialOffers.Count();
                Console.WriteLine("DiExample");
                Console.WriteLine($"db.Sales_SpecialOffers.Coun: {count}");
            }
        }
    }
}
