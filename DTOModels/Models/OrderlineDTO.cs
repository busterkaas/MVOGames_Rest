using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class OrderlineDTO
    {
        public int Id { get; set; }
        private int Amount { get; set; }
        public decimal Discount { get; set; }
        public int PlatformGameId { get; set; }
        public int OrderId { get; set; }
        public PlatformGameDTO PlatformGame { get; set; }
        public OrderDTO Order { get; set; }
    }
}
