using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class mmProjectsModel
    {
        public int id { get; set; }
        public string ProjectName { get; set; }


        public static List<mmProjectsModel> fromProjectDB(List<MeetingMinutesProjects> pList)
        {
            List<mmProjectsModel> proList = pList.Select(x => new mmProjectsModel { id = x.id, ProjectName = x.ProjectName }).ToList();
            return proList;
        }

        public static List<mmProjectsModel> GetProjectList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return fromProjectDB(ent.MeetingMinutesProjects.ToList());
        }
        public mmProjectsModel()
        {

        }

        public mmProjectsModel(string projectName)
        {
            projectName = ProjectName;
        }
        public static MeetingMinutesProjects ConvertFromModelToDB(mmProjectsModel p)
        {
            MeetingMinutesProjects pro = new MeetingMinutesProjects();
            pro.id = p.id;
            pro.ProjectName = p.ProjectName;
            return pro;
        }
        public static mmProjectsModel ConvertFromDbToModel(MeetingMinutesProjects p)
        {

            mmProjectsModel pro = new mmProjectsModel();
            pro.id = p.id;
            pro.ProjectName = p.ProjectName;
            return pro;
        }

        public void Save()
        {
            if (this.id == 0)
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                ent.MeetingMinutesProjects.Add(mmProjectsModel.ConvertFromModelToDB(this));
            }
        }



    }
}