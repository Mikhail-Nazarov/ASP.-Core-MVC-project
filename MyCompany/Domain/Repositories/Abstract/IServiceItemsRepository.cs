using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid Id);
        void SafeServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid Id);
    }
}
