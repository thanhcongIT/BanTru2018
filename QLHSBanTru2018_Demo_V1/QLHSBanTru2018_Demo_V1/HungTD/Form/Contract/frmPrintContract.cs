using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataConnect.ViewModel;
using QLHSBanTru2018_Demo_V1.Reports;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Contract
{
    public partial class frmPrintContract : DevExpress.XtraEditors.XtraForm
    {
        public ContractReportViewModel contract;
        public frmPrintContract()
        {
            InitializeComponent();
        }
        public void InitContract(ContractReportViewModel contract)
        {
            this.contract = contract;
        }

        private void frmPrintContract_Load(object sender, EventArgs e)
        {
            try
            {
                ContractReport report = new ContractReport();
                report.InitData(contract);
                documentViewer1.DocumentSource = report;
                report.CreateDocument();
            }
            catch
            {

            }
        }
    }
}