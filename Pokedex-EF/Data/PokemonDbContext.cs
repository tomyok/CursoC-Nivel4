using Microsoft.EntityFrameworkCore;
using Pokedex_EF.Models;

namespace Pokedex_EF.Data
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Elemento> Elementos  { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
