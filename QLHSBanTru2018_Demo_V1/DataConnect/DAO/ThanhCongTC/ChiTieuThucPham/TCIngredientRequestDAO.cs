using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC.ChiTieuThucPham
{
    public class TCIngredientRequestDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public List<IngredientRequest> listIngredienRequesByDate(DateTime ngaymua)
        {
            var a = dt.IngredientRequests.Where(t => t.Date == ngaymua);
            return a.ToList();
        }
        public List<IngredientRequest> lítIngredienRequesByCreatedDate(DateTime ngaytao)
        {
            var a = dt.IngredientRequests.Where(t => t.CreatedDate == ngaytao);
            return a.ToList();
        }
        public bool Edit(IngredientRequest ingredientRequest)
        {
            IngredientRequest a = dt.IngredientRequests.FirstOrDefault(t => t.IngredientRequestID == ingredientRequest.IngredientRequestID);
            a.Status = ingredientRequest.Status;
            dt.SubmitChanges();
            return true;
        }
    }
}
