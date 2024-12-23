using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    [Serializable]
    public class Plan : Entity_Identity
    {
        public List<Routine> Routines { get; set; }

        public Plan()
        {
            this.Routines = new List<Routine>();
        }

        public void AddRoutine(Routine r)
        { }

        public void RemoveRoutine(Routine r)
        { }

        public override string ToString()
        {
            string routinesInfo = string.Join(",", Routines.ConvertAll(routine => routine.ToString()).ToArray());
            return string.Format("{0}\r\n[Routines: {1}]", base.ToString(), routinesInfo).Replace(",", "\r\n^");
        }
    }
}
