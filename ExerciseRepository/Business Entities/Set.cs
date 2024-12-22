using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    [Serializable]
    public class Set : Entity_Identity
    {
        public int Number { get; set; }
        public double Weight { get; set; }
        public int Reps { get; set; }

        public override string ToString()
        {
            return string.Format("{0} \r\n[Set {1}: {3} reps x {2} lbs]", base.ToString(), Number, Weight, Reps);
        }
    }
}
