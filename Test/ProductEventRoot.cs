using Architecture.Events.Generics;
using System.Collections.Generic;

namespace Test
{
    class ProductEventRoot : EventRoot<Product, ProductEvent>
    {
        public ProductEventRoot()
        {
            Events = new List<ProductEvent>();
        }
    }
}
