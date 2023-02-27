using System;
using System.IO;
using System.IO.Compression;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            KAV.KAVDiskInfo.Info();
            Console.WriteLine("----------------------------------");
            KAV.KAVFileInfo.Info(@"C:\Users/Arsik/Downloads\gnbgfnbfb.png");
            Console.WriteLine("----------------------------------");
            KAV.KAVDirInfo.Info(@"C:\Users\Arsik\test");
            Console.WriteLine("----------------------------------");
            KAV.KAVFileManager.KAVInspect();
            KAV.KAVFileManager.Files();
            KAV.KAVFileManager.Archive();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Чтение лога");
            using (StreamReader sr = new StreamReader(@"KAVlogfile.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Подсчёт строк в логе");
            using (StreamReader sr = new StreamReader(@"KAVlogfile.txt", System.Text.Encoding.Default))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    i++;
                    Console.WriteLine(line);
                }
                Console.WriteLine($"В логе {i} строк");
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Удаление записей за промежуток времени");
            Console.WriteLine(KAV.KAVLog.RemoverByTime(Convert.ToDateTime("19.12.2022 7:36:17"), Convert.ToDateTime("19.12.2022 7:40:35")));
            Console.WriteLine("----------------------------------");
        }
    }
    class KAV
    {
        //Класс xxxLog
        public delegate void LogHandler(string message);
        public static event LogHandler Notify = KAVLog.Log;

        public static class KAVLog
        {
            private static readonly string path = @"KAVlogfile.txt";
            public static void Log(string message)
            {
                using (StreamWriter sw = new(path, true, System.Text.Encoding.Default))
                {
                    sw.Write(DateTime.Now);
                    sw.Write(' ');
                    sw.Write(message);
                    sw.WriteLine();
                }
            }

            public static bool RemoverByTime(DateTime startTime, DateTime endTime)
            {
                //if (startTime > endTime)
                 //   return false;

                using (StreamReader sr = new StreamReader("KAVlogfile.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string Line = sr.ReadLine();
                        string date = "";
                        DateTime DT = new DateTime();
                        for (int i = 1; i < 20; i++)
                            date += Line[i];
                        try
                        {
                            DT = Convert.ToDateTime(date);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return false;
                        }
      
                    }
                }
                return true;
            }
        }

        //Класс xxxDiskInfo
        public static class KAVDiskInfo
        {
            public static void Info()
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    try
                    {
                        Console.WriteLine($"Имя диска: " + drive.Name);//имя диска
                        Console.WriteLine($"Файловая система: " + drive.DriveFormat);//имя файловой системы
                        Console.WriteLine($"Тип диска: " + drive.DriveType);//тип диска
                        Console.WriteLine($"Общий объем свободного места (в байтах): " + drive.TotalFreeSpace);//общий объем свободного места на диске в байтах
                        Console.WriteLine($"Размер диска (в байтах): " + drive.TotalSize);//общий размер диска в байтах
                        Console.WriteLine($"Метка тома диска: " + drive.VolumeLabel);//метка тома
                        Notify("Использованы Name, DriveFormat, DriveType, TotalFreeSpace, TotalSize, VolumeLabel класса KAVDiskInfo");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error:  { ex.Message} ");
                        Notify(ex.Message);
                    }
                }
            }
        }
        //Класс xxxFileInfo
        public static class KAVFileInfo
        {
            public static void Info(string path)
            {
                try
                {
                    FileInfo file = new FileInfo(path);
                    Console.WriteLine($"Польный путь: " + file.FullName);
                    Console.WriteLine($"Размер:" + file.Length);
                    Console.WriteLine($"Расширение: " + file.Extension);
                    Console.WriteLine($"Имя: " + file.Name);
                    Console.WriteLine($"Дата создания: " + File.GetCreationTime(path));
                    Console.WriteLine($"Дата изменения: " + File.GetLastWriteTime(path));
                    Notify("Использованы FullName, Lenght, Extension, Name, GetCreationTime(), GetLastWriteTime() класса KAVFileInfo");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error:  { ex.Message} ");
                    Notify(ex.Message);
                }
            }
        }

        //Класс xxxDirInfo
        public static class KAVDirInfo
        {
            public static void Info(string path)
            {
                try
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    Console.WriteLine("Количество файлов: " + directory.GetFiles().Length);
                    Console.WriteLine("Время создания: " + directory.CreationTime);
                    Console.WriteLine("Количество поддиректорий: " + directory.GetDirectories().Length);
                    Console.WriteLine("Родительская директория: " + directory.Parent);
                    Notify("Использованы GetFiles().Lenght, CreationTme, GetDirectories().Length, Parent класса KAVDirInfo");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error:  { ex.Message} ");
                    Notify(ex.Message);
                }
            }
        }
        //Класс xxxFileManager
        public static class KAVFileManager
        {

            //a.Прочитать список файлов и папок заданного диска........
            public static void KAVInspect()
            {
                Directory.CreateDirectory("KAVInspect");
                Notify("Создана директория KAVInspect");
                FileInfo file1 = new(@"KAVInspect\KAVDirinfo.txt");
                Notify("Создан Файл KAVDirInfo.txt");
                using (StreamWriter sw = new(@"KAVInspect\KAVDirinfo.txt", false, System.Text.Encoding.Default))
                {
                    foreach (DirectoryInfo d in new DirectoryInfo(DriveInfo.GetDrives()[0].Name).GetDirectories())
                        sw.WriteLine(d.Name);
                }
                FileInfo file2 = file1.CopyTo(@"KAVInspect\KAVDirinfo1.txt");
                Notify("Создана копия Файла KAVDirInfo.txt");
                File.Delete("KAVInspect/KAVDirinfo.txt");
                Notify("Удалён Файл KAVDirInfo.txt");


            }
            //b. Создать еще один директорий XXXFiles.
            public static void Files()
            {
                Directory.CreateDirectory("KAVFiles");
                Notify("Создана директория KAVFiles");
                DirectoryInfo directory = new(@"C:\Users\Arsik\test");
                foreach (FileInfo f in directory.GetFiles())
                    if (f.Extension == ".png")
                        File.Copy(f.FullName, @"KAVFiles\" + f.Name);
                Directory.Move(@"KAVFiles\", @"KAVInspect\KAVFiles");
                Notify("Перемещена директория KAVFiles");
            }
            //Сделайте архив из файлов директория XXXFiles. Разархивируйте его в другой директорий
            public static void Archive()
            {
                ZipFile.CreateFromDirectory(@"KAVInspect\KAVFiles", "archive");
                Notify("Архивирована директория KAVFiles");
                Directory.CreateDirectory(@"Archive1");
                Notify("Создана директория Archive1");
                ZipFile.ExtractToDirectory("archive", "Archive1");
                Notify("Разархивировано в директорию KAVFiles");
            }
        }
    }


}
