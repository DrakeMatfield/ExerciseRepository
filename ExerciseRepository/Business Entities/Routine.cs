using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Business_Entities
{
    public class Routine: Entity_Identity
    {
        public List<ExercisseDay> Days;
        
        public void AddDay(ExercisseDay d)
        { }

        public void RemoveDay(ExercisseDay d)
        { }



        public override string ToString()
        {
            string daysInfo = string.Join(",", Days.ConvertAll(day => day.ToString()).ToArray());
            if (string.IsNullOrEmpty(daysInfo))
            {
                daysInfo = "no days are listed";
            }
            return string.Format("{0}\r\n[Days: {1}]", base.ToString(), daysInfo).Replace(",", "\r\n^");
        }
    }
}
