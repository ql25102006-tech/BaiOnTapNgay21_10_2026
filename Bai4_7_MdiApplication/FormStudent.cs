using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bai4_7_MdiApplication
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
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.SelectedIndex = 0;

            CauHinhDataGridView();

            listStudents.Add(new Student("SV001", "Nguyễn Văn An", 20, "Nam", ""));
            listStudents.Add(new Student("SV002", "Trần Thị Bích", 21, "Nữ", ""));
            listStudents.Add(new Student("SV003", "Lê Hoàng Nam", 19, "Nam", ""));
            listStudents.Add(new Student("SV004", "Phạm Thu Hà", 22, "Nữ", ""));

            bindingSource.DataSource = listStudents;
            dgvStudents.DataSource = bindingSource;

            ThietLapDataBinding();

            bindingSource.CurrentChanged += BindingSource_CurrentChanged;
            CapNhatAnhDaiDien();

            ThongBaoVeFormCha($"Đã nạp danh sách {listStudents.Count} sinh viên.");
        }

        private void ThongBaoVeFormCha(string thongBao)
        {
            // Giao tiếp Form con -> Form cha: cập nhật StatusStrip của FormMain
            (this.MdiParent as FormMain)?.CapNhatTrangThai(thongBao);
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

            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                errorProvider1.SetError(txtStudentId, "Mã sinh viên không được để trống!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider1.SetError(txtFullName, "Họ tên không được để trống!");
                isValid = false;
            }

            if (!int.TryParse(txtAge.Text.Trim(), out age) || age < 15 || age > 100)
            {
                errorProvider1.SetError(txtAge, "Tuổi phải là số nguyên hợp lệ từ 15 đến 100!");
                isValid = false;
            }

            if (cboGender.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboGender, "Vui lòng chọn giới tính!");
                isValid = false;
            }

            return isValid;
        }

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

                    if (bindingSource.Current is Student sv)
                    {
                        sv.AvatarPath = currentAvatarPath;
                        bindingSource.ResetCurrentItem();
                        ThongBaoVeFormCha($"Đã cập nhật ảnh đại diện cho sinh viên [{sv.StudentId}].");
                    }
                }
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(out int age)) return;

            string id = txtStudentId.Text.Trim();

            foreach (var s in listStudents)
            {
                if (s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    errorProvider1.SetError(txtStudentId, "Mã sinh viên này đã tồn tại!");
                    MessageBox.Show("Mã sinh viên đã tồn tại, vui lòng nhập mã khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            ThongBaoVeFormCha($"Thêm mới thành công sinh viên [{newStudent.StudentId}] - {newStudent.FullName}.");
            MessageBox.Show("Thêm mới sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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

                ThongBaoVeFormCha($"Cập nhật thành công sinh viên [{sv.StudentId}] - {sv.FullName}.");
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 sinh viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            ThucHienXoaSinhVien();
        }

        private void ThucHienXoaSinhVien()
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
                    string info = $"[{sv.StudentId}] {sv.FullName}";
                    listStudents.Remove(sv);
                    ThongBaoVeFormCha($"Đã xóa thành công sinh viên {info}.");
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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
            ThongBaoVeFormCha("Đã làm mới thông tin ô nhập.");
        }

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
                        sb.AppendLine("Mã SV,Họ và tên,Tuổi,Giới tính,Đường dẫn Avatar");

                        foreach (var sv in listStudents)
                        {
                            string ten = sv.FullName.Contains(",") ? $"\"{sv.FullName}\"" : sv.FullName;
                            string anh = sv.AvatarPath.Contains(",") ? $"\"{sv.AvatarPath}\"" : sv.AvatarPath;
                            sb.AppendLine($"{sv.StudentId},{ten},{sv.Age},{sv.Gender},{anh}");
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        ThongBaoVeFormCha($"Đã xuất danh sách {listStudents.Count} sinh viên ra file CSV.");
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

        #region ContextMenuStrip (Menu ngữ cảnh trên DataGridView)
        private void menuCtxViewDetail_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Student sv)
            {
                string info = $"Mã sinh viên: {sv.StudentId}\n" +
                              $"Họ và tên: {sv.FullName}\n" +
                              $"Tuổi: {sv.Age}\n" +
                              $"Giới tính: {sv.Gender}\n" +
                              $"Đường dẫn Avatar: {(string.IsNullOrEmpty(sv.AvatarPath) ? "(Chưa có ảnh)" : sv.AvatarPath)}";

                MessageBox.Show(info, "Chi tiết sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ThongBaoVeFormCha($"Đang xem chi tiết sinh viên [{sv.StudentId}].");
            }
        }

        private void menuCtxDelete_Click(object? sender, EventArgs e)
        {
            ThucHienXoaSinhVien();
        }

        private void menuCtxRefresh_Click(object? sender, EventArgs e)
        {
            bindingSource.ResetBindings(false);
            CapNhatAnhDaiDien();
            ThongBaoVeFormCha("Đã làm mới dữ liệu danh sách sinh viên.");
        }
        #endregion
    }
}
