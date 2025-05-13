
namespace DateTime_Timespan
{
     public class Book:Product
    {
        public string Genre { get; set; } 
        public Book(string name, decimal price, int count, string genre)
            : base(name, price, count=1) 
        {
            if (string.IsNullOrEmpty(genre))
                throw new ArgumentException("Kitabin janrı bos ola bilmez", nameof(genre));
            Genre = genre;
        }

        public override string Detail()
        {
            return base.Detail() + $"\nJanr: {Genre}";
        }
    
    }
}
