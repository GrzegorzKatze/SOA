using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CarController : ApiController
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

        public IQueryable<Models.Car> GetAllCars()
        {
            return DBContext.Cars;
        }

        [ResponseType(typeof(Car))]
        public async Task<IHttpActionResult> GetCar(int id)
        {
            var result = await DBContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }
    }
}