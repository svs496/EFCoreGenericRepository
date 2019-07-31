using System;
using ProductAppCore2.Data;
using ProductAppCore2.Models;

namespace ProductAppCore2.Services
{
    public class SqlSupplierData : GenericRepository<Supplier>, ISupplierService
    {
        public SqlSupplierData(ProductDBContext dBContext)
            : base(dBContext)
        {

        }

    }
}
