using static BitHelper.BitHelper;

namespace BinaryAlgorithms;

public class Program
{
  static void Main(string[] args)
  {
    bool loop = true;
    int choice, number;

    while (loop)
    {
      try
      {
        choice = Menu();
        if (choice == 0) loop = false;
        Console.WriteLine();

        Console.Write("Enter a number to use: ");
        number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        MenuSelector(choice, number);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Enter any key to continue.");
        Console.ReadLine();
        Console.Clear();
      }
      catch
      {
        Console.WriteLine();
        Console.WriteLine("Invalid numeric integer input");
        Console.WriteLine("Enter any key to continue.");
        Console.ReadLine();
        Console.Clear();
      }
    }
  }

  public static int Menu()
  {
    Console.WriteLine($@"Please make a choice.

1. Count the amount of one's in a number's binary representation.
2. Check if a number is a power of 2.
3. Check if a particular bit (2^ith) is set in a number.
4. Output all subsets of a given set.
5. Find the largest power within a number.
0. Exit.
");
    Console.Write("Enter your choice: ");
    return Convert.ToInt32(Console.ReadLine());
  }

  public static void MenuSelector(int choice, int number)
  {
    Console.Clear();
    Console.WriteLine($"Using the number {number} with choice {choice}");
    Console.Write($"{number} as binary is ");
    Print(number);
    Console.WriteLine();
    Console.WriteLine();

    switch (choice)
    {
      case (int)MenuChoices.CountOnes:
        CountOnes(number);
        break;

      case (int)MenuChoices.CheckPowerOfTwo:
        CheckPowerOfTwo(number);
        break;

      case (int)MenuChoices.CheckBitSet:
        //Call a static Program function CheckIfBitSet()
        break;

      case (int)MenuChoices.OutputAllSubsets:
        //Call a static Program function OutputAllSubsets()
        break;

      case (int)MenuChoices.LargestPowerOfTwo:
        //Call a static Program function LargestPowerOfTwo()
        break;

      default:
        break;
    }
  }

  public static void CountOnes(int number)
  {
    Console.WriteLine("Counting the number of one's in {4}...");
    Console.WriteLine();

    int count = 0;
    int initial = number;
    while (number != 0)
    {
      Console.WriteLine($"Count: {count} || n: {number} || {Convert.ToString(number, 2)}");
      number &= number - 1;
      count++;
    }

    Console.WriteLine();
    Console.WriteLine($"The number of one's in {initial} is: {count}");
    Print(initial);
  }
  public static void CheckPowerOfTwo(int number)
  {
    Console.WriteLine("Checking if the number is a power of two...");


    if ((number & number - 1) == 0)
      Console.WriteLine($"The number {number} is a power of 2.");
    else
      Console.WriteLine($"The number {number} is not a power of 2.");
  }
}
