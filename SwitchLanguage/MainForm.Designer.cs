
namespace SwitchLanguage
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SuccessHotKey = new System.Windows.Forms.Button();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startkeyTextBox = new System.Windows.Forms.TextBox();
            this.endkeyTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.settingKey = new System.Windows.Forms.Button();
            this.contextTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SuccessHotKey
            // 
            this.SuccessHotKey.Location = new System.Drawing.Point(14, 115);
            this.SuccessHotKey.Name = "SuccessHotKey";
            this.SuccessHotKey.Size = new System.Drawing.Size(87, 23);
            this.SuccessHotKey.TabIndex = 0;
            this.SuccessHotKey.Text = "키설정 완료";
            this.SuccessHotKey.UseVisualStyleBackColor = true;
            this.SuccessHotKey.UseWaitCursor = true;
            this.SuccessHotKey.Click += new System.EventHandler(this.SuccessHotKeyFunction);
            // 
            // TrayIcon
            // 
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "언어설정변경";
            this.TrayIcon.Visible = true;
            // 
            // contextTrayMenu
            // 
            this.contextTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.보기ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.contextTrayMenu.Name = "contextTrayMenu";
            this.contextTrayMenu.Size = new System.Drawing.Size(99, 48);
            // 
            // 보기ToolStripMenuItem
            // 
            this.보기ToolStripMenuItem.Name = "보기ToolStripMenuItem";
            this.보기ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.보기ToolStripMenuItem.Text = "보기";
            this.보기ToolStripMenuItem.Click += new System.EventHandler(this.보기ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // startupCheckBox
            // 
            this.startupCheckBox.AutoSize = true;
            this.startupCheckBox.Location = new System.Drawing.Point(327, 49);
            this.startupCheckBox.Name = "startupCheckBox";
            this.startupCheckBox.Size = new System.Drawing.Size(88, 16);
            this.startupCheckBox.TabIndex = 2;
            this.startupCheckBox.Text = "부팅시 실행";
            this.startupCheckBox.UseVisualStyleBackColor = true;
            this.startupCheckBox.UseWaitCursor = true;
            this.startupCheckBox.CheckedChanged += new System.EventHandler(this.startupCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "시작프로그램 등록";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "변경할 언어키 입력받기";
            this.label2.UseWaitCursor = true;
            // 
            // startkeyTextBox
            // 
            this.startkeyTextBox.Location = new System.Drawing.Point(60, 47);
            this.startkeyTextBox.Name = "startkeyTextBox";
            this.startkeyTextBox.Size = new System.Drawing.Size(85, 21);
            this.startkeyTextBox.TabIndex = 6;
            this.startkeyTextBox.UseWaitCursor = true;
            // 
            // endkeyTextBox
            // 
            this.endkeyTextBox.Location = new System.Drawing.Point(60, 74);
            this.endkeyTextBox.Name = "endkeyTextBox";
            this.endkeyTextBox.Size = new System.Drawing.Size(85, 21);
            this.endkeyTextBox.TabIndex = 7;
            this.endkeyTextBox.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "시작키";
            this.label3.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "보조키";
            this.label4.UseWaitCursor = true;
            // 
            // settingKey
            // 
            this.settingKey.Location = new System.Drawing.Point(151, 47);
            this.settingKey.Name = "settingKey";
            this.settingKey.Size = new System.Drawing.Size(86, 23);
            this.settingKey.TabIndex = 10;
            this.settingKey.Text = "키설정 하기";
            this.settingKey.UseVisualStyleBackColor = true;
            this.settingKey.UseWaitCursor = true;
            this.settingKey.Click += new System.EventHandler(this.settingKey_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 203);
            this.Controls.Add(this.settingKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endkeyTextBox);
            this.Controls.Add(this.startkeyTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startupCheckBox);
            this.Controls.Add(this.SuccessHotKey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "언어설정변경";
            this.UseWaitCursor = true;
            this.contextTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SuccessHotKey;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip contextTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem 보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.CheckBox startupCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox startkeyTextBox;
        private System.Windows.Forms.TextBox endkeyTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button settingKey;
    }
}

