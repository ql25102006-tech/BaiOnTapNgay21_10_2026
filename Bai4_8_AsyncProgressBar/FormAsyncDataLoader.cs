using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4_8_AsyncProgressBar
{
    public partial class FormAsyncDataLoader : Form
    {
        private CancellationTokenSource? cts;

        public FormAsyncDataLoader()
        {
            InitializeComponent();
        }

        private void FormAsyncDataLoader_Load(object? sender, EventArgs e)
        {
            CauHinhDataGridView();
        }

        private void CauHinhDataGridView()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Clear();

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StudentId",
                HeaderText = "Mã SV",
                Width = 100
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Họ và tên",
                Width = 200
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Age",
                HeaderText = "Tuổi",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gender",
                HeaderText = "Giới tính",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AvatarPath",
                HeaderText = "Đường dẫn Avatar",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        /// <summary>
        /// Phương thức nạp dữ liệu danh sách sinh viên dạng bất đồng bộ (async Task<List<T>>)
        /// Sử dụng Task.Run kết hợp await để đẩy việc xử lý nặng xuống tiến trình ngầm
        /// </summary>
        private async Task<List<Student>> NapDuLieuSinhVienAsync(IProgress<int> progress, CancellationToken token)
        {
            return await Task.Run(() =>
            {
                List<Student> danhSach = new List<Student>();

                // Giả lập tiến trình nạp dữ liệu lớn gồm 10 giai đoạn
                for (int i = 1; i <= 10; i++)
                {
                    token.ThrowIfCancellationRequested();

                    // Mô phỏng độ trễ truy vấn CSDL hoặc đọc file lớn (350ms * 10 = 3.5 giây)
                    Thread.Sleep(350);

                    int phanTram = i * 10;
                    progress.Report(phanTram);
                }

                // Dữ liệu kết quả thu được
                danhSach.Add(new Student("SV101", "Đoàn Văn Hậu", 21, "Nam", ""));
                danhSach.Add(new Student("SV102", "Nguyễn Quang Hải", 22, "Nam", ""));
                danhSach.Add(new Student("SV103", "Hoàng Thị Loan", 20, "Nữ", ""));
                danhSach.Add(new Student("SV104", "Huỳnh Như", 23, "Nữ", ""));
                danhSach.Add(new Student("SV105", "Đỗ Hùng Dũng", 22, "Nam", ""));
                danhSach.Add(new Student("SV106", "Bùi Tiến Dũng", 21, "Nam", ""));
                danhSach.Add(new Student("SV107", "Nguyễn Thị Tuyết Dung", 22, "Nữ", ""));
                danhSach.Add(new Student("SV108", "Nguyễn Tiến Linh", 21, "Nam", ""));

                return danhSach;
            }, token);
        }

        private async void btnLoadAsync_Click(object? sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            var token = cts.Token;

            // 1. Quản lý trạng thái giao diện: khóa nút bấm tránh click trùng lặp
            btnLoadAsync.Enabled = false;
            btnCancel.Enabled = true;
            progressBar1.Value = 0;
            lblPercent.Text = "0%";
            lblStatus.Text = "Trạng thái: Đang kết nối và nạp dữ liệu lớn (3 - 5 giây)...";
            lblStatus.ForeColor = Color.DarkOrange;

            var parent = this.MdiParent as FormMain;
            parent?.CapNhatTienTrinh(0, true, "Bắt đầu nạp dữ liệu bất đồng bộ...");

            // 2. Sử dụng IProgress<T> (Progress<int>) để nhận phần trăm tiến trình từ ngầm về UI Thread
            var progress = new Progress<int>(phanTram =>
            {
                progressBar1.Value = phanTram;
                lblPercent.Text = $"{phanTram}%";
                lblStatus.Text = $"Trạng thái: Đang nạp dữ liệu... ({phanTram}%)";

                // Đồng thời cập nhật trạng thái tiến trình lên StatusStrip của Form cha MDI
                parent?.CapNhatTienTrinh(phanTram, true, $"Đang nạp dữ liệu: {phanTram}%");
            });

            try
            {
                // 3. Gọi hàm bất đồng bộ với từ khóa await
                var ketQua = await NapDuLieuSinhVienAsync(progress, token);

                // 4. Nạp dữ liệu lên Grid trên UI Thread
                dgvStudents.DataSource = ketQua;

                lblStatus.Text = $"Trạng thái: Nạp thành công {ketQua.Count} sinh viên lúc {DateTime.Now:HH:mm:ss}!";
                lblStatus.ForeColor = Color.DarkGreen;
                parent?.CapNhatTienTrinh(100, false, $"Đã nạp xong {ketQua.Count} sinh viên.");

                MessageBox.Show($"Nạp dữ liệu bất đồng bộ hoàn tất!\nTổng số: {ketQua.Count} sinh viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "Trạng thái: Người dùng đã hủy thao tác nạp dữ liệu.";
                lblStatus.ForeColor = Color.DarkRed;
                parent?.CapNhatTienTrinh(0, false, "Thao tác nạp dữ liệu đã bị hủy.");
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Lỗi: {ex.Message}";
                lblStatus.ForeColor = Color.Red;
                parent?.CapNhatTienTrinh(0, false, "Xảy ra lỗi trong quá trình nạp dữ liệu.");
                MessageBox.Show($"Lỗi nạp dữ liệu:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 5. Mở lại nút bấm khi hoàn tất hoặc gặp lỗi
                btnLoadAsync.Enabled = true;
                btnCancel.Enabled = false;
                cts.Dispose();
                cts = null;
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            cts?.Cancel();
        }

        private void FormAsyncDataLoader_FormClosing(object? sender, FormClosingEventArgs e)
        {
            cts?.Cancel();
            (this.MdiParent as FormMain)?.CapNhatTienTrinh(0, false, "Sẵn sàng");
        }
    }
}
