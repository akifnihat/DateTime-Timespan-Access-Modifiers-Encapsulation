
namespace DateTime_Timespan
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public Product(string name, decimal price, int count=1)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Mehsulun adi bos ola bilmez", nameof(name));
           
            if (price <= 0)
                throw new ArgumentException("Qiymet 0-dan ve ya - ola bilmez", nameof(price));
            
            Name = name;
            Price = price;
            Count = count;
        }

        public virtual string Detail()
        {
            return $"Mehsul: {Name}\nQiymet: {Price} AZN\nMiqdar: {Count} Say";
        }
 
        public decimal Discount(int percent)
        {
            if (percent < 0 || percent > 100)
            {
                Console.WriteLine("Endirim faizi 0 ile 100 arasında olmalıdır.");
                return Price;
            }

            decimal discountAmount = (Price * percent) / 100;
            decimal discountedPrice = Price - discountAmount;
            return discountedPrice;
        }

    }
}
