using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ccar.ModelsLayout
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
            public int IdResponsibleLayout { get; set; }

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
            public int Status { get; set; }


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
                    //Comments = x.Comments

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
                    //Comments = x.Comments

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
                act.IdResponsibleLayout = a.IdResponsibleLayout;
                act.TargetDate = a.TargetDate;
                act.IdProgress = a.IdProgress;
                act.CompletionDate = a.CompletionDate;
                act.Status = a.Status;
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
                actL.IdResponsibleLayout = a.IdResponsibleLayout;
                actL.TargetDate = a.TargetDate;
                actL.IdProgress = a.IdProgress;
                actL.CompletionDate = a.CompletionDate;
                actL.Status = a.Status;

                return actL;
            }

        public void Save()
        {
            if (this.Id == 0)
            {

                ccarEntities ent = new ccarEntities();


                this.IdInitiator = ent.users.Where(x => x.email == System.Web.HttpContext.Current.User.Identity.Name).Select(x => x.id).SingleOrDefault();
                this.OriginationDate = DateTime.Now;
                this.Status = 0;

                ent.actionsLayout.Add(LayoutModel.ConvertToActionsFromDb(this));
                ent.SaveChanges();
            }
            //else
            //{
            //    ccarEntities ent = new ccarEntities();

            //    if (this.idProgress == 5)
            //    {
            //        this.completionDate = DateTime.Now;
            //    }

            //    string Replaced = System.Environment.UserName.Replace('.', ' ');
            //    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            //    TextInfo textInfo = cultureInfo.TextInfo;

            //    this.Initiator = (textInfo.ToTitleCase(Replaced));

            //    ent.Entry(ActionModel.ConvertToActionsFromDb(this)).State = EntityState.Modified;
            //    ent.SaveChanges();

            //}
        }






    }

    }
