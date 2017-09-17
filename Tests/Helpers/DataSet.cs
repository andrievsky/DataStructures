using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.DotNet.PlatformAbstractions;

namespace Tests.Helpers
{
    public class DataSetSource
    {
        public string[] IntpuData { get; private set; }
        public string OutputData { get; private set; }

        public DataSetSource(string inputPath, string outputPath)
        {
            IntpuData = File.ReadAllText(inputPath).Trim().Split(null);
            OutputData = File.ReadAllText(outputPath).Trim();
        }

        public object[] ToObject()
        {
            return new object[] {IntpuData, OutputData};
        }
    }

    public class DataSet
    {
        public IList<DataSetSource> Items { get; private set; } = new List<DataSetSource>();
        public IList<object[]> Objects { get; private set; } = new List<object[]>();

        public DataSet(string folderPath, uint limit = 0)
        {
            folderPath = ResolvePath(folderPath);
            var inputFiles = Directory.GetFiles(folderPath, "*", SearchOption.TopDirectoryOnly);
            if (inputFiles.Length == 0)
            {
                throw new Exception(string.Format("Folder {0} does not contain any files", folderPath));
            }
            foreach (var filePath in inputFiles)
            {
                if (!string.IsNullOrEmpty(Path.GetExtension(filePath)))
                {
                    continue;
                }
                Items.Add(new DataSetSource(filePath, string.Format("{0}.a", filePath)));
                Objects.Add(Items.Last().ToObject());
                if (limit != 0 && Items.Count >= limit)
                {
                    break;
                }
            }
            if (Items.Count == 0)
            {
                throw new Exception(string.Format("Folder {0} does not contain any test data sources", folderPath));
            }
        }

        string ResolvePath(string relativePath)
        {
            return Path.Combine(ApplicationEnvironment.ApplicationBasePath, "../../../../", relativePath);
        }
    }
}