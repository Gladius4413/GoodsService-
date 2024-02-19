﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods.DataBase.Entities
{
    public class GoodEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

       
        
    }
}
