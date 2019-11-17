using ccar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.ModelsMM.MMViewModels
{
    public class AddMeetingViewModel
    {
        public AddMeetingViewModel(int projectId)
        {
            meeting = new MeetingModel();
            meeting.ProjectId = projectId;
            meetingUsers = new MeetingUsersModel();
        }

        public AddMeetingViewModel(int projectId, int meetingid)
        {
            meeting = new MeetingModel();
            meeting.ProjectId = projectId;
            meetingUsers = new MeetingUsersModel();
            meetingUsers.id = meetingid;
        }

        public AddMeetingViewModel()
        {
            meeting = new MeetingModel();
            meetingUsers = new MeetingUsersModel();
        }

        public MeetingModel meeting { get; set; }
        public MeetingUsersModel meetingUsers { get; set; }
        public List<ProjectModel> projList { get { return ProjectModel.GetProjectList(); } }
        public List<UserModel> userList { get { return UserModel.GetUsersList(); } }


        public void Save(int[] PersonsIds)
        {
            ccarMeetingMinutesEntities ent = new ccarMeetingMinutesEntities();
            Meeting m = new Meeting();
            m.projectId = meeting.ProjectId;
            m.Date = DateTime.Now;
            ent.Meeting.Add(m);
            for (int i = 0; i < PersonsIds.Count(); i++)
            {
                MeetingUsers u = new MeetingUsers();
                u.userId = PersonsIds[i];
                u.isPresent = true;
                u.Meeting = m;
                ent.MeetingUsers.Add(u);
            }
            ent.SaveChanges();
        }
    }






}