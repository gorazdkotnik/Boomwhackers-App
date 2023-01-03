using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace Boomwhackers
{
    public class RecentProjectData
    {
        private List<RecentProject> recentProjects = new List<RecentProject>();
        private string jsonFileLocation = Path.Combine(Application.StartupPath, "recentProjects.json");

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

        private RecentProjectData()
        {
            LoadData();
        }

        public void AddProject(RecentProject project)
        {
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
            File.WriteAllText(jsonFileLocation, JsonConvert.SerializeObject(this));
        }

        public void LoadData()
        {
            if (File.Exists(jsonFileLocation))
            {
                RecentProjectData data = JsonConvert.DeserializeObject<RecentProjectData>(File.ReadAllText(jsonFileLocation));
                recentProjects = data.recentProjects;
            } else
            {
                SaveData();
            }
        }
    }
}
