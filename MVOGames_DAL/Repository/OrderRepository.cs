using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;

namespace MVOGames_DAL.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private MVOGamesContext ctx;

        public OrderRepository(MVOGamesContext context)
        {
            ctx = context;
        }

        public void Add(Order t)
        {
            try
            {
                ctx.Orders.Add(t);
                ctx.SaveChanges();
            }
            catch
            {

            }
        }

        public void Delete(int? id)
        {
            var order = ctx.Orders.Find(id);
            try
            {
                ctx.Orders.Attach(order);
                ctx.Orders.Remove(order);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Order Find(int? id)
        {
            foreach (var item in ReadAll())
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Order> ReadAll()
        {
            try
            {
                return ctx.Orders.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Order t)
        {
            ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
