using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using RepositoryPattern.Data;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public abstract class myDbController<TEntity, TRepository> : ControllerBase
    where TEntity : class, IEntity
    where TRepository : IRepository<TEntity>
    {

        private readonly TRepository repository;
        public myDbController(TRepository repository) 
        {
            this.repository = repository;
        }

        //Get: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        //Get : api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var movie = await repository.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie; //there is no Ok in the initial code
        }

        //Put : api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,TEntity movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            await repository.Update(movie);
            return NoContent();
        }

        //Post : api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity movie)
        {
            await repository.Add(movie);
            return CreatedAtAction("Get",new { id = movie.Id },movie);
        }

        //Delete : api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var movie = await repository.Delete(id);
            if(movie == null)
            {
                return NotFound();
            }
            return movie;
        }

    }
}
