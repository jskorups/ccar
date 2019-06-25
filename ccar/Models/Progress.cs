using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class Progress
    {
        public int id { get; set; }
        public string progressValue { get; set; }


        public static List<Progress> fromProgress (List<progress> progList)
        {
            List<Progress> ProgList = progList.Select(x => new Progress() { id = x.id, progressValue = x.progressValue }).ToList();
            return ProgList;
        }

        public static List<Progress> GetProgressList()
        {
            ccarEntities ent = new ccarEntities();
            return fromProgress(ent.progress.ToList());
        }


    }
}