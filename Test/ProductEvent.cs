using Architecture.Events.Generics;
using System.Collections.Generic;

namespace Test
{
    class ProductEvent : Event<Product, ProductEventRoot, ProductEventResponse>
    {
        public ProductEvent()
        {
            Root = new ProductEventRoot();
            Responseses = new List<ProductEventResponse>();
        }
    }
}
