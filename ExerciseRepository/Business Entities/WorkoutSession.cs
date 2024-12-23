using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    [Serializable]
    public class WorkoutSession: Entity_Identity
    {
        public Guid bioID { get; set; }
        public Guid profieID { get; set; }
        public Guid routineID { get; set; }
        public Guid planID { get; set; }
        public Guid orginalExerciseDayID { get; set; }
        public ExerciseDay EDay { get; set; }
        
        public WorkoutSession()
        {
            //this.EDay = new ExerciseDay();
            //this.Name = EDay.Name + DateTime.Now.ToShortDateString();
        }
    }
}
