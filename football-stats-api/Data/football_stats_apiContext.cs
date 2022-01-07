#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using football_stats_api.Models;

namespace football_stats_api.Data
{
    public class football_stats_apiContext : DbContext
    {
        public football_stats_apiContext (DbContextOptions<football_stats_apiContext> options)
            : base(options)
        {
        }

        public DbSet<football_stats_api.Models.Player> Player { get; set; }
    }
}
