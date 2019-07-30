using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using novicap.app.entities;
using novicap.app.Exceptions;

namespace novicap.app
{
    public class Checkout : BaseCheckout
    {
        protected Hashtable pricingRules;

        public Checkout(Hashtable pricingRules) : base(pricingRules)
        {
            this.cart = new List<Product>();
            this.pricingRules = pricingRules;
        }

        public override void scan(string item)
        {
            string product = item.ToUpper();
            if (pricingRules.ContainsKey(product))
            {
                cart.Add((Product)pricingRules[product]);
            }
            else
            {
                throw new ProductNotFoundException(product);
            }

        }

        public override void remove(string item)
        {
            string product = item.ToUpper();
            if (pricingRules.ContainsKey(product))
            {
                cart.Add((Product)pricingRules[product]);
            }
            else
            {
                throw new ProductNotFoundException(product);
            }
        }

        public override decimal total()
        {
            return cart.Sum(x => x.Price);
        }

    }
}
