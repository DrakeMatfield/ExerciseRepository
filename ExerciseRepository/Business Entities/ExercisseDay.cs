using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    [Serializable]
    public class ExerciseDay : Entity_Identity
    {
        public DateTime Date { get; set; }
        public List<Exercise> Exercises{ get; set; }


        public ExerciseDay()
        {
            this.Exercises = new List<Exercise>();
        }
        public void AddExercise(Exercise e)
        { }

        public void RemoveExercise(Exercise e)
        { }

        public override string ToString()
        {
            string exercisesInfo = string.Join(",", Exercises.ConvertAll(exercise => exercise.ToString()).ToArray());
            if (string.IsNullOrEmpty(exercisesInfo))
            {
                exercisesInfo = "No exercise are listed.";
            }
            return string.Format("{0} - Date: {1}\r\n[Exercises: {2}]", base.ToString(), Date.ToString("MM-dd-yyyy"), exercisesInfo);
        }
    }
}
