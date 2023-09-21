using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TestEntityFramework
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(string connStr) : base(connStr)
        {

        }

        public DbSet<Person> Person { get; set; }
    }

    [Table("Person.Person")]
    public class Person
    {
        [Key]
        public int BusinessEntityID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
