using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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

        public IEnumerable<Models.Receipt> GetAllReceipts()
        {
            return DBContext.Receipts;
        }

        [HttpGet]
        [ActionName("GetReceiptById")]
        public Models.Receipt GetReceipt(int id)
        {
            return DBContext.Receipts.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet]
        [ActionName("GetReceiptBySymbol")]
        public Models.Receipt GetReceipt(string symbol)
        {
            return DBContext.Receipts.FirstOrDefault(x => x.Symbol == symbol);
        }
    }
}