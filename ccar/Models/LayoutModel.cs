using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class LayoutModel
    {
        // 1:1 from DB
        public int Id { get; set; }

        [Range(1, float.MaxValue, ErrorMessage = "Required")]
        public int IdReason { get; set; }
        public string Reason { get; set; }
        public int IdInitiator { get; set; }
        public string Initiator { get; set; }

        [DataType(DataType.Date)]
        public DateTime OriginationDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(20, ErrorMessage = "Maximum 20 characters.")]
        public string TaskDescription { get; set; }
        [Range(1, float.MaxValue, ErrorMessage = "Required")]
        public int IdResponsible { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TargetDate { get; set; }

        [Range(1, float.MaxValue, ErrorMessage = "Required")]
        public int IdProgress { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CompletionDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(20, ErrorMessage = "Maximum 30 characters.")]
        public string Comments { get; set; }


        public static List<actionLayoutView> fromLayoutDB(List<actionLayoutView> layoutList)
        {
            List<actionLayoutView> actionList = layoutList.Select(x => new actionLayoutView()
            {
                Id = x.Id,
                Reason = x.Reason,
                Initiator = x.Initiator,
                OriginationDate = x.OriginationDate,
                TaskDescription = x.TaskDescription,
                Responsible = x.Responsible,
                TargetDate = x.TargetDate,
                Progress = x.Progress,
                CompletionDate = x.CompletionDate,
                Comments = x.Comments

            }).ToList();
            return layoutList;
        }

        public static List<actionLayoutDoneView> fromLayoutDB2(List<actionLayoutDoneView> layoutList)
        {
            List<actionLayoutDoneView> actionList = layoutList.Select(x => new actionLayoutDoneView()
            {
                Id = x.Id,
                Reason = x.Reason,
                Initiator = x.Initiator,
                OriginationDate = x.OriginationDate,
                TaskDescription = x.TaskDescription,
                Responsible = x.Responsible,
                TargetDate = x.TargetDate,
                Progress = x.Progress,
                CompletionDate = x.CompletionDate,
                Comments = x.Comments

            }).ToList();
            return layoutList;
        }

        public static actionsLayout ConvertToActionsFromDb(LayoutModel a)
        {
            actionsLayout act = new actionsLayout();
            act.Id = a.Id;
            act.IdReasonLayout = a.IdReason;
            act.IdInitiator = a.IdInitiator;
            act.OriginationDate = a.OriginationDate;
            act.TaskDescription = a.TaskDescription;
            act.IdResponsibleLayout = a.IdResponsible;
            act.TargetDate = a.TargetDate;
            act.IdProgress = a.IdProgress;
            act.CompletionDate = a.CompletionDate;
            act.Comments = a.Comments;
            return act;
        }

        public static LayoutModel ConvertFromEFtoModel(actionsLayout a)
        {

            LayoutModel actL = new LayoutModel();
            actL.Id = a.Id;
            actL.IdReason = a.IdReasonLayout;
            actL.IdInitiator = a.IdInitiator;
            actL.Initiator = a.Initiator;
            actL.OriginationDate = a.OriginationDate;
            actL.TaskDescription = a.TaskDescription;
            actL.IdResponsible = a.IdResponsibleLayout;
            actL.TargetDate = a.TargetDate;
            actL.IdProgress = a.IdProgress;
            actL.CompletionDate = a.CompletionDate;
            actL.Comments = a.Comments;
        
            return actL;
        }




    }

   




}