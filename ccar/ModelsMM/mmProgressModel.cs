using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class mmProgressModel
    {
        public int id { get; set; }
        public string progressValue { get; set; }


        public static List<mmProgressModel> fromProgress (List<progress> progList)
        {
            List<mmProgressModel> ProgList = progList.Select(x => new mmProgressModel() { id = x.id, progressValue = x.progressValue }).ToList();
            return ProgList;
        }

        public static List<mmProgressModel> GetProgressList()
        {
            ccarEntities ent = new ccarEntities();
            return fromProgress(ent.progress.ToList());
        }


    }
}