﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAPI.FlowerModel;

namespace CustomerAPI.Provider
{
   public  interface IProvider
    {
        public void RegisterCustomer(Customer temp);
        public Customer CustomerbyId(int id);

        public void UpdateCustomer(Customer temp);

        public Customer CustomerLogin(string tempPhone, string tempPass, string tempType);
        public void DeleteCustomerbyId(int id);
    }
}
