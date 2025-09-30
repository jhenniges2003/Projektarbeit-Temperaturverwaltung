using Microsoft.EntityFrameworkCore;

namespace DesktopanwendungTemperatur
{
    internal class MyDbContext
        : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ManufacturerModel> Manufacturers { get; set; }
        public DbSet<SensorModel> Sensors { get; set; }
        public DbSet<TemperatureModel> Temperatures { get; set; }
        public DbSet<LogModel> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;Database=projektarbeit;User=root;Password=;",
                new MySqlServerVersion(new Version(10, 4, 32)));
        }
    }
}
