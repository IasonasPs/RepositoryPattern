using RepositoryPattern.Models;

namespace RepositoryPattern.EfCore
{
    public class EfCoreMovieRepository : EfCoreRepository<Movie, myDbContext>
    {
        public EfCoreMovieRepository(myDbContext context) : base(context)
        {
            
        }
    }
}
