using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bai4_8_AsyncProgressBar
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

            bindingSource.CurrentChanged += (s, ev) => CapNhatAnhDaiDien();
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

            txtStudentId.DataBindings.Add("Text", bindingSource, "StudentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("Text", bindingSource, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge.DataBindings.Add("Text", bindingSource, "Age", true, DataSourceUpdateMode.OnPropertyChanged);
            cboGender.DataBindings.Add("SelectedItem", bindingSource, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
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

        private void btnChooseAvatar_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh đại diện";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All Files (*.*)|*.*";

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    currentAvatarPath = ofd.FileName;
                    HienThiAnhLenPictureBox(currentAvatarPath);

                    if (bindingSource.Current is Student sv)
                    {
                        sv.AvatarPath = currentAvatarPath;
                        bindingSource.ResetCurrentItem();
                    }
                }
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            string id = txtStudentId.Text.Trim();
            string name = txtFullName.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Mã và tên sinh viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int.TryParse(txtAge.Text.Trim(), out int age);

            Student newStudent = new Student(id, name, age, cboGender.SelectedItem?.ToString() ?? "Nam", currentAvatarPath);
            listStudents.Add(newStudent);
            bindingSource.Position = listStudents.IndexOf(newStudent);

            MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Student sv)
            {
                sv.FullName = txtFullName.Text.Trim();
                int.TryParse(txtAge.Text.Trim(), out int age);
                sv.Age = age;
                sv.Gender = cboGender.SelectedItem?.ToString() ?? "Nam";
                sv.AvatarPath = currentAvatarPath;

                bindingSource.ResetCurrentItem();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Student sv)
            {
                DialogResult dr = MessageBox.Show($"Xóa sinh viên [{sv.StudentId} - {sv.FullName}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    listStudents.Remove(sv);
                    MessageBox.Show("Đã xóa sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            bindingSource.AddNew();
            txtStudentId.Clear();
            txtFullName.Clear();
            txtAge.Clear();
            cboGender.SelectedIndex = 0;
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;
            txtStudentId.Focus();
        }
    }
}
