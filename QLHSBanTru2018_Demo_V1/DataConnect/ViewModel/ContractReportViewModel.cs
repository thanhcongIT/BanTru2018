using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect.ViewModel
{
    public class ContractReportViewModel
    {
        [Display(Name = "Mã Hợp Đồng")]
        public int ContractID { get; set; }
        [Display(Name = "Loại Hợp Đồng")]
        public string ContractType { get; set; }
        public int? TimeType { get; set; }
        [Display(Name = "Thời Hạn Hợp Đồng")]
        public string StringTimeType { get; set; }
        public int EmployeeID { get; set; }
        [Display(Name = "Họ Tên Nhân Viên")]
        public string EmployeeFullName { get; set; }
        [Display(Name = "Hệ Số Lương")]
        public double PayRate { get; set; }
        [Display(Name = "Ngày Bắt Đầu")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Ngày Kết Thúc")]
        public DateTime? EndDate { get; set; }
        public int? CreatedBy { get; set; }
        [Display(Name = "Người Ký")]
        public string CreatedByFullName { get; set; }
        [Display(Name = "Ngày Ký")]
        public DateTime CreatedDate { get; set; }
    }
}
