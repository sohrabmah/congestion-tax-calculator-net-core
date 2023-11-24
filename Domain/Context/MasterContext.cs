using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        {

        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Motorbike> Motorbikes { get; set; }
    }
}
