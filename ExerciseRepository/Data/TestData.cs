using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExerciseRepository.Business_Entities;

namespace ExerciseRepository.Data
{

    public class TestData
    {
        public static Bio CreateTestBio()
        {
            var bio = new Bio
            {
                id = Guid.NewGuid(),
                Name = "John Doe",
                profile = new Profile
                {
                    id = Guid.NewGuid(),
                    Name = "John's Profile",
                    Description = "Personal fitness profile",
                    Plans = new List<Plan>
                {
                    new Plan
                    {
                        id = Guid.NewGuid(),
                        Name = "Fitness Plan 1",
                        Description = "General fitness plan",
                        Routines = new List<Routine>
                        {
                            new Routine
                            {
                                id = Guid.NewGuid(),
                                Name = "Morning Routine",
                                Description = "Morning workout routine",
                                Days = new List<ExercisseDay>
                                {
                                    new ExercisseDay
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Day 1",
                                        Description = "Cardio day",
                                        Date = DateTime.Now,
                                        Exrcises = new List<Exercise>
                                        {
                                            new Exercise
                                            {
                                                id = Guid.NewGuid(),
                                                Name = "Running",
                                                Description = "30 minutes of running",
                                                Duration = TimeSpan.FromMinutes(30),
                                                Sets = new List<Set>
                                                {
                                                    new Set
                                                    {
                                                        id = Guid.NewGuid(),
                                                        Name = "Set 1",
                                                        Description = "Warm-up",
                                                        Number = 1,
                                                        Weight = 135,
                                                        Reps = 10
                                                    },
                                                    new Set
                                                    {
                                                        id = Guid.NewGuid(),
                                                        Name = "Set 2",
                                                        Description = "Main run",
                                                        Number = 2,
                                                        Weight = 255,
                                                        Reps = 5
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                },
                stats = new Stats
                {
                    // Initialize Stats properties if needed
                }
            };

            return bio;
        }
    }

}
