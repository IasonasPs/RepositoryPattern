using RepositoryPattern.Models;

namespace RepositoryPattern.EfCore
{
    public class EfCoreStarRepository : EfCoreRepository<Star,myDbContext>
    {
        public EfCoreStarRepository(myDbContext context) : base(context) 
        {
        
        }
    }
}
