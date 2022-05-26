using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Interfaces;
using WCF.Models;
using WCF.Persistence;
using WCF.ViewModels;

namespace WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Users" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Users.svc or Users.svc.cs at the Solution Explorer and start debugging.
    public class Users : IUser
    {
        private readonly ILog log;
        public Users() : base()
        {
            log = LogManager.GetLogger(typeof(Users));
        }

        public List<UserVM> All()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    return db.Users.Select(item => new UserVM
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Birthday = item.Birthday,
                        Gender = item.Gender,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return new List<UserVM>();
            }
        }

        public UserVM Show(int id)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var item = db.Users.Find(id);
                    if (item != null)
                    {
                        return new UserVM
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Birthday = item.Birthday,
                            Gender = item.Gender,
                        };
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        public bool Insert(UserVM item)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var model = new User
                    {
                        Name = item.Name,
                        Birthday = item.Birthday,
                        Gender = item.Gender,
                    };
                    db.Users.Add(model);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
        }

        public bool Update(int id, UserVM item)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var model = db.Users.Find(id);
                    if (model != null)
                    {
                        model.Name = item.Name;
                        model.Birthday = item.Birthday;
                        model.Gender = item.Gender;
                        db.Entry(model).State = EntityState.Modified;
                        db.SaveChanges();
                        return true;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var model = db.Users.Find(id);
                    if (model != null)
                    {
                        db.Users.Remove(model);
                        db.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
        }
    }
}
