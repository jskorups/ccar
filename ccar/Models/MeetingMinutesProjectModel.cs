using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class MeetingMinutesProjectModel
    {
        public int id { get; set; }
        public string ProjectName { get; set; }


        public static List<MeetingMinutesProjectModel> fromProjectDB(List<MeetingMinutesProjects> pList)
        {
            List<MeetingMinutesProjectModel> proList = pList.Select(x => new MeetingMinutesProjectModel { id = x.id, ProjectName = x.ProjectName }).ToList();
            return proList;
        }

        public static List<MeetingMinutesProjectModel> GetProjectList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return fromProjectDB(ent.MeetingMinutesProjects.ToList());
        }
        public MeetingMinutesProjectModel()
        {

        }

        public MeetingMinutesProjectModel(string projectName)
        {
            projectName = ProjectName;
        }
        public static MeetingMinutesProjects ConvertFromModelToDB(MeetingMinutesProjectModel p)
        {
            MeetingMinutesProjects pro = new MeetingMinutesProjects();
            pro.id = p.id;
            pro.ProjectName = p.ProjectName;
            return pro;
        }
        public static MeetingMinutesProjectModel ConvertFromDbToModel(MeetingMinutesProjects p)
        {

            MeetingMinutesProjectModel pro = new MeetingMinutesProjectModel();
            pro.id = p.id;
            pro.ProjectName = p.ProjectName;
            return pro;
        }

        public void Save()
        {
            if (this.id == 0)
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                ent.MeetingMinutesProjects.Add(MeetingMinutesProjectModel.ConvertFromModelToDB(this));
            }
        }



    }
}