using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC.ChiTieu
{
    public class InvoiceDetailDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public bool Insert(InvoiceDetail invoiceDetail)
        {
            InvoiceDetail a = new InvoiceDetail();
            a.InvoiceID = invoiceDetail.InvoiceID;
            a.NameInvoiceDetail = invoiceDetail.NameInvoiceDetail;
            a.Price = invoiceDetail.Price;
            a.Unit = invoiceDetail.Unit;
            a.Amount = invoiceDetail.Amount;
            a.TotalPriceDetail = invoiceDetail.TotalPriceDetail;
            a.Note = invoiceDetail.Note;
            a.Status = false;
            dt.InvoiceDetails.InsertOnSubmit(a);
            dt.SubmitChanges();
            return true;
        }
        public bool Edti(InvoiceDetail invoiceDetail)
        {
            InvoiceDetail a = new InvoiceDetail();
            a = dt.InvoiceDetails.FirstOrDefault(t => t.InvoiceDetailID == invoiceDetail.InvoiceDetailID && t.InvoiceID == invoiceDetail.InvoiceID);
            a.NameInvoiceDetail = invoiceDetail.NameInvoiceDetail;
            a.Price = invoiceDetail.Price;
            a.Unit = invoiceDetail.Unit;
            a.Amount = invoiceDetail.Amount;
            a.TotalPriceDetail = invoiceDetail.TotalPriceDetail;
            a.Note = invoiceDetail.Note;
            a.Status = invoiceDetail.Status;
            dt.SubmitChanges();
            return true;
        }
        public bool Remove(InvoiceDetail invoiceDetail)
        {
            InvoiceDetail a = new InvoiceDetail();
            a = dt.InvoiceDetails.FirstOrDefault(t => t.InvoiceDetailID == invoiceDetail.InvoiceDetailID && t.InvoiceID == invoiceDetail.InvoiceID);
            dt.InvoiceDetails.DeleteOnSubmit(a);
            dt.SubmitChanges();
            return true;
        }
        public List<InvoiceDetail> ListInvoiceDetail(System.Guid InvoiceID)
        {
            var a = dt.InvoiceDetails.Where(t => t.InvoiceID == InvoiceID);
            return a.ToList();
        }
        public static List<InvoiceDetail> listDemoInvoiceDetail = new List<InvoiceDetail>();
        public static int Therowfocust = 0;
        public static InvoiceDetail DemoInvoiceDetail = new InvoiceDetail();
    }
}
