using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServiceBroker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlWatch();
            Console.ReadLine();
        }

        public static void SqlWatch()
        {
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-VQEUHM2\\SQLEXPRESS",
                InitialCatalog = "AdventureWorks2022",
                IntegratedSecurity = true,
            }.ConnectionString;

            SqlDependency.Start(connectionString);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Create a new SqlCommand object.
                using (SqlCommand command = new SqlCommand(
                    "select * from person.address",
                    connection))
                {

                    // Create a dependency and associate it with the SqlCommand.
                    SqlDependency dependency = new SqlDependency(command);
                    // Maintain the reference in a class member.

                    // Subscribe to the SqlDependency event.
                    dependency.OnChange += new
                       OnChangeEventHandler(OnDependencyChange);

                    // Execute the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Process the DataReader.
                    }
                }
            }
        }
        public static void OnDependencyChange(object sender, SqlNotificationEventArgs e)
        {
            // Handle the event (for example, invalidate this cache entry).
            Console.WriteLine($"{e.Info.ToString()}");

            SqlWatch();
        }
    }
}
