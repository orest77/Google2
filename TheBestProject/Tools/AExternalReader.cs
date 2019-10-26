using System.Collections.Generic;
using System.Reflection;

namespace TheBestProject.Tools
{
    public abstract class AExternalReader
    {
        public const int PATH_PREFIX = 6;
        public const string PATH_SEPARATOR = "\\";
        private const string FOLDER_DATA = "Resource";
        private const string FOLDER_BIN = "bin";

        public string Filename { get; protected set; }
        public string Path { get; protected set; }

        protected AExternalReader(string filename)
        {
            Filename = filename;
            Path = System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(AExternalReader)).CodeBase)
                    .Substring(PATH_PREFIX);
            Path = Path.Remove(Path.IndexOf(FOLDER_BIN)) + FOLDER_DATA + PATH_SEPARATOR + filename;
        }

        public abstract IList<IList<string>> GetAllCells();

        public abstract IList<IList<string>> GetAllCells(string path);

        public abstract string GetConnection();
    }
}
