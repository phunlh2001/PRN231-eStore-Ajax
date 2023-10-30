using BusinessObjects.Data;
using System.Collections.Generic;

namespace DataAccess.Repository.Interface
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetList();
        void Add(OrderDetail detail);
    }
}
