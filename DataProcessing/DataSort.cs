using JSONObjects;
using InOut;

namespace DataProcessing
{

    /// <summary>
    /// Class to sort data.
    /// </summary>
    public static class DataSort
    {

        /// <summary>
        /// A method for sorting data.
        /// </summary>
        /// <param name="projects">List of the Project class objects.</param>
        /// <param name="reverse">Boolean parametr for reverse.</param>
        /// <returns>Sorted list of the Project class objects.</returns>
        public static List<Project> Sort(List<Project> projects, bool reverse)
        {
            string header = Input.GetHeaderFromUser();
            List<Project> sortedProjects;
            if (header == "ProjectId")
            {
                sortedProjects = projects.OrderBy(b =>
                {
                    int x = int.Parse(ProjectProcessing.GetClassField(b, header));
                    return x;
                }).ToList();
            }
            else
            {
                sortedProjects = projects.OrderBy(b =>
                {
                    string x = ProjectProcessing.GetClassField(b, header);
                    return x;
                }).ToList();
            }
            if (reverse)
            {
                sortedProjects.Reverse();
            }
            return sortedProjects;
        }

        /// <summary>
        /// Getting boolean answer if sort is reverse.
        /// </summary>
        /// <returns>Boolean answer.</returns>
        public static bool IsReverse()
        {
            if (Output.VariantsForSort() == 1)
            {
                return false;
            }
            return true;
        }
    }
}