using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DataConnect.ViewModel;
using DataConnect.DAO.HungTD;

namespace DataConnect.DAO.TienBao
{
   public class HealthExaminationDAO
    {
        QLHSSmartKidsDataContext db = new QLHSSmartKidsDataContext();

        Table<HealthExamination> HealthExamTable;
        

        public List<HealthExaminationViewModel> ListHealthExamination()
        {
          
            HealthExamTable = db.GetTable<HealthExamination>();
            
            var query = from hex in HealthExamTable                                                
                        select new HealthExaminationViewModel
                        {
                            HealthExaminationID = hex.HealthExaminationID,
                            DateExamination = hex.Date,
                            NameExamination = hex.Name,
                            PlaceExamination = hex.Place,
                            Height = hex.Height,
                            Weight = hex.Weight,
                            Eyes = hex.Eyes,
                            ENT = hex.ENT,
                            Oral = hex.Oral,
                            InternalMedicine = hex.InternalMedicine,
                            Surgery = hex.Surgery,
                            Dermatology = hex.Dermatology,
                            BoneMuscle = hex.BoneMuscle,
                            Nerve = hex.Nerve,
                            Endocrine = hex.Endocrine,                      
                            Status = hex.Status
                        };
            List<HealthExaminationViewModel> list = query.ToList();
            return list;
        }
        public bool HealthExamInsert(HealthExamination entity)
        {
            try
            {
                HealthExamTable = db.GetTable<HealthExamination>();
                HealthExamTable.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool HealthExamUpdate(HealthExamination entity)
        {
            try
            {
                HealthExamTable = db.GetTable<HealthExamination>();
                HealthExamination model = HealthExamTable.SingleOrDefault(x => x.HealthExaminationID.Equals(entity.HealthExaminationID));
                model.Date = entity.Date;
                model.Name = entity.Name;
                model.Place = entity.Place;
                model.Height = entity.Height;
                model.Weight = entity.Weight;
                model.Eyes = entity.Eyes;
                model.ENT = entity.ENT;
                model.Oral = entity.Oral;
                model.InternalMedicine = entity.InternalMedicine;
                model.Surgery = entity.Surgery;
                model.Dermatology = entity.Dermatology;
                model.BoneMuscle = entity.BoneMuscle;
                model.Nerve = entity.Nerve;
                model.Endocrine = entity.Endocrine;
                model.Status = entity.Status;

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool HealthExamDelete(int HealthExaminationID)
        {
            try
            {
                HealthExamTable = db.GetTable<HealthExamination>();
                HealthExamination model = HealthExamTable.SingleOrDefault(x => x.HealthExaminationID.Equals(HealthExaminationID));
                model.Status = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public HealthExamination GetByID(int HealthExaminationID)
        {
            HealthExamTable = db.GetTable<HealthExamination>();
            return db.HealthExaminations.SingleOrDefault(x => x.HealthExaminationID == HealthExaminationID);
        }

    }
}
