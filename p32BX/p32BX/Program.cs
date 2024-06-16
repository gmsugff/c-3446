namespace p32BX
{
    
    class DirNavigator
    {
        
private string currentDir;

        public DirNavigator()
        {
            currentDir = "C:\\";
            Console.WriteLine("Текущая директория:" + currentDir);
        }
            /// <summary>
            /// Выводит  dirs
            /// </summary>
        public void ShowDirectories()
        {
            string[] directories = Directory.GetDirectories(currentDir);
            Console.WriteLine("Директории:");

                foreach (string dir in directories)
                {
                    Console.WriteLine(dir);
                }
        }
        /// <summary>
        /// Выводит  files
        /// </summary>
        public void ShowFiles()
        {
            string[] files = Directory.GetFiles(currentDir);
            Console.WriteLine("Файлы:");

                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
        }

        /// <summary>
        /// назад
        /// </summary>
        public void MoveBack()
        {
            DirectoryInfo parentDirectory = Directory.GetParent(currentDir);
                if (parentDirectory != null)
                {
                    currentDir = parentDirectory.FullName;
                    Console.WriteLine("Переход назад в директорию: " + currentDir);
                }
                    else
                    {
                        Console.WriteLine("Невозможно вернуться назад, текущая директория - корневая.");
                    }
        }
        /// <summary>
        /// Переход в директорию:
        /// </summary>
        public void MoveToDir(string dirName)
        {
            string newDir = Path.Combine(currentDir, dirName);
                if (Directory.Exists(newDir))
                {
                    currentDir = newDir;
                    Console.WriteLine("Переход в директорию: " + currentDir);
                }
                    else
                    {
                        Console.WriteLine("Директория не найдена.");
                    }
        }
    }

    class Program
    {
        static void Main()
        {
            string commandPC = "";
            DirNavigator nav = new DirNavigator();

            
            while (commandPC != "exit")
            {
                Console.Write("Введите команду:");
                commandPC = Console.ReadLine();

                switch (commandPC)
                {
                    case "dirs":
                        nav.ShowDirectories();
                            break;
                    case "files":
                        nav.ShowFiles();
                            break;
                    case "back":
                        nav.MoveBack();
                            break;
                    default:
                            if (commandPC.StartsWith("cd "))
                            {
                                string dirName = commandPC.Substring(3);
                                nav.MoveToDir(dirName);
                            }
                                break;
                }
            }
        }
    }
}
