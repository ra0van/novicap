using novicap.app.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace novicap.app
{
    interface ICheckout
    {
        void scan(string product);

        void remove(string product);

        decimal total();
    }
}
