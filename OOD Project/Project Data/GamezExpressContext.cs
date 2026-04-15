using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OOD_Project.ProjectData;

namespace OOD_Project.Data
{
    public class GamezExpressContext : DbContext
    {
        public GamezExpressContext() : base("GamezExpressDB")
        {
        }

        public DbSet<Game> Games { get; set; }
    }
}
