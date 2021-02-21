using System;
using System.Collections.Generic;
using System.Text;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mekhnin.Shelter.Context.Shelter
{
    public class ContextFactory<TDbContext> : IBaseContextFactory<TDbContext> 
        where TDbContext : DbContext
    {
        public TDbContext Create()
        {
            var context = Activator.CreateInstance<TDbContext>();

            return context;
        }
    }
}
