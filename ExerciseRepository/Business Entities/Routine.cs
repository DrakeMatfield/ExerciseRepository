using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    public class Routine: Entity_Identity
    {
        public List<ExercisseDay> Days;
        
        public void AddDay(ExercisseDay d)
        { }

        public void RemoveDay(ExercisseDay d)
        { }
    }
}
