namespace Bai4_7_MdiApplication
{
    partial class FormProduct
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpInput = new GroupBox();
            txtQuantity = new TextBox();
            lblQuantity = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            cboCategory = new ComboBox();
            lblCategory = new Label();
            txtProductName = new TextBox();
            lblProductName = new Label();
            txtProductId = new TextBox();
            lblProductId = new Label();
            pnlButtons = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            grpList = new GroupBox();
            dgvProducts = new DataGridView();
            grpInput.SuspendLayout();
            pnlButtons.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Controls.Add(txtQuantity);
            grpInput.Controls.Add(lblQuantity);
            grpInput.Controls.Add(txtPrice);
            grpInput.Controls.Add(lblPrice);
            grpInput.Controls.Add(cboCategory);
            grpInput.Controls.Add(lblCategory);
            grpInput.Controls.Add(txtProductName);
            grpInput.Controls.Add(lblProductName);
            grpInput.Controls.Add(txtProductId);
            grpInput.Controls.Add(lblProductId);
            grpInput.Location = new Point(15, 15);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(330, 240);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin sản phẩm";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(110, 190);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(200, 27);
            txtQuantity.TabIndex = 9;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(15, 193);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(72, 20);
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "Số lượng:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(110, 150);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 27);
            txtPrice.TabIndex = 7;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(15, 153);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(65, 20);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Đơn giá:";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(110, 110);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(200, 28);
            cboCategory.TabIndex = 5;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(15, 113);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 20);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Danh mục:";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(110, 70);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(200, 27);
            txtProductName.TabIndex = 3;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(15, 73);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(103, 20);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Tên sản phẩm:";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(110, 30);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(200, 27);
            txtProductId.TabIndex = 1;
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(15, 33);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(101, 20);
            lblProductId.TabIndex = 0;
            lblProductId.Text = "Mã sản phẩm:";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Location = new Point(15, 270);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(330, 95);
            pnlButtons.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(170, 50);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(140, 34);
            btnClear.TabIndex = 3;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(15, 50);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(170, 8);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 34);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(15, 8);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(140, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // grpList
            // 
            grpList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpList.Controls.Add(dgvProducts);
            grpList.Location = new Point(360, 15);
            grpList.Name = "grpList";
            grpList.Size = new Size(540, 420);
            grpList.TabIndex = 2;
            grpList.TabStop = false;
            grpList.Text = "Danh sách sản phẩm";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(3, 23);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 35;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(534, 394);
            dgvProducts.TabIndex = 0;
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 450);
            Controls.Add(grpList);
            Controls.Add(pnlButtons);
            Controls.Add(grpInput);
            MinimumSize = new Size(820, 420);
            Name = "FormProduct";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Sản phẩm (MDI Child)";
            Load += FormProduct_Load;
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            pnlButtons.ResumeLayout(false);
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInput;
        private Label lblProductId;
        private TextBox txtProductId;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Panel pnlButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private GroupBox grpList;
        private DataGridView dgvProducts;
    }
}
