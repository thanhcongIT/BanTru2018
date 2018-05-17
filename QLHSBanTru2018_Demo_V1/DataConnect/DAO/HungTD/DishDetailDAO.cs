using DataConnect.ViewModel;
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
        public bool Update(DishDetail entity)
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
        public bool Update(List<DishDetail> listDishDetail)
        {
            try
            {
                foreach (DishDetail item in listDishDetail)
                {
                    if (!Update(item))
                    {
                        break;
                    }
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

        public List<DishDetailViewModel> GetDishDetailViewModels(int dishID)
        {
            try
            {
                Table<Ingredient> ingredients = db.GetTable<Ingredient>();
                var model = from d in dishDetails
                            join i in ingredients
                            on d.IngredientID equals i.IngredientID
                            where d.DishID == dishID
                            select new DishDetailViewModel
                            {
                                DishID = d.DishID,
                                IngredientID = d.IngredientID,
                                IngredientName = i.Name,
                                QuantityOfUnit = d.QuantiyOfUnit,
                                Status = d.Status
                            };
                return model.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Ingredient NutritionCalculation(int DishID)
        {            
            try
            {
                Ingredient total = new Ingredient();

                total.IngredientID = 0;
                total.Name = "ABC";
                total.IngredientTypeID = 1;
                total.Unit = "X";
                total.Kcal = 0;
                total.Protein = 0;
                total.Fat = 0;
                total.Glucose = 0;
                total.Fiber = 0;
                total.Canxi = 0;
                total.Iron = 0;
                total.Photpho = 0;
                total.Kali = 0;
                total.Natri = 0;
                total.VitaminA = 0;
                total.VitaminB1 = 0;
                total.VitaminC = 0;
                total.AxitFolic = 0;
                total.Cholesterol = 0;
                total.Status = true;

                List<DishDetail> listDishDetail = dishDetails.Where(x => x.DishID.Equals(DishID)).ToList();
                List<Ingredient> listIngredient = new List<Ingredient>();
                foreach (var item in listDishDetail)
                {
                    Ingredient ingredient = new IngredientDAO().GetByID(item.IngredientID);

                    total.Kcal = ingredient.Kcal * item.QuantiyOfUnit;
                    total.Protein = ingredient.Protein * item.QuantiyOfUnit;
                    total.Fat = ingredient.Fat * item.QuantiyOfUnit;
                    total.Glucose = ingredient.Glucose * item.QuantiyOfUnit;
                    total.Fiber = ingredient.Fiber * item.QuantiyOfUnit;
                    total.Canxi = ingredient.Canxi * item.QuantiyOfUnit;
                    total.Iron = ingredient.Iron * item.QuantiyOfUnit;
                    total.Photpho = ingredient.Photpho * item.QuantiyOfUnit;
                    total.Kali = ingredient.Kali * item.QuantiyOfUnit;
                    total.Natri = ingredient.Natri * item.QuantiyOfUnit;
                    total.VitaminA = ingredient.VitaminA * item.QuantiyOfUnit;
                    total.VitaminB1 = ingredient.VitaminB1 * item.QuantiyOfUnit;
                    total.VitaminC = ingredient.VitaminC * item.QuantiyOfUnit;
                    total.AxitFolic = ingredient.AxitFolic * item.QuantiyOfUnit;
                    total.Cholesterol = ingredient.Cholesterol * item.QuantiyOfUnit;


                    listIngredient.Add(ingredient);
                }
                return total;
            }
            catch
            {
                return null;
            }
        }
    }
}
