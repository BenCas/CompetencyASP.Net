using System;
namespace Competency.Controllers
{
    public class ScheduleCont
    {
        public ScheduleCont(DbContextOptions<ScheduleCont> options)
      : base(options)
        {
        }

        public DbSet<Backend.Models.Schedule> Schedule { get; set; }
    }
