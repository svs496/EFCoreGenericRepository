using System;
using ProductAppCore2.Data;
using ProductAppCore2.Models;

namespace ProductAppCore2.Services
{
    public class SqlProductData : GenericRepository<Product>, IProductService
    {
        public SqlProductData(ProductDBContext dBContext)
            :base(dBContext)
        {
        }
    }
}
