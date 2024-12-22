using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ExerciseRepository.Business_Entities;

namespace ExerciseRepository.Data_Access
{
    public class FileRepository : IRepository
    {
        #region IRepository Members

        public void Save(ExerciseRepositoryDataObject dataObject)
        {
            // Save settings to a binary file
            using (FileStream fs = new FileStream(dataObject.FileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, dataObject.bio_data);
            }
        }

        public ExerciseRepositoryDataObject Get(string fileName)
        {
            ExerciseRepositoryDataObject data = new ExerciseRepositoryDataObject(fileName);

            if (File.Exists(data.FileName))
            {
                try
                {
            
                    // Load and parse settings from binary file
                    using (FileStream fs = new FileStream(data.FileName, FileMode.Open))
                    {
                        if (fs.Length > 0)
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            data.bio_data = (Bio)formatter.Deserialize(fs);
                        }
                        else
                        {
                            // data.Settings = new TreeStencilsSettings();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle deserialization error (e.g., log the error, set default settings, etc.)
                    //Console.WriteLine($"Error deserializing settings: {ex.Message}");
                    //data.Settings = new TreeStencilsSettings();
                }


                // Return the reconstructed MilestoneDataObject
                // return new MilestoneDataObject(fileName, rootNode, nodes);
                return data;
            }
            else
            {
                return null;
            }
        }

        #endregion

    }
}

