using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Infrastructure.SeedData
{
    public class SeedHelper<T>
    {
        public static List<T> GetData(string filePath, string folderName)
        {
            var baseDir = Directory.GetCurrentDirectory();
            var path = File.ReadAllText(FilePath(baseDir, filePath, folderName));
            return JsonConvert.DeserializeObject<List<T>>(path);
        }

        private static string FilePath(string curDir, string fileName, string folderName)
        {
            curDir += $"/{folderName}/";
            return Path.Combine(curDir, fileName);
        }
    }
}
