using JSONObjects;
using InOut;
using IOController;

namespace DataProcessing
{

    /// <summary>
    /// Class to filter data.
    /// </summary>
    public static class DataFilter
    {

        /// <summary>
        /// A method for filter data by the value of the column..
        /// </summary>
        /// <param name="projects">List of the Project class objects.</param>
        /// <returns>Filtered list of the Project class objects.</returns>
        public static List<Project> Filter(List<Project> projects)
        {
            string header = Input.GetHeaderFromUser();
            ConsoleController.WriteLine($"Возможные варианты для {header}:", ConsoleColor.Cyan);
            ConsoleController.WriteLine(ColumnVariants.StringVariants(projects, header), ConsoleColor.Yellow);
            string[] areas = ColumnVariants.VariantsOfColumn(projects, header);
            if (areas.Length == 0)
            {
                return projects;
            }
            string area;
            while (true)
            {
                ConsoleController.Write("Введите доступное поле: ", ConsoleColor.Blue);
                area = ConsoleController.ReadLine();
                if ((area != null && Array.IndexOf(areas, area) != -1))
                {
                    break;
                }
                else
                {
                    ConsoleController.WriteLine("Такого значения нет в файле, повторите ввод.", ConsoleColor.Red);
                }
            }
            string p = ProjectProcessing.GetClassField(projects[0], header);

            projects = projects.Where(b =>
            {
                string x = ProjectProcessing.GetClassField(b, header);
                return x == area;
            }).ToList();
            return projects;
        }
    }
}