using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static bool CreateNotice(TblNotices notice)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblNotices.Add(notice);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool EditNotice(TblNotices notice)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(notice).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
