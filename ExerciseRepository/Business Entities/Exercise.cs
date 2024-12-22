using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    [Serializable]
    public class Exercise: Entity_Identity
    {
        public TimeSpan Duration { get; set; }
        public List<Set> Sets;

        public void AddSet(Set s)
        { }

        public void RemoveSet(Set s)
        { }

        public override string ToString()
        {
            string setsInfo = string.Join(",", Sets.ConvertAll(set => set.ToString()).ToArray());
            if (string.IsNullOrEmpty(setsInfo))
            {
                setsInfo = "No Sets are listed";
            }
            return string.Format("{0}\r\n[Duration: {1}\r\n^Sets:\r\n[{2}]]", base.ToString(), Duration, setsInfo).Replace(",","\r\n^");
        }

    }
}
