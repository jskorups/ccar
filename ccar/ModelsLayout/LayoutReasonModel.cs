using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ccar.ModelsLayout
{   
        public class LayoutReasonModel
        {

            // 1:1 from DB
            public int id { get; set; }
            [Required(ErrorMessage = "Required")]
            [StringLength(20, ErrorMessage = "Maximum 20 characters.")]
            public string reasonLayout { get; set; }


            // List of reasons
            public static List<LayoutReasonModel> fromReason(List<reasonsLayout> rList)
            {
                List<LayoutReasonModel> listReason = rList.Select(x => new LayoutReasonModel() { id = x.id, reasonLayout = x.reasonLayout }).ToList();
                return listReason;
            }
            public static List<LayoutReasonModel> GetReasonList()
            {
                ccarEntities ent = new ccarEntities();
                return fromReason(ent.reasonsLayout.ToList());
            }

            public static string getNameOfReason(int? reasonId)
            {
                ccarEntities ent = new ccarEntities();
                var xo = ent.reasonsLayout.Where(x => x.id == reasonId).FirstOrDefault();
                if (xo != null)
                {
                    return xo.reasonLayout;
                }
                else
                {
                    return "";
                }

            }

            public static reasonsLayout ConvertFromModelToDB(LayoutReasonModel r)
            {
                reasonsLayout rea = new reasonsLayout();
                rea.id = r.id;
                rea.reasonLayout = r.reasonLayout;

                return rea;
            }
            public static LayoutReasonModel ConvertFromDbToModel(reasonsLayout r)
            {

                LayoutReasonModel rea = new LayoutReasonModel();
                rea.id = r.id;
                rea.reasonLayout = r.reasonLayout;
                return rea;
            }

            public void Save()
            {
                if (this.id == 0)
                {
                    ccarEntities ent = new ccarEntities();
                    ent.reasonsLayout.Add(LayoutReasonModel.ConvertFromModelToDB(this));
                }
            }
        }
    }
