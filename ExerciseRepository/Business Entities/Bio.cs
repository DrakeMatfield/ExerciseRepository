using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{

    [Serializable]
    public class Bio
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public Profile profile { get; set; }
        public Stats stats { get; set; }

        public List<WorkoutSession> worksessions { get; set; }
                
        public override string ToString()
        {
            return string.Format("Bio: {0} (ID: {1})\r\n[Profile: {2}\r\n^Stats:\r\n[{3}]]]", Name, id, profile, stats);
        }

        public void Add_Session(WorkoutSession session)
        {
            this.worksessions.Add(session);
        }
    }
}
