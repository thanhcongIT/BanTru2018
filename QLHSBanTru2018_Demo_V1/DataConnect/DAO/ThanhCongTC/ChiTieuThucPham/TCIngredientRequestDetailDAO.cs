using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnect.DAO.ThanhCongTC.TCViewModle;

namespace DataConnect.DAO.ThanhCongTC.ChiTieuThucPham
{
    public class TCIngredientRequestDetailDAO
    {
        Table<Ingredient> ingredient;
        Table<IngredientRequestDetail> ingredientRequesDetail;
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public List<TCIngredientRequestDetaiViewModle> listInredientRequestDetail(int ingredientRequest)
        {
            ingredient = dt.GetTable<Ingredient>();
            ingredientRequesDetail = dt.GetTable<IngredientRequestDetail>();
            var a = from b in ingredient
                    join c in ingredientRequesDetail on b.IngredientID equals c.IngredientID
                    where c.IngredientRequestID.Equals(ingredientRequest)
                    select new TCIngredientRequestDetaiViewModle
                    {
                        IngredientID = c.IngredientID,
                        IngredientRequestID = c.IngredientRequestID,
                        Quantity = c.Quantity,
                        Unit = b.Unit,
                        Name = b.Name,
                        Status = c.Status
                    };
            return a.ToList();
                                   
        }
        public bool Edit(IngredientRequestDetail ingredientRequest)
        {
            IngredientRequestDetail a = dt.IngredientRequestDetails.FirstOrDefault(t => t.IngredientRequestID == ingredientRequest.IngredientRequestID && t.IngredientID == ingredientRequest.IngredientID);
            a.Status = ingredientRequest.Status;
            dt.SubmitChanges();
            return true;
        }
    }
}
