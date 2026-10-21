using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bai4_6_StudentManager
{
    public partial class FormStudent : Form
    {
        private BindingList<Student> listStudents = new BindingList<Student>();
        private BindingSource bindingSource = new BindingSource();
        private string currentAvatarPath = string.Empty;

        public FormStudent()
        {
            InitializeComponent();
        }

        private void FormStudent_Load(object? sender, EventArgs e)
        {
            // 1. Nạp danh sách Giới tính
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.SelectedIndex = 0;

            // 2. Cấu hình DataGridView bằng code
            CauHinhDataGridView();

            // 3. Nạp dữ liệu mẫu ban đầu
            listStudents.Add(new Student("SV001", "Nguyễn Văn An", 20, "Nam", ""));
            listStudents.Add(new Student("SV002", "Trần Thị Bích", 21, "Nữ", ""));
            listStudents.Add(new Student("SV003", "Lê Hoàng Nam", 19, "Nam", ""));
            listStudents.Add(new Student("SV004", "Phạm Thu Hà", 22, "Nữ", ""));

            // 4. Thiết lập BindingSource làm trung gian
            bindingSource.DataSource = listStudents;
            dgvStudents.DataSource = bindingSource;

            // 5. Cấu hình Data Binding 2 chiều cho các Control nhập liệu
            ThietLapDataBinding();

            // 6. Bắt sự kiện chuyển dòng để nạp Avatar tương ứng
            bindingSource.CurrentChanged += BindingSource_CurrentChanged;

            // Nạp ảnh cho dòng đầu tiên
            CapNhatAnhDaiDien();
        }

        private void CauHinhDataGridView()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Clear();

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StudentId",
                HeaderText = "Mã SV",
                Width = 90
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Họ và tên",
                Width = 180
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Age",
                HeaderText = "Tuổi",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gender",
                HeaderText = "Giới tính",
                Width = 90,
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

        private void ThietLapDataBinding()
        {
            txtStudentId.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            cboGender.DataBindings.Clear();

            // Ràng buộc 2 chiều (BindingSource <-> Control)
            txtStudentId.DataBindings.Add("Text", bindingSource, "StudentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("Text", bindingSource, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge.DataBindings.Add("Text", bindingSource, "Age", true, DataSourceUpdateMode.OnPropertyChanged);
            cboGender.DataBindings.Add("SelectedItem", bindingSource, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BindingSource_CurrentChanged(object? sender, EventArgs e)
        {
            CapNhatAnhDaiDien();
            errorProvider1.Clear();
        }

        private void CapNhatAnhDaiDien()
        {
            if (bindingSource.Current is Student sv)
            {
                currentAvatarPath = sv.AvatarPath;
                HienThiAnhLenPictureBox(currentAvatarPath);
            }
            else
            {
                picAvatar.Image?.Dispose();
                picAvatar.Image = null;
                currentAvatarPath = string.Empty;
            }
        }

        private void HienThiAnhLenPictureBox(string imagePath)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
                {
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    using (Image img = Image.FromStream(fs))
                    {
                        picAvatar.Image?.Dispose();
                        picAvatar.Image = new Bitmap(img);
                    }
                }
                else
                {
                    picAvatar.Image?.Dispose();
                    picAvatar.Image = null;
                }
            }
            catch
            {
                picAvatar.Image?.Dispose();
                picAvatar.Image = null;
            }
        }

        private bool ValidateInput(out int age)
        {
            bool isValid = true;
            age = 0;
            errorProvider1.Clear();

            // 1. Kiểm tra Mã SV
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                errorProvider1.SetError(txtStudentId, "Mã sinh viên không được để trống!");
                isValid = false;
            }

            // 2. Kiểm tra Họ tên
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider1.SetError(txtFullName, "Họ tên không được để trống!");
                isValid = false;
            }

            // 3. Kiểm tra Tuổi
            if (!int.TryParse(txtAge.Text.Trim(), out age) || age < 15 || age > 100)
            {
                errorProvider1.SetError(txtAge, "Tuổi phải là số nguyên hợp lệ từ 15 đến 100!");
                isValid = false;
            }

            // 4. Kiểm tra Giới tính
            if (cboGender.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboGender, "Vui lòng chọn giới tính!");
                isValid = false;
            }

            return isValid;
        }

        // 1. Nút Chọn ảnh Avatar
        private void btnChooseAvatar_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện sinh viên";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All Files (*.*)|*.*";

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    currentAvatarPath = ofd.FileName;
                    HienThiAnhLenPictureBox(currentAvatarPath);

                    // Gán đường dẫn vào sinh viên đang chọn
                    if (bindingSource.Current is Student sv)
                    {
                        sv.AvatarPath = currentAvatarPath;
                        bindingSource.ResetCurrentItem();
                    }
                }
            }
        }

        // 2. Nút Thêm mới
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(out int age)) return;

            string id = txtStudentId.Text.Trim();

            // Kiểm tra trùng mã
            foreach (var s in listStudents)
            {
                if (s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    errorProvider1.SetError(txtStudentId, "Mã sinh viên này đã tồn tại!");
                    MessageBox.Show("Mã sinh viên đã tồn tại, vui lòng nhập mã khác!", "Cảnh báo trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Student newStudent = new Student(
                id,
                txtFullName.Text.Trim(),
                age,
                cboGender.SelectedItem?.ToString() ?? "Nam",
                currentAvatarPath
            );

            listStudents.Add(newStudent);
            bindingSource.Position = listStudents.IndexOf(newStudent);

            MessageBox.Show("Thêm mới sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 3. Nút Cập nhật
        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Student sv)
            {
                if (!ValidateInput(out int age)) return;

                sv.FullName = txtFullName.Text.Trim();
                sv.Age = age;
                sv.Gender = cboGender.SelectedItem?.ToString() ?? "Nam";
                sv.AvatarPath = currentAvatarPath;

                bindingSource.EndEdit();
                bindingSource.ResetCurrentItem();

                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 sinh viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 4. Nút Xóa
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Student sv)
            {
                DialogResult dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sinh viên [{sv.StudentId} - {sv.FullName}]?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    listStudents.Remove(sv);
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 5. Nút Làm mới
        private void btnClear_Click(object? sender, EventArgs e)
        {
            bindingSource.AddNew();
            txtStudentId.Clear();
            txtFullName.Clear();
            txtAge.Clear();
            cboGender.SelectedIndex = 0;
            currentAvatarPath = string.Empty;
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;
            errorProvider1.Clear();
            txtStudentId.Focus();
        }

        // 6. Nút Xuất CSV (SaveFileDialog)
        private void btnExportCsv_Click(object? sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách sinh viên ra tệp CSV";
                sfd.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.FileName = $"DanhSachSinhVien_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                sfd.DefaultExt = "csv";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        // Tiêu đề cột
                        sb.AppendLine("Mã SV,Họ và tên,Tuổi,Giới tính,Đường dẫn Avatar");

                        foreach (var sv in listStudents)
                        {
                            string ten = sv.FullName.Contains(",") ? $"\"{sv.FullName}\"" : sv.FullName;
                            string anh = sv.AvatarPath.Contains(",") ? $"\"{sv.AvatarPath}\"" : sv.AvatarPath;
                            sb.AppendLine($"{sv.StudentId},{ten},{sv.Age},{sv.Gender},{anh}");
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show(
                            $"Xuất dữ liệu thành công ra tệp:\n{sfd.FileName}\n\nTổng số sinh viên: {listStudents.Count}",
                            "Xuất CSV thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất tệp CSV:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
