using System.Collections;
using System.Collections.Generic;
using novicap.app.entities;

namespace novicap.app
{
    public abstract class BaseCheckout : ICheckout
    {
        public List<Product> cart { get; protected set; }
        public BaseCheckout(Hashtable pricingRules)
        {

        }

        public abstract void scan(string product);
        public abstract void remove(string product);
        public abstract decimal total();
    }
}
