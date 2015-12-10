using DTOModels.Models;
using MVOGames_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Converter
{
    public class OrderlineConverter : AbstractDTOConverter<Orderline, OrderlineDTO>
    {
        public override OrderlineDTO Convert(Orderline item)
        {
            var orderlineDTO = new OrderlineDTO()
            {
                Id = item.Id,
                Discount = item.Discount,
                OrderId = item.OrderId,
                Order= new OrderConverter().Convert(item.Order),
                PlatformGameId = item.PlatformGameId,
                PlatformGame = new PlatformGameConverter().Convert(item.PlatformGame)               
            };
            return orderlineDTO;
        }

        public override Orderline Reverse(OrderlineDTO item)
        {
            var orderline = new Orderline()
            {
                Id = item.Id,
                Discount = item.Discount,
                OrderId = item.OrderId,
                Order = new OrderConverter().Reverse(item.Order),
                PlatformGameId = item.PlatformGameId,
                PlatformGame = new PlatformGameConverter().Reverse(item.PlatformGame)
            };
            return orderline;
        }
    }
}
