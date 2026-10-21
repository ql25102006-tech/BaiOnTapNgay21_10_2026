namespace Bai4_8_AsyncProgressBar
{
    partial class FormAsyncDataLoader
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
            pnlTop = new Panel();
            lblStatus = new Label();
            lblPercent = new Label();
            progressBar1 = new ProgressBar();
            btnCancel = new Button();
            btnLoadAsync = new Button();
            grpGrid = new GroupBox();
            dgvStudents = new DataGridView();
            pnlTop.SuspendLayout();
            grpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BorderStyle = BorderStyle.FixedSingle;
            pnlTop.Controls.Add(lblStatus);
            pnlTop.Controls.Add(lblPercent);
            pnlTop.Controls.Add(progressBar1);
            pnlTop.Controls.Add(btnCancel);
            pnlTop.Controls.Add(btnLoadAsync);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(882, 115);
            pnlTop.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(20, 75);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(205, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Trạng thái: Sẵn sàng nạp dữ liệu";
            // 
            // lblPercent
            // 
            lblPercent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPercent.AutoSize = true;
            lblPercent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPercent.Location = new Point(810, 30);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(31, 20);
            lblPercent.TabIndex = 3;
            lblPercent.Text = "0%";
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(340, 25);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(450, 30);
            progressBar1.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(220, 23);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Hủy tác vụ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLoadAsync
            // 
            btnLoadAsync.Location = new Point(20, 23);
            btnLoadAsync.Name = "btnLoadAsync";
            btnLoadAsync.Size = new Size(185, 35);
            btnLoadAsync.TabIndex = 0;
            btnLoadAsync.Text = "Nạp dữ liệu (Async/Await)";
            btnLoadAsync.UseVisualStyleBackColor = true;
            btnLoadAsync.Click += btnLoadAsync_Click;
            // 
            // grpGrid
            // 
            grpGrid.Controls.Add(dgvStudents);
            grpGrid.Dock = DockStyle.Fill;
            grpGrid.Location = new Point(0, 115);
            grpGrid.Name = "grpGrid";
            grpGrid.Padding = new Padding(10);
            grpGrid.Size = new Size(882, 378);
            grpGrid.TabIndex = 1;
            grpGrid.TabStop = false;
            grpGrid.Text = "Kết quả dữ liệu sinh viên sau khi nạp bất đồng bộ";
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.Location = new Point(10, 30);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersWidth = 35;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(862, 338);
            dgvStudents.TabIndex = 0;
            // 
            // FormAsyncDataLoader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 493);
            Controls.Add(grpGrid);
            Controls.Add(pnlTop);
            MinimumSize = new Size(800, 400);
            Name = "FormAsyncDataLoader";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nạp dữ liệu lớn Bất đồng bộ (Async/Await & IProgress)";
            FormClosing += FormAsyncDataLoader_FormClosing;
            Load += FormAsyncDataLoader_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            grpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Button btnLoadAsync;
        private Button btnCancel;
        private ProgressBar progressBar1;
        private Label lblPercent;
        private Label lblStatus;
        private GroupBox grpGrid;
        private DataGridView dgvStudents;
    }
}
