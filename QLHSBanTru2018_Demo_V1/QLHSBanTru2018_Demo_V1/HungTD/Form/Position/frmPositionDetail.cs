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
using DataConnect.DAO.HungTD;

namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Position
{
    public partial class frmPositionDetail : DevExpress.XtraEditors.XtraForm
    {
        public int Function = 0;
        public DataConnect.Position position;
        public frmPositionDetail()
        {
            InitializeComponent();
        }

        private void frmPositionDetail_Load(object sender, EventArgs e)
        {
            if(Function == 2)
            {
                try
                {
                    txtName.Text = position.Name;
                    chbStatus.Checked = position.Status == true ? true : false;
                }
                catch
                {

                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataConnect.Position entity = new DataConnect.Position();
            entity.Name = txtName.Text;
            entity.Status = chbStatus.Checked == true ? true : false;
            if (Function == 1)
            {
                if(new PositionDAO().Insert(entity) == true)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {

                }
            }
            else if(Function==2)
            {
                entity.PositionID = position.PositionID;
                if(new PositionDAO().Edit(entity) == true)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {

                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}