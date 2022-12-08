namespace CabInvoiceGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator!");
            InvoiceGenerator objInvoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = objInvoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine($"Fare: {fare}");
        }
    }
}