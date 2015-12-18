using DomainModels.Models;
using DTOModels.Converter;
using DTOModels.Models;
using MVOGames_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MVOGames_Rest.Controllers
{
    public class OrdersController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private OrderConverter converter = new OrderConverter();

        // GET: api/Orders
        public IEnumerable<OrderDTO> GetOrders()
        {
            var orders = facade.GetOrderRepository().ReadAll();
            var ordersDTO = converter.Convert(orders);
            return ordersDTO;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = facade.GetOrderRepository().Find(id);
            var orderDTO = converter.Convert(order);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(orderDTO);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, OrderDTO order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }
            facade.GetOrderRepository().Update(converter.Reverse(order));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult PostOrder(OrderDTO order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetOrderRepository().Add(converter.Reverse(order));
            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = facade.GetOrderRepository().Find(id);
            var orderDTO = converter.Convert(order);
            if (order == null)
            {
                return NotFound();
            }
            facade.GetOrderRepository().Delete(id);

            return Ok(orderDTO);
        }
    }
}
