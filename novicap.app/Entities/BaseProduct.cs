namespace novicap.app.entities
{
    public abstract class BaseProduct
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }
    }
}
