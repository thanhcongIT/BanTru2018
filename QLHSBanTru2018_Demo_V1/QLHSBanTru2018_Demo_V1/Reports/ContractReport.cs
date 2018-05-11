using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DataConnect.ViewModel;

namespace QLHSBanTru2018_Demo_V1.Reports
{
    public partial class ContractReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ContractReport()
        {
            InitializeComponent();
        }
        public void InitData(ContractReportViewModel contract)
        {
            labName.Text = contract.EmployeeFullName;
        }
    }
}
