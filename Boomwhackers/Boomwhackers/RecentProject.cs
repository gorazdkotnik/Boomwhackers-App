namespace Boomwhackers
{
    public class RecentProject
    {
        private string location;

        public RecentProject(string location)
        {
            this.location = location;
        }

        public string Location
        {
            get
            {
                return location;
            }
        }
    }
}
