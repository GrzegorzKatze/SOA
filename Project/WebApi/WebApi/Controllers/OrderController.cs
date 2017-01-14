using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        public IEnumerable<Models.Order> GetAllOrders()
        {
            return DBContext.Orders;
        }

        public Models.Order GetOrders(int id)
        {
            return DBContext.Orders.FirstOrDefault(x => x.Id == id);
        }
    }
}
