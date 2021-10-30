using DNI.Data.Shared.Base;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Shared.Models.Db;
using System;

namespace PasswordManager.Core
{
    public class PasswordManagerDbContext : DbContextBase
    {
        public PasswordManagerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Credential> Credentials { get; set; }
    }
}
