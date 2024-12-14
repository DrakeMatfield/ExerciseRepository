using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    public class Plan : Entity_Identity
    {
        public List<Routine> Routines;


        public void AddRoutine(Routine r)
        { }

        public void RemoveRoutine(Routine r)
        { }


    }
}
