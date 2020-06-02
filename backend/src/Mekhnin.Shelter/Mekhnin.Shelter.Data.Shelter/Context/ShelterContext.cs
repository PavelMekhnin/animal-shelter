using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mekhnin.Shelter.Data.Shelter.Entities;
using Mekhnin.Shelter.Data.Shelter.Extends;
using Microsoft.EntityFrameworkCore;

namespace Mekhnin.Shelter.Data.Shelter.Context
{
    public class ShelterContext : DbContext
    {
        protected Dictionary<Type, string> _pgtableNamesExclusions;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;port=5432;Database=postgres;Username=postgres;Password=mysecretpassword");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                }
            }

            // получаем все табличные проперти
            var genProps = typeof(ShelterContext)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(pi => pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            foreach (var g in genProps)
            {
                Type type = g.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(DbSet<>))
                {
                    // добываем из генерик типа тип таблицы
                    var tableType = type.GetGenericArguments()[0];

                    // генерим имя таблицы
                    string tableName;
                    if (_pgtableNamesExclusions?.ContainsKey(tableType) == true)
                        tableName = _pgtableNamesExclusions[tableType];
                    else
                        // имена таблиц к одному стилю
                        tableName = g.Name.ToSnakeCase();

                    // создаем генерик метод DbModelBuilder.Entity
                    var entityRef = typeof(ModelBuilder)
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .Single(e =>
                            e.Name == nameof(ModelBuilder.Entity)
                            && e.IsGenericMethod
                            && e.GetParameters().Length == 0
                        )
                        .MakeGenericMethod(tableType);
                    // инвокаем его
                    dynamic table = entityRef.Invoke(modelBuilder, null);
                    // меняем имя таблицы. динамик тут для того, чтобы не усложнять код выведением генерик типов
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

