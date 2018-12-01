namespace EyesManager
{
    partial class WorkSeeControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSeconds = new System.Windows.Forms.ComboBox();
            this.cbbShowFinish = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDays = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.dgvDetial = new System.Windows.Forms.DataGridView();
            this.timer = new System.Windows.Forms.Timer(this.components);
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
            this.spcMain.Panel1.Controls.Add(this.label4);
            this.spcMain.Panel1.Controls.Add(this.label3);
            this.spcMain.Panel1.Controls.Add(this.label2);
            this.spcMain.Panel1.Controls.Add(this.cbxSeconds);
            this.spcMain.Panel1.Controls.Add(this.cbbShowFinish);
            this.spcMain.Panel1.Controls.Add(this.label1);
            this.spcMain.Panel1.Controls.Add(this.cbxDays);
            this.spcMain.Panel1.Controls.Add(this.btnRun);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.dgvDetial);
            this.spcMain.Size = new System.Drawing.Size(800, 600);
            this.spcMain.SplitterWidth = 1;
            this.spcMain.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(214, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "天";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(419, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "秒";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(255, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "更新時間";
            // 
            // cbxSeconds
            // 
            this.cbxSeconds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSeconds.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxSeconds.FormattingEnabled = true;
            this.cbxSeconds.Location = new System.Drawing.Point(333, 9);
            this.cbxSeconds.Name = "cbxSeconds";
            this.cbxSeconds.Size = new System.Drawing.Size(80, 24);
            this.cbxSeconds.TabIndex = 4;
            // 
            // cbbShowFinish
            // 
            this.cbbShowFinish.AutoSize = true;
            this.cbbShowFinish.Checked = true;
            this.cbbShowFinish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbbShowFinish.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbbShowFinish.Location = new System.Drawing.Point(455, 13);
            this.cbbShowFinish.Name = "cbbShowFinish";
            this.cbbShowFinish.Size = new System.Drawing.Size(146, 20);
            this.cbbShowFinish.TabIndex = 3;
            this.cbbShowFinish.Text = "顯示已完成工單";
            this.cbbShowFinish.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "追蹤工單天數";
            // 
            // cbxDays
            // 
            this.cbxDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDays.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxDays.FormattingEnabled = true;
            this.cbxDays.Location = new System.Drawing.Point(128, 9);
            this.cbxDays.Name = "cbxDays";
            this.cbxDays.Size = new System.Drawing.Size(80, 24);
            this.cbxDays.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRun.Location = new System.Drawing.Point(618, 4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(135, 36);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "開始追蹤";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dgvDetial
            // 
            this.dgvDetial.AllowUserToAddRows = false;
            this.dgvDetial.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetial.Location = new System.Drawing.Point(0, 0);
            this.dgvDetial.Name = "dgvDetial";
            this.dgvDetial.ReadOnly = true;
            this.dgvDetial.RowHeadersVisible = false;
            this.dgvDetial.RowTemplate.Height = 24;
            this.dgvDetial.Size = new System.Drawing.Size(800, 549);
            this.dgvDetial.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Interval = 20000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // WorkSeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorkSeeControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.WorkSeeControl_Load);
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
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DataGridView dgvDetial;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox cbxDays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxSeconds;
        private System.Windows.Forms.CheckBox cbbShowFinish;
    }
}
