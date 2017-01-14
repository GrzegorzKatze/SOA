using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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

        public IEnumerable<Models.Client> GetAllClients()
        {
            return DBContext.Clients;
        }

        public Models.Client GetClient(int id)
        {
            return DBContext.Clients.FirstOrDefault(x => x.Id == id);
        }
    }
}