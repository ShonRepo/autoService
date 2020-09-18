using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoService
{
    public partial class Order
    {
        public decimal Price
        {
            get
            {
                return AmenitiesOrder.Sum(i => i.Amenities1.Price) + component.Sum(i =>i.Type1.Price).Value;
            }
        }
    }
}
