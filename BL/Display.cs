using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagochi.Modules;

namespace Tamagochi.BL;

static class Display
{
    public static void Show(List<Cat> cats)
    {
        Console.WriteLine("{0,-2} | {1,-15} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-15} |", "#", "Имя", "Возраст", "Здоровье", "Настроение", "Сытость", "Средний уровень");
        Console.WriteLine("---+-----------------+------------+------------+------------+------------+-----------------+");
        int id = 1;

        cats = cats.OrderBy(x => x.Level).ToList();

        foreach (Cat cat in cats)
        {
            Console.WriteLine("{0,-2} | {1,-15} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-15} |", id, cat.Name, cat.Age, cat.Health, cat.Mood, cat.Satiety, cat.Level);
            Console.WriteLine("---+-----------------+------------+------------+------------+------------+-----------------+");
            id++;
        }
    }   

}
