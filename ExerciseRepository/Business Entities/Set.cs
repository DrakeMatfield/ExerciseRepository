using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    public class Set : Entity_Identity
    {
        public int Number { get; set; }
        public double Weight { get; set; }
        public int Reps { get; set; }
    }
}
