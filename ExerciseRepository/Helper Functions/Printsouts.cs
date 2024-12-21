using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExerciseRepository.Business_Entities;

namespace ExerciseRepository.Helper_Functions
{
    public class Printsouts
    {
        public static string ProcessHierarchyString(string input)
        {
            var output = new System.Text.StringBuilder();
            int indentLevel = 0;
            bool newLine = true;

            foreach (char c in input)
            {
                if (c == '[')
                {
                    output.Append(new string('\t', indentLevel));
                    output.AppendLine("{");
                    indentLevel++;
                    newLine = true;
                }
                else if (c == ']')
                {
                    indentLevel--;
                    if (output.Length > 0 && output[output.Length - 1] != '\n')
                    {
                        output.AppendLine();
                        output.Append(new string('\t', indentLevel));
                        output.Append("}");
                    }
                    newLine = true;
                }
                else if (c == '^')
                {
                    newLine = true;
                }
                else
                {
                    if (newLine)
                    {
                        output.Append(new string('\t', indentLevel));
                        newLine = false;
                    }
                    output.Append(c);
                }
            }

            return output.ToString();
        }


        public static string GetBioDetailsAsString(Bio bio)
        {
            if (bio != null)
            {
                return GetBioDetails(bio, 0);
            }
            else
            {
                return "Bio is null.";
            }
        }

        private static string GetBioDetails(Bio bio, int indentLevel)
        {
            string indent = new string(' ', indentLevel * 2);
            string result = indent + string.Format("Bio: {0} (ID: {1})\r\n", bio.Name, bio.id);

            if (bio.profile != null)
            {
                result += indent + "Profiles:\r\n" + GetProfileDetails(bio.profile, indentLevel + 1);
            }

            if (bio.stats != null)
            {
                result += indent + "Stats: (details not provided)\r\n";
            }

            return result;
        }

        private static string GetProfileDetails(Profile profile, int indentLevel)
        {
            string indent = new string(' ', indentLevel * 2);
            string result = indent + string.Format("Profile: {0} (ID: {1}): {2}\r\n", profile.Name, profile.id, profile.Description);

            indentLevel += 1;
            indent = new string(' ', indentLevel * 2);

            foreach (var plan in profile.Plans)
            {
                result += indent + "Plans:\r\n" + GetPlanDetails(plan, indentLevel + 1);
            }

            return result;
        }

        private static string GetPlanDetails(Plan plan, int indentLevel)
        {
            string indent = new string(' ', indentLevel * 2);
            string result = indent + string.Format("Plan: {0} (ID: {1}): {2}\r\n", plan.Name, plan.id, plan.Description);

            indentLevel += 1;
            indent = new string(' ', indentLevel * 2);

            foreach (var routine in plan.Routines)
            {
                result += indent + "Routine:\r\n" + GetRoutineDetails(routine, indentLevel + 1);
            }

            return result;
        }

        private static string GetRoutineDetails(Routine routine, int indentLevel)
        {
            string indent = new string(' ', indentLevel * 2);
            string result = indent + string.Format("Routine: {0} (ID: {1}): {2}\r\n", routine.Name, routine.id, routine.Description);

            indentLevel += 1;
            indent = new string(' ', indentLevel * 2);

            foreach (var day in routine.Days)
            {
                result += indent + "Day:\r\n" + GetExerciseDayDetails(day, indentLevel + 1);
            }

            return result;
        }

        private static string GetExerciseDayDetails(ExercisseDay day, int indentLevel)
        {
            string indent = new string(' ', indentLevel * 2);
            string result = indent + string.Format("Day: {0} (ID: {1}): {2}\r\n{4}     Date: {3}\r\n", day.Name, day.id, day.Description, day.Date.ToString("yyyy-MM-dd"), indent);

            indentLevel += 1;
            indent = new string(' ', indentLevel * 2);

            foreach (var exercise in day.Exrcises)
            {
                result += indent + "Exercise:\r\n" + GetExerciseDetails(exercise, indentLevel + 1);
            }

            return result;
        }

        private static string GetExerciseDetails(Exercise exercise, int indentLevel)
        {
            string indent = new string(' ', indentLevel * 2);
            string result = indent + string.Format("Exercise: {0} (ID: {1}): {2}\r\nDuration: {3}\r\n", exercise.Name, exercise.id, exercise.Description, exercise.Duration);

            indentLevel += 1;
            indent = new string(' ', indentLevel * 2);

            foreach (var set in exercise.Sets)
            {
                result += indent + "Set:\r\n" + GetSetDetails(set, indentLevel + 1);
            }

            return result;
        }

        private static string GetSetDetails(Set set, int indentLevel)
        {
            string indent = new string(' ', indentLevel * 2);
            return indent + string.Format("Set: {0} (ID: {1}): {2} - Set {3}: {4} lbs, {5} reps\r\n", set.Name, set.id, set.Description, set.Number, set.Weight, set.Reps);
        }

    }
}
