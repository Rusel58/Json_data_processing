using IOController;

namespace InOut
{
    /// <summary>
    /// A class for outputting data to the console.
    /// </summary>
    public static class Input
    {

        /// <summary>
        /// A method for requesting the correct number from the user.
        /// </summary>
        /// <param name="message">A message with a choice.</param>
        /// <param name="min">The minimum number of choices.</param>
        /// <param name="max">The maximum number of choices.</param>
        /// <returns>User's choice.</returns>
        public static int GetCorrectNumberFromUser(string message, int min, int max)
        {
            while (true)
            {
                ConsoleController.Write(message, ConsoleColor.Blue);

                if (int.TryParse(ConsoleController.ReadLine(), out int number) &&
                    number >= min && number <= max)
                    return number;

                ConsoleController.WriteLine("Некорректный ввод, повторите попытку", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// A method for getting column from the user.
        /// </summary>
        /// <returns></returns>
        public static string GetHeaderFromUser()
        {
            Output.PrintChoicesForHeader();
            int choice = GetCorrectNumberFromUser("Выберите нужный пункт: ", 1, 5);
            string[] choices = { "ProjectId", "ProjectName", "Client", "StartDate", "Status" };
            return choices[choice - 1];
        }
    }
}