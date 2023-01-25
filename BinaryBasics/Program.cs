using static BitHelper.BitHelper;
public class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("Enter two numbers to compare them in binary.");
    int numberOne = Convert.ToInt32(Console.ReadLine());
    int numberTwo = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"{numberOne} is represented as:");
    Print(numberOne);

    Console.WriteLine();

    Console.WriteLine($"{numberTwo} is represented as:");
    Print(numberTwo);




  }
}