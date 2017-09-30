using CQPROJ.Data.DB.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BDocument
    {
        public static Object GetDocumentsbyUser(int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var docs = db.TblDocuments.Where(x => x.UserFK == userID).ToList();
                    if (docs.Count() == 0) {
                        return new { result = true, info = "Não submeteu nenhum documento." };
                    }
                    return new { result = true, data = docs };
                }
            }
            catch (ArgumentException) { return new { result = false, info = "Não foram encontrados documentos do utilizador." }; }
        }


        public static Object GetDocumentsbyClass(int classID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var docs = db.TblDocuments.Where(x => x.ClassFK == classID).ToList();
                    if (docs.Count() == 0) {
                        return new { result = false, info = "Não existem documentos da turma." };
                    }
                    return new { result = true, data = docs };
                }
            }
            catch (ArgumentException) { return new { result = false, info = "Não foram encontrados documentos da turma." }; }
        }


        public static Object GetDocumentsbyClassStudent(int classID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var docs = db.TblDocuments.Where(x => x.ClassFK == classID && x.IsVisible == true).ToList();
                    if (docs.Count() == 0) {
                        return new { result = false, info = "Não existem documentos da turma." };
                    }
                    return new { result = true, data = docs };
                }
            }
            catch (ArgumentException) { return new { result = false, info = "Não foram encontrados documentos da turma." }; }
        }


        public static Object CreateDocument(TblDocuments document, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    if (!BClass.GetActivity(document.ClassFK ?? 0))
                    {
                        return new { result = false, info = "A turma enconstra-se inativa, já não é possível adicionar o documento." };
                    }
                    db.TblDocuments.Add(document);
                    db.SaveChanges();

                    var cla = db.TblClasses.Find(document.ClassFK);
                    BAction.SetActionToUser(String.Format("Adicionou documento '{0}' da turma '{1}' da escola '{2}'", document.File.Split('.')[1] + document.File.Split('.')[2], cla.Year + cla.ClassDesc, db.TblSchools.Find(cla.SchoolFK).Name), userID);
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível eliminar o documento." }; }
        }


        public static Object EditDocument(TblDocuments document, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    if (document.UserFK != userID)
                    {
                        return new { result = false, info = "Não Autorizado, não foi o utilizador a submeter o documento." };
                    }
                    if (!BClass.GetActivity(document.ClassFK ?? 0))
                    {
                        return new { result = false, info = "A turma enconstra-se inativa, já não é possível alterar o documento." };
                    }
                    db.Entry(document).State = EntityState.Modified;
                    db.SaveChanges();

                    var cla = db.TblClasses.Find(document.ClassFK);
                    BAction.SetActionToUser(String.Format("Alterou o documento '{0}' da turma '{1}' da escola '{2}'", document.File.Split('.')[1] + document.File.Split('.')[2], cla.Year + cla.ClassDesc, db.TblSchools.Find(cla.SchoolFK).Name), userID);
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível alterar o documento." }; }
        }

        public static Object DeleteDocument(int documentID, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var document = db.TblDocuments.Find(documentID);
                    if (document.UserFK != userID)
                    {
                        return new { result = false, info = "Não Autorizado, não foi o utilizador a submeter o documento." };
                    }
                    if (!BClass.GetActivity(document.ClassFK ?? 0))
                    {
                        return new { result = false, info = "A turma enconstra-se inativa, já não é possível eliminar o documento." };
                    }
                    db.TblDocuments.Remove(document);
                    db.SaveChanges();

                    var cla = db.TblClasses.Find(document.ClassFK);
                    BAction.SetActionToUser(String.Format("Eliminou o documento '{0}' da turma '{1}' da escola '{2}'", document.File.Split('.')[1] + document.File.Split('.')[2], cla.Year + cla.ClassDesc, db.TblSchools.Find(cla.SchoolFK).Name), userID);
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível eliminar o documento." }; }
        }
    }
}
