using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Boomwhackers
{
    public class InvalidExtensionException : Exception { }
    public class InvalidDataException : Exception { }
    class BoomProject
    {
        public static string extension = "boom";

        public static bool VerifyExtension(string path)
        {
            return Path.GetExtension(path) == extension;
        }


        public string projectName;

        private BoomData data = new BoomData();
        private string projectRoot;

        BoomProject(string projectName, string projectRoot)
        {
            this.projectName = projectName;
            this.projectRoot = projectRoot;
        }

        BoomProject(string loadFile)
        {
            LoadData(loadFile);
        }

        public string DefaultLocation()
        {
            string path = Path.Combine(projectRoot, projectName);
            return Path.ChangeExtension(path, extension);
        }

        public void SaveData()
        {
            SaveData(DefaultLocation());
        }

        public void SaveData(string path = null)
        {
            if (path == null)
            {
                path = DefaultLocation();
            }

            if (!VerifyExtension(path))
            {
                throw new Exception("Invalid file extension");
            }

            string jsonData = JsonConvert.SerializeObject(data);

            File.WriteAllText(path, jsonData);
        }


        public void LoadData(string loadFile)
        {
            if (!VerifyExtension(loadFile))
            {
                throw new Exception("Invalid file extension");
            }

            string loadData = File.ReadAllText(loadFile);

            BoomData loadedProject = JsonConvert.DeserializeObject<BoomData>(loadData);

            if (loadedProject == null)
            {
                throw new Exception("Invalid project");
            }

            data = loadedProject;
        }
    }
}
