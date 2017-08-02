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
        private DBContextModel db = new DBContextModel();

        public Object GetClassDocuments(int id)
        {
            var documents = db.TblDocuments.Select(x => x).Where(x => x.UserFK == id);

            var toSend = new List<Object>();
            foreach (var document in documents)
            {
                toSend.Add(new
                {
                    ID = document.ID,
                    File = document.File,
                    IsVisible = document.IsVisible,
                    SubmitedIn = document.SubmitedIn
                });
            }
            return toSend;
        }

        public void CreateClassDocument(Document document)
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
