using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    public interface IBaseContextFactory<out TDbContext> where TDbContext : DbContext
    {
        TDbContext Create();
    }
}
