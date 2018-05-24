namespace QLHSBanTru2018_Demo_V1.HungTD.Form.DailyTracker
{
    partial class frmListDrugTime
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnChangeStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStudentFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStudentHomeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDrugName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDrugTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDrugQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeRemaining = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStringStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtNote);
            this.layoutControl1.Controls.Add(this.comboBox1);
            this.layoutControl1.Controls.Add(this.gcMain);
            this.layoutControl1.Controls.Add(this.checkEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(630, 427);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(12, 348);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(606, 67);
            this.txtNote.TabIndex = 7;
            this.txtNote.Text = "ABCDEFG";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(131, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(229, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // gcMain
            // 
            this.gcMain.ContextMenuStrip = this.contextMenuStrip1;
            this.gcMain.Location = new System.Drawing.Point(12, 37);
            this.gcMain.MainView = this.gridView1;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(606, 291);
            this.gcMain.TabIndex = 4;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChangeStatus,
            this.btnDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 48);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(157, 22);
            this.btnChangeStatus.Text = "Đã Uống Thuốc";
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(157, 22);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Bisque;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStudentFullName,
            this.colStudentHomeName,
            this.colDrugName,
            this.colDrugTime,
            this.colDrugQuantity,
            this.colTimeRemaining,
            this.colStringStatus});
            this.gridView1.GridControl = this.gcMain;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colStudentFullName
            // 
            this.colStudentFullName.Caption = "Họ Và Tên";
            this.colStudentFullName.FieldName = "StudentFullName";
            this.colStudentFullName.MaxWidth = 220;
            this.colStudentFullName.MinWidth = 150;
            this.colStudentFullName.Name = "colStudentFullName";
            this.colStudentFullName.Visible = true;
            this.colStudentFullName.VisibleIndex = 0;
            this.colStudentFullName.Width = 180;
            // 
            // colStudentHomeName
            // 
            this.colStudentHomeName.AppearanceCell.Options.UseTextOptions = true;
            this.colStudentHomeName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStudentHomeName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStudentHomeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colStudentHomeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStudentHomeName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStudentHomeName.Caption = "Biệt Danh";
            this.colStudentHomeName.FieldName = "StudentHomeName";
            this.colStudentHomeName.MaxWidth = 60;
            this.colStudentHomeName.MinWidth = 60;
            this.colStudentHomeName.Name = "colStudentHomeName";
            this.colStudentHomeName.Visible = true;
            this.colStudentHomeName.VisibleIndex = 1;
            this.colStudentHomeName.Width = 60;
            // 
            // colDrugName
            // 
            this.colDrugName.AppearanceCell.Options.UseTextOptions = true;
            this.colDrugName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDrugName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDrugName.AppearanceHeader.Options.UseTextOptions = true;
            this.colDrugName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDrugName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDrugName.Caption = "Tên Thuốc";
            this.colDrugName.FieldName = "DrugName";
            this.colDrugName.MaxWidth = 160;
            this.colDrugName.MinWidth = 90;
            this.colDrugName.Name = "colDrugName";
            this.colDrugName.Visible = true;
            this.colDrugName.VisibleIndex = 2;
            this.colDrugName.Width = 90;
            // 
            // colDrugTime
            // 
            this.colDrugTime.AppearanceCell.Options.UseTextOptions = true;
            this.colDrugTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDrugTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDrugTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colDrugTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDrugTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDrugTime.Caption = "Thời Gian";
            this.colDrugTime.DisplayFormat.FormatString = "hh\\:mm";
            this.colDrugTime.FieldName = "DrugTime";
            this.colDrugTime.MaxWidth = 60;
            this.colDrugTime.MinWidth = 60;
            this.colDrugTime.Name = "colDrugTime";
            this.colDrugTime.Visible = true;
            this.colDrugTime.VisibleIndex = 4;
            this.colDrugTime.Width = 60;
            // 
            // colDrugQuantity
            // 
            this.colDrugQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colDrugQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDrugQuantity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDrugQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colDrugQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDrugQuantity.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDrugQuantity.Caption = "SL";
            this.colDrugQuantity.FieldName = "DrugQuantity";
            this.colDrugQuantity.MaxWidth = 40;
            this.colDrugQuantity.MinWidth = 40;
            this.colDrugQuantity.Name = "colDrugQuantity";
            this.colDrugQuantity.Visible = true;
            this.colDrugQuantity.VisibleIndex = 3;
            this.colDrugQuantity.Width = 40;
            // 
            // colTimeRemaining
            // 
            this.colTimeRemaining.AppearanceCell.Options.UseTextOptions = true;
            this.colTimeRemaining.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTimeRemaining.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTimeRemaining.AppearanceHeader.Options.UseTextOptions = true;
            this.colTimeRemaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTimeRemaining.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTimeRemaining.Caption = "Còn Lại";
            this.colTimeRemaining.DisplayFormat.FormatString = "hh\\:mm";
            this.colTimeRemaining.FieldName = "RemainingTime";
            this.colTimeRemaining.MaxWidth = 60;
            this.colTimeRemaining.MinWidth = 60;
            this.colTimeRemaining.Name = "colTimeRemaining";
            this.colTimeRemaining.Visible = true;
            this.colTimeRemaining.VisibleIndex = 5;
            this.colTimeRemaining.Width = 60;
            // 
            // colStringStatus
            // 
            this.colStringStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStringStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStringStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStringStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStringStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStringStatus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStringStatus.Caption = "Tình Trạng";
            this.colStringStatus.FieldName = "StringStatus";
            this.colStringStatus.MaxWidth = 110;
            this.colStringStatus.MinWidth = 110;
            this.colStringStatus.Name = "colStringStatus";
            this.colStringStatus.Visible = true;
            this.colStringStatus.VisibleIndex = 6;
            this.colStringStatus.Width = 110;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(483, 12);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Có";
            this.checkEdit1.Size = new System.Drawing.Size(135, 19);
            this.checkEdit1.StyleController = this.layoutControl1;
            this.checkEdit1.TabIndex = 6;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(630, 427);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcMain;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(610, 295);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.comboBox1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(352, 25);
            this.layoutControlItem2.Text = "Tiêu Chí Sắp Xếp:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(116, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.checkEdit1;
            this.layoutControlItem3.Location = new System.Drawing.Point(352, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(258, 25);
            this.layoutControlItem3.Text = "Hiển Thị Lời Nhắc Trước:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(116, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtNote;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 320);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(610, 87);
            this.layoutControlItem4.Text = "Ghi Chú:";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(116, 13);
            // 
            // frmListDrugTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 427);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmListDrugTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmListDrugTime";
            this.Load += new System.EventHandler(this.frmListDrugTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.TextBox txtNote;
        private DevExpress.XtraGrid.Columns.GridColumn colStudentFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colStudentHomeName;
        private DevExpress.XtraGrid.Columns.GridColumn colDrugName;
        private DevExpress.XtraGrid.Columns.GridColumn colDrugTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDrugQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colStringStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeRemaining;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnChangeStatus;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
    }
}