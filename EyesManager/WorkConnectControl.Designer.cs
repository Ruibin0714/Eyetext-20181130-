namespace EyesManager
{
    partial class WorkConnectControl
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.labStatus = new System.Windows.Forms.Label();
            this.tbxWorkNumber = new EyesManager.NumberTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetial = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetial)).BeginInit();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.spcMain.Panel1.Controls.Add(this.labStatus);
            this.spcMain.Panel1.Controls.Add(this.tbxWorkNumber);
            this.spcMain.Panel1.Controls.Add(this.label1);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.dgvDetial);
            this.spcMain.Size = new System.Drawing.Size(831, 600);
            this.spcMain.SplitterDistance = 100;
            this.spcMain.SplitterWidth = 2;
            this.spcMain.TabIndex = 0;
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labStatus.ForeColor = System.Drawing.Color.Red;
            this.labStatus.Location = new System.Drawing.Point(465, 59);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(141, 32);
            this.labStatus.TabIndex = 14;
            this.labStatus.Text = "偵測中...";
            // 
            // tbxWorkNumber
            // 
            this.tbxWorkNumber.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbxWorkNumber.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxWorkNumber.Location = new System.Drawing.Point(165, 51);
            this.tbxWorkNumber.MaxLength = 8;
            this.tbxWorkNumber.Name = "tbxWorkNumber";
            this.tbxWorkNumber.Size = new System.Drawing.Size(294, 40);
            this.tbxWorkNumber.TabIndex = 13;
            this.tbxWorkNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxWorkNumber.TextChanged += new System.EventHandler(this.tbxWorkNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "條碼輸入";
            // 
            // dgvDetial
            // 
            this.dgvDetial.AllowUserToAddRows = false;
            this.dgvDetial.AllowUserToDeleteRows = false;
            this.dgvDetial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetial.Location = new System.Drawing.Point(0, 0);
            this.dgvDetial.Name = "dgvDetial";
            this.dgvDetial.RowHeadersVisible = false;
            this.dgvDetial.RowTemplate.Height = 24;
            this.dgvDetial.Size = new System.Drawing.Size(831, 498);
            this.dgvDetial.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WorkConnectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "WorkConnectControl";
            this.Size = new System.Drawing.Size(831, 600);
            this.Load += new System.EventHandler(this.WorkConnectControl_Load);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.DataGridView dgvDetial;
        private System.Windows.Forms.Label labStatus;
        private NumberTextBox tbxWorkNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}
