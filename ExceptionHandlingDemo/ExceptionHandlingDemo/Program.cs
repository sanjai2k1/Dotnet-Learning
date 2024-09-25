internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());
            int c = a / b;
            Console.WriteLine("Quotient is " + c);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Finished");
        }
        Console.ReadKey();
    }
}

