﻿using DomainModels.Models;
using DTOModels.Converter;
using DTOModels.Models;
using MVOGames_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace MVOGames_Rest.Controllers
{
    public class OrderlinesController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private OrderlineConverter converter = new OrderlineConverter();

        // GET: api/Orders
        public IEnumerable<OrderlineDTO> GetOrderlines()
        {
            var orderlines = facade.GetOrderlineRepository().ReadAll();
            var orderlinesDTO = converter.Convert(orderlines);
            return orderlinesDTO;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(OrderlineDTO))]
        public IHttpActionResult GetOrderline(int id)
        {
            Orderline orderline = facade.GetOrderlineRepository().Find(id);
            var orderlineDTO = converter.Convert(orderline);
            if (orderline == null)
            {
                return NotFound();
            }

            return Ok(orderlineDTO);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderline(int id, OrderlineDTO orderline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderline.Id)
            {
                return BadRequest();
            }
            facade.GetOrderlineRepository().Update(new OrderlineConverter().Reverse(orderline));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(OrderlineDTO))]
        public IHttpActionResult PostOrderline(OrderlineDTO orderline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetOrderlineRepository().Add(new OrderlineConverter().Reverse(orderline));
            return CreatedAtRoute("DefaultApi", new { id = orderline.Id }, orderline);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(OrderlineDTO))]
        public IHttpActionResult DeleteOrderline(int id)
        {
            Orderline orderline = facade.GetOrderlineRepository().Find(id);
            if (orderline == null)
            {
                return NotFound();
            }
            facade.GetOrderlineRepository().Delete(id);

            return Ok(orderline);
        }
    }
}