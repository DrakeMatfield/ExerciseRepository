using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ExerciseRepository.Business_Entities;
using System.Xml.Linq;

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

        public void ExportToXml_original(ExerciseRepositoryDataObject dataObject)
        {
            string xml = BioParser.ConvertBioToXml(dataObject.bio_data);
            string filename = dataObject.FileName;

            XDocument d = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                XElement.Parse(xml)
            );

            d.Save(filename);
        }

        public void ExportToXml(ExerciseRepositoryDataObject dataObject)
        {
            string xml = BioParser.ConvertBioToXml(dataObject.bio_data);
            string filename = dataObject.FileName;
            string workoutSessionsFilename = dataObject.FileNameWithoutEXT + "_workouts.xml";

            string workoutSessionsfilename_withoutPath = System.IO.Path.GetFileName(workoutSessionsFilename);

            XDocument originalDoc = XDocument.Parse(xml);

            // Extract the <workout_sessions> element
            XElement workoutSessionsElement = originalDoc.Root.Element("workout_sessions");

            // Create a new document for workout sessions
            XDocument workoutSessionsDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                workoutSessionsElement
            );

            // Save the workout sessions document
            workoutSessionsDoc.Save(workoutSessionsFilename);

            // Remove the original <workout_sessions> element
            workoutSessionsElement.Remove();

            // Add an empty <workout_sessions> element with the filename attribute
            XElement emptyWorkoutSessionsElement = new XElement("workout_sessions",
                new XAttribute("filename", workoutSessionsfilename_withoutPath)
            );
            originalDoc.Root.Add(emptyWorkoutSessionsElement);

            // Save the original document with the modification
            originalDoc.Save(filename);
        }
        
        public ExerciseRepositoryDataObject ImportFromXml_original(string fileName)
        {
           ExerciseRepositoryDataObject data = new ExerciseRepositoryDataObject(fileName);

            if (File.Exists(data.FileName))
            {
                try
                {
                        // Read the XML from the file
                        string xmlContent = File.ReadAllText(fileName);

                        // Convert the XML string to a Bio object
                        data.bio_data = BioParser.ConvertXmlToBio(xmlContent);

                        return data;

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


        public ExerciseRepositoryDataObject ImportFromXml(string fileName)
        {
            ExerciseRepositoryDataObject data = new ExerciseRepositoryDataObject(fileName);

            if (File.Exists(data.FileName))
            {
                try
                {
                    // Read the XML from the original file
                    string xmlContent = File.ReadAllText(fileName);

                    // Convert the XML string to a Bio object
                    Bio bio = BioParser.ConvertXmlToBio(xmlContent);

                    // Get the filename of the workout sessions XML from the attribute
                    XElement bioElement = XElement.Parse(xmlContent);
                    XElement workoutSessionsElement = bioElement.Element("workout_sessions");
                    string workoutSessionsFilename = workoutSessionsElement.Attribute("filename").Value;

                    // Read the XML from the workout sessions file
                    string workoutSessionsFilePath = Path.Combine(Path.GetDirectoryName(fileName), workoutSessionsFilename);
                    if (File.Exists(workoutSessionsFilePath))
                    {
                        string workoutSessionsContent = File.ReadAllText(workoutSessionsFilePath);

                        // Convert the workout sessions XML string to a list of WorkoutSession objects
                        List<WorkoutSession> workoutSessions = (from session in XElement.Parse(workoutSessionsContent).Elements("workout_session")
                                                                select BioParser.ConvertXmlToWorkoutSession(session)).ToList();

                        // Add the workout sessions to the Bio object
                        bio.worksessions = workoutSessions;
                    }

                    // Set the bio_data and FileName properties
                    data.bio_data = bio;
                    data.FileName = fileName;

                    return data;
                }
                catch (Exception ex)
                {
                    // Handle deserialization error (e.g., log the error, set default settings, etc.)
                    //Console.WriteLine("Error deserializing settings: " + ex.Message);
                }

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

