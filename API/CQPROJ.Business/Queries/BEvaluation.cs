using CQPROJ.Business.Entities;
using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BEvaluation
    {
        private DBContextModel db = new DBContextModel();

        public void CreateEvaluation(Evaluation evaluation)
        {

            TblEvaluations eval = new TblEvaluations
            {
                EvaluationDate = evaluation.EvaluationDate,
                Purport = evaluation.Purport,
                ScheduleFK = evaluation.ScheduleFK
            };

            db.TblEvaluations.Add(eval);
            db.SaveChanges();
        }
    }
}
