using CQPROJ.Data.DB.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BNotice
    {
        public static Object GetNews()
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var notices = db.TblNotices
                    .ToList()
                    .OrderByDescending(x => x.ID)
                    .Take(4);
                    if (notices.Count() == 0) { return null; }
                    return notices;
                }
            }
            catch (Exception) { return null; }
        }

        public static object GetNoticeBySchool(int schoolID, int pageID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var notices = db.TblNotices
                    .ToList()
                    .Where(x => x.SchoolFK == schoolID)
                    .OrderByDescending(x => x.ID)
                    .Skip(12 * pageID)
                    .Take(12);
                    if (notices.Count() == 0) { return null; }
                    return notices;
                }
            }
            catch (Exception) { return null; }
        }

        public static bool CreateNotice(TblNotices notice, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblNotices.Add(notice);
                    db.SaveChanges();

                    BAction.SetActionToUser(String.Format("Criou o anuncio '{0}' de escola '{1}'", notice.Title, db.TblSchools.Find(notice.SchoolFK).Name), userID);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool EditNotice(TblNotices notice, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(notice).State = EntityState.Modified;
                    db.SaveChanges();

                    BAction.SetActionToUser(String.Format("Editou o anuncio '{0}' de escola '{1}'", notice.Title, db.TblSchools.Find(notice.SchoolFK).Name), userID);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool DeleteNotice(int noticeid, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var notice = db.TblNotices.Find(noticeid);
                    db.TblNotices.Remove(notice);
                    db.SaveChanges();
                    
                    BAction.SetActionToUser(String.Format("Removou o anuncio '{0}' de escola '{1}'", notice.Title, db.TblSchools.Find(notice.SchoolFK).Name), userID);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
