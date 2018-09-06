using Architecture.Events.Generics;

namespace Test
{
    class ProductEventResponse : EventResponse<ProductEvent>
    {
        public ProductEventResponse()
        {
            Event = new ProductEvent();
        }
    }
}
