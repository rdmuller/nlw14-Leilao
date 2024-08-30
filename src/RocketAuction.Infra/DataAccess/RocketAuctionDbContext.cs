using Microsoft.EntityFrameworkCore;
using RocketAuction.Domain.Entities;

namespace RocketAuction.Infra.DataAccess;
public class RocketAuctionDbContext : DbContext
{
    public RocketAuctionDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<User> Users { get; set; }
}
