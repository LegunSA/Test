using Microsoft.EntityFrameworkCore;
using TestTask.Data.Entityes;

namespace TestTask.Data
{
  public class DemoDBContext : DbContext
  {
    public DemoDBContext(DbContextOptions<DemoDBContext> options) : base(options) {}

    public DbSet<Patient> Patients { get; set; }
  }
}
