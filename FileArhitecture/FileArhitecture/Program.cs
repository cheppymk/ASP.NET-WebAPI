using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileLister
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your project's root folder path
            string rootPath = @"C:\Users\tosom\OneDrive\Desktop\sp2023-cp02-dsw-5";
            // Where you want the output CSV to be saved
            string outputPath = @"C:\Users\tosom\OneDrive\Desktop\output.csv";

            List<string[]> fileData = new List<string[]>();

            // Add the header to the CSV
            fileData.Add(new string[] { "Directory", "FileName", "Extension" });

            // Traverse the directory and populate fileData
            TraverseFiles(rootPath, fileData);

            // Write to the CSV file
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (var row in fileData)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }
        }

        static void TraverseFiles(string path, List<string[]> fileData)
        {
            try
            {
                foreach (string directory in Directory.GetDirectories(path))
                {
                    foreach (string file in Directory.GetFiles(directory))
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        fileData.Add(new string[]
                        {
                            directory,
                            fileInfo.Name,
                            fileInfo.Extension
                        });
                    }
                    TraverseFiles(directory, fileData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
