namespace PruebaExamen.Helpers
{
    public enum Folders { images = 0, documents = 1 }

    public class HelperPathProvider
    {
        private IWebHostEnvironment environment;

        public HelperPathProvider(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public string MapPath(string fileName, Folders folder)
        {
            string carpeta = "";
            if (folder == Folders.images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.documents)
            {
                carpeta = "documents";
            }
            string path = Path.Combine(this.environment.WebRootPath
                , carpeta, fileName);
            return path;
        }
    }
}
