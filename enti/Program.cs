using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;

namespace enti
{
    class Program
    {
        public static BillingRepository Repository { get; set; }
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
        }
        public void ConfigureServices(IServiceCollection services)
        => services.AddDbContext<ApplicationContext>();
        private static void UseSqlServer()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer("Data Source=LAPTOP-7KC3O54G\\RECEPTION;Initial Catalog=Billing3;User Id=sa;Password=sa@12345;");
            Repository = new BillingRepository(dbOptions);

        }
    }

}
