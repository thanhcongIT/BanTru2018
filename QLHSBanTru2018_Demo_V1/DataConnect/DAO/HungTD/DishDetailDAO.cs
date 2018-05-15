using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.HungTD
{
    public class DishDetailDAO
    {
        QLHSSmartKidsDataContext db;
        Table<DishDetail> dishDetails;
        public DishDetailDAO()
        {
            db = new QLHSSmartKidsDataContext();
            dishDetails = db.GetTable<DishDetail>();
        }
        public List<DishDetail> GetByDishID(int dishID)
        {
            return dishDetails.Where(x => x.DishID.Equals(dishID) && x.Status.Equals(true)).ToList();
        }
        public DishDetail GetByID(int dishDetailID)
        {
            return dishDetails.FirstOrDefault(x => x.DishDetailID.Equals(dishDetailID));
        }
        public int Insert(DishDetail entity, int dishID)
        {
            DishDetail dishDetail = new DishDetail();
            dishDetail.DishID = dishID;
            dishDetail.IngredientID = entity.IngredientID;
            dishDetail.QuantiyOfUnit = entity.QuantiyOfUnit;
            dishDetail.Status = entity.Status;
            dishDetails.InsertOnSubmit(dishDetail);
            db.SubmitChanges();
            return dishDetail.DishDetailID;
        }
        public bool InsertList(List<DishDetail> listDishDetail, int dishID)
        {
            //try
            //{
            //    foreach (DishDetail item in listDishDetail)
            //    {
            //        Insert(item, dishID);
            //    }
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
            foreach (DishDetail item in listDishDetail)
            {
                Insert(item, dishID);
            }
            return true;
        }
        public bool ChangeQuantity(DishDetail entity)
        {
            try
            {
                DishDetail obj = dishDetails.Single(x => x.DishDetailID.Equals(entity.DishDetailID));
                obj.QuantiyOfUnit = entity.QuantiyOfUnit;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ChangeQuantityList(List<DishDetail> listDishDetail)
        {
            try
            {
                foreach (DishDetail item in listDishDetail)
                {
                    ChangeQuantity(item);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int dishDetailID)
        {
            try
            {
                DishDetail obj = dishDetails.Single(x => x.DishDetailID.Equals(dishDetailID));
                obj.Status = false;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
