using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class FinalDBContext :DbContext
    {
        public FinalDBContext(DbContextOptions<FinalDBContext> options) : base(options)
        {
            
        }

        public DbSet<InfoRequest> InfoTable { get; set; }

        public DbSet<FavoritesRequest> FavoritesTable { get; set; }

        public DbSet<HistoryRequest> HistoryTable { get; set; }

        public DbSet<MusicRequest> MusicTable { get; set; }
    }
}
