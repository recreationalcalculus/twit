using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twit.Data.Models;

namespace Twit.Data
{
    public class TwitDbContext : IdentityDbContext<TwitUser>
    {
        public TwitDbContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<Follow> Follows { get; set; }

    }
}
