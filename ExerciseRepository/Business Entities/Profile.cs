using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    public class Profile:Entity_Identity
    {
        public List<Plan> Plans;

        public void AddPlan(Plan p)
        { }

        public void RemovePlan(Plan p)
        { }
    }
}
