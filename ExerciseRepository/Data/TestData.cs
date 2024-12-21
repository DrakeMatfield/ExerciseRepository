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
                                Name = "Weightlifting Routine",
                                Description = "3Day cycle workout routine",
                                Days = new List<ExercisseDay>
                                {
                                    new ExercisseDay
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Day 1",
                                        Description = "Chest and Back",
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
                                    },
                                    new ExercisseDay
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Day 2",
                                        Description = "Shoulders and Arms",
                                        Date = DateTime.Now,
                                        Exrcises = new List<Exercise>
                                        {
                                            new Exercise
                                            {
                                                id = Guid.NewGuid(),
                                                Name = "Shoulder Press",
                                                Description = "Lift Bar above head",
                                                Duration = TimeSpan.FromMinutes(10),
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
                                                    },
                                                    new Set
                                                    {
                                                        id = Guid.NewGuid(),
                                                        Name = "Set 3",
                                                        Description = "last run",
                                                        Number = 3,
                                                        Weight = 275,
                                                        Reps = 1
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    new ExercisseDay
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Day 3",
                                        Description = "Leg Day",
                                        Date = DateTime.Now,
                                        Exrcises = new List<Exercise>()
                                    }
                                
                                }
                            },
                                                            new Routine
                            {
                                id = Guid.NewGuid(),
                                Name = "Daily Routine",
                                Description = "Everyday workout routine",
                                Days = new List<ExercisseDay>
                                {
                                                                    new ExercisseDay
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Daily Rountine",
                                        Description = "Routine is done daily",
                                        Date = DateTime.Now,
                                        Exrcises = new List<Exercise>()
                                        {
                                            new Exercise
                                            {
                                                id = Guid.NewGuid(),
                                                Name = "Jogging",
                                                Description = "3 mile Jog",
                                                Duration = TimeSpan.FromMinutes(30),
                                                Sets = new List<Set>()
                                    }
                                        }
                                }}
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
