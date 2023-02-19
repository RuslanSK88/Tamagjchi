
using System.Text.Json;
using System.Text.Json.Nodes;
using Tamagochi.Modules;

namespace Tamagochi.BL;

static class FileManager
{
    private static string fileName = "Cats.json";



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
    public static void CreateFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            File.Create(fileName);
        }
    }
    public static void SaveAll(List<Cat> allCats)
    {
        File.WriteAllText(fileName, "");
        foreach (Cat cat in allCats)
        {
            SaveOne(cat);
        }
    }
    public static void SaveOne(Cat cat)
    {
        // TODO: запись файла
        {
            string serCat = JsonSerializer.Serialize<Cat>(cat);
            File.AppendAllText(fileName, serCat + "\n");
        }     
    }
    public static List<Cat>  ReadAll()
    {
        string[] allCatsString = File.ReadAllLines(fileName);
        List<Cat> allCats = new List<Cat>();
        foreach (string cat in allCatsString)
        {
            Cat? catDesir = JsonSerializer.Deserialize<Cat>(cat);
            allCats.Add(catDesir);
        }
        return allCats;
    }
}
