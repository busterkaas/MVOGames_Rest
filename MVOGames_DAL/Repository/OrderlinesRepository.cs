using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using DomainModels.Models;

namespace MVOGames_DAL.Repository
{
    public class OrderlinesRepository : IRepository<Orderline>
    {
        public void Add(Orderline t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Orderlines.Add(t);
                ctx.SaveChanges();
            }
        }
        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                Orderline orderline = Find(id);

                ctx.Orderlines.Attach(orderline);
                ctx.Orderlines.Remove(orderline);
                ctx.SaveChanges();
            }
        }
        public Orderline Find(int? id)
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

        public List<Orderline> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                return ctx.Orderlines.ToList();
            }
        }

        public void Update(Orderline t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
