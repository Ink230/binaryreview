using System.Text.RegularExpressions;

namespace BitHelper;

public class BitHelper
{
  public static void Print(int binary, int digits = 8, int spacing = 4)
  {
    string result = Convert.ToString(binary, 2).PadLeft(digits, '0');

    result = Regex.Replace(result, ".{" + spacing + "}", "$0 ");

    Console.WriteLine($"B: {result}");
  }
}