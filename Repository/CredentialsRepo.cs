using AuthorizationService.FlowerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Repository
{
    public class CredentialsRepo: ICredentialsRepo
    {

        public List<Customer> GetCredentials()
        {
            using(var db = new dbFlowerStoreContext())
            {
                return db.Customers.ToList();
            }
        }
    }
}
