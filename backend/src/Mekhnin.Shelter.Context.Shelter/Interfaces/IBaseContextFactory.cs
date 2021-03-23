using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{  
     /// <summary>
     /// Factory to create instance of an context
     /// </summary>
     /// <typeparam name="TDbContext">Type of context</typeparam>
    public interface IBaseContextFactory<out TDbContext> where TDbContext : DbContext
    {
        /// <summary>
        /// Create an instance of an context
        /// </summary>
        /// <returns>Context</returns>
        TDbContext Create();
    }
}
