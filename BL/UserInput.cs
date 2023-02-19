
namespace Tamagochi.BL;

 static class UserInput
{
    public static int InputInteger(string title)
    {
        int result = 0;
        Console.Write(title + ": ");
        while (result == 0)
        {
            string? temp = Console.ReadLine();
            if (temp == "")
                Console.WriteLine("Вы не ввели данные");
            else if (int.TryParse(temp, out int value))
                result = value;
            else
                Console.WriteLine("Данные не являются числом");
        }
        return result;
    }
    public static string InputString(string title) 
    {
        string result = "";
        Console.Write(title + ": ");
        while (result == "")
        {
            string? temp = Console.ReadLine();
            if(temp is null || temp == "")
            {
                Console.WriteLine("Вы не ввели данные");
            } 
            else
                result = temp;
        }
        return result;
    }
}
