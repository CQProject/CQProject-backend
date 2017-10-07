using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BClass
    {
        public static Object GetClassesByUser(int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var classes = db.TblClassUsers.Where(x => x.UserFK == userID).Select(x => x.ClassFK).ToList();
                    if (classes.Count() == 0)
                    {
                        return new { result = false, info = "Sem turma atribuída." };
                    }
                    return new { result = true, data = classes };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível encontrar turmas do utilizador." }; }
        }

        public static Object GetTeachersByClass(int classID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var teachers = db.TblClassUsers
                        .Where(x => x.ClassFK == classID && db.TblUserRoles.Any(y => y.UserFK == x.UserFK && y.RoleFK == 2))
                        .Select(x => x.UserFK).ToList();
                    if (teachers.Count() == 0)
                    {
                        return new { result = false, info = "Turma sem professores." };
                    }
                    return new { result = true, data = teachers };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível encontrar professores da turma." }; }
        }

        public static List<int> GetStudentsByClass(int classID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var students = db.TblClassUsers
                        .Where(x => x.ClassFK == classID && db.TblUserRoles.Any(y => y.UserFK == x.UserFK && y.RoleFK == 1))
                        .Select(x => x.UserFK).ToList();
                    if (students.Count() == 0) {
                        return null;
                    }
                    return  students;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetClassesPrimaryBySchool(int schoolID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var classes = db.TblClasses.Where(x => x.SchoolFK == schoolID && x.Year != null).ToList();
                    if (classes.Count() == 0) {
                        return new { result = false, info = "Escola 1º ciclo sem turmas." };
                    }
                    return new { result = true, data = classes };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível encontrar turmas da escola de 1º ciclo." }; }
        }

        public static Object GetClassesKindergartenBySchool(int schoolID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var classes = db.TblClasses.Where(x => x.SchoolFK == schoolID && x.Year == null).ToList();
                    if (classes.Count() == 0) {
                        return new { result = false, info = "Jardim de infância sem turmas." };
                    }
                    return new { result = true, data = classes };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível encontrar turmas do Jardim de infância." }; }
        }

        public static Object GetClassProfile(int classID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return new { result = true, data = db.TblClasses.Find(classID) };
                }
            }
            catch (Exception) { return new { result = false, info = "Turma inexistente." }; }
        }

        public static Object CreateClass(TblClasses newClass, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblClasses.Add(newClass);
                    db.SaveChanges();

                    BAction.SetActionToUser(String.Format("Criou a turma '{0}' da escola '{1}'", newClass.Year+newClass.ClassDesc, db.TblSchools.Find(newClass.SchoolFK).Name), userID);
                    return new { result = true, data = newClass.ID };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível criar a turma." }; }
        }

        public static Object EditClass(TblClasses alteredClass, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(alteredClass).State = EntityState.Modified;
                    db.SaveChanges();

                    BAction.SetActionToUser(String.Format("Editou a turma '{0}' da escola '{1}'", alteredClass.Year + alteredClass.ClassDesc, db.TblSchools.Find(alteredClass.SchoolFK).Name), userID);
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível editar a turma." }; }
        }

        public static Object SwitchActivity(int classID, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var cla = db.TblClasses.Find(classID);
                    cla.IsActive = cla.IsActive ? false : true;
                    db.Entry(cla).State = EntityState.Modified;
                    db.SaveChanges();

                    BAction.SetActionToUser(String.Format("Alterou o estado de actividade da turma '{0}' da escola '{1}' para '{2}'", cla.Year + cla.ClassDesc, db.TblSchools.Find(cla.SchoolFK).Name, (cla.IsActive?"ACTIVO":"INACTIVO")), userID);
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível alterar estado de atividade da turma." }; }
        }

        public static Object AddUser(int classID, int userID, int currentUser)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var classUser = new TblClassUsers { ClassFK = classID, UserFK = userID };
                    db.TblClassUsers.Add(classUser);
                    db.SaveChanges();

                    var cla = db.TblClasses.Find(classUser.ClassFK);
                    BAction.SetActionToUser(String.Format("Adicionou o utilizador '{0}' à turma '{1}' da escola {2}", db.TblUsers.Find(classUser.UserFK).Name ,cla.Year + cla.ClassDesc, db.TblSchools.Find(cla.SchoolFK).Name), currentUser);
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível adicionar o utilizador à turma." }; }
        }

        public static Object RemoveUser(int classID, int userID, int currentUser)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var classUser = db.TblClassUsers.Where(x => x.ClassFK == classID && x.UserFK == userID).FirstOrDefault();
                    db.TblClassUsers.Remove(classUser);
                    db.SaveChanges();

                    var cla = db.TblClasses.Find(classUser.ClassFK);
                    BAction.SetActionToUser(String.Format("Removeu o utilizador '{0}' à turma '{1}' da escola {2}", db.TblUsers.Find(classUser.UserFK).Name, cla.Year + cla.ClassDesc, db.TblSchools.Find(cla.SchoolFK).Name), currentUser);
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível remover o utilizador à turma." }; }
        }

        public static Boolean HasUser(int classID, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblClassUsers.Any(x => x.UserFK == userID && x.ClassFK == classID);
                }
            }
            catch { return false; }
        }

        public static Boolean HasUser(int? classID, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblClassUsers.Any(x => x.UserFK == userID && x.ClassFK == classID);
                }
            }
            catch { return false; }
        }

        public static Boolean GetActivity(int classID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblClasses.Find(classID).IsActive;
                }
            }
            catch { return false; };
        }
    }
}
