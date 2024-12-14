using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    public class Bio
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public Profile profile { get; set; }
        public Stats stats { get; set; }
    }
}
