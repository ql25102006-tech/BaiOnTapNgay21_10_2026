namespace Bai4_8_AsyncProgressBar
{
    partial class FormMain
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
            menuStrip1 = new MenuStrip();
            menuSystem = new ToolStripMenuItem();
            menuLogout = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuExit = new ToolStripMenuItem();
            menuFunction = new ToolStripMenuItem();
            menuAsyncDataLoader = new ToolStripMenuItem();
            menuStudentManager = new ToolStripMenuItem();
            menuWindow = new ToolStripMenuItem();
            menuCascade = new ToolStripMenuItem();
            menuTileHorizontal = new ToolStripMenuItem();
            menuTileVertical = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            btnToolAsync = new ToolStripButton();
            btnToolStudent = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnToolExit = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            sslUser = new ToolStripStatusLabel();
            sslMessage = new ToolStripStatusLabel();
            tspbMainProgress = new ToolStripProgressBar();
            sslProgressPercent = new ToolStripStatusLabel();
            sslTime = new ToolStripStatusLabel();
            timerClock = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuSystem, menuFunction, menuWindow });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MdiWindowListItem = menuWindow;
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1100, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuSystem
            // 
            menuSystem.DropDownItems.AddRange(new ToolStripItem[] { menuLogout, toolStripSeparator1, menuExit });
            menuSystem.Name = "menuSystem";
            menuSystem.Size = new Size(85, 24);
            menuSystem.Text = "Hệ thống";
            // 
            // menuLogout
            // 
            menuLogout.Name = "menuLogout";
            menuLogout.Size = new Size(160, 26);
            menuLogout.Text = "Đăng xuất";
            menuLogout.Click += menuLogout_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(157, 6);
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.ShortcutKeys = Keys.Alt | Keys.F4;
            menuExit.Size = new Size(160, 26);
            menuExit.Text = "Thoát";
            menuExit.Click += menuExit_Click;
            // 
            // menuFunction
            // 
            menuFunction.DropDownItems.AddRange(new ToolStripItem[] { menuAsyncDataLoader, menuStudentManager });
            menuFunction.Name = "menuFunction";
            menuFunction.Size = new Size(93, 24);
            menuFunction.Text = "Chức năng";
            // 
            // menuAsyncDataLoader
            // 
            menuAsyncDataLoader.Name = "menuAsyncDataLoader";
            menuAsyncDataLoader.ShortcutKeys = Keys.Control | Keys.A;
            menuAsyncDataLoader.Size = new Size(305, 26);
            menuAsyncDataLoader.Text = "Nạp dữ liệu Bất đồng bộ";
            menuAsyncDataLoader.Click += menuAsyncDataLoader_Click;
            // 
            // menuStudentManager
            // 
            menuStudentManager.Name = "menuStudentManager";
            menuStudentManager.ShortcutKeys = Keys.Control | Keys.S;
            menuStudentManager.Size = new Size(305, 26);
            menuStudentManager.Text = "Quản lý Sinh viên";
            menuStudentManager.Click += menuStudentManager_Click;
            // 
            // menuWindow
            // 
            menuWindow.DropDownItems.AddRange(new ToolStripItem[] { menuCascade, menuTileHorizontal, menuTileVertical });
            menuWindow.Name = "menuWindow";
            menuWindow.Size = new Size(73, 24);
            menuWindow.Text = "Cửa sổ";
            // 
            // menuCascade
            // 
            menuCascade.Name = "menuCascade";
            menuCascade.Size = new Size(187, 26);
            menuCascade.Text = "Cascade";
            menuCascade.Click += menuCascade_Click;
            // 
            // menuTileHorizontal
            // 
            menuTileHorizontal.Name = "menuTileHorizontal";
            menuTileHorizontal.Size = new Size(187, 26);
            menuTileHorizontal.Text = "Tile Horizontal";
            menuTileHorizontal.Click += menuTileHorizontal_Click;
            // 
            // menuTileVertical
            // 
            menuTileVertical.Name = "menuTileVertical";
            menuTileVertical.Size = new Size(187, 26);
            menuTileVertical.Text = "Tile Vertical";
            menuTileVertical.Click += menuTileVertical_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnToolAsync, btnToolStudent, toolStripSeparator2, btnToolExit });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1100, 27);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnToolAsync
            // 
            btnToolAsync.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnToolAsync.Name = "btnToolAsync";
            btnToolAsync.Size = new Size(176, 24);
            btnToolAsync.Text = "Nạp dữ liệu Bất đồng bộ";
            btnToolAsync.Click += menuAsyncDataLoader_Click;
            // 
            // btnToolStudent
            // 
            btnToolStudent.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnToolStudent.Name = "btnToolStudent";
            btnToolStudent.Size = new Size(128, 24);
            btnToolStudent.Text = "Quản lý Sinh viên";
            btnToolStudent.Click += menuStudentManager_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // btnToolExit
            // 
            btnToolExit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnToolExit.Name = "btnToolExit";
            btnToolExit.Size = new Size(51, 24);
            btnToolExit.Text = "Thoát";
            btnToolExit.Click += menuExit_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { sslUser, sslMessage, tspbMainProgress, sslProgressPercent, sslTime });
            statusStrip1.Location = new Point(0, 674);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1100, 26);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // sslUser
            // 
            sslUser.BorderSides = ToolStripStatusLabelBorderSides.Right;
            sslUser.Name = "sslUser";
            sslUser.Size = new Size(200, 20);
            sslUser.Text = "Người dùng: Administrator";
            // 
            // sslMessage
            // 
            sslMessage.Name = "sslMessage";
            sslMessage.Size = new Size(444, 20);
            sslMessage.Spring = true;
            sslMessage.Text = "Thông báo: Sẵn sàng";
            sslMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tspbMainProgress
            // 
            tspbMainProgress.Name = "tspbMainProgress";
            tspbMainProgress.Size = new Size(160, 18);
            tspbMainProgress.Visible = false;
            // 
            // sslProgressPercent
            // 
            sslProgressPercent.BorderSides = ToolStripStatusLabelBorderSides.Right;
            sslProgressPercent.Name = "sslProgressPercent";
            sslProgressPercent.Size = new Size(33, 20);
            sslProgressPercent.Text = "0%";
            sslProgressPercent.Visible = false;
            // 
            // sslTime
            // 
            sslTime.Name = "sslTime";
            sslTime.Size = new Size(139, 20);
            sslTime.Text = "Thời gian: 00:00:00";
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Interval = 1000;
            timerClock.Tick += timerClock_Tick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(950, 600);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 4.8 - Lập trình bất đồng bộ (Async/Await) & Tiến trình ProgressBar";
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuSystem;
        private ToolStripMenuItem menuLogout;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menuExit;
        private ToolStripMenuItem menuFunction;
        private ToolStripMenuItem menuAsyncDataLoader;
        private ToolStripMenuItem menuStudentManager;
        private ToolStripMenuItem menuWindow;
        private ToolStripMenuItem menuCascade;
        private ToolStripMenuItem menuTileHorizontal;
        private ToolStripMenuItem menuTileVertical;
        private ToolStrip toolStrip1;
        private ToolStripButton btnToolAsync;
        private ToolStripButton btnToolStudent;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnToolExit;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel sslUser;
        private ToolStripStatusLabel sslMessage;
        private ToolStripProgressBar tspbMainProgress;
        private ToolStripStatusLabel sslProgressPercent;
        private ToolStripStatusLabel sslTime;
        private System.Windows.Forms.Timer timerClock;
    }
}
