using Microsoft.EntityFrameworkCore;
using cashcrusaderspos.Models;

namespace cashcrusaderspos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CaptureProductsModel>? CaptureProducts { get; set; }
        public DbSet<CaptureOrdersModel>? CaptureOrders { get; set; }
        public DbSet<CaptureOrderLinesModel>? CaptureOrderLines { get; set; }
        public DbSet<CaptureSalesByDayModel>? CaptureSalesByDay { get; set; }
    
    }
}
