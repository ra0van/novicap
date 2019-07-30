using System;
using System.Collections;
using novicap.app;
using novicap.app.entities;
using novicap.app.Exceptions;
using NUnit.Framework;

namespace novicap.tests
{
    public class TestCheckout
    {
        private Hashtable data;
        [SetUp]
        public void SetUp()
        {
            data = new Hashtable();
            Product voucher = new Product() {
                Code = "VOUCHER",
                Name = "Novicap Voucher",
                Price = 5.00M,
                Currency = "EURO"
            };

            Product tshirt = new Product()
            {
                Code = "TSHIRT",
                Name = "Novicap T-Shirt",
                Price = 20.00M,
                Currency = "EURO"
            };

            Product mug = new Product()
            {
                Code = "MUG",
                Name = "Novicap Coffee Mug",
                Price = 7.50M,
                Currency = "EURO"
            };

            data.Add("VOUCHER", voucher);
            data.Add("TSHIRT", tshirt);
            data.Add("MUG", mug);
        }

        [Test]
        public void TestCheckout_When_ItemsAdded()
        {
            Checkout checkout = new Checkout(data);
            checkout.scan("VOUCHER");
            checkout.scan("MUG");
            Assert.AreEqual(12.50, checkout.total());
            Assert.AreEqual(2, checkout.cart.Count);
        }

        [Test]
        public void TestCheckout_When_ItemsAreAddedAndRemoved()
        {
            Checkout checkout = new Checkout(data);
            checkout.scan("VOUCHER");
            checkout.scan("MUG");
            checkout.remove("MUG");
            Assert.AreEqual(5.00, checkout.total());
            Assert.AreEqual(1, checkout.cart.Count);
        }

        [Test]
        public void TestCheckout_When_InvalidItemsAreAdded()
        {
            Checkout checkout = new Checkout(data);
            checkout.scan("VOUCHER");
            Assert.Throws<ProductNotFoundException>(() => checkout.scan("MUGS"));
            Assert.AreEqual(5.00, checkout.total());
            Assert.AreEqual(1, checkout.cart.Count);
        }

    }
}
