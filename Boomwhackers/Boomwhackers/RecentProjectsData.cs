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
    public class RecentProjectsData
    {
        private static List<RecentProject> recentProjects = new List<RecentProject>();
        private static string jsonFileLocation = Path.Combine(Application.StartupPath, "recentprojects.json");
        private static int maxSize = 10;

        private static bool loaded = false;

        public static void AddProject(RecentProject project)
        {
            if (recentProjects.Exists(x => x.Location == project.Location))
            {
                recentProjects.Remove(recentProjects.Find(x => x.Location == project.Location));
            }

            recentProjects.Add(project);

            if (recentProjects.Count > maxSize)
            {
                recentProjects.RemoveAt(0);
            }

            SaveData();
        }

        public static void RemoveProject(RecentProject project)
        {
            recentProjects.Remove(project);
            SaveData();
        }

        public static List<RecentProject> RecentProjects
        {
            get
            {
                if (!loaded)
                {
                    LoadData();
                    loaded = true;
                }
                return recentProjects;
            }
        }

        private static void SaveData()
        {
            if (!File.Exists(jsonFileLocation))
            {
                File.Create(jsonFileLocation).Close();
            }
            File.WriteAllText(jsonFileLocation, JsonConvert.SerializeObject(recentProjects));
        }
        
        private static void LoadData()
        {
            try
            {
                if (File.Exists(jsonFileLocation))
                {
                    recentProjects = JsonConvert.DeserializeObject<List<RecentProject>>(File.ReadAllText(jsonFileLocation));
                } else
                {
                    recentProjects = new List<RecentProject>();
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Prišlo je do napake pri nalaganju podatkov o nedavnih projektih. Napaka: ", "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
