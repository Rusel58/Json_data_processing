using InOut;
using JSONObjects;
using JSONProcessing;

namespace _7_Davletov_CHW3_1_pro
{

    /// <summary>
    /// Class for working with program.cs.
    /// </summary>
    public static class ProgramProcessing
    {

        /// <summary>
        /// A method for getting data with list of the Project class objects.
        /// </summary>
        /// <returns></returns>
        public static List<Project> GetData()
        {
            Output.PrintChoiseGettingData();
            int choice = Input.GetCorrectNumberFromUser("Выберите пункт записи данных: ", 1, 2);
            return ProjectProcessing.MakeProjects(JsonReaderProcessing.GetDataDepenceOnVariantsOfRead(choice));
        }
    }
}