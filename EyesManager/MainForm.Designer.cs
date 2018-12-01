namespace EyesManager
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sspStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsspStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssa = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolWorkCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolWorkMaintain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolWorkSee = new System.Windows.Forms.ToolStripMenuItem();
            this.palMain = new System.Windows.Forms.Panel();
            this.sspStatus.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sspStatus
            // 
            this.sspStatus.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.sspStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsspStatus,
            this.tssa});
            this.sspStatus.Location = new System.Drawing.Point(0, 533);
            this.sspStatus.Name = "sspStatus";
            this.sspStatus.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.sspStatus.Size = new System.Drawing.Size(1008, 29);
            this.sspStatus.TabIndex = 0;
            this.sspStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(77, 24);
            this.toolStripStatusLabel1.Text = "連線狀態:";
            // 
            // tsspStatus
            // 
            this.tsspStatus.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tsspStatus.Name = "tsspStatus";
            this.tsspStatus.Size = new System.Drawing.Size(206, 24);
            this.tsspStatus.Text = "toolStripStatusLabel2";
            // 
            // tssa
            // 
            this.tssa.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tssa.Name = "tssa";
            this.tssa.Size = new System.Drawing.Size(110, 24);
            this.tssa.Text = "                    ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSetting,
            this.toolConnect,
            this.toolWorkCreate,
            this.toolWorkMaintain,
            this.toolWorkSee});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1008, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolSetting
            // 
            this.toolSetting.Name = "toolSetting";
            this.toolSetting.Size = new System.Drawing.Size(44, 20);
            this.toolSetting.Text = "設定";
            this.toolSetting.Click += new System.EventHandler(this.toolSetting_Click);
            // 
            // toolConnect
            // 
            this.toolConnect.Name = "toolConnect";
            this.toolConnect.Size = new System.Drawing.Size(68, 20);
            this.toolConnect.Text = "工單作業";
            this.toolConnect.Click += new System.EventHandler(this.toolConnect_Click);
            // 
            // toolWorkCreate
            // 
            this.toolWorkCreate.Name = "toolWorkCreate";
            this.toolWorkCreate.Size = new System.Drawing.Size(68, 20);
            this.toolWorkCreate.Text = "工單建立";
            this.toolWorkCreate.Click += new System.EventHandler(this.toolWorkCreate_Click);
            // 
            // toolWorkMaintain
            // 
            this.toolWorkMaintain.Name = "toolWorkMaintain";
            this.toolWorkMaintain.Size = new System.Drawing.Size(68, 20);
            this.toolWorkMaintain.Text = "工單維護";
            this.toolWorkMaintain.Click += new System.EventHandler(this.toolWorkMaintain_Click);
            // 
            // toolWorkSee
            // 
            this.toolWorkSee.Name = "toolWorkSee";
            this.toolWorkSee.Size = new System.Drawing.Size(68, 20);
            this.toolWorkSee.Text = "工單追蹤";
            this.toolWorkSee.Click += new System.EventHandler(this.toolWorkSee_Click);
            // 
            // palMain
            // 
            this.palMain.BackColor = System.Drawing.Color.LightSteelBlue;
            this.palMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palMain.Location = new System.Drawing.Point(0, 26);
            this.palMain.Margin = new System.Windows.Forms.Padding(4);
            this.palMain.Name = "palMain";
            this.palMain.Padding = new System.Windows.Forms.Padding(5);
            this.palMain.Size = new System.Drawing.Size(1008, 507);
            this.palMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.palMain);
            this.Controls.Add(this.sspStatus);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(742, 387);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EyesManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.sspStatus.ResumeLayout(false);
            this.sspStatus.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sspStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolSetting;
        private System.Windows.Forms.ToolStripMenuItem toolConnect;
        private System.Windows.Forms.ToolStripMenuItem toolWorkCreate;
        private System.Windows.Forms.Panel palMain;
        private System.Windows.Forms.ToolStripMenuItem toolWorkMaintain;
        private System.Windows.Forms.ToolStripMenuItem toolWorkSee;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsspStatus;
        private System.Windows.Forms.ToolStripStatusLabel tssa;
    }
}

