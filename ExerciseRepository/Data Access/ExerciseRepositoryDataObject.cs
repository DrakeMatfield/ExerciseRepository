using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExerciseRepository.Business_Entities;

namespace ExerciseRepository.Data_Access
{
    public class ExerciseRepositoryDataObject
    {
        public string FileName { get; set; }
        public string FileNameWithoutEXT { get; set; } // New property including path without extension

        public Bio bio_data { get; set; }
        //Bio data;

        public ExerciseRepositoryDataObject()
        {

        }
        public ExerciseRepositoryDataObject(string fileName, Bio _data)
        {
            FileName = fileName;
            FileNameWithoutEXT = GetFileNameWithoutExtension(fileName); // Set the new property with path

            this.bio_data = _data;
        }

        public ExerciseRepositoryDataObject(string fileName)
        {
            FileName = fileName;
            FileNameWithoutEXT = GetFileNameWithoutExtension(fileName); // Set the new property with path

        }

        private string GetFileNameWithoutExtension(string fileName)
        {
            // Get the full path without the extension
            string directory = System.IO.Path.GetDirectoryName(fileName);
            string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileName);
            return System.IO.Path.Combine(directory, fileNameWithoutExtension);
        }
    }
}
