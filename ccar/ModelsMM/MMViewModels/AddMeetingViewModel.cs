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
        public List<ProjectModel> projList { get { return ProjectModel.GetProjectList(); } }
        public List<UserModel> userList { get { return UserModel.GetUsersList(); } }
    }
    // 1 a (new addmeeting i przekazac do widoku w gecie), return view(model)
    // 1. metody do zapisywania tego zmieniam na widoku (http post)
    // 2. podpinanie kontrolek z modelu
    // 3. textboxfor(x=>x.meeting.projectid)

  

}