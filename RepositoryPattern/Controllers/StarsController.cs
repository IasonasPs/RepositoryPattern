using RepositoryPattern.EfCore;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    public class StarsController : myDbController<Star,EfCoreStarRepository>
    {
        public StarsController(EfCoreStarRepository repository) : base(repository)
        {
            
        }


    }
}
