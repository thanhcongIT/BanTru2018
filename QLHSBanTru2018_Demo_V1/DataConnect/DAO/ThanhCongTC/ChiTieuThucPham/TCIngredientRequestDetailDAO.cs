using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC.ChiTieuThucPham
{
    public class TCIngredientRequestDetailDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public List<IngredientRequestDetail> listInredientRequestDetail(int ingredientRequest)
        {
            var a = dt.IngredientRequestDetails.Where(t => t.IngredientRequestID == ingredientRequest);
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
