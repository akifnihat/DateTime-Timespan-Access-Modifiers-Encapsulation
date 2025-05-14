namespace DateTime_Timespan
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Product product = new Product("telefon", 199.99m, 20);
            Console.WriteLine(product.Detail());

            decimal discountedPrice = product.Discount(10);
            Console.WriteLine($"\n20% endirimli qiymet: {discountedPrice} AZN");

            Console.Write("Kitab sayi daxil et: ");
            int bookCount = int.Parse(Console.ReadLine()); 

            Book[] books = new Book[bookCount];

            for (int i = 0; i < bookCount; i++)
            {
                Console.WriteLine($"\n{(i + 1)}. Kitabin melumatlarini daxil et:");

                Console.Write("Adini daxil et: ");
                string name = Console.ReadLine();

                Console.Write("Qiymetini daxil et: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("Miqdarini daxil et: ");
                int count = int.Parse(Console.ReadLine());

                Console.Write("Janr daxil et: ");
                string genre = Console.ReadLine();

                try
                {
                    books[i] = new Book(name, price, count, genre);
                    Console.WriteLine($"{name} kitabi elave edildi.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Xeta: {ex.Message}");
                    i--;  
                }
            }

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.Write("option daxil et: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    for (int i = 0; i < books.Length-1; i++)
                    {
                        for(int j = 0; j < books.Length-1; j++)
                        {
                            if(books[i].Price > books[j + 1].Price)
                            {
                                Book temp = books[i];
                                books[i] = books[j + 1];
                                books[j + 1] = temp;
                            }
                        }
                            
                    }
                    

                    Console.WriteLine("\nQiymete gore filtr edilmis kitablar:");
                    foreach (var book in books)
                    {
                        if (book != null && book.Price >= minPrice && book.Price <= maxPrice)
                            Console.WriteLine(book.Detail());
                    }
                }
                else if (option == "2")
                {
                    Console.WriteLine("\nButun kitablara baxıs:");
                    foreach (var book in books)
                    {
                        if (book != null)
                            Console.WriteLine(book.Detail());
                    }
                }
                else if (option == "0")
                {
                    Console.WriteLine("Proqram baglanır");
                    break;
                }
                else
                    Console.WriteLine("Yanlis secim etdiniz. Yeniden cehd edin.");
            }
        }

    }
}

   
