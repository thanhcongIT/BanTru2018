namespace QLHSBanTru2018_Demo_V1.HungTD.Form.Position
{
    partial class frmPositionList
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement7 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement8 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement9 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement10 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement11 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPositionList));
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.colLayoutLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirtName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEmployee = new DevExpress.XtraGrid.GridControl();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.txtName = new System.Windows.Forms.MaskedTextBox();
            this.txtPositionID = new System.Windows.Forms.MaskedTextBox();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.pcMenu = new DevExpress.XtraEditors.PanelControl();
            this.colLayoutLocation = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colLayoutPosition = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colLayoutEmail = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colLayoutPhone = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colLayoutFullName = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colLayoutPhoto = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.pcLeft = new DevExpress.XtraEditors.PanelControl();
            this.gcPositionList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMenu)).BeginInit();
            this.pcMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcLeft)).BeginInit();
            this.pcLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPositionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cardView1
            // 
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLayoutLastName,
            this.colFirtName});
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.gcEmployee;
            this.cardView1.Name = "cardView1";
            this.cardView1.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            // 
            // colLayoutLastName
            // 
            this.colLayoutLastName.FieldName = "LastName";
            this.colLayoutLastName.Name = "colLayoutLastName";
            this.colLayoutLastName.Visible = true;
            this.colLayoutLastName.VisibleIndex = 0;
            // 
            // colFirtName
            // 
            this.colFirtName.FieldName = "LastName";
            this.colFirtName.Name = "colFirtName";
            this.colFirtName.Visible = true;
            this.colFirtName.VisibleIndex = 1;
            // 
            // gcEmployee
            // 
            this.gcEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcEmployee.Location = new System.Drawing.Point(484, 30);
            this.gcEmployee.MainView = this.tileView1;
            this.gcEmployee.Name = "gcEmployee";
            this.gcEmployee.Size = new System.Drawing.Size(319, 523);
            this.gcEmployee.TabIndex = 7;
            this.gcEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1,
            this.cardView1});
            // 
            // tileView1
            // 
            this.tileView1.GridControl = this.gcEmployee;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(420, 120);
            this.tileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.Kanban;
            this.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileView1.OptionsTiles.RowCount = 0;
            tableColumnDefinition1.Length.Value = 150D;
            tableColumnDefinition2.Length.Value = 302D;
            this.tileView1.TileColumns.Add(tableColumnDefinition1);
            this.tileView1.TileColumns.Add(tableColumnDefinition2);
            tableRowDefinition1.Length.Value = 15D;
            this.tileView1.TileRows.Add(tableRowDefinition1);
            tileViewItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement1.Text = "";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement2.ImageLocation = new System.Drawing.Point(2, 0);
            tileViewItemElement2.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement2.Text = "colLayoutPhoto";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement2.TextLocation = new System.Drawing.Point(2, 0);
            tileViewItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement3.Appearance.Normal.ForeColor = System.Drawing.Color.DodgerBlue;
            tileViewItemElement3.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement3.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement3.ColumnIndex = 1;
            tileViewItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement3.Text = "colLayoutFullName";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement3.TextLocation = new System.Drawing.Point(8, -35);
            tileViewItemElement4.ColumnIndex = 1;
            tileViewItemElement4.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement4.Text = "colLayoutPhone";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement4.TextLocation = new System.Drawing.Point(70, -15);
            tileViewItemElement5.ColumnIndex = 1;
            tileViewItemElement5.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement5.Text = "colLayoutEmail";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement5.TextLocation = new System.Drawing.Point(70, 0);
            tileViewItemElement6.ColumnIndex = 1;
            tileViewItemElement6.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement6.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement6.Text = "Điện thoại:";
            tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement6.TextLocation = new System.Drawing.Point(8, -15);
            tileViewItemElement7.ColumnIndex = 1;
            tileViewItemElement7.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement7.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement7.Text = "Email:";
            tileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement7.TextLocation = new System.Drawing.Point(8, 0);
            tileViewItemElement8.ColumnIndex = 1;
            tileViewItemElement8.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement8.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement8.Text = "Chức vụ:";
            tileViewItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement8.TextLocation = new System.Drawing.Point(8, 15);
            tileViewItemElement9.ColumnIndex = 1;
            tileViewItemElement9.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement9.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement9.Text = "colLayoutPosition";
            tileViewItemElement9.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement9.TextLocation = new System.Drawing.Point(70, 15);
            tileViewItemElement10.ColumnIndex = 1;
            tileViewItemElement10.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement10.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement10.Text = "Địa chỉ:";
            tileViewItemElement10.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement10.TextLocation = new System.Drawing.Point(8, 30);
            tileViewItemElement11.ColumnIndex = 1;
            tileViewItemElement11.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement11.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement11.Text = "colLayoutLocation";
            tileViewItemElement11.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement11.TextLocation = new System.Drawing.Point(70, 30);
            this.tileView1.TileTemplate.Add(tileViewItemElement1);
            this.tileView1.TileTemplate.Add(tileViewItemElement2);
            this.tileView1.TileTemplate.Add(tileViewItemElement3);
            this.tileView1.TileTemplate.Add(tileViewItemElement4);
            this.tileView1.TileTemplate.Add(tileViewItemElement5);
            this.tileView1.TileTemplate.Add(tileViewItemElement6);
            this.tileView1.TileTemplate.Add(tileViewItemElement7);
            this.tileView1.TileTemplate.Add(tileViewItemElement8);
            this.tileView1.TileTemplate.Add(tileViewItemElement9);
            this.tileView1.TileTemplate.Add(tileViewItemElement10);
            this.tileView1.TileTemplate.Add(tileViewItemElement11);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(526, 3);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(122, 21);
            this.txtName.TabIndex = 5;
            // 
            // txtPositionID
            // 
            this.txtPositionID.Location = new System.Drawing.Point(486, 3);
            this.txtPositionID.Name = "txtPositionID";
            this.txtPositionID.ReadOnly = true;
            this.txtPositionID.Size = new System.Drawing.Size(34, 21);
            this.txtPositionID.TabIndex = 6;
            this.txtPositionID.Text = "1";
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnAdd.Location = new System.Drawing.Point(2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 78);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm Mới";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnEdit.Location = new System.Drawing.Point(2, 80);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 78);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Chỉnh Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(2, 158);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 78);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pcMenu
            // 
            this.pcMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pcMenu.Controls.Add(this.btnDelete);
            this.pcMenu.Controls.Add(this.btnEdit);
            this.pcMenu.Controls.Add(this.btnAdd);
            this.pcMenu.Location = new System.Drawing.Point(3, 3);
            this.pcMenu.Name = "pcMenu";
            this.pcMenu.Size = new System.Drawing.Size(79, 552);
            this.pcMenu.TabIndex = 3;
            // 
            // colLayoutLocation
            // 
            this.colLayoutLocation.Caption = "Location";
            this.colLayoutLocation.FieldName = "LocationDetail";
            this.colLayoutLocation.Name = "colLayoutLocation";
            this.colLayoutLocation.Visible = true;
            this.colLayoutLocation.VisibleIndex = 0;
            // 
            // colLayoutPosition
            // 
            this.colLayoutPosition.Caption = "Position";
            this.colLayoutPosition.FieldName = "PositionName";
            this.colLayoutPosition.Name = "colLayoutPosition";
            this.colLayoutPosition.Visible = true;
            this.colLayoutPosition.VisibleIndex = 0;
            // 
            // colLayoutEmail
            // 
            this.colLayoutEmail.Caption = "Email";
            this.colLayoutEmail.FieldName = "Email";
            this.colLayoutEmail.Name = "colLayoutEmail";
            this.colLayoutEmail.Visible = true;
            this.colLayoutEmail.VisibleIndex = 0;
            // 
            // colLayoutPhone
            // 
            this.colLayoutPhone.FieldName = "Phone";
            this.colLayoutPhone.Name = "colLayoutPhone";
            this.colLayoutPhone.Visible = true;
            this.colLayoutPhone.VisibleIndex = 0;
            // 
            // colLayoutFullName
            // 
            this.colLayoutFullName.FieldName = "FullName";
            this.colLayoutFullName.Name = "colLayoutFullName";
            this.colLayoutFullName.Visible = true;
            this.colLayoutFullName.VisibleIndex = 0;
            // 
            // colLayoutPhoto
            // 
            this.colLayoutPhoto.Caption = "Photo";
            this.colLayoutPhoto.FieldName = "Image";
            this.colLayoutPhoto.Name = "colLayoutPhoto";
            this.colLayoutPhoto.Visible = true;
            this.colLayoutPhoto.VisibleIndex = 0;
            // 
            // pcLeft
            // 
            this.pcLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pcLeft.Controls.Add(this.gcPositionList);
            this.pcLeft.Location = new System.Drawing.Point(88, 3);
            this.pcLeft.Name = "pcLeft";
            this.pcLeft.Size = new System.Drawing.Size(392, 552);
            this.pcLeft.TabIndex = 4;
            // 
            // gcPositionList
            // 
            this.gcPositionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPositionList.Location = new System.Drawing.Point(2, 2);
            this.gcPositionList.MainView = this.gridView1;
            this.gcPositionList.Name = "gcPositionList";
            this.gcPositionList.Size = new System.Drawing.Size(388, 548);
            this.gcPositionList.TabIndex = 0;
            this.gcPositionList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colName,
            this.colStatus});
            this.gridView1.GridControl = this.gcPositionList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSTT
            // 
            this.colSTT.AppearanceCell.Options.UseTextOptions = true;
            this.colSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "DepartmentID";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 89;
            // 
            // colName
            // 
            this.colName.Caption = "Tên Chức Vụ";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 404;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatus.Caption = "Tình Trạng";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 199;
            // 
            // frmPositionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPositionID);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.gcEmployee);
            this.Controls.Add(this.pcLeft);
            this.Controls.Add(this.pcMenu);
            this.Name = "frmPositionList";
            this.Size = new System.Drawing.Size(806, 558);
            this.Load += new System.EventHandler(this.frmPositionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMenu)).EndInit();
            this.pcMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcLeft)).EndInit();
            this.pcLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPositionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.GridColumn colLayoutLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colFirtName;
        private DevExpress.XtraGrid.GridControl gcEmployee;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private System.Windows.Forms.MaskedTextBox txtName;
        private System.Windows.Forms.MaskedTextBox txtPositionID;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.PanelControl pcMenu;
        private DevExpress.XtraGrid.Columns.TileViewColumn colLayoutLocation;
        private DevExpress.XtraGrid.Columns.TileViewColumn colLayoutPosition;
        private DevExpress.XtraGrid.Columns.TileViewColumn colLayoutEmail;
        private DevExpress.XtraGrid.Columns.TileViewColumn colLayoutPhone;
        private DevExpress.XtraGrid.Columns.TileViewColumn colLayoutFullName;
        private DevExpress.XtraGrid.Columns.TileViewColumn colLayoutPhoto;
        private DevExpress.XtraEditors.PanelControl pcLeft;
        private DevExpress.XtraGrid.GridControl gcPositionList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
