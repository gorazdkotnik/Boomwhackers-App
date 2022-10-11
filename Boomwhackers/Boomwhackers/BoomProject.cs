using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace Boomwhackers
{
    public class InvalidExtensionException : Exception { }
    public class InvalidDataException : Exception { }
    public class BoomProject
    {
        public static string extension = ".boom";
        public static string filter = "Boom project (*" + extension + ")|*" + extension;

        public static bool VerifyExtension(string path)
        {
            return Path.GetExtension(path) == extension;
        }


        public string projectName;

        public BoomData data = new BoomData();
        public string projectRoot;

        public BoomProject(string projectName, string projectRoot)
        {
            this.projectName = projectName;
            this.projectRoot = projectRoot;
        }

        public BoomProject(string loadFile)
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

        [JsonIgnore]
        public string jsonData
        {
            get
            {
                return JsonConvert.SerializeObject(this);
            }
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

            File.WriteAllText(path, jsonData);
        }


        public void LoadData(string loadFile)
        {
            if (!VerifyExtension(loadFile))
            {
                throw new Exception("Invalid file extension");
            }

            string loadData = File.ReadAllText(loadFile);

            try
            {
                JsonConvert.PopulateObject(loadData, this);
            } catch {
                throw new InvalidDataException();
            }
        }
    }
}
