﻿using System.Data.Entity;
using SetMeta.Web.Domain.Entities;

namespace SetMeta.Web.Domain.Repositories
{
    public class SetMetaDbContext : DbContext
    {
        public SetMetaDbContext(string connectionStringOrName)
            : base(connectionStringOrName)
        {
            Database.SetInitializer(new SetMetaDbInitializer());
        }

        public SetMetaDbContext()
            : this("Name=SetMeta")
        {
        }

        public DbSet<Day> Days { get; set; }
        public DbSet<User> Users { get; set; }
    }
}