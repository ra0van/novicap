using System;

namespace novicap.app.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string item) : base(string.Format($"Product "+ item + "not found"))
        {

        }
    }
}
