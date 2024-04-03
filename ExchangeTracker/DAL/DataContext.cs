using ExchangeTracker.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExchangeTracker.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrencyEntry> CurrencyEntry { get; set; }
        public DbSet<CurrencyTrack> CurrencyTrack { get; set; }
        public DbSet<User> User { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tracks)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.Id_User)
                .HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<Currency>()
                .HasMany(e => e.Entries)
                .WithOne(e => e.Currency)
                .HasForeignKey(e => e.Id_Currency)
                .HasPrincipalKey(e => e.Id);
            modelBuilder.Entity<Currency>()
                .HasMany(e => e.Tracks)
                .WithOne(e => e.Currency)
                .HasForeignKey(e => e.Id_Currency)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
