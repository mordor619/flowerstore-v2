﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderAPI.FlowerModel;

namespace OrderAPI.Repository
{
    interface IOrder
    {
        public void AddingToOrderDetails(OrderDetail ord);
        public List<OrderDetail> OrderdetailsbyCustomerId(int id);
        public List<Occasion> GetAllOccasion();

        public OrderDetail OrderByOrderID(int id);
    }
}
