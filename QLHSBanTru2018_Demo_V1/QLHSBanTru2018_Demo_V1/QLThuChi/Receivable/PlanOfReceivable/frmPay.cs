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
using DataConnect.DAO.ThanhCongTC;
using DataConnect;
using System.IO;

namespace QLHSBanTru2018_Demo_V1.QLThuChi.DotThu.KeHoachThu
{
    public partial class frmPay : DevExpress.XtraEditors.XtraForm
    {
        public frmPay()
        {
            InitializeComponent();
        }
        public void LoadKhoanPhi()
        {
            ReceivableDetail_StudentDAO dt = new ReceivableDetail_StudentDAO();
            ReceivableDetailDAO dc = new ReceivableDetailDAO();
            List<ReceivableDetail_Student> a = new List<ReceivableDetail_Student>();
            List<ReceivableDetail> b = new List<ReceivableDetail>();
            a = dt.ListReceivableDetail_Student(ClassStudentDAO.StudentID);
            foreach (var i in a)
            {
                ReceivableDetail c = new ReceivableDetail();
                c = dc.ReceivableDetaiByStudenID(i.ReceivableDetailID, ReceivableIDAO.ReceivableID);
                if (c!=null)
                {
                    b.Add(c);
                }
                
            }
            grcDanhSachKhoanThu.DataSource = b;
        }
        public void checkKhoathu()
        {
            ReceivableDetail_StudentDAO dt = new ReceivableDetail_StudentDAO();
            List<ReceivableDetail_Student> a = new List<ReceivableDetail_Student>();
            a = dt.ListReceivableDetail_Student(ClassStudentDAO.StudentID);
            foreach (var i in a)
            {
                //bool b = (bool)i.Status;
                for (int j = 0; j < grDanhSachKhoanThu.RowCount; j++)
                {
                    if ((int)grDanhSachKhoanThu.GetRowCellValue(j, grDanhSachKhoanThu.Columns["ReceivableDetailID"])==(int)i.ReceivableDetailID)
                    {
                        grDanhSachKhoanThu.SetRowCellValue(j, "Status", (bool)i.Status);
                    }
                }
            }
        }
        public void loatGrKhoanPhi()
        {
            decimal a = 0;
            decimal b=0;
            for (int i = 0; i < grDanhSachKhoanThu.RowCount; i++)
            {
                try
                {
                    if (grDanhSachKhoanThu.GetRowCellValue(i, grDanhSachKhoanThu.Columns["Status"]).ToString() == "True")
                    {
                        a += (decimal)grDanhSachKhoanThu.GetRowCellValue(i, grDanhSachKhoanThu.Columns["miengiam"]);
                    }
                    b += (decimal)grDanhSachKhoanThu.GetRowCellValue(i, grDanhSachKhoanThu.Columns["miengiam"]);
                }
                catch 
                {

                   
                }
            }
            txtDathanhtoan.Text = a.ToString();
            txtTongSo.Text = b.ToString();
            txtConlai.Text = (b - a).ToString();          
        }
        public void loadStuden()
        {
            try
            {
                ClassStudentDAO dt = new ClassStudentDAO();
                Student a = new Student();
                a = dt.lookForStuden(ClassStudentDAO.StudentID);
                txtHoten.Text = a.FirstName + a.LastName;
                txtNgaySinh.Text = a.Birthday.ToShortDateString();
                txtDiachi.Text = a.AdressDetail;
                MemoryStream mom = new MemoryStream(a.Image.ToArray());
                Image img = Image.FromStream(mom);
                pcAnhhocsinh.Image = img;
            }
            catch 
            {

               
            }
        }
        private void FrThanhToan_Load(object sender, EventArgs e)
        {
            loadStuden();
            LoadKhoanPhi();
            checkKhoathu();
            loatGrKhoanPhi();
            if (txtConlai.Text == "0")
            {
                bntLuu.Enabled = false;
            }

        }
        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {           
            string b = grDanhSachKhoanThu.GetRowCellValue(grDanhSachKhoanThu.FocusedRowHandle, grDanhSachKhoanThu.Columns["Status"]).ToString();
            if (b=="True")
            {
                grDanhSachKhoanThu.SetRowCellValue(e.RowHandle, "Status", false);
            }
            else
            {
                grDanhSachKhoanThu.SetRowCellValue(e.RowHandle, "Status", true);
            }
            if ((bool)grDanhSachKhoanThu.GetRowCellValue(grDanhSachKhoanThu.FocusedRowHandle,grDanhSachKhoanThu.Columns["Status"])==true)
            {
                txtDathanhtoan.Text = (decimal.Parse(txtDathanhtoan.Text) + (decimal)grDanhSachKhoanThu.GetRowCellValue(grDanhSachKhoanThu.FocusedRowHandle, grDanhSachKhoanThu.Columns["TotalPriceDetail"])).ToString();
            }
            else
            {
                txtDathanhtoan.Text = (decimal.Parse(txtDathanhtoan.Text) - (decimal)grDanhSachKhoanThu.GetRowCellValue(grDanhSachKhoanThu.FocusedRowHandle, grDanhSachKhoanThu.Columns["TotalPriceDetail"])).ToString();
            }
          
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ReceivableDetail_StudentDAO dt = new ReceivableDetail_StudentDAO();
                ReceivableIDAO dc = new ReceivableIDAO();
                for (int i = 0; i < grDanhSachKhoanThu.RowCount; i++)
                {
                    ReceivableDetail_Student a = new ReceivableDetail_Student();
                    a.ReceivableDetailID = (int)grDanhSachKhoanThu.GetRowCellValue(i, grDanhSachKhoanThu.Columns["ReceivableDetailID"]);
                    a.StudentID = ClassStudentDAO.StudentID;
                    a.Status = (bool)grDanhSachKhoanThu.GetRowCellValue(i, grDanhSachKhoanThu.Columns["Status"]);
                    if (dt.Edit(a)==true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Bản ghi thứ " + i + " Chưa được lưu");
                    }
                    
                }
                MessageBox.Show("Lưu thành công");
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Lỗi");
                
            }
        }

        private void danhSáchMiễnGiảmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRViewDoituongchinhsach a = new FRViewDoituongchinhsach();
            a.ShowDialog();
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                studentReceivableDAO.PreferredID = grDanhSachKhoanThu.GetRowCellValue(e.FocusedRowHandle, "PreferredID").ToString();
            }
            catch 
            {

                
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            studentReceivableDAO dt = new studentReceivableDAO();
            PreferredDAO dc = new PreferredDAO();
            int rowindex = e.ListSourceRowIndex;
            decimal a = 0;
            if (e.Column.FieldName != "miengiam") return;
            int? perferredID = dt.lookforPreferredID(ClassStudentDAO.StudentID);
            if (perferredID==null)
            {
                e.Value = 0;
            }
            List<string> b = new List<string>();
            string mg = grDanhSachKhoanThu.GetListSourceRowCellValue(rowindex, "PreferredID").ToString();
            decimal f =Convert.ToDecimal(grDanhSachKhoanThu.GetListSourceRowCellValue(rowindex, "TotalPriceDetail"));
            for (int i = 0; i < (mg.Length- 1); i += 2)
            {

                string c = mg.Substring(i, 1);
                b.Add(c);
            }
            if (b.Count==0)
            {
                e.Value = f;
            }
            else
            {
                foreach (var i in b)
                {
                    if (int.Parse(i) == perferredID)
                    {
                        float pr = dc.lookPreferredPercent(int.Parse(i));
                        a = f - ((f * (decimal)pr) / 100);
                        e.Value = a;
                        break;
                    }
                    e.Value = f;
                }
            }
            
            
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 0)
            {
                e.Appearance.BackColor = Color.FromArgb(245, 245, 245);
            }
        }
    }
}