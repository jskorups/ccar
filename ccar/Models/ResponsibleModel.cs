using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ccar.Models
{
    public class ResponsibleModel
    {




            public int? id { get; set; }

            [Required(ErrorMessage ="Required")]
            [StringLength(10, ErrorMessage = "Maximum 10 characters.")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Required")]
            [StringLength(15, ErrorMessage = "Maximum 15 characters.")]
            public string Lastname { get; set; }

            [Required(ErrorMessage = "Required")]
            [StringLength(50, ErrorMessage = "Maximum 30 characters.")]
            [RegularExpression(@"^\w+([-+.']\w+)*@grupoantolin.com$", ErrorMessage = "Incorrect email. ")]
            public string email { get; set; }

            public string Name { get; set; }

            //      1.pobrac adres mailowy na podtsawie ID act(w modelu initaiotor), get emailadress, zwraca maila
            //2. sprawdzanie czy nie jest null i czy jest poprawny - w metodzie


            public static string getEmailAdress(int? userId)
            {
                ccarEntities ent = new ccarEntities();
                var xo = ent.responsibles.Where(x => x.id == userId).FirstOrDefault();
                if (xo != null)
                {
                    return xo.email;
                }
                else
                {
                    return "";
                }

            }

        public static string getNameOfResponsible(int? responsibleId)
        {
            ccarEntities ent = new ccarEntities();
            var xo = ent.responsibles.Where(x => x.id == responsibleId).FirstOrDefault();
            if (xo != null)
            {
                return xo.FirstName + " " + xo.Lastname;
            }
            else
            {
                return "";
            }

        }

        public static List<ResponsibleModel> fromUsers(List<responsibles> userList)
            {
                List<ResponsibleModel> listUsers = userList.Select(x => new ResponsibleModel() { id = x.id, FirstName = x.FirstName, Lastname  = x.Lastname, email = x.email, Name = x.FirstName + " " + x.Lastname }).ToList();
                return listUsers;
            }
            public static List<ResponsibleModel> getUsersList()
            {
                ccarEntities ent = new ccarEntities();
                return fromUsers(ent.responsibles.ToList());
            }

            public static responsibles ConvertFromModelToDB(ResponsibleModel u)
            {
                responsibles us = new responsibles();
                us.id = Convert.ToInt32(u.id == null ? 0 : u.id);
                us.FirstName = u.FirstName;
                us.Lastname = u.Lastname;
                us.email = u.email;

                return us;
            }
            public static ResponsibleModel ConvertFromDbToModel(responsibles u)
            {
                ResponsibleModel mod = new ResponsibleModel();
                mod.id = u.id;
                mod.FirstName = u.FirstName;
                mod.Lastname = u.Lastname;
                mod.email = u.email;

                return mod;
            }

            public void Save()
            {
                if (this.id == 0)
                {
                    ccarEntities ent = new ccarEntities();
                    ent.responsibles.Add(ResponsibleModel.ConvertFromModelToDB(this));
                }
            }       
    }
}