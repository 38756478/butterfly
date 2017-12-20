﻿using Butterfly.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Butterfly.EntityFrameworkCore
{
    public class InMemoryDbContext : DbContext
    {
        public DbSet<BaggageModel> Baggages { get; set; }

        public DbSet<LogFieldModel> LogFields { get; set; }

        public DbSet<LogModel> Logs { get; set; }

        public DbSet<SpanModel> Spans { get; set; }

        public DbSet<SpanReferenceModel> SpanReferences { get; set; }

        public DbSet<TagModel> Tags { get; set; }

        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase("--Butterfly--");
        }
    }
}