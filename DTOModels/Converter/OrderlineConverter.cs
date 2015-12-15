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
                Amount = item.Amount,
                Discount = item.Discount,
                OrderId = item.OrderId,
                PlatformGameId = item.PlatformGameId,             
            };
            return orderlineDTO;
        }

        public override Orderline Reverse(OrderlineDTO item)
        {
            var orderline = new Orderline()
            {
                Id = item.Id,
                Amount = item.Amount,
                Discount = item.Discount,
                OrderId = item.OrderId,
                PlatformGameId = item.PlatformGameId,
            };
            return orderline;
        }
    }
}
