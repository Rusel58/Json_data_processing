using InOut;
using IOController;

namespace JSONObjects
{

    /// <summary>
    /// A class for working with Project class data.
    /// </summary>
    public static class ProjectProcessing
    {

        /// <summary>
        /// A method for getting field of the Project class object.
        /// </summary>
        /// <param name="project">List of the Project class objects.</param>
        /// <param name="header">Column.</param>
        /// <returns></returns>
        public static string GetClassField(Project project, string header)
        {
            string result = header switch
            {
                "ProjectId" => project.ProjectId.ToString(),
                "ProjectName" => project.ProjectName,
                "Client" => project.Client,
                "StartDate" => project.StartDate.ToString("yyyy.MM.dd"),
                "Status" => project.Status,
                _ => String.Empty
            };
            return result;
        }

        /// <summary>
        /// A method for making list of the Project class objects.
        /// </summary>
        /// <param name="objects">List of dictionaries of JSON objects.</param>
        /// <returns>List of the Project class object.</returns>
        public static List<Project> MakeProjects(List<Dictionary<string, object>> objects)
        {
            List<Project> projects = new List<Project>();
            foreach (var elem in objects)
            {
                if (elem.Count == 7)
                {
                    Project project = new Project((int)elem["project_id"], (string)elem["project_name"],
                        (string)elem["client"], (DateTime)elem["start_date"], (string)elem["status"],
                        (string[])elem["team_members"], (string[])elem["tasks"]);
                    projects.Add(project);
                }
            }
            return projects;
        }
    }
}