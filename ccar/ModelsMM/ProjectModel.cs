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


        public static List<ProjectModel> fromProjectDB(List<Projects> pList)
        {
            List<ProjectModel> proList = pList.
                Select
                (x => new ProjectModel
                { id = x.id,
              ProjectName = x.ProjectName }).ToList();

            return proList;
        }

        public static List<ProjectModel> GetProjectList()
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            return fromProjectDB(ent.Projects.ToList());
        }
        public ProjectModel()
        {

        }

        public ProjectModel(string projectName)
        {
            projectName = ProjectName;
        }
        public static Projects ConvertFromModelToDB(ProjectModel p)
        {
            Projects pro = new Projects();
            pro.id = p.id;
            pro.ProjectName = p.ProjectName;
            return pro;
        }
        public static ProjectModel ConvertFromDbToModel(Projects p)
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
                ent.Projects.Add(ProjectModel.ConvertFromModelToDB(this));
            }
        }
    }
}