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
                                Days = new List<ExerciseDay>
                                {
                                    new ExerciseDay
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Day 1",
                                        Description = "Chest and Back",
                                        Date = DateTime.Now,
                                        Exercises = new List<Exercise>
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
                                    new ExerciseDay
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Day 2",
                                        Description = "Shoulders and Arms",
                                        Date = DateTime.Now,
                                        Exercises = new List<Exercise>
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
                                    new ExerciseDay
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Day 3",
                                        Description = "Leg Day",
                                        Date = DateTime.Now,
                                        Exercises = new List<Exercise>()
                                    }
                                
                                }
                            },
                                                            new Routine
                            {
                                id = Guid.NewGuid(),
                                Name = "Daily Routine",
                                Description = "Everyday workout routine",
                                Days = new List<ExerciseDay>
                                {
                                                                    new ExerciseDay
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Daily Rountine",
                                        Description = "Routine is done daily",
                                        Date = DateTime.Now,
                                        Exercises = new List<Exercise>()
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


        public static Bio CreateDrakeBio()
        {
            var bio = new Bio
            {
                id = Guid.NewGuid(),
                Name = "Drake Matfield",
                profile = new Profile
                {
                    id = Guid.NewGuid(),
                    Name = "Drake's Profile",
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
                            Description = "3-Day cycle workout routine",
                            Days = new List<ExerciseDay>
                            {
                                new ExerciseDay
                                {
                                    id = Guid.NewGuid(),
                                    Name = "Day 1",
                                    Description = "Chest and Back",
                                    Date = DateTime.Now,
                                    Exercises = new List<Exercise>
                                    {
                                        new Exercise
                                        {
                                            id = Guid.NewGuid(),
                                            Name = "Bench Press",
                                            Description = "Lift bar above chest",
                                            Duration = TimeSpan.Zero,
                                            Sets = new List<Set>
                                            {
                                                new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "Warm-up", Number = 1, Weight = 135, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 185, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 225, Reps = 3 }
                                            }
                                        },
                                        new Exercise
                                        {
                                            id = Guid.NewGuid(),
                                            Name = "Incline Press",
                                            Description = "Lift bar at an incline",
                                            Duration = TimeSpan.Zero,
                                            Sets = new List<Set>
                                            {
                                                new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 135, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 155, Reps = 6 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 165, Reps = 4 }
                                            }
                                        },
                                        new Exercise
                                        {
                                            id = Guid.NewGuid(),
                                            Name = "Flys",
                                            Description = "Dumbbell flys",
                                            Duration = TimeSpan.Zero,
                                            Sets = new List<Set>
                                            {
                                                new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 70, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 30, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 15, Reps = 10 }
                                            }
                                        },
                                        new Exercise
                                        {
                                            id = Guid.NewGuid(),
                                            Name = "Pull Down",
                                            Description = "Lat pulldowns",
                                            Duration = TimeSpan.Zero,
                                            Sets = new List<Set>
                                            {
                                                new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 110, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 110, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 121, Reps = 10 }
                                            }
                                        },
                                        new Exercise
                                        {
                                            id = Guid.NewGuid(),
                                            Name = "Pull Back",
                                            Description = "Seated rows",
                                            Duration = TimeSpan.Zero,
                                            Sets = new List<Set>
                                            {
                                                new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 110, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 121, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 143, Reps = 6 }
                                            }
                                        }
                                    }
                                },
                                new ExerciseDay
                                {
                                    id = Guid.NewGuid(),
                                    Name = "Day 2",
                                    Description = "Shoulders and Arms",
                                    Date = DateTime.Now,
                                    Exercises = new List<Exercise>
                                    {
                                        new Exercise
                                        {
                                            id = Guid.NewGuid(),
                                            Name = "Shoulder Press",
                                            Description = "Lift bar above head",
                                            Duration = TimeSpan.Zero,
                                            Sets = new List<Set>
                                            {
                                                new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 115, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 115, Reps = 5 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 115, Reps = 5 }
                                            }
                                        },
                                        new Exercise
                                        {
                                            id = Guid.NewGuid(),
                                            Name = "Shoulder Flap",
                                            Description = "Dumbbell lateral raises",
                                            Duration = TimeSpan.Zero,
                                            Sets = new List<Set>
                                            {
                                                new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 35, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 35, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 35, Reps = 10 }
                                            }
                                        },
                                        new Exercise
                                        {
                                            id = Guid.NewGuid(),
                                            Name = "Traps",
                                            Description = "Shrugs",
                                            Duration = TimeSpan.Zero,
                                            Sets = new List<Set>
                                            {
                                                new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 70, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 70, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 70, Reps = 10 }
                                            }
                                        },
                                        new Exercise
                                        {
                                            id = Guid.NewGuid(),
                                            Name = "Triceps",
                                            Description = "Tricep pushdowns",
                                            Duration = TimeSpan.Zero,
                                            Sets = new List<Set>
                                            {
                                                new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 60, Reps = 11 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 66, Reps = 11 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 71, Reps = 7 }
                                            }
                                        },
                                        new Exercise
                                        {
                                            id = Guid.NewGuid(),
                                            Name = "Biceps",
                                            Description = "Bicep curls",
                                            Duration = TimeSpan.Zero,
                                            Sets = new List<Set>
                                            {
                                                new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 38, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 44, Reps = 10 },
                                                new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 49, Reps = 10 }
                                            }
                                        }
                                    }
                                },
                                new ExerciseDay
                                {
                                    id = Guid.NewGuid(),
                                    Name = "Day 3",
                                    Description = "Leg Day",
                                    Date = DateTime.Now,
                                    Exercises = new List<Exercise>
                                    {
                                     new Exercise
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Squats",
                                        Description = "Barbell squats",
                                        Duration = TimeSpan.Zero,
                                        Sets = new List<Set>
                                        {
                                            new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 45, Reps = 10 },
                                            new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 135, Reps = 10 },
                                            new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 255, Reps = 5 }
                                        }
                                    },
                                    new Exercise
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Hack Squats",
                                        Description = "Hack squats",
                                        Duration = TimeSpan.Zero,
                                        Sets = new List<Set>
                                        {
                                            new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 225, Reps = 10 },
                                            new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 315, Reps = 10 },
                                            new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 475, Reps = 11 }
                                        }
                                    },
                                    new Exercise
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Hamstrings",
                                        Description = "Hamstring curls",
                                        Duration = TimeSpan.Zero,
                                        Sets = new List<Set>
                                        {
                                            new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 80, Reps = 10 },
                                            new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 90, Reps = 10 },
                                            new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 100, Reps = 7 }
                                        }
                                    },
                                    new Exercise
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Thighs",
                                        Description = "Thigh extensions",
                                        Duration = TimeSpan.Zero,
                                        Sets = new List<Set>
                                        {
                                            new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 130, Reps = 10 },
                                            new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 130, Reps = 10 },
                                            new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 140, Reps = 10 }
                                        }
                                    },
                                    new Exercise
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Calves",
                                        Description = "Calf raises",
                                        Duration = TimeSpan.Zero,
                                        Sets = new List<Set>
                                        {
                                            new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "", Number = 1, Weight = 250, Reps = 10 },
                                            new Set { id = Guid.NewGuid(), Name = "Set 2", Description = "", Number = 2, Weight = 250, Reps = 10 },
                                            new Set { id = Guid.NewGuid(), Name = "Set 3", Description = "", Number = 3, Weight = 250, Reps = 10 }
                                        }
                                    }                                                               
                                  }
                               }
                            }// end of day
                        }
                    , 
                    new Routine
                    {
                            id = Guid.NewGuid(),
                            Name = "Daily Routine",
                            Description = "Done Everyday",
                            Days = new List<ExerciseDay>
                            {
                                new ExerciseDay
                                {
                                    id = Guid.NewGuid(),
                                    Name = "Daily Routine",
                                    Description = "every day",
                                    Date = DateTime.Now,
                                    Exercises = new List<Exercise>
                                    {
                                            new Exercise
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Push ups",
                                        Description = "Do as many push ups as possiable in one set",
                                        Duration = TimeSpan.Zero,
                                        Sets = new List<Set>
                                        {
                                            new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "Max Out", Number = 1, Weight = 0, Reps = 40 }
                                        }
                                    },
                                    new Exercise
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Squats ups",
                                        Description = "Do 1 squats, then calvf raise once and then lift each chin once: that's one set",
                                        Duration = TimeSpan.Zero,
                                        Sets = new List<Set>
                                        {
                                            new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "Max Out", Number = 1, Weight = 0, Reps = 50 }
                                        }
                                    },
                                    new Exercise
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Lunges",
                                        Description = "Lunges with no weights",
                                        Duration = TimeSpan.Zero,
                                        Sets = new List<Set>
                                        {
                                            new Set { id = Guid.NewGuid(), Name = "Set 1", Description = "Max Out", Number = 1, Weight = 0, Reps = 50 }
                                        }
                                    },
                                    new Exercise
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "3-mile jog",
                                        Description = "Jog 3 miles",
                                        Duration = TimeSpan.FromMinutes(30),
                                        Sets = new List<Set>()
                                        
                                    },
                                    new Exercise
                                    {
                                        id = Guid.NewGuid(),
                                        Name = "Stationary Cycle",
                                        Description = "Stationary Cycle at the gym - 30 mins",
                                        Duration = TimeSpan.FromMinutes(30),
                                        Sets = new List<Set>
                                        {
                                            new Set { id = Guid.NewGuid(), Name = "30 mins", Description = "enter the number of miles in weight for now", Number = 1, Weight = 7, Reps = 1 }
                                        }
                                    }                                                               
                                  
                                    }                                    
                                }
                            }
                    } }//
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