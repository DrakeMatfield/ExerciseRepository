using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseRepository.Data_Access
{
    public interface IRepository
    {
        void Save(ExerciseRepositoryDataObject dataObject);
        void ExportToXml(ExerciseRepositoryDataObject dataObject);
        ExerciseRepositoryDataObject Get(string fileName);
        ExerciseRepositoryDataObject ImportFromXml(string fileName);
        
    }

    public enum DataAccess_Type
    {
        XML_FILE,
        FILE,
        DATABASE,
        WEB_CONFIG_SETTINGS
    }

    public class Repository
    {
        public static IRepository Get_DataAccess(DataAccess_Type access_type)
        {
            switch (access_type)
            {
                case DataAccess_Type.FILE:
                    return new FileRepository();
                    break;
                case DataAccess_Type.XML_FILE:
                case DataAccess_Type.DATABASE:
                //return new Mysql_p1_Repository();
                //break;
                case DataAccess_Type.WEB_CONFIG_SETTINGS:
                ////string choice = ConfigurationManager.AppSettings["DataAccess_Option"].Trim();
                //string choice = string.Empty;
                //if (choice == "0")
                //{
                //    return new XmlFileRepository();
                //}
                //else
                //{
                //    //return new Mysql_p1_Repository();
                //}
                //break;
                default:
                    return new FileRepository();
            }


        }

    }

}