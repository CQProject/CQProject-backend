using CQPROJ.Business.Entities;
using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BDocuments
    {
        private static DBContextModel db = new DBContextModel();

        public static Object GetDocumentsbyUser(int id)
        {
            try
            {
                var docs = db.TblDocuments.Where(x => x.UserFK == id).Select(x => new { x.ID, x.ClassFK, x.File, x.SubmitedIn, x.IsVisible });

                if (docs.Count() == 0)
                {
                    return null;
                }
                return docs;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public void CreateClassDocument(IDocument document)
        {
            var date = DateTime.Now;

            TblDocuments doc = new TblDocuments
            {
                File = document.File,
                IsVisible = document.IsVisible,
                SubmitedIn = date,
                ClassFK = document.ClassFK,
                UserFK = document.UserFK
            };

            db.TblDocuments.Add(doc);
            db.SaveChanges();
        }

    }
}
