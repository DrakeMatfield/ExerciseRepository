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

        public override string ToString()
        {
            string plansInfo = string.Join(", ", Plans.ConvertAll(plan => plan.ToString()).ToArray());
            return string.Format("{0}\r\n[Plans: {1}", base.ToString(), plansInfo);
        }
    }
}
