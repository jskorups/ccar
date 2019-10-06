using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.ModelsMM
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

        public ProjectModel(string projectName)
        {
            projectName = ProjectName;
        }
        public static MeetingMinutesProjects ConvertFromModelToDB(ProjectModel p)
        {
            MeetingMinutesProjects pro = new MeetingMinutesProjects();
            pro.id = p.id;
            pro.ProjectName = p.ProjectName;
            return pro;
        }
        public static ProjectModel ConvertFromDbToModel(MeetingMinutesProjects p)
        {

            ProjectModel pro = new ProjectModel();
            pro.id = p.id;
            pro.ProjectName = p.ProjectName;
            return pro;
        }

        public void Save()
        {
            if (this.id == 0)
            {
                ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
                ent.MeetingMinutesProjects.Add(ProjectModel.ConvertFromModelToDB(this));
            }
        }
    }
}