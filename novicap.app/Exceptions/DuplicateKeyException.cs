using System;
using System.Collections.Generic;
using System.Text;

namespace novicap.app.Exceptions
{
    public class DuplicateKeyException : Exception
    {
        public DuplicateKeyException() : base("Duplicate keys exists in the pricing rules")
        {

        }
    }
}
