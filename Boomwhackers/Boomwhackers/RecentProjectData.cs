using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Boomwhackers
{
    public class RecentProjectData
    {
        private List<RecentProject> recentProjects = new List<RecentProject>();
        private string jsonFileLocation = Path.Combine(Application.StartupPath, "recentprojects.json");
        private ListBox recentProjectsListBox;

        private static RecentProjectData instance = null;
        

        public static RecentProjectData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecentProjectData();
                }
                return instance;
            }
        }

        public ListBox RecentProjectsListBox
        {
            get
            {
                return instance.recentProjectsListBox;
            }
            set
            {

                instance.recentProjectsListBox = value;
                UpdateListBox();
            }
        }

        private RecentProjectData()
        {
            LoadData();
        }

        public void AddProject(RecentProject project)
        {
            if (recentProjects.Exists(x => x.Location == project.Location))
            {
                recentProjects.Remove(recentProjects.Find(x => x.Location == project.Location));
            }

            recentProjects.Add(project);
            SaveData();
        }

        public void RemoveProject(RecentProject project)
        {
            recentProjects.Remove(project);
            SaveData();
        }

        public List<RecentProject> RecentProjects
        {
            get
            {
                return recentProjects;
            }
        }

        public void SaveData()
        {
            if (!File.Exists(jsonFileLocation))
            {
                File.Create(jsonFileLocation).Close();
            }
            File.WriteAllText(jsonFileLocation, JsonConvert.SerializeObject(recentProjects));

            UpdateListBox();
        }

        public void UpdateListBox()
        {
            if (recentProjectsListBox != null)
            {
                recentProjectsListBox.Items.Clear();

                for (int i = recentProjects.Count() - 1; i >= 0; i--)
                {
                    recentProjectsListBox.Items.Add(recentProjects[i].Location);
                }
            }
        }

        public void LoadData()
        {
            try
            {
                if (File.Exists(jsonFileLocation))
                {
                    recentProjects = JsonConvert.DeserializeObject<List<RecentProject>>(File.ReadAllText(jsonFileLocation));
                    UpdateListBox();
                }
                else
                {
                    SaveData();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Prišlo je do napake pri nalaganju podatkov o nedavnih projektih. Napaka: ", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
