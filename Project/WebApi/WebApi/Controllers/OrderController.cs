using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class OrderController : ApiController
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

        public IQueryable<Models.Order> GetAllOrders()
        {
            return DBContext.Orders;
        }

        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> GetOrders(int id)
        {
            var result = await DBContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }
    }
}