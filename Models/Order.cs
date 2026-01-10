using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OederProcessSystem.Model
{
    public class Order
    {

        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

    }
}
