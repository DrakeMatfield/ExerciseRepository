using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    public class ExercisseDay: Entity_Identity
    {
        public DateTime Date { get; set; }
        public List<Exercise> Exrcises;

        public void AddExercise (Exercise e)
        { }

        public void RemoveExercise(Exercise e)
        { }
    }
}
