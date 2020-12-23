using System;
using System.IO;
using System.Management;

namespace Командная_Строка
{

    class Program
    {
        static void print()
        {
            Console.WriteLine("/diskinfo - информация о диске", "\n");
            Console.WriteLine("/cls - очистить консоль", "\n");
            Console.WriteLine("/catalog - информация о файле", "\n");
        }
        static void cls()
        {
            Console.Clear();
        }
        static void Catalog()
        {
            string PathToTheFile = Environment.CurrentDirectory;
            Console.WriteLine(PathToTheFile);
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("/goto - переход в другую директорию");
        }
        static void AnotherDirectory()
        {
            Console.WriteLine("Введите новую директорию");
            string newPath;
            newPath = Console.ReadLine();
            string oldPath = Environment.CurrentDirectory;
            try
            {
                Directory.Move(newPath, oldPath);

            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);
            
            }
            
        }
        static void DiskInfo()
        {
            System.IO.DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Свободного места на диске:{drive.AvailableFreeSpace}");
                Console.WriteLine($"Тип: {drive.DriveFormat}");

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите команду /info, чтобы узнать больше о доступных программах");


            string command;
            do
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "/info":
                        print();
                        break;
                    case "/cls":
                        cls();
                        break;
                    case "/catalog":
                        Catalog();
                        break;
                    case "/diskinfo":
                        DiskInfo();
                        break;
                    case "/goto":
                        AnotherDirectory();
                        break;

                }

            } while (command != "/exit");



        }
    }
}

 
