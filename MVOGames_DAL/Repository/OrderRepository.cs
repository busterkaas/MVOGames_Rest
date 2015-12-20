using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using DomainModels.Models;

namespace MVOGames_DAL.Repository
{
    public class OrderRepository : IRepository<Order>
    {

        public void Add(Order t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                try
                {
                    t.User = new User() { Id = t.UserId };
                    ctx.Entry(t).State = System.Data.Entity.EntityState.Unchanged;
                    ctx.Orders.Add(t);
                    ctx.SaveChanges();
                }
                catch
                {

                }
            }
        }

        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
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
        }

        public Order Find(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
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
        }

        public List<Order> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                try
                {
                    return ctx.Orders.Include("User.Role").Include("Orderlines").ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public void Update(Order t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                var originalOrder = ctx.Orders.Include(j => j.Orderlines).Single(j => j.Id == t.Id);

                // Update scalar/complex properties
                ctx.Entry(originalOrder).CurrentValues.SetValues(t);

                // Update reference
                originalOrder.Orderlines.Clear();

                foreach (var orderline in t.Orderlines)
                {
                    originalOrder.Orderlines.Add(ctx.Orderlines.FirstOrDefault(x => x.Id == orderline.Id));
                }
                ctx.SaveChanges();
            }
        }
    }
}
