using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ClientController : ApiController
    {
        private WebApiEntities _dbContext;

        public WebApiEntities DBContext
        {
            get
            {
                _dbContext = _dbContext == null ? new WebApiEntities() : _dbContext;

                return _dbContext;
            }
        }

        public IQueryable<Models.Client> GetAllClients()
        {
            return DBContext.Clients;
        }

        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> GetClient(int id)
        {
            var result = await DBContext.Clients.SingleOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> UpdateClient(int id, Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != client.Id)
                return BadRequest();

            DBContext.Entry(client).State = EntityState.Modified;

            try
            {
                await DBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DBContext.Clients.Any(x => x.Id == id))
                    return NotFound();
                throw;
            }

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> AddClient(Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DBContext.Clients.Add(client);

            await DBContext.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = client.Id }, client);
        }
    }
}