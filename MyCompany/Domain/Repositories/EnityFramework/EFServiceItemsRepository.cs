using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class EFServiceItemsRepository:IServiceItemsRepository
    {
        private readonly AppDBContext context;
        public EFServiceItemsRepository(AppDBContext context) => this.context = context;
        public IQueryable<ServiceItem> GetServiceItems() => context.ServiceItems;
        public ServiceItem GetServiceItemById(Guid id) => context.ServiceItems.FirstOrDefault(x => x.Id == id);
        public void SafeServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteServiceItem(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id = id });
            context.SaveChanges();
        }
    }
}
