using static BitHelper.BitHelper;

namespace BitFlags;

public class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Bit flags are used to manage conditions on an imaginary entity.");
    Console.WriteLine("You may add, remove or check if a condition exists but at this current time, only one condition per text input.");
    Console.WriteLine();
    Console.WriteLine("Here is a list of the conditions and their corresponding value:");
    Console.WriteLine();

    foreach (var condition in Enum.GetValues(typeof(Conditions)))
    {
      int value = (int)condition;
      int position = value == 0 ? 0 : (int)(Math.Log(value, 2) + 1);
      Console.WriteLine(condition + ": " + position);
    }

    Console.WriteLine();
    // Interesting approach
    //foreach (string name in Enum.GetNames(typeof(Conditions)))
    //{
    //  Conditions condition = (Conditions)Enum.Parse(typeof(Conditions), name);
    //  int value = (int)Convert.ChangeType(condition, condition.GetTypeCode());
    //  Console.WriteLine(name + ": " + (int)(Math.Log(value, 2) + 1));
    //}

    //not using unsigned ints for potential future expansion
    int entity = 0;

    Console.WriteLine("Which condition(s) would you like to add?");
    int addConditionOne = GetInput();
    entity = AddCondition(entity, addConditionOne);

    Console.WriteLine();
    Console.WriteLine("Which condition(s) would you like to add as well?");
    int addConditionTwo = GetInput();
    entity = AddCondition(entity, addConditionTwo);

    Console.WriteLine();
    Console.WriteLine("Finally, which condition(s) would you like to add?");
    int addConditionThree = GetInput();
    entity = AddCondition(entity, addConditionThree);

    Console.WriteLine();
    Console.WriteLine("Which condition(s) would you like to check if set?");
    int checkCondition = GetInput();
    if (CheckCondition(entity, checkCondition))
      Console.WriteLine("\nThe condition(s) are set!");
    else
      Console.WriteLine("\nThe condition(s) are not set");

    Console.WriteLine();
    Console.WriteLine("Which condition(s) would you like to remove?");
    int removeConditionOne = GetInput();
    entity = RemoveCondition(entity, removeConditionOne);

    Console.WriteLine();
    Console.WriteLine("Which condition(s) would you like to remove as well?");
    int removeConditionTwo = GetInput();
    entity = RemoveCondition(entity, removeConditionTwo);

    Console.WriteLine();
    Console.WriteLine("The final condition(s) present:");
    Print(entity);

    Console.WriteLine();
    foreach (var condition in Enum.GetValues(typeof(Conditions)))
    {
      int value = (int)condition;
      if ((entity & value) != 0)
      {
        Console.WriteLine(condition);
      }
    }

    Console.WriteLine();
    Console.WriteLine();
  }
  public static int AddCondition(int currentConditions, int addCondition)
  {
    return currentConditions |= addCondition;
  }
  public static int RemoveCondition(int currentCondition, int removeCondition)
  {
    return currentCondition &= ~removeCondition;
  }
  public static bool CheckCondition(int currentCondition, int checkCondition)
  {
    return (currentCondition & checkCondition) == checkCondition;
  }
  public static int GetInput()
  {
    //adjust to catch for values that exceed the Length of the enum Conditions
    return (1 << (Convert.ToInt32(Console.ReadLine()) - 1));
  }
}
