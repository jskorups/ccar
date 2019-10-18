using ccar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.ModelsMM.MMViewModels
{
    public class AddMeetingViewModel
    {
        public MeetingModel meeting { get; set; }
        public MeetingUsersModel meetingUsers { get; set; }
        public List<ProjectModel> projList { get { return ProjectModel.GetProjectList(); } }
        public List<UserModel> userList { get { return UserModel.GetUsersList(); } }


        public static MeetingUsers ConvertFromDbToMOdel(MeetingModel m, UserModel u  )
        {
            MeetingUsers mU = new MeetingUsers();
            mU.id = m.Id;
            mU.meetingId = m.Id;
            mU.userId = u.id;
           
            return mU;
        }

        public static Meeting ConvertFromDbToMOdel(MeetingModel m)
        {
            Meeting mmD = new Meeting();
            mmD.id = m.Id;
            mmD.Date = m.Date;
            mmD.projectId = m.ProjectId;
            return mmD;
        }

    }


   

    // 1 a (new addmeeting i przekazac do widoku w gecie), return view(model)
    // 1. metody do zapisywania tego zmieniam na widoku (http post)
    // 2. podpinanie kontrolek z modelu
    // 3. textboxfor(x=>x.meeting.projectid)



}