using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ExerciseRepository.Business_Entities;
using System.Xml;

namespace ExerciseRepository.Data_Access
{
    public class BioParser
    {
        public static string ConvertBioToXml(Bio bio)
        {
            XElement bioElement = new XElement("bio",
                new XAttribute("id", bio.id),
                new XAttribute("name", bio.Name),
                ConvertProfileToXml(bio.profile),
                new XElement("stats"), // Placeholder for Stats conversion if needed
                new XElement("workout_sessions",
                    from session in bio.worksessions
                    select ConvertWorkoutSessionToXmlElement(session))
            );

            return bioElement.ToString();
        }

        public static XElement ConvertWorkoutSessionToXmlElement(WorkoutSession workoutSession)
        {
            return new XElement("workout_session",
                ConvertEntityIdentityToXml(workoutSession),
                new XElement("bioID", workoutSession.bioID),
                new XElement("profieID", workoutSession.profieID),
                new XElement("routineID", workoutSession.routineID),
                new XElement("planID", workoutSession.planID),
                new XElement("orginalExerciseDayID", workoutSession.orginalExerciseDayID),
                new XElement("EDay", ConvertExerciseDayToXml(workoutSession.EDay))
            );
        }

        public static XElement ConvertProfileToXml(Profile profile)
        {
            return new XElement("profile",
                ConvertEntityIdentityToXml(profile),
                new XElement("plans",
                    from plan in profile.Plans
                    select ConvertPlanToXml(plan)));
        }

        public static XElement ConvertPlanToXml(Plan plan)
        {
            return new XElement("plan",
                ConvertEntityIdentityToXml(plan),
                new XElement("routines",
                    from routine in plan.Routines
                    select ConvertRoutineToXml(routine)));
        }

        public static XElement ConvertRoutineToXml(Routine routine)
        {
            return new XElement("routine",
                ConvertEntityIdentityToXml(routine),
                new XElement("exercise_days",
                    from day in routine.Days
                    select ConvertExerciseDayToXml(day)));
        }

        public static XElement ConvertExerciseDayToXml(ExerciseDay day)
        {
            return new XElement("exercise_day",
                ConvertEntityIdentityToXml(day),
                new XElement("date", day.Date),
                new XElement("exercises",
                    from exercise in day.Exercises
                    select ConvertExerciseToXml(exercise)));
        }

        public static XElement ConvertExerciseToXml(Exercise exercise)
        {
            return new XElement("exercise",
                ConvertEntityIdentityToXml(exercise),
                new XElement("duration", exercise.Duration),
                new XElement("sets",
                    from set in exercise.Sets
                    select ConvertSetToXml(set)));
        }

        public static XElement ConvertSetToXml(Set set)
        {
            return new XElement("set",
                ConvertEntityIdentityToXml(set),
                new XElement("number", set.Number),
                new XElement("reps", set.Reps),
                new XElement("weight", set.Weight));
        }

        public static XElement ConvertEntityIdentityToXml(Entity_Identity entity)
        {
            return new XElement("entity",
                new XElement("id", entity.id),
                new XElement("name", entity.Name),
                new XElement("description", entity.Description));
        }



        public static Bio ConvertXmlToBio(string xml)
        {
            XElement bioElement = XElement.Parse(xml);

            Bio bio = new Bio
            {
                id = new Guid(bioElement.Attribute("id").Value),
                Name = bioElement.Attribute("name").Value,
                profile = ConvertXmlToProfile(bioElement.Element("profile")),
                stats = new Stats(), // Placeholder if necessary
                worksessions = (from session in bioElement.Element("workout_sessions").Elements("workout_session")
                                select ConvertXmlToWorkoutSession(session)).ToList()
            };

            return bio;
        }

        public static WorkoutSession ConvertXmlToWorkoutSession(XElement sessionElement)
        {
            return new WorkoutSession
            {
                id = new Guid(sessionElement.Element("entity").Element("id").Value),
                Name = sessionElement.Element("entity").Element("name").Value,
                Description = sessionElement.Element("entity").Element("description").Value,
                bioID = new Guid(sessionElement.Element("bioID").Value),
                profieID = new Guid(sessionElement.Element("profieID").Value),
                routineID = new Guid(sessionElement.Element("routineID").Value),
                planID = new Guid(sessionElement.Element("planID").Value),
                orginalExerciseDayID = new Guid(sessionElement.Element("orginalExerciseDayID").Value),
                EDay = ConvertXmlToExerciseDay(sessionElement.Element("EDay").Element("exercise_day"))
            };
        }
    
        public static Profile ConvertXmlToProfile(XElement profileElement)
        {
            return new Profile
            {
                id = new Guid(profileElement.Element("entity").Element("id").Value),
                Name = profileElement.Element("entity").Element("name").Value,
                Description = profileElement.Element("entity").Element("description").Value,
                Plans = (from plan in profileElement.Element("plans").Elements("plan")
                         select ConvertXmlToPlan(plan)).ToList()
            };
        }

        public static Plan ConvertXmlToPlan(XElement planElement)
        {
            return new Plan
            {
                id = new Guid(planElement.Element("entity").Element("id").Value),
                Name = planElement.Element("entity").Element("name").Value,
                Description = planElement.Element("entity").Element("description").Value,
                Routines = (from routine in planElement.Element("routines").Elements("routine")
                            select ConvertXmlToRoutine(routine)).ToList()
            };
        }

        public static Routine ConvertXmlToRoutine(XElement routineElement)
        {
            return new Routine
            {
                id = new Guid(routineElement.Element("entity").Element("id").Value),
                Name = routineElement.Element("entity").Element("name").Value,
                Description = routineElement.Element("entity").Element("description").Value,
                Days = (from day in routineElement.Element("exercise_days").Elements("exercise_day")
                        select ConvertXmlToExerciseDay(day)).ToList()
            };
        }

        public static ExerciseDay ConvertXmlToExerciseDay(XElement dayElement)
        {
            return new ExerciseDay
            {
                id = new Guid(dayElement.Element("entity").Element("id").Value),
                Name = dayElement.Element("entity").Element("name").Value,
                Description = dayElement.Element("entity").Element("description").Value,
                Date = DateTime.Parse(dayElement.Element("date").Value),
                Exercises = (from exercise in dayElement.Element("exercises").Elements("exercise")
                             select ConvertXmlToExercise(exercise)).ToList()
            };
        }

        public static Exercise ConvertXmlToExercise(XElement exerciseElement)
        {
            return new Exercise
            {
                id = new Guid(exerciseElement.Element("entity").Element("id").Value),
                Name = exerciseElement.Element("entity").Element("name").Value,
                Description = exerciseElement.Element("entity").Element("description").Value,
                Duration = XmlConvert.ToTimeSpan(exerciseElement.Element("duration").Value),
                Sets = (from set in exerciseElement.Element("sets").Elements("set")
                        select ConvertXmlToSet(set)).ToList()
            };
        }

        public static Set ConvertXmlToSet(XElement setElement)
        {
            return new Set
            {
                id = new Guid(setElement.Element("entity").Element("id").Value),
                Name = setElement.Element("entity").Element("name").Value,
                Description = setElement.Element("entity").Element("description").Value,
                Number = int.Parse(setElement.Element("number").Value),
                Weight = double.Parse(setElement.Element("weight").Value),
                Reps = int.Parse(setElement.Element("reps").Value)
            };
        }


    }


}
