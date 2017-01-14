using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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

        public IEnumerable<Models.Car> GetAllCars()
        {
            return DBContext.Cars;
        }

        public Models.Car GetCar(int id)
        {
            return DBContext.Cars.FirstOrDefault(x => x.Id == id);
        }
    }
}