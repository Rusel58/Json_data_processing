using JSONObjects;
using IOController;
using InOut;

namespace JSONProcessing
{

    /// <summary>
    /// A class for working with writing JSON file.
    /// </summary>
    public static class JsonWriterProcessing
    {

        /// <summary>
        /// A method for making JSONObject in string.
        /// </summary>
        /// <param name="project">JSON object in Project class.</param>
        /// <returns>String with JSON object.</returns>
        public static string MakeJSONObject(Project project)
        {
            string jsObject = "  {\n";
            jsObject += MakeJSONString("project_id", project.ProjectId.ToString());
            jsObject += MakeJSONString("project_name", "\"" + project.ProjectName + "\"");
            jsObject += MakeJSONString("client", "\"" + project.Client + "\"");
            jsObject += MakeJSONString("start_date", "\"" + project.StartDate.ToString("yyyy-MM-dd") + "\"");
            jsObject += MakeJSONString("status", "\"" + project.Status + "\"");
            jsObject += MakeJSONArray("team_members", project.TeamMembers) + ",\n";
            jsObject += MakeJSONArray("tasks", project.Tasks) + "\n";
            jsObject += "  }";
            return jsObject;
        }

        /// <summary>
        /// A method for making string with key and value in JSON.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        /// <returns>String with key and value.</returns>
        public static string MakeJSONString(string key, string value)
        {
            return $"    \"{key}\": {value},\n";
        }

        /// <summary>
        /// A method for making string with key and value with Array in value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value with array.</param>
        /// <returns>String with key and value with Array in value.</returns>
        public static string MakeJSONArray(string key, string[] value)
        {
            string jsArray = $"    \"{key}\": [\n";
            for (int i = 0; i < value.Length; i++)
            {
                if (i != value.Length - 1)
                {
                    jsArray += $"      \"{value[i]}\",\n";
                }
                else
                {
                    jsArray += $"      \"{value[i]}\"\n";
                }
            }
            jsArray += "    ]";
            return jsArray;
        }

        /// <summary>
        /// Method for getting variant of writer from the user.
        /// </summary>
        /// <returns>Variant of writer from the user.</returns>
        public static int VariantsForWriter()
        {
            if (JsonReaderProcessing.JsPath == String.Empty)
            {
                ConsoleController.WriteLine("Данные считывались из консоли.", ConsoleColor.DarkGreen);
                ConsoleController.WriteLine("1. Вывести в консоль.", ConsoleColor.DarkGreen);
                ConsoleController.WriteLine("2. Записать новый файл.", ConsoleColor.DarkGreen);
                return Input.GetCorrectNumberFromUser(("Выберите нужный пункт: "), 1, 2);
            }
            else
            {
                ConsoleController.WriteLine("Выберите вариант записи файла:", ConsoleColor.Cyan);
                ConsoleController.WriteLine("1. Вывести в консоль.", ConsoleColor.DarkGreen);
                ConsoleController.WriteLine("2. Записать новый файл.", ConsoleColor.DarkGreen);
                ConsoleController.WriteLine("3. Перезаписать исходный файл.", ConsoleColor.DarkGreen);
                return Input.GetCorrectNumberFromUser(("Выберите нужный пункт: "), 1, 3);
            }
        }

        /// <summary>
        /// A method for getting the absolute path of the file to write to.
        /// </summary>
        /// <returns>An absolute path of the file to write to.</returns>
        public static string GetFilePath()
        {
            string jsPath;
            char[] invalidPathChars = Path.GetInvalidPathChars();
            while (true)
            {
                ConsoleController.Write("Введите абсолютный путь (без кавычек) для сохранения JSON файла: ",
                    ConsoleColor.Blue);
                jsPath = ConsoleController.ReadLine();
                if (jsPath != null && jsPath.IndexOfAny(invalidPathChars) == -1
                    && FileProcessing.FileIsAvailibleToCreate(jsPath))
                {
                    break;
                }
                else
                {
                    ConsoleController.WriteLine("Некорректные данные, повторите ввод:", ConsoleColor.Red);
                }
            }
            return jsPath;
        }

        /// <summary>
        /// A method for getting Path depence on variant of writer/
        /// </summary>
        /// <returns>Path of the file to write.</returns>
        public static string GetPathDepenceOnVariantOfWriter(int choice)
        {
            if (choice == 3)
            {
                return JsonReaderProcessing.JsPath;
            }
            else
            {
                return GetFilePath();
            }
        }

        public static string MakeJsonStringToWrite(List<Project> projects)
        {
            string print = "[\n";
            for (int i = 0; i < projects.Count; i++)
            {
                print += JsonWriterProcessing.MakeJSONObject(projects[i]);
                if (i != projects.Count - 1)
                {
                    print += ",";
                }
                print += "\n";
            }
            print += "]";
            return print;
        }
    }
}