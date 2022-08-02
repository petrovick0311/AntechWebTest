using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AntechLicense.Models
{
    public class EFOrderRepository: IOrderRepository
    {
        private DataContext context;
        public EFOrderRepository(DataContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Licencia);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Licencia));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
