﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class OrderHistoryDto
    {

        public int OrderId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string MenuName { get; set; }
        public System.DateTime OrderTime { get; set; }
        public int OrderAmount { get; set; }
    }
}
