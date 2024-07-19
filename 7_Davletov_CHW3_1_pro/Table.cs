using JSONObjects;
using System.Data;

namespace _7_Davletov_CHW3_1_pro
{
    public partial class Table : Form
    {

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Table() { }

        /// <summary>
        /// Constructor with list of the Project class objects.
        /// </summary>
        /// <param name="projects">List of the Project class objects.</param>
        public Table(List<Project> projects)
        {
            InitializeComponent();

            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            DataTable table = new DataTable();
            table.Columns.Add("global_id", typeof(int));
            table.Columns.Add("project_name", typeof(string));
            table.Columns.Add("client", typeof(string));
            table.Columns.Add("start_date", typeof(DateTime));
            table.Columns.Add("status", typeof(string));
            table.Columns.Add("team_members", typeof(string));
            table.Columns.Add("tasks", typeof(string));

            for (int i = 0; i < projects.Count; i++)
            {
                table.Rows.Add(projects[i].ProjectId, projects[i].ProjectName, projects[i].Client,
                    projects[i].StartDate, projects[i].Status, String.Join(", ", projects[i].TeamMembers),
                    String.Join(", ", projects[i].Tasks));
            }

            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}