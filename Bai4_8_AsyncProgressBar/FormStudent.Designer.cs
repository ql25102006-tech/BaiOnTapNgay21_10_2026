namespace Bai4_8_AsyncProgressBar
{
    partial class FormStudent
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
            components = new System.ComponentModel.Container();
            grpInput = new GroupBox();
            btnChooseAvatar = new Button();
            picAvatar = new PictureBox();
            lblAvatar = new Label();
            cboGender = new ComboBox();
            lblGender = new Label();
            txtAge = new TextBox();
            lblAge = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtStudentId = new TextBox();
            lblStudentId = new Label();
            pnlButtons = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            grpList = new GroupBox();
            dgvStudents = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlButtons.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Controls.Add(btnChooseAvatar);
            grpInput.Controls.Add(picAvatar);
            grpInput.Controls.Add(lblAvatar);
            grpInput.Controls.Add(cboGender);
            grpInput.Controls.Add(lblGender);
            grpInput.Controls.Add(txtAge);
            grpInput.Controls.Add(lblAge);
            grpInput.Controls.Add(txtFullName);
            grpInput.Controls.Add(lblFullName);
            grpInput.Controls.Add(txtStudentId);
            grpInput.Controls.Add(lblStudentId);
            grpInput.Location = new Point(15, 15);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(330, 310);
            grpInput.TabIndex = 0;
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin sinh viên";
            // 
            // btnChooseAvatar
            // 
            btnChooseAvatar.Location = new Point(210, 245);
            btnChooseAvatar.Name = "btnChooseAvatar";
            btnChooseAvatar.Size = new Size(100, 32);
            btnChooseAvatar.TabIndex = 10;
            btnChooseAvatar.Text = "Chọn ảnh...";
            btnChooseAvatar.UseVisualStyleBackColor = true;
            btnChooseAvatar.Click += btnChooseAvatar_Click;
            // 
            // picAvatar
            // 
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(100, 195);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(95, 95);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 9;
            picAvatar.TabStop = false;
            // 
            // lblAvatar
            // 
            lblAvatar.AutoSize = true;
            lblAvatar.Location = new Point(15, 205);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(55, 20);
            lblAvatar.TabIndex = 8;
            lblAvatar.Text = "Avatar:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(100, 150);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(210, 28);
            cboGender.TabIndex = 7;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(15, 153);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(68, 20);
            lblGender.TabIndex = 6;
            lblGender.Text = "Giới tính:";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(100, 110);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(210, 27);
            txtAge.TabIndex = 5;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(15, 113);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(41, 20);
            lblAge.TabIndex = 4;
            lblAge.Text = "Tuổi:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(100, 70);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(210, 27);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(15, 73);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(57, 20);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ tên:";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(100, 30);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(210, 27);
            txtStudentId.TabIndex = 1;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(15, 33);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(54, 20);
            lblStudentId.TabIndex = 0;
            lblStudentId.Text = "Mã SV:";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Location = new Point(15, 335);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(330, 95);
            pnlButtons.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(170, 50);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(145, 34);
            btnClear.TabIndex = 3;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(10, 50);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(170, 8);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(145, 34);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(10, 8);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // grpList
            // 
            grpList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpList.Controls.Add(dgvStudents);
            grpList.Location = new Point(360, 15);
            grpList.Name = "grpList";
            grpList.Size = new Size(540, 415);
            grpList.TabIndex = 2;
            grpList.TabStop = false;
            grpList.Text = "Danh sách sinh viên";
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.Location = new Point(3, 23);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersWidth = 35;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(534, 389);
            dgvStudents.TabIndex = 0;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FormStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 445);
            Controls.Add(grpList);
            Controls.Add(pnlButtons);
            Controls.Add(grpInput);
            MinimumSize = new Size(820, 420);
            Name = "FormStudent";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Sinh viên (MDI Child)";
            Load += FormStudent_Load;
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlButtons.ResumeLayout(false);
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInput;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblAge;
        private TextBox txtAge;
        private Label lblGender;
        private ComboBox cboGender;
        private Label lblAvatar;
        private PictureBox picAvatar;
        private Button btnChooseAvatar;
        private Panel pnlButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private GroupBox grpList;
        private DataGridView dgvStudents;
        private ErrorProvider errorProvider1;
    }
}
