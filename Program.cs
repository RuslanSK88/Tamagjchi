using System;
using System.Text;
using Tamagochi.BL;
using Tamagochi.Interfaces;
using Tamagochi.Modules;

namespace Tamagochi;

class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        /*
        - CopyTo(path): копирует файл в новое место по указанному пути path
        - Create(): создает файл
        - Delete(): удаляет файл
        - MoveTo(destFileName): перемещает файл в новое место
        - Свойство Directory: получает родительский каталог в виде объекта DirectoryInfo
        - Свойство DirectoryName: получает полный путь к родительскому каталогу
        - Свойство Exists: указывает, существует ли файл
        - Свойство Length: получает размер файла
        - Свойство Extension: получает расширение файла
        - Свойство Name: получает имя файла
        - Свойство FullName: получает полное имя файла
        Для создания объекта FileInfo применяется конструктор, который получает в качестве параметра путь к файлу:
        
        
        FileInfo fileInf = new FileInfo(@"C:\app\content.txt");
        string fName = fileInf.Extension;
        fileInf.Create();
        */
        FileManager.CreateFile("Cats.json");
        Menu menu = new Menu();
        while (true)
        {
            switch (menu.Run())
            {
                case 0:
                    FileManager.SaveOne(InputData());
                    break;
                case 1:
                    ActionCat("Вы покормили кота", 1);
                    break;
                case 2:
                    ActionCat("Вы поиграли с котом", 2);
                    break;
                case 3:
                    ActionCat("Вы полечили кота", 3);
                    break;
                case 4:
                    NextDay("Наступил следующий день");
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
            Console.Clear();
        }
    }
    public static void ActionCat(string action, int actionIndex)
    {
        string nameCat = UserInput.InputString("Вебирите кота по имени");

        List<Cat> allCats = FileManager.ReadAll();
        bool findCat = false;
        foreach (Cat cat in allCats)
        {
            if (cat.Name.Contains(nameCat))
            {
                Console.WriteLine($"{action}: {nameCat}");

                switch (actionIndex)
                {
                    case 1:
                        if (cat.Age <= 5)
                        {
                            cat.Satiety += 7;
                            cat.Mood += 7;
                        }
                        else if (cat.Age >= 6 && cat.Age <= 10)
                        {
                            cat.Satiety += 5;
                            cat.Mood += 5;
                        }
                        else
                        {
                            cat.Satiety += 4;
                            cat.Mood += 4;
                        }
                        break;
                    case 2:
                        if (cat.Age <= 5)
                        {
                            cat.Mood += 7;
                            cat.Health += 7;
                            cat.Satiety -= 3;
                        }
                        else if (cat.Age >= 6 && cat.Age <= 10)
                        {
                            cat.Mood += 5;
                            cat.Health += 5;
                            cat.Satiety -= 5;
                        }
                        else
                        {
                            cat.Mood += 4;
                            cat.Health += 4;
                            cat.Satiety -= 6;
                        }
                        break;
                    case 3:
                        if (cat.Age <= 5)
                        {
                            cat.Mood -= 7;
                            cat.Health += 7;
                            cat.Satiety -= 3;
                        }
                        else if (cat.Age >= 6 && cat.Age <= 10)
                        {
                            cat.Mood -= 5;
                            cat.Health += 5;
                            cat.Satiety -= 5;
                        }
                        else
                        {
                            cat.Mood -= 6;
                            cat.Health += 4;
                            cat.Satiety -= 6;
                        }
                        break;
                }
                findCat = true;
            }
            cat.Level = (cat.Health + cat.Mood + cat.Satiety) / 3;
        }
        FileManager.SaveAll(allCats);
        if (!findCat)
        {
            Console.WriteLine("нет такого кота");
        }
        Console.ReadKey(true);
    }
    public static void NextDay(string action)
    {
        List<Cat> allCats = FileManager.ReadAll();
        Random random = new Random();
        foreach (Cat cat in allCats)
        {
            cat.Satiety -= random.Next(1, 6);
            cat.Mood += random.Next(-3, 4);
            cat.Health += random.Next(-3, 4);
            cat.Level = (cat.Health + cat.Mood + cat.Satiety) / 3;
        }
        Console.WriteLine(action);
        FileManager.SaveAll(allCats);
        Console.ReadKey(true);
    }
    public static Cat InputData()
    {
        Cat cat = new Cat();
        cat.Name = UserInput.InputString("Введи Имя");
        cat.Age = UserInput.InputInteger("Введи возраст");
        Random random = new Random();
        cat.Health = random.Next(20, 81);
        cat.Mood = random.Next(20, 81);
        cat.Satiety = random.Next(20, 81);
        cat.Level = (cat.Health + cat.Mood + cat.Satiety) / 3;
        return cat;
    }
}
