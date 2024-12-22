using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExerciseRepository.Data_Access;

namespace ExerciseRepository.Business_Entities
{
    static class Business_Logic
    {
        // Save bio data
        public static void SaveBio(string filePath, Bio bio)
        {
            ExerciseRepositoryDataObject data = new ExerciseRepositoryDataObject(filePath,bio);

            IRepository r = Repository.Get_DataAccess(DataAccess_Type.FILE);
            r.Save(data);
        }

        // Create new bio
        public static void CreateBio()
        {
            // Implementation here
        }

        // Open existing bio
        public static Bio OpenBio(string filePath)
        {
            IRepository r = Repository.Get_DataAccess(DataAccess_Type.FILE);
            ExerciseRepositoryDataObject data = r.Get(filePath);
            return data.bio_data;
        }

        // Create new stats
        public static void CreateStats()
        {
            // Implementation here
        }

        // Edit existing stats
        public static void EditStats()
        {
            // Implementation here
        }

        // Create new profile
        public static void CreateProfile()
        {
            // Implementation here
        }

        // Remove profile
        public static void RemoveProfile()
        {
            // Implementation here
        }

        // Export bio data
        public static void ExportBio()
        {
            // Implementation here
        }

        // Create new plan
        public static void CreatePlan()
        {
            // Implementation here
        }

        // Delete plan
        public static void DeletePlan()
        {
            // Implementation here
        }

        // Import bio data
        public static void ImportBio()
        {
            // Implementation here
        }

        // Create new routine
        public static void CreateRoutine()
        {
            // Implementation here
        }

        // Remove routine
        public static void RemoveRoutine()
        {
            // Implementation here
        }

        // Rename entity
        public static void RenameEntity()
        {
            // Implementation here
        }

        // Add new day
        public static void AddDay()
        {
            // Implementation here
        }

        // Remove existing day
        public static void RemoveDay()
        {
            // Implementation here
        }

        // Edit day details
        public static void EditDay()
        {
            // Implementation here
        }

        // Edit description
        public static void EditDescription()
        {
            // Implementation here
        }

        // Create new exercise
        public static void CreateExercise()
        {
            // Implementation here
        }

        // Remove exercise
        public static void RemoveExercise()
        {
            // Implementation here
        }

        // Edit exercise details
        public static void EditExercise()
        {
            // Implementation here
        }

        // Edit entity details
        public static void EditEntity()
        {
            // Implementation here
        }

        // Remove set
        public static void RemoveSet()
        {
            // Implementation here
        }

        // Add new set
        public static void AddSet()
        {
            // Implementation here
        }

        // Edit set details
        public static void EditSet()
        {
            // Implementation here
        }
    }

}

