using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModels.Models;
using MVOGames_DAL.Models;

namespace DTOModels.Converter
{
    public class OrderConverter : AbstractDTOConverter<Order, OrderDTO>
    {
        public override OrderDTO Convert(Order item)
        {
            var orderDTO = new OrderDTO()
            {
                Id = item.Id,
                UserId = item.UserId,
                Date = item.Date,
            };
            if (item.Orderlines != null)
            {
                orderDTO.Orderlines = new List<OrderlineDTO>();
                foreach (var orderline in item.Orderlines)
                {
                    orderDTO.Orderlines.Add(new OrderlineDTO()
                    {
                        Id = orderline.Id,
                        Discount = orderline.Discount,
                        OrderId = orderline.OrderId,
                        GameId = orderline.GameId
                       
                    });
                }
            }
            return orderDTO;
        }

        public override Order Reverse(OrderDTO item)
        {
            var order = new Order()
            {
                Id = item.Id,
                UserId = item.UserId,
                Date = item.Date,
            };
            if (item.Orderlines != null)
            {
                order.Orderlines = new List<Orderline>();
                foreach (var orderline in item.Orderlines)
                {
                    order.Orderlines.Add(new Orderline()
                    {
                        Id = orderline.Id,
                        Discount = orderline.Discount,
                        OrderId = orderline.OrderId,
                        GameId = orderline.GameId

                    });
                }
            }
            return order;
        }
    }
}
