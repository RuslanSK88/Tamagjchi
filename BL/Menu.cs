using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagochi.Modules;

namespace Tamagochi.BL
{
    class Menu
    {
        private List<string> Menus { get; set; } = new List<string>();
        private int selected = 0;
        public Menu()
        {
            Menus.Add("Завести нового питомца");
            Menus.Add("Покормить");
            Menus.Add("Поиграть");
            Menus.Add("К ветеринару");
            Menus.Add("Следующий день");
            Menus.Add("Выход");
        }
        public void DisplayMenu()
        {
            for (int i = 0; i < Menus.Count; i++)
            {
                if (selected == i)
                    Console.WriteLine($"> {Menus[i]}");
                else
                    Console.WriteLine($"  {Menus[i]}");
            }
        }
        public int Run()
        {
            List<Cat> allCats = FileManager.ReadAll();
            while (true)
            {
                Console.Clear();
                Display.Show(allCats);
                DisplayMenu();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        if (selected < Menus.Count - 1)
                        {
                            selected++;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (selected > 0)
                        {
                            selected--;
                        }
                        break;

                    case ConsoleKey.Enter:
                        return selected;
                }
            }
        }
    }
}
