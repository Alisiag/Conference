using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Infrastructure
{
    public class ConferenceContext : DbContext
    {
        public ConferenceContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.ApplyConfiguration(new
           CompanyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new
           ActorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new
           DirectorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new
           ArtistEntityTypeConfiguration());
            */
        }
    }
}
