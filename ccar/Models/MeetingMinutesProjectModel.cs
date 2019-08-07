using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class ProjectModel
    {
        public int id { get; set; }
        public string ProjectName { get; set; }


        public static List<ProjectModel> fromProjectDB(List<MeetingMinutesProjects> pList)
        {
            List<ProjectModel> proList = pList.Select(x => new ProjectModel { id = x.id, ProjectName = x.ProjectName }).ToList();
            return proList;
        }

        public static List<ProjectModel> GetProjectList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return fromProjectDB(ent.MeetingMinutesProjects.ToList());
        }
        public ProjectModel()
        {

        }



    }
}