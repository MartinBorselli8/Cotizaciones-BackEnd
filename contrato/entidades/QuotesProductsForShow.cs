﻿using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.entidades
{
    public class QuotesProductsForShow
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
    }
}
