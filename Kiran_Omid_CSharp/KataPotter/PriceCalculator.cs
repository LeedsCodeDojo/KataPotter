using System.Linq;

namespace KataPotter
{
    public class PriceCalculator
    {
        public const double BookPrice = 7.0;

        public double Scan(params Book[] books)
        {
            int count = books.Count();
            double totalPrice = BookPrice * count;

            var discount = 0;

            int distinctCount = books.Distinct().Count();

            switch (distinctCount)
            {
                case 2:
                    discount = 5;
                    break;
                case 3:
                    discount = 10;
                    break;
                case 4:
                    discount = 20;
                    break;
                case 5:
                    discount = 25;
                    break;
            }

            return totalPrice - (BookPrice * distinctCount * discount / 100);
        }
    }
}