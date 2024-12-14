using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    public class Exercise: Entity_Identity
    {
        public TimeSpan Duration { get; set; }
        public List<Set> Sets;

        public void AddSet(Set s)
        { }

        public void RemoveSet(Set s)
        { }

    }
}
