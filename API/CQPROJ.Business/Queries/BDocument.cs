using CQPROJ.Business.Entities;
using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BDocument
    {
        private static DBContextModel db = new DBContextModel();
        

        public static Object GetDocumentsbyUser(int userID)
        {
            try
            {
                var docs = db.TblDocuments.Where(x => x.UserFK == userID);
                if (docs.Count() == 0) { return null; }
                return docs;
            }
            catch (ArgumentException) { return null; }
        }


        public static Object GetDocumentsbyClass(int classID)
        {
            try
            {
                var docs = db.TblDocuments.Where(x => x.ClassFK == classID);
                if (docs.Count() == 0) { return null; }
                return docs;
            }
            catch (ArgumentException) { return null; }
        }


        public static Object GetDocumentsbyClassStudent(int classID)
        {
            try
            {
                var docs = db.TblDocuments.Where(x => x.ClassFK == classID && x.IsVisible == true);
                if (docs.Count() == 0) { return null; }
                return docs;
            }
            catch (ArgumentException) { return null; }
        }


        public static Boolean CreateDocument(TblDocuments document)
        {
            try
            {
                document.SubmitedIn = DateTime.Now;
                db.TblDocuments.Add(document);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }


        public static Boolean EditDocument(TblDocuments document)
        {
            try
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
