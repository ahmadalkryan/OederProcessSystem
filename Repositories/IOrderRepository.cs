using OederProcessSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Core.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);

        Order GetById(Guid id);

        bool Exists(Guid id);
    }
}
