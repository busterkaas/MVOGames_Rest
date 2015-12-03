using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;

namespace MVOGames_DAL.Repository
{
    class OrderlinesRepository : IRepository<Orderline>
    {
        private MVOGamesContext ctx;
        public OrderlinesRepository(MVOGamesContext context)
        {
            ctx = context;
        }
        public void Add(Orderline t)
        {
            ctx.Orderlines.Add(t);
            ctx.SaveChanges();
        }

        public void Delete(int? id)
        {
            Orderline orderline = Find(id);

            ctx.Orderlines.Attach(orderline);
            ctx.Orderlines.Remove(orderline);
            ctx.SaveChanges();
        }

        public Orderline Find(int? id)
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

        public List<Orderline> ReadAll()
        {
            return ctx.Orderlines.ToList();
        }

        public void Update(Orderline t)
        {
            ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
