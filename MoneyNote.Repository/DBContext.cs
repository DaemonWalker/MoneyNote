using Microsoft.EntityFrameworkCore;
using MoneyNote.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MoneyNote.Repository
{
    public class DBContext : DbContext
    {
        public DBContext()
        {

        }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<TypeDto> FeeTypes { get; set; }
        public DbSet<RecordDto> FeeItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.EntityTypeConfiguration();
        }
        public DbSet<T> Get<T>() where T : class
        {
            if (typeof(T) == typeof(UserDto))
            {
                return Users as DbSet<T>;
            }
            if (typeof(T) == typeof(TypeDto))
            {
                return FeeTypes as DbSet<T>;
            }
            if (typeof(T) == typeof(RecordDto))
            {
                return FeeItems as DbSet<T>;
            }
            throw new Exception("Type Not Supported!");
        }
    }
}
