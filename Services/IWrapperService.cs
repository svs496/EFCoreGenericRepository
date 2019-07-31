using System;
namespace ProductAppCore2.Services
{
    public interface IWrapperService
    {
        IProductService Product { get; }
        ISupplierService Supplier { get; }
    }
}
