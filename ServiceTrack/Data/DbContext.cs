
namespace ServiceTrack.Data;
using Microsoft.EntityFrameworkCore;
using ServiceTrack.Models;

public class AppDb : DbContext
{
    public AppDb(DbContextOptions<AppDb> options) : base(options) { }
    
    public DbSet<Ticket>    Tickets    => Set<Ticket>();
    public DbSet<Category>  Categories => Set<Category>();
    public DbSet<RepairRequest>  RepairRequests => Set<RepairRequest>();
    public DbSet<AttachedFile>  AttachedFiles => Set<AttachedFile>();
}