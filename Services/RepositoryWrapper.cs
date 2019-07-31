using System;
using ProductAppCore2.Data;

namespace ProductAppCore2.Services
{
    public class RepositoryWrapper :IWrapperService
    {
        private readonly ProductDBContext context;

        private IProductService _product;
        private ISupplierService _supplier;

        public RepositoryWrapper(ProductDBContext context)
        {
            this.context = context;
        }

        public IProductService Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new SqlProductData(context);
                }

                return _product;
            }
        }

        public ISupplierService Supplier
        {
            get
            {
                if (_supplier == null)
                {
                    _supplier = new SqlSupplierData(context);
                }

                return _supplier;
            }
        }



    }
}
