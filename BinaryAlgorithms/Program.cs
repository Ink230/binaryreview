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
      number = 0;
      try
      {
        choice = Menu();
        if (choice == 0) loop = false;
        Console.WriteLine();

        if (choice != (int)MenuChoices.OutputAllSubsets)
        {
          Console.Write("Enter a number to use: ");
          number = Convert.ToInt32(Console.ReadLine());
          Console.WriteLine();
        }

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
3. Check if the bit at 2^ith is set in a number.
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
        CheckIfBitIsSet(number);
        break;

      case (int)MenuChoices.OutputAllSubsets:
        OutputAllSubsets();
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
  public static void CheckIfBitIsSet(int number)
  {
    Console.WriteLine("Note: 2^ith where (i - 1) == column position");
    Console.Write("Enter the 2^ith bit to check if set: ");
    int inputValue = Convert.ToInt32(Console.ReadLine());

    int bitToCheck = (int)Math.Pow(2, inputValue);
    if ((bitToCheck & (bitToCheck - 1)) != 0) throw new Exception();

    Console.WriteLine();
    Console.WriteLine($"Checking if the 2^{inputValue} bit is set in {number}...");

    if ((number & bitToCheck) == bitToCheck)
      Console.WriteLine($"The number {number} has the bit 2^{inputValue} set.");
    else
      Console.WriteLine($"The number {number} has the bit 2^{inputValue} unset.");

    //Can also be done with (~number & bitToCheck) == 0
  }
  public static void OutputAllSubsets()
  {
    Console.WriteLine("Warning: >12 N in a set can take a very long time to compute.");
    Console.WriteLine("Warning: The subsets will all be output to the console.");
    Console.WriteLine();
    Console.WriteLine("Ex sets: A,B,C || 1,2,3 || a,2,f || @,7,*");
    Console.Write("Enter a comma separated string to represent a set: ");
    string? input = Console.ReadLine();
    string[] set;

    if (!string.IsNullOrEmpty(input))
      set = input.Trim().Replace(" ", "").Split(",");
    else
      throw new Exception();

    Console.WriteLine();

    for (int i = 0; i < (1 << set.Length); i++)
    {
      for (int j = 0; j < set.Length; j++)
      {
        if ((i & (1 << j)) != 0)
          Console.Write($"{set[j]} ");
        else
          Console.Write("- ");
      }
      Console.WriteLine();
    }
  }
}
