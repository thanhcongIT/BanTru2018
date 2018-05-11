using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.DAO.ThanhCongTC.ChiTieu
{
    public class InvoiceDAO
    {
        QLHSSmartKidsDataContext dt = new QLHSSmartKidsDataContext();
        public System.Guid Insert(Invoice invoice)
        {
            Invoice a = new Invoice();
            a.InvoiceID = System.Guid.NewGuid();
            a.CreatedDate = invoice.CreatedDate;
            a.CourseID = invoice.CourseID;
            a.SemesterID = invoice.SemesterID;
            a.EmployeeID = invoice.EmployeeID;
            a.NameMoneyReceive = invoice.NameMoneyReceive;
            a.PhoneNumber = invoice.PhoneNumber;
            a.AdressDetail = invoice.AdressDetail;
            a.TotalPrice = invoice.TotalPrice;
            a.SpendSpeciesID = invoice.SpendSpeciesID;
            a.Note = invoice.Note;
            a.Status = false;
            dt.Invoices.InsertOnSubmit(a);
            dt.SubmitChanges();
            return a.InvoiceID;
        }
        public bool Edit(Invoice invoice)
        {
            Invoice a = new Invoice();
            a = dt.Invoices.FirstOrDefault(t => t.InvoiceID == invoice.InvoiceID);
            a.CreatedDate = invoice.CreatedDate;
            a.CourseID = invoice.CourseID;
            a.SemesterID = invoice.SemesterID;
            a.EmployeeID = invoice.EmployeeID;
            a.NameMoneyReceive = invoice.NameMoneyReceive;
            a.PhoneNumber = invoice.PhoneNumber;
            a.AdressDetail = invoice.AdressDetail;
            a.TotalPrice = invoice.TotalPrice;
            a.SpendSpeciesID = invoice.SpendSpeciesID;
            a.Note = invoice.Note;
            a.Status = invoice.Status;
            dt.SubmitChanges();
            return true;
        }
        public bool Remove(Invoice invoice)
        {
            Invoice a = new Invoice();
            a = dt.Invoices.FirstOrDefault(t => t.InvoiceID == invoice.InvoiceID);
            dt.Invoices.DeleteOnSubmit(a);
            dt.SubmitChanges();
            return true;
        }
        public List<Invoice>ListInvoice(int CourseID,int SemesterID)
        {
            var a = dt.Invoices.Where(t => t.CourseID == CourseID && t.SemesterID == SemesterID);
            return a.ToList();
        }
    }
}
