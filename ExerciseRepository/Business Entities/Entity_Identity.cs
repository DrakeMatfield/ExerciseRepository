using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    [Serializable]
    public class Entity_Identity
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("{0} (ID: {1}): {2}", Name, id, Description);
        }
    }
}
