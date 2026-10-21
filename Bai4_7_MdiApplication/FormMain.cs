using System;
using System.Windows.Forms;

namespace Bai4_7_MdiApplication
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object? sender, EventArgs e)
        {
            sslUser.Text = "Người dùng: Administrator";
            sslMessage.Text = "Thông báo: Hệ thống MDI đã sẵn sàng làm việc.";
            CapNhatThoiGian();
        }

        private void timerClock_Tick(object? sender, EventArgs e)
        {
            CapNhatThoiGian();
        }

        private void CapNhatThoiGian()
        {
            sslTime.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        /// <summary>
        /// Cơ chế truyền dữ liệu / gọi hàm giữa Form con và Form cha:
        /// Form con gọi hàm này để cập nhật trạng thái lên StatusStrip của FormMain
        /// </summary>
        public void CapNhatTrangThai(string thongBao)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => CapNhatTrangThai(thongBao)));
                return;
            }

            sslMessage.Text = $"Thông báo: {thongBao}";
        }

        /// <summary>
        /// Thuật toán kiểm tra Form con khi mở:
        /// - Nếu Form chưa mở: khởi tạo mới, gán MdiParent = this và Show()
        /// - Nếu Form đã mở: kích hoạt (Activate) đưa lên trên cùng, KHÔNG ĐƯỢC MỞ LẶP LẠI
        /// </summary>
        public void MoFormCon(Type loaiForm)
        {
            Form? formCon = null;

            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == loaiForm)
                {
                    formCon = f;
                    break;
                }
            }

            if (formCon != null)
            {
                if (formCon.WindowState == FormWindowState.Minimized)
                {
                    formCon.WindowState = FormWindowState.Normal;
                }
                formCon.Activate();
                formCon.BringToFront();
            }
            else
            {
                Form fMoi = (Form)Activator.CreateInstance(loaiForm)!;
                fMoi.MdiParent = this;
                fMoi.StartPosition = FormStartPosition.CenterScreen;
                fMoi.Show();
            }
        }

        private void menuStudentManager_Click(object? sender, EventArgs e)
        {
            MoFormCon(typeof(FormStudent));
        }

        private void menuProductManager_Click(object? sender, EventArgs e)
        {
            MoFormCon(typeof(FormProduct));
        }

        private void menuCascade_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void menuTileHorizontal_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuTileVertical_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void menuLogout_Click(object? sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất phiên làm việc hiện tại?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                foreach (Form child in this.MdiChildren)
                {
                    child.Close();
                }

                sslUser.Text = "Người dùng: Đã đăng xuất";
                sslMessage.Text = "Thông báo: Vui lòng đăng nhập lại để tiếp tục.";
            }
        }

        private void menuExit_Click(object? sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi ứng dụng?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
