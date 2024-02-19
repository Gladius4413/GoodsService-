using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods.Core.Models
{
    public class Good
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public Good(Guid id, string title, decimal price, string description)
        {
            Id = id;
            Title = title;
            Price = price;
            Description = description;
        }

        public static Good Create(Guid id, string title, decimal price, string description)
        {
            var good = new Good(id, title, price, description);

            return good;


        }
    }
}
