using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boomwhackers
{
    internal static class ProjectManager
    {
        static OpenFileDialog openProjectDialog = new OpenFileDialog()
        {
            FileName = "Izberi projekt",
            Filter = BoomProject.filter,
            Title = "Odpri Boomwhackers projekt",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        };

        static SaveFileDialog saveProjectDialog = new SaveFileDialog()
        {
            Title = "Izberi, kam shraniti projekt",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            AddExtension = true,
            Filter = BoomProject.filter,
        };

        public static void SaveProjectDialog(BoomProject project)
        {
            if (project.projectLocationIfKnown != null)
            {
                project.SaveData(project.projectLocationIfKnown);

                //SetStatus("Projekt shranjen: " + openProjectLocation);
            }
            else
            {
                SaveProjectAsDialog(project);
            }
        }

        public static void SaveProjectAsDialog(BoomProject project)
        {
            if (saveProjectDialog.ShowDialog() == DialogResult.OK)
            {
                project.SaveData(saveProjectDialog.FileName);
                project.projectLocationIfKnown = saveProjectDialog.FileName;

                //SetStatus("Projekt shranjen kot: " + saveProjectDialog.FileName);
            }
        }

        public static BoomProject LoadProjectDialog()
        {
            if (openProjectDialog.ShowDialog() == DialogResult.OK)
            {
                return LoadProject(openProjectDialog.FileName);
            }

            return null;
        }

        public static BoomProject LoadProject(string location)
        {
            BoomProject project = new BoomProject(location);
            project.projectLocationIfKnown = location;

            //InitializeEditor();

            //SetStatus("Odprt projekt: " + openProjectLocation);
            RecentProjectsData.AddProject(new RecentProject(project.projectLocationIfKnown));

            return project;
        }

        public static BoomProject CreateProjectDialog()
        {
            CreateProject createForm = new CreateProject();

            if (createForm.ShowDialog() == DialogResult.OK)
            {
                BoomProject openProject = createForm.project;

                if (openProject != null)
                {
                    return openProject;
                }
                else
                {
                    MessageBox.Show("Null project");
                }
            }

            return null;
        }


    }
}
