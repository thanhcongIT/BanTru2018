namespace QLHSBanTru2018_Demo_V1.TienBao
{
    partial class frmHealthProblem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHealthProblem));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dgvHealthProblem = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHealthProblemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStudentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiagnosed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServerity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtFillStartDate = new DevExpress.XtraEditors.DateEdit();
            this.txtFillEndDate = new DevExpress.XtraEditors.DateEdit();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHealthProblem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFillStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFillStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFillEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFillEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dgvHealthProblem);
            this.layoutControl1.Controls.Add(this.dtFillStartDate);
            this.layoutControl1.Controls.Add(this.txtFillEndDate);
            this.layoutControl1.Controls.Add(this.btnXem);
            this.layoutControl1.Controls.Add(this.btnThem);
            this.layoutControl1.Controls.Add(this.btnCapNhat);
            this.layoutControl1.Controls.Add(this.btnXoa);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(718, 219, 650, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1045, 527);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dgvHealthProblem
            // 
            this.dgvHealthProblem.Location = new System.Drawing.Point(219, 38);
            this.dgvHealthProblem.MainView = this.gridView1;
            this.dgvHealthProblem.Name = "dgvHealthProblem";
            this.dgvHealthProblem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.dgvHealthProblem.Size = new System.Drawing.Size(814, 477);
            this.dgvHealthProblem.TabIndex = 78;
            this.dgvHealthProblem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHealthProblemID,
            this.colStartDate,
            this.colStudentCode,
            this.colFullName,
            this.colClassName,
            this.colSignal,
            this.colDiagnosed,
            this.colMeasure,
            this.colServerity,
            this.colEmployee,
            this.gridColumn1});
            this.gridView1.GridControl = this.dgvHealthProblem;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colHealthProblemID
            // 
            this.colHealthProblemID.AppearanceCell.Options.UseTextOptions = true;
            this.colHealthProblemID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHealthProblemID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHealthProblemID.AppearanceHeader.Options.UseFont = true;
            this.colHealthProblemID.AppearanceHeader.Options.UseTextOptions = true;
            this.colHealthProblemID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHealthProblemID.Caption = "Mã sự cố";
            this.colHealthProblemID.FieldName = "HealthProblemID";
            this.colHealthProblemID.Name = "colHealthProblemID";
            this.colHealthProblemID.OptionsColumn.AllowEdit = false;
            this.colHealthProblemID.Visible = true;
            this.colHealthProblemID.VisibleIndex = 0;
            this.colHealthProblemID.Width = 56;
            // 
            // colStartDate
            // 
            this.colStartDate.AppearanceCell.Options.UseTextOptions = true;
            this.colStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStartDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStartDate.AppearanceHeader.Options.UseFont = true;
            this.colStartDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colStartDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStartDate.Caption = "Ngày xảy ra sự cố";
            this.colStartDate.DisplayFormat.FormatString = "dd/mm/yyyy hh:mm tt";
            this.colStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.OptionsColumn.AllowEdit = false;
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 1;
            this.colStartDate.Width = 110;
            // 
            // colStudentCode
            // 
            this.colStudentCode.AppearanceCell.Options.UseTextOptions = true;
            this.colStudentCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStudentCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStudentCode.AppearanceHeader.Options.UseFont = true;
            this.colStudentCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colStudentCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStudentCode.Caption = "Mã học sinh";
            this.colStudentCode.FieldName = "StudentCode";
            this.colStudentCode.Name = "colStudentCode";
            this.colStudentCode.OptionsColumn.AllowEdit = false;
            this.colStudentCode.Visible = true;
            this.colStudentCode.VisibleIndex = 2;
            this.colStudentCode.Width = 98;
            // 
            // colFullName
            // 
            this.colFullName.AppearanceCell.Options.UseTextOptions = true;
            this.colFullName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFullName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colFullName.AppearanceHeader.Options.UseFont = true;
            this.colFullName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFullName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFullName.Caption = "Họ và tên";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.AllowEdit = false;
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 3;
            this.colFullName.Width = 103;
            // 
            // colClassName
            // 
            this.colClassName.AppearanceCell.Options.UseTextOptions = true;
            this.colClassName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colClassName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colClassName.AppearanceHeader.Options.UseFont = true;
            this.colClassName.AppearanceHeader.Options.UseTextOptions = true;
            this.colClassName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colClassName.Caption = "Lớp";
            this.colClassName.FieldName = "ClassName";
            this.colClassName.Name = "colClassName";
            this.colClassName.OptionsColumn.AllowEdit = false;
            this.colClassName.Visible = true;
            this.colClassName.VisibleIndex = 4;
            this.colClassName.Width = 57;
            // 
            // colSignal
            // 
            this.colSignal.AppearanceCell.Options.UseTextOptions = true;
            this.colSignal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSignal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSignal.AppearanceHeader.Options.UseFont = true;
            this.colSignal.AppearanceHeader.Options.UseTextOptions = true;
            this.colSignal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSignal.Caption = "Hiện tượng";
            this.colSignal.FieldName = "Signal";
            this.colSignal.Name = "colSignal";
            this.colSignal.OptionsColumn.AllowEdit = false;
            this.colSignal.Visible = true;
            this.colSignal.VisibleIndex = 5;
            this.colSignal.Width = 109;
            // 
            // colDiagnosed
            // 
            this.colDiagnosed.AppearanceCell.Options.UseTextOptions = true;
            this.colDiagnosed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiagnosed.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDiagnosed.AppearanceHeader.Options.UseFont = true;
            this.colDiagnosed.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiagnosed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiagnosed.Caption = "Loại sự cố";
            this.colDiagnosed.FieldName = "Diagnosed";
            this.colDiagnosed.Name = "colDiagnosed";
            this.colDiagnosed.OptionsColumn.AllowEdit = false;
            this.colDiagnosed.Visible = true;
            this.colDiagnosed.VisibleIndex = 6;
            this.colDiagnosed.Width = 103;
            // 
            // colMeasure
            // 
            this.colMeasure.AppearanceCell.Options.UseTextOptions = true;
            this.colMeasure.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMeasure.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMeasure.AppearanceHeader.Options.UseFont = true;
            this.colMeasure.AppearanceHeader.Options.UseTextOptions = true;
            this.colMeasure.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMeasure.Caption = "Biện pháp xử lý";
            this.colMeasure.FieldName = "Measure";
            this.colMeasure.Name = "colMeasure";
            this.colMeasure.OptionsColumn.AllowEdit = false;
            this.colMeasure.Visible = true;
            this.colMeasure.VisibleIndex = 7;
            this.colMeasure.Width = 99;
            // 
            // colServerity
            // 
            this.colServerity.AppearanceCell.Options.UseTextOptions = true;
            this.colServerity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colServerity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colServerity.AppearanceHeader.Options.UseFont = true;
            this.colServerity.AppearanceHeader.Options.UseTextOptions = true;
            this.colServerity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colServerity.Caption = "Mức độ nghiêm trọng";
            this.colServerity.FieldName = "Serverity";
            this.colServerity.Name = "colServerity";
            this.colServerity.OptionsColumn.AllowEdit = false;
            this.colServerity.Visible = true;
            this.colServerity.VisibleIndex = 8;
            this.colServerity.Width = 91;
            // 
            // colEmployee
            // 
            this.colEmployee.AppearanceCell.Options.UseTextOptions = true;
            this.colEmployee.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmployee.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colEmployee.AppearanceHeader.Options.UseFont = true;
            this.colEmployee.AppearanceHeader.Options.UseTextOptions = true;
            this.colEmployee.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmployee.Caption = "Người xử lý";
            this.colEmployee.FieldName = "EmployeeName";
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.OptionsColumn.AllowEdit = false;
            this.colEmployee.Visible = true;
            this.colEmployee.VisibleIndex = 9;
            this.colEmployee.Width = 120;
            // 
            // dtFillStartDate
            // 
            this.dtFillStartDate.EditValue = null;
            this.dtFillStartDate.Location = new System.Drawing.Point(74, 42);
            this.dtFillStartDate.Name = "dtFillStartDate";
            this.dtFillStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFillStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFillStartDate.Size = new System.Drawing.Size(129, 20);
            this.dtFillStartDate.StyleController = this.layoutControl1;
            this.dtFillStartDate.TabIndex = 13;
            // 
            // txtFillEndDate
            // 
            this.txtFillEndDate.EditValue = null;
            this.txtFillEndDate.Location = new System.Drawing.Point(74, 66);
            this.txtFillEndDate.Name = "txtFillEndDate";
            this.txtFillEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFillEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFillEndDate.Size = new System.Drawing.Size(129, 20);
            this.txtFillEndDate.StyleController = this.layoutControl1;
            this.txtFillEndDate.TabIndex = 14;
            // 
            // btnXem
            // 
            this.btnXem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXem.ImageOptions.Image")));
            this.btnXem.Location = new System.Drawing.Point(24, 90);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(179, 22);
            this.btnXem.StyleController = this.layoutControl1;
            this.btnXem.TabIndex = 77;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnThem
            // 
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.Location = new System.Drawing.Point(219, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(126, 22);
            this.btnThem.StyleController = this.layoutControl1;
            this.btnThem.TabIndex = 74;
            this.btnThem.Text = "Thêm sự cố";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.ImageOptions.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(349, 12);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(119, 22);
            this.btnCapNhat.StyleController = this.layoutControl1;
            this.btnCapNhat.TabIndex = 75;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(472, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(105, 22);
            this.btnXoa.StyleController = this.layoutControl1;
            this.btnXoa.TabIndex = 76;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem13,
            this.layoutControlGroup4,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1045, 527);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dgvHealthProblem;
            this.layoutControlItem2.Location = new System.Drawing.Point(207, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(818, 481);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.btnThem;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new System.Drawing.Point(207, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(130, 26);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "Lọc Thông Tin";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem6,
            this.layoutControlItem1});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(207, 507);
            this.layoutControlGroup4.Text = "Thời gian sự cố";
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.dtFillStartDate;
            this.layoutControlItem9.CustomizationFormText = "Lọc từ ngày";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(183, 24);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(183, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(183, 24);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "Từ ngày";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(47, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtFillEndDate;
            this.layoutControlItem6.CustomizationFormText = "Lọc đến ngày";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(183, 24);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(183, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(183, 24);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Đến ngày";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(47, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnXem;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(183, 417);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.btnCapNhat;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
            this.layoutControlItem14.Location = new System.Drawing.Point(337, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(123, 26);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.btnXoa;
            this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem15.Location = new System.Drawing.Point(460, 0);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(109, 26);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(569, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(456, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Cập nhật";
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 10;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnUpdate_ButtonClick);
            // 
            // frmHealthProblem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmHealthProblem";
            this.Size = new System.Drawing.Size(1045, 527);
            this.Load += new System.EventHandler(this.frmHealthProblem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHealthProblem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFillStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFillStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFillEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFillEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl dgvHealthProblem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colHealthProblemID;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStudentCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colSignal;
        private DevExpress.XtraGrid.Columns.GridColumn colDiagnosed;
        private DevExpress.XtraGrid.Columns.GridColumn colMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn colServerity;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployee;
        private DevExpress.XtraEditors.DateEdit dtFillStartDate;
        private DevExpress.XtraEditors.DateEdit txtFillEndDate;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}
