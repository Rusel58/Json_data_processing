using JSONObjects;

namespace DataProcessing
{

    /// <summary>
    /// Class for working with variants of column.
    /// </summary>
    public static class ColumnVariants
    {

        /// <summary>
        /// A method for getting variants of the column.
        /// </summary>
        /// <param name="projects">List of the Project class objects.</param>
        /// <param name="header">Column.</param>
        /// <returns>Array with all non-repetitive variants of the column.</returns>
        public static string[] VariantsOfColumn(List<Project> projects, string header)
        {
            string[] variants = new string[projects.Count];
            int counter = 0;
            foreach (Project project in projects)
            {
                string p = ProjectProcessing.GetClassField(project, header);
                if (Array.IndexOf(variants, p) == -1)
                {
                    variants[counter++] = p;
                }
            }
            int kol = GetCountOfVariants(variants);
            variants = MakeCorrectArray(variants, kol);
            return variants;
        }

        /// <summary>
        /// A method for getting string of all non-repetetive variants of the column.
        /// </summary>
        /// <param name="projects">List of the Project class objects.</param>
        /// <param name="header">Column</param>
        /// <returns></returns>
        public static string StringVariants(List<Project> projects, string header)
        {
            string choice = string.Empty;
            string[] variants = new string[projects.Count];
            int counter = 0;
            foreach (Project project in projects)
            {
                string p = ProjectProcessing.GetClassField(project, header);
                if (Array.IndexOf(variants, p) == -1)
                {
                    choice += p + ", ";
                    variants[counter++] = p;
                }
            }
            return "(" + choice.Trim(' ').Trim(',') + ")";
        }

        /// <summary>
        /// A mehtod for getting count of values that not empty.
        /// </summary>
        /// <param name="data">Array for counting values.</param>
        /// <returns>Count values that not empty.</returns>
        public static int GetCountOfVariants(string[] data)
        {
            int counter = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != string.Empty)
                {
                    counter++;
                }
            }
            return counter;
        }

        /// <summary>
        /// A method for making correct array with first values.
        /// </summary>
        /// <param name="data">Array with values before the conversion.</param>
        /// <param name="kol">The number of the first elements.</param>
        /// <returns>Array with values after the conversion.</returns>
        public static string[] MakeCorrectArray(string[] data, int kol)
        {
            string[] newdata = new string[kol];
            for (int i = 0; i < kol; i++)
            {
                newdata[i] = data[i];
            }
            return newdata;
        }
    }
}