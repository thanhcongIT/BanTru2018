namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Function
{
    partial class frmFunctionList
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
            this.gcFunctionList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFunctionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcFunctionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcFunctionList
            // 
            this.gcFunctionList.Location = new System.Drawing.Point(12, 12);
            this.gcFunctionList.MainView = this.gridView1;
            this.gcFunctionList.Name = "gcFunctionList";
            this.gcFunctionList.Size = new System.Drawing.Size(383, 407);
            this.gcFunctionList.TabIndex = 0;
            this.gcFunctionList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colGroupName,
            this.colFunctionName,
            this.colNote});
            this.gridView1.GridControl = this.gcFunctionList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "FunctionID";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 80;
            // 
            // colGroupName
            // 
            this.colGroupName.Caption = "Nhóm Chức Năng";
            this.colGroupName.FieldName = "FunctionGroupName";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.Visible = true;
            this.colGroupName.VisibleIndex = 1;
            this.colGroupName.Width = 216;
            // 
            // colFunctionName
            // 
            this.colFunctionName.Caption = "Tên Chức Năng";
            this.colFunctionName.FieldName = "FunctionName";
            this.colFunctionName.Name = "colFunctionName";
            this.colFunctionName.Visible = true;
            this.colFunctionName.VisibleIndex = 2;
            this.colFunctionName.Width = 178;
            // 
            // colNote
            // 
            this.colNote.Caption = "Ghi Chú";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 3;
            this.colNote.Width = 545;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(401, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmFunctionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 431);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gcFunctionList);
            this.Name = "frmFunctionList";
            this.Text = "Chức Năng";
            this.Load += new System.EventHandler(this.frmFunctionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcFunctionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcFunctionList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colFunctionName;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
    }
}