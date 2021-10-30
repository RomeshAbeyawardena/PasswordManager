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

        public DbSet<Customer> Customer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Credential> Credential { get; set; }
    }
}
