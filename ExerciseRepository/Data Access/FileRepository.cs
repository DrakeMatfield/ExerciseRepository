using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Data_Access
{
    public class FileRepository :IRepository
    {
        #region IRepository Members

        public void Save(ExerciseRepositoryDataObject dataObject)
        {
            throw new NotImplementedException();
        }

        public ExerciseRepositoryDataObject Get(string fileName)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
