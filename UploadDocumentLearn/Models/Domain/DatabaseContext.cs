﻿using Microsoft.EntityFrameworkCore;

namespace UploadDocumentLearn.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options)
        {

        }
        public DbSet<Product> Product { get; set; }
    }
}
