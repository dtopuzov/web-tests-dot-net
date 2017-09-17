using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FunctionalTestinngCore.Utils
{
    public class OSUtils
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static string ProjectDirectory
        {
            get
            {
                var directory = new DirectoryInfo(AssemblyDirectory);
                while (directory != null && !directory.GetFiles("*.csproj").Any())
                {
                    directory = directory.Parent;
                }
                return directory.FullName;
            }
        }

        public static string SolutionDirectory
        {
            get
            {
                var directory = new DirectoryInfo(AssemblyDirectory);
                while (directory != null && !directory.GetFiles("*.sln").Any())
                {
                    directory = directory.Parent;
                }
                return directory.FullName;
            }
        }

        public static string NormalizePath(string path)
        {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalid)
            {
                path = path.Replace(c.ToString(), "");
            }

            return path;
        }

        public static void CreatePath(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);
        }
    }
}
