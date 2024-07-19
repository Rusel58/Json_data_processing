using IOController;
using JSONObjects;
using JSONProcessing;
using InOut;
using DataProcessing;

namespace _7_Davletov_CHW3_1_pro;
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        bool EndOfProgram = false;
        List<Project> projects = new List<Project>();
        while (true)
        {
            try
            {
                // Input data reading.
                projects = ProgramProcessing.GetData();
                break;
            }

            catch (FileNotFoundException) // Catching the error that the file was not found.
            {
                ConsoleController.WriteLine("Файл не был найден.", ConsoleColor.Red);
            }
            catch (ArgumentException) // Catching an error related to the file name.
            {
                ConsoleController.WriteLine("Введено некорректное название файла.", ConsoleColor.Red);
            }
            catch (IOException) // Catching an error when opening a file.
            {
                ConsoleController.WriteLine("При открытии файла произошла ошибка.", ConsoleColor.Red);
            }
            catch (Exception ex) // Catching the remaining errors.
            {
                ConsoleController.WriteLine($"Ошибка: {ex.Message}", ConsoleColor.Red);
            }
        }

        while (!EndOfProgram)
        {

            try
            {

                // Menu output.
                Output.PrintMenu();

                // Selection of a menu item by the user.
                int menuChoice = Input.GetCorrectNumberFromUser("Выберите пункт меню: ", 1, 6);
                switch (menuChoice)
                {
                    case 1:
                        // Data reading.
                        projects = ProgramProcessing.GetData();
                        break;
                    case 2:
                        // Data filtering.
                        projects = DataFilter.Filter(projects);

                        // Data output with windows form.
                        Application.Run(new Table(projects));
                        break;
                    case 3:
                        // Sorting the data.
                        projects = DataSort.Sort(projects, DataSort.IsReverse());

                        // Data output with windows form.
                        Application.Run(new Table(projects));
                        break;
                    case 4:
                        // Data output with windows form.
                        Application.Run(new Table(projects));
                        break;
                    case 5:
                        // Data recording.
                        JsonParser.WriteJson(projects);
                        break;
                    case 6:
                        // End of the program.
                        EndOfProgram = true;
                        break;
                }
            }

            catch (FileNotFoundException) // Catching the error that the file was not found.
            {
                ConsoleController.WriteLine("Файл не был найден.", ConsoleColor.Red);
            }
            catch (ArgumentException) // Catching an error related to the file name.
            {
                ConsoleController.WriteLine("Введено некорректное название файла.", ConsoleColor.Red);
            }
            catch (IOException) // Catching an error when opening a file.
            {
                ConsoleController.WriteLine("При открытии файла произошла ошибка.", ConsoleColor.Red);
            }
            catch (Exception ex) // Catching the remaining errors.
            {
                ConsoleController.WriteLine($"Ошибка: {ex.Message}", ConsoleColor.Red);
            }
        }
    }
}