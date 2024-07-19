using System.Text.RegularExpressions;
using JSONObjects;
using IOController;

namespace JSONProcessing
{

    /// <summary>
    /// Class for working with JSON files.
    /// </summary>
    public static class JsonParser
    {
        /// <summary>
        /// A method for reading a JSON file.
        /// </summary>
        /// <returns>A dictionary where the keys are headers, and the value of the dictionary is the value.</returns>
        public static List<Dictionary<string, object>> ReadJson()
        {
            string js = String.Empty;

            while (true)
            {
                string? temp = Console.ReadLine();
                if (string.IsNullOrEmpty(temp))
                {
                    break;
                }
                js += temp.Trim();
            }

            List<Dictionary<string, object>> projects = new List<Dictionary<string, object>>();

            Regex regex = new Regex("{.+?}");
            MatchCollection matches = regex.Matches(js);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Regex regexProject = new Regex("\"([^\"]+)\"\\s*:\\s*(\"([^\"]*)\"\\s*|\\[[^\\]]+\\]|[^{},\\s]+)");
                    MatchCollection matcheskeys = regexProject.Matches(match.Value);

                    projects.Add(JsonReaderProcessing.MakeDictionaryFromJSON(matcheskeys));
                }
            }

            return projects;
        }

        /// <summary>
        /// A method for writing a JSON file.
        /// </summary>
        /// <param name="projects">A list with objects of the Project class where JSON objects are stored.</param>
        public static void WriteJson(List<Project> projects)
        {
            ConsoleController.WriteLine("Для записи может потребоваться некоторое время.", ConsoleColor.DarkMagenta);
            int choice = JsonWriterProcessing.VariantsForWriter();
            if (choice == 2 || choice == 3)
            {
                string JsPath = JsonWriterProcessing.GetPathDepenceOnVariantOfWriter(choice);
                TextWriter save_out = Console.Out;
                StreamWriter streamWriter = new StreamWriter(JsPath);
                Console.SetOut(streamWriter);

                Console.Write(JsonWriterProcessing.MakeJsonStringToWrite(projects));

                Console.Out.Close();
                Console.SetOut(save_out);

                ConsoleController.WriteLine("Данные успешно записаны!", ConsoleColor.Green);
            }
            else
            {
                Console.WriteLine(JsonWriterProcessing.MakeJsonStringToWrite(projects));

                ConsoleController.WriteLine("Данные успешно записаны (выведены)!", ConsoleColor.Green);
            }
        }
    }
}