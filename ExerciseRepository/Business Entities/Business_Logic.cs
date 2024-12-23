using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExerciseRepository.Data_Access;

namespace ExerciseRepository.Business_Entities
{
    static class Business_Logic
    {
           private static List<ExerciseDay> exerciseDays;

            public static List<ExerciseDay> Predefine_ExerciseDays
            {
                get
                {
                    if (exerciseDays == null)
                    {
                        exerciseDays = new List<ExerciseDay>();
                    }
                    return exerciseDays;
                }
                set
                {
                    exerciseDays = value;
                }
            }
      

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

        public static List<WorkoutSession> GeneratePredefinedWorkoutSessions(Bio bio)
        {
            var predefinedSessions = new List<WorkoutSession>();
            var exerciseDays = GetAllExerciseDays(bio);

            foreach (var exerciseDay in exerciseDays)
            {
                var workoutSession = CreateWorkoutSession(bio, exerciseDay.id);
                predefinedSessions.Add(workoutSession);
            }

            return predefinedSessions;
        }
        public static List<ExerciseDay> GetAllExerciseDays(Bio bio)
        {
            var exerciseDays = new List<ExerciseDay>();

            // Loop through all Plans, Routines, and Days to collect ExerciseDays
            foreach (var plan in bio.profile.Plans)
            {
                foreach (var routine in plan.Routines)
                {
                    exerciseDays.AddRange(routine.Days);
                }
            }

            return exerciseDays;
        }

        public static WorkoutSession CreateWorkoutSession_old_one(Bio bio, Guid exerciseDayId)
        {
            // Find the profile
            var profile = bio.profile;

            // Find the plan
            var plan = profile.Plans.FirstOrDefault();

            // Find the routine
            var routine = plan.Routines.FirstOrDefault();

            // Find the original exercise day
            var originalExerciseDay = routine.Days.FirstOrDefault(day => day.id == exerciseDayId);

            // Create a deep copy of the original exercise day but maintain the same IDs
            var exerciseDayCopy = new ExerciseDay
            {
                id = originalExerciseDay.id, // Maintain the same ID
                Name = originalExerciseDay.Name,
                Description = originalExerciseDay.Description,
                Date = DateTime.Now,
                Exercises = originalExerciseDay.Exercises.Select(exercise => new Exercise
                {
                    id = exercise.id, // Maintain the same ID
                    Name = exercise.Name,
                    Description = exercise.Description,
                    Duration = exercise.Duration,
                    Sets = exercise.Sets.Select(set => new Set
                    {
                        id = set.id, // Maintain the same ID
                        Name = set.Name,
                        Description = set.Description,
                        Number = set.Number,
                        Weight = set.Weight,
                        Reps = set.Reps
                    }).ToList()
                }).ToList()
            };

            // Create WorkoutSession with corresponding IDs
            var workoutSession = new WorkoutSession
            {
                id = Guid.NewGuid(), // Assign a new ID for WorkoutSession
                bioID = bio.id,
                profieID = profile.id,
                planID = plan.id,
                routineID = routine.id,
                orginalExerciseDayID = originalExerciseDay.id,
                EDay = exerciseDayCopy
            };

            return workoutSession;
        }

        public static WorkoutSession CreateWorkoutSession(Bio bio, Guid exerciseDayId)
        {
            // Find the profile
            var profile = bio.profile;

            // Initialize variables for plan, routine, and exercise day
            Plan plan = null;
            Routine routine = null;
            ExerciseDay originalExerciseDay = null;

            // Find the original exercise day
            foreach (var p in profile.Plans)
            {
                foreach (var r in p.Routines)
                {
                    originalExerciseDay = r.Days.FirstOrDefault(day => day.id == exerciseDayId);
                    if (originalExerciseDay != null)
                    {
                        plan = p;
                        routine = r;
                        break;
                    }
                }
                if (originalExerciseDay != null)
                {
                    break;
                }
            }

            // Check if the exercise day was found
            if (originalExerciseDay == null)
            {
                throw new Exception("The specified ExerciseDay was not found in any plan or routine.");
            }

            // Create a deep copy of the original exercise day but maintain the same IDs
            var exerciseDayCopy = new ExerciseDay
            {
                id = originalExerciseDay.id, // Maintain the same ID
                Name = originalExerciseDay.Name,
                Description = originalExerciseDay.Description,
                Date = DateTime.Now,
                Exercises = originalExerciseDay.Exercises.Select(exercise => new Exercise
                {
                    id = exercise.id, // Maintain the same ID
                    Name = exercise.Name,
                    Description = exercise.Description,
                    Duration = exercise.Duration,
                    Sets = exercise.Sets.Select(set => new Set
                    {
                        id = set.id, // Maintain the same ID
                        Name = set.Name,
                        Description = set.Description,
                        Number = set.Number,
                        Weight = set.Weight,
                        Reps = set.Reps
                    }).ToList()
                }).ToList()
            };

            // Create WorkoutSession with corresponding IDs
            var workoutSession = new WorkoutSession
            {
                id = Guid.NewGuid(), // Assign a new ID for WorkoutSession
                bioID = bio.id,
                profieID = profile.id,
                planID = plan.id,
                routineID = routine.id,
                orginalExerciseDayID = originalExerciseDay.id,
                EDay = exerciseDayCopy,
                Name = originalExerciseDay.Name + " - " + DateTime.Now.ToShortDateString()
            };

            return workoutSession;
        }

    }

}

