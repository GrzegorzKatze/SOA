using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ReceiptController : ApiController
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

        public IQueryable<Models.Receipt> GetAllReceipts()
        {
            return DBContext.Receipts;
        }

        [ResponseType(typeof(Receipt))]
        public async Task<IHttpActionResult> GetReceipt(int id)
        {
            var result = await DBContext.Receipts.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }
    }
}