using System;
using System.Windows.Forms;

namespace Bai4_8_AsyncProgressBar
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
            sslMessage.Text = "Thông báo: Hệ thống MDI & Tiến trình Async đã sẵn sàng.";
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
        /// Cập nhật tiến trình phần trăm từ Form con lên StatusStrip của Form cha
        /// </summary>
        public void CapNhatTienTrinh(int percent, bool visible = true, string message = "")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => CapNhatTienTrinh(percent, visible, message)));
                return;
            }

            tspbMainProgress.Visible = visible;
            sslProgressPercent.Visible = visible;

            tspbMainProgress.Value = Math.Max(0, Math.Min(100, percent));
            sslProgressPercent.Text = $"{percent}%";

            if (!string.IsNullOrEmpty(message))
            {
                sslMessage.Text = $"Thông báo: {message}";
            }
        }

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

        private void menuAsyncDataLoader_Click(object? sender, EventArgs e)
        {
            MoFormCon(typeof(FormAsyncDataLoader));
        }

        private void menuStudentManager_Click(object? sender, EventArgs e)
        {
            MoFormCon(typeof(FormStudent));
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
                "Bạn có muốn đăng xuất khỏi hệ thống?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                foreach (Form child in this.MdiChildren)
                {
                    child.Close();
                }

                sslUser.Text = "Người dùng: Đã đăng xuất";
                sslMessage.Text = "Thông báo: Vui lòng đăng nhập lại.";
            }
        }

        private void menuExit_Click(object? sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi ứng dụng?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
