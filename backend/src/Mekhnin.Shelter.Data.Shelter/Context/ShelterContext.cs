using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mekhnin.Shelter.Data.Shelter.Entities;
using Mekhnin.Shelter.Data.Shelter.Extends;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mekhnin.Shelter.Data.Shelter.Context
{
    /// <summary>
    /// Shelter Db context
    /// </summary>
    public class ShelterContext : DbContext
    {
        private readonly IConfiguration _configuration;
        protected Dictionary<Type, string> _pgtableNamesExclusions;

        public ShelterContext(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbHost = _configuration["PG_HOST"];
            var dbDatabaseName = _configuration["PG_DBNAME"];
            var dbPsw = _configuration["PG_PASSWORD"];
            var dbUser = _configuration["PG_USER"];

            optionsBuilder.UseNpgsql($"Host={dbHost};port=5432;Database={dbDatabaseName};Username={dbUser};Password={dbPsw}");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    // Convert all names to snake_case due to PostgreSQL conventions
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                }
            }

            var genProps = typeof(ShelterContext)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(pi => pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            foreach (var g in genProps)
            {
                Type type = g.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(DbSet<>))
                {
                    var tableType = type.GetGenericArguments()[0];

                    // table name generation
                    string tableName;
                    if (_pgtableNamesExclusions?.ContainsKey(tableType) == true)
                        tableName = _pgtableNamesExclusions[tableType];
                    else
                        // table names to one style
                        tableName = g.Name.ToSnakeCase();

                    // create generic method DbModelBuilder.Entity
                    var entityRef = typeof(ModelBuilder)
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .Single(e =>
                            e.Name == nameof(ModelBuilder.Entity)
                            && e.IsGenericMethod
                            && e.GetParameters().Length == 0
                        )
                        .MakeGenericMethod(tableType);
                    dynamic table = entityRef.Invoke(modelBuilder, null);

                    RelationalEntityTypeBuilderExtensions.ToTable(table, tableName);
                }
                else
                    throw new ArgumentException($"Unknown {g}");
            }


			modelBuilder.Entity<Entities.Shelter>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Entities.Shelter>()
                .HasMany(x => x.ShelterVolunteers)
                .WithOne(x => x.Shelter)
                .HasForeignKey(x => x.ShelterId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Animal>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Animal>()
                .HasOne<Entities.Shelter>(x => x.Shelter)
                .WithMany(x => x.Animals)
                .HasForeignKey(x => x.ShelterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Need>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Need>()
                .HasOne(x => x.Shelter)
                .WithMany(x => x.Needs)
                .HasForeignKey(x => x.ShelterId)
                .IsRequired(true);

            modelBuilder.Entity<Need>()
                .HasOne(x => x.Animal)
                .WithMany(x => x.Needs)
                .HasForeignKey(x => x.AnimalId)
                .IsRequired(false);

            modelBuilder.Entity<Volunteer>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Volunteer>()
                .HasMany(x => x.ShelterVolunteers)
                .WithOne(x => x.Volunteer)
                .HasForeignKey(x => x.VolunteerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Contact>()
                .HasOne(x => x.Volunteer)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.VolunteerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<ShelterVolunteer>()
                .HasKey(x => new {x.ShelterId, x.VolunteerId});

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Entities.Shelter> Shelters { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Need> Needs { get; set; }

        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<ShelterVolunteer> ShelterVolunteers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}

