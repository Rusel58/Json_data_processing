using System.Text.RegularExpressions;
using IOController;
using InOut;

namespace JSONProcessing
{

    /// <summary>
    /// A class for working with reading JSON file.
    /// </summary>
    public static class JsonReaderProcessing
    {

        /// <summary>
        /// Storing the absolute path of the file to overwrite it.
        /// </summary>
        public static string JsPath = String.Empty;

        /// <summary>
        /// A method for requesting the path to the JSON file from the user. 
        /// </summary>
        /// <returns>An absolute path of the file to read.</returns>
        public static string GetJSONPathFromUserToRead()
        {
            while (true)
            {
                ConsoleController.Write("Введите абсолютный путь к JSON файлу (без кавычек): ", ConsoleColor.Blue);
                string path = ConsoleController.ReadLine();
                if (File.Exists(path))
                {
                    JsPath = path;
                    return path;
                }
                ConsoleController.WriteLine("Файл не найден, повторите ввод пути.", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// A method for making dictionary with JSON object.
        /// </summary>
        /// <param name="keysValues">JSON object.</param>
        /// <returns>Dictionary with JSON object.</returns>
        public static Dictionary<string, object> MakeDictionaryFromJSON(MatchCollection keysValues)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            foreach (Match elem in keysValues)
            {
                switch (elem.Groups[1].Value)
                {
                    case "project_id":
                        int number;
                        if (int.TryParse(elem.Groups[2].Value, out number))
                        {
                            pairs.Add(elem.Groups[1].Value, number);
                        }
                        break;
                    case "project_name":
                        pairs.Add(elem.Groups[1].Value, elem.Groups[2].Value.Trim('"'));
                        break;
                    case "client":
                        pairs.Add(elem.Groups[1].Value, elem.Groups[2].Value.Trim('"'));
                        break;
                    case "start_date":
                        string[] data = elem.Groups[2].Value.Trim('"').Split('-');
                        int year, month, day;
                        if (int.TryParse(data[0], out year) && int.TryParse(data[1], out month)
                            && int.TryParse(data[2], out day))
                        {
                            pairs.Add(elem.Groups[1].Value, new DateTime(year, month, day));
                        }
                        break;
                    case "status":
                        pairs.Add(elem.Groups[1].Value, elem.Groups[2].Value.Trim('"'));
                        break;
                    case "team_members":
                        string[] dataTM = elem.Groups[2].Value.Trim('[').Trim(']').Split(",");
                        dataTM = dataTM.Select(x => x.Replace("\"", "")).ToArray();
                        pairs.Add(elem.Groups[1].Value, dataTM);
                        break;
                    case "tasks":
                        string[] dataT = elem.Groups[2].Value.Trim('[').Trim(']').Split(",");
                        dataT = dataT.Select(x => x.Replace("\"", "")).ToArray();
                        pairs.Add(elem.Groups[1].Value, dataT);
                        break;
                    default:
                        break;
                }
            }
            return pairs;
        }

        /// <summary>
        /// A method for Reading JSON file depence on user's choice.
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> GetDataDepenceOnVariantsOfRead(int choice)
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            switch (choice)
            {
                case 1:
                    ConsoleController.WriteLine("После ввода данных, введите Ctrl+Z (или нажмите Enter)" +
                        " с новой строки.", ConsoleColor.DarkGreen);
                    data = JsonParser.ReadJson();
                    ConsoleController.WriteLine("Данные успешно считаны!", ConsoleColor.Green);
                    break;
                case 2:
                    string jsPath = GetJSONPathFromUserToRead(); // Getting the path to the JSON file from the user.
                    JsPath = jsPath;
                    StreamReader streamReader = new StreamReader(jsPath);
                    Console.SetIn(streamReader);
                    data = JsonParser.ReadJson();
                    ConsoleController.WriteLine("Данные успешно считаны!", ConsoleColor.Green);
                    streamReader.Dispose();
                    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
                    break;
            }
            return data;
        }
    }
}