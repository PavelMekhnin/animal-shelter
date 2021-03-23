using System;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mekhnin.Shelter.Context.Shelter
{
    public class ContextFactory<TDbContext> : IBaseContextFactory<TDbContext> 
        where TDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ContextFactory(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }

        public TDbContext Create()
        {
            var context = (TDbContext)Activator.CreateInstance(typeof(TDbContext), _configuration);

            return context;
        }
    }
}
