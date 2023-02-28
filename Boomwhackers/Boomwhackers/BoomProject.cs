using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

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

        public BoomData data = new BoomData();

        public string projectLocationIfKnown = null;

        // Create empty project
        public BoomProject()
        {
            LoadData(Properties.Resources.ResourceManager.GetString("defaultProject"));
        }

        public BoomProject(string location)
        {
            LoadDataFromFile(location);
        }

        [JsonIgnore]
        public bool madeChanges = false;

        [JsonIgnore]
        public string jsonData
        {
            get
            {
                return JsonConvert.SerializeObject(this);
            }
        }

        public void SaveData(string path)
        {
            if (!VerifyExtension(path))
            {
                throw new Exception("Invalid file extension");
            }
            
            try
            {
                File.WriteAllText(path, jsonData);
                //MessageBox.Show("Projekt je bil uspešno shranjen.", "Shranjevanje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LoadDataFromFile(string loadFile)
        {
            if (!VerifyExtension(loadFile))
            {
                throw new Exception("Invalid file extension");
            }

            string loadData = File.ReadAllText(loadFile);

            LoadData(loadData);
        }

        public void LoadData(string loadData)
        {
            //MessageBox.Show(loadData);
            try
            {
                JsonConvert.PopulateObject(loadData, this);
            }
            catch
            {
                throw new InvalidDataException();
            }
        }
    }
}
