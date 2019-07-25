using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class ProgressModel
    {
        public int id { get; set; }
        public string progressValue { get; set; }


        public static List<ProgressModel> fromProgress (List<progress> progList)
        {
            List<ProgressModel> ProgList = progList.Select(x => new ProgressModel() { id = x.id, progressValue = x.progressValue }).ToList();
            return ProgList;
        }

        public static List<ProgressModel> GetProgressList()
        {
            ccarEntities ent = new ccarEntities();
            return fromProgress(ent.progress.ToList());
        }


    }
}