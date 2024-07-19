using IOController;

namespace InOut
{

    /// <summary>
    /// A class for inputting data to the console.
    /// </summary>
    public static class Output
    {

        /// <summary>
        /// A method for outputing menu.
        /// </summary>
        public static void PrintMenu()
        {
            ConsoleController.WriteLine("Меню:", ConsoleColor.Cyan);
            ConsoleController.WriteLine("1. Ввести данные.", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("2. Отфильтровать данные по одному из полей заголовка.", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("3. Отсортировать данные по одному из заголовков.", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("4. Вывести данные.", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("5. Сохранить данные в файл (вывести в консоль).", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("6. Выход.", ConsoleColor.DarkGreen);
        }

        /// <summary>
        /// A method for outputing choise for getting data.
        /// </summary>
        public static void PrintChoiseGettingData()
        {
            ConsoleController.WriteLine("Выберите способ ввода данных:", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("1. Ввести данные через консоль.", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("2. Считать данные из файла.", ConsoleColor.DarkGreen);
        }

        /// <summary>
        /// A method for printing possible column options.
        /// </summary>
        public static void PrintChoicesForHeader()
        {
            ConsoleController.WriteLine("Возможные заголовки:", ConsoleColor.Cyan);
            ConsoleController.WriteLine("1. Id", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("2. Name", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("3. Client", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("4. Date", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("5. Status", ConsoleColor.DarkGreen);
        }

        /// <summary>
        /// A method for getting column from the user.
        /// </summary>
        /// <returns></returns>
        public static string GetHeaderFromUser()
        {
            PrintChoicesForHeader();
            int choice = Input.GetCorrectNumberFromUser("Выберите нужный пункт: ", 1, 5);
            string[] choices = { "ProjectId", "ProjectName", "Client", "StartDate", "Status" };
            return choices[choice - 1];
        }

        /// <summary>
        /// Method for getting all non-repetitive variants of column.
        /// </summary>
        /// <returns>All non-repetitive variants of column.</returns>
        public static int VariantsForSort()
        {
            ConsoleController.WriteLine("Выберите в каком порядке отсортировать:", ConsoleColor.Cyan);
            ConsoleController.WriteLine("1. В прямом порядке.", ConsoleColor.DarkGreen);
            ConsoleController.WriteLine("2. В обратном порядке.", ConsoleColor.DarkGreen);
            return Input.GetCorrectNumberFromUser(("Выберите нужный пункт: "), 1, 2);
        }
    }
}