using Microsoft.EntityFrameworkCore;
using EmsEntity;

namespace EmsData.DataContext
{
    /// <summary>
    /// Represents the database context for the Employee Management System (EMS) application.
    /// </summary>
    public class EmsDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the EmsDbContext class with the specified options.
        /// </summary>
        /// <param name="options">The options to be used for configuring the database context.</param>
        public EmsDbContext(DbContextOptions<EmsDbContext> options) : base(options)
        {
            // This constructor passes the options to the base class (DbContext) for configuration.
        }

        /// <summary>
        /// Gets or sets the DbSet representing the Department table in the database.
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Gets or sets the DbSet representing the Employee table in the database.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the DbSet representing the User_Master table in the database.
        /// </summary>
        public DbSet<User_Master> User_Masters { get; set; }

        /// <summary>
        /// Gets or sets the DbSet representing the Grade_Master table in the database.
        /// </summary>
        public DbSet<Grade_Master> Grade_Masters { get; set; }
    }
}
