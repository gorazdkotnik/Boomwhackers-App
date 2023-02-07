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
        }

        public void LoadData()
        {
            if (File.Exists(jsonFileLocation))
            {      
                recentProjects = JsonConvert.DeserializeObject<List<RecentProject>>(File.ReadAllText(jsonFileLocation));
            } else
            {
                SaveData();
            }
        }
    }
}
