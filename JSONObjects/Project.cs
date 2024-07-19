namespace JSONObjects
{

    /// <summary>
    /// A class for storing JSON file data.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// project_id value.
        /// </summary>
        public readonly int ProjectId;

        /// <summary>
        /// project_name value.
        /// </summary>
        public readonly string ProjectName;

        /// <summary>
        /// client value.
        /// </summary>
        public readonly string Client;

        /// <summary>
        /// start_date value.
        /// </summary>
        public readonly DateTime StartDate;

        /// <summary>
        /// status value.
        /// </summary>
        public readonly string Status;

        /// <summary>
        /// team_members value.
        /// </summary>
        public readonly string[] TeamMembers;

        /// <summary>
        /// tasks value.
        /// </summary>
        public readonly string[] Tasks;

        /// <summary>
        /// An empty constructor with initial initialization of fields.
        /// </summary>
        public Project()
        {
            ProjectName = string.Empty;
            Client = string.Empty;
            StartDate = DateTime.MinValue;
            Status = string.Empty;
            TeamMembers = Array.Empty<string>();
            Tasks = Array.Empty<string>();
        }

        /// <summary>
        /// Сonstructor with initialization of fields.
        /// </summary>
        /// <param name="projectId">project_id value.</param>
        /// <param name="projectName">project_name value.</param>
        /// <param name="client">client value.</param>
        /// <param name="startDate">start_date value.</param>
        /// <param name="status">status value.</param>
        /// <param name="teamMembers">team_members value.</param>
        /// <param name="tasks">tasks value.</param>
        public Project(int projectId, string projectName, string client, DateTime startDate,
            string status, string[] teamMembers, string[] tasks)
        {
            ProjectId = projectId;
            ProjectName = projectName;
            Client = client;
            StartDate = startDate;
            Status = status;
            TeamMembers = teamMembers;
            Tasks = tasks;
        }
    }
}