namespace EyesManager
{
    partial class WorkCreateControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.label13 = new System.Windows.Forms.Label();
            this.Nontbx1 = new System.Windows.Forms.TextBox();
            this.btnOutput2 = new System.Windows.Forms.Button();
            this.tbxCustcName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxCustomName = new System.Windows.Forms.TextBox();
            this.btnNonSelect = new System.Windows.Forms.Button();
            this.btnAllSelect = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxWorkNumber = new EyesManager.NumberTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbxRightDegree = new System.Windows.Forms.TextBox();
            this.tbx222 = new System.Windows.Forms.Label();
            this.tbxLeftDegree = new System.Windows.Forms.TextBox();
            this.cbxAddDegree = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnMulti = new System.Windows.Forms.RadioButton();
            this.rbtnSignal = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxCreateMan = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxGlassType = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxFrameMode = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxOutputFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxOutputPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxMemo = new System.Windows.Forms.TextBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.dgvDetial = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetial)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "工單單號";
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("標楷體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreate.ForeColor = System.Drawing.Color.Red;
            this.btnCreate.Location = new System.Drawing.Point(735, 105);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(138, 84);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "建立";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            this.btnCreate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCreate_KeyDown);
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcMain.IsSplitterFixed = true;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.spcMain.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.spcMain.Panel1.Controls.Add(this.label13);
            this.spcMain.Panel1.Controls.Add(this.Nontbx1);
            this.spcMain.Panel1.Controls.Add(this.btnOutput2);
            this.spcMain.Panel1.Controls.Add(this.tbxCustcName);
            this.spcMain.Panel1.Controls.Add(this.label6);
            this.spcMain.Panel1.Controls.Add(this.tbxCustomName);
            this.spcMain.Panel1.Controls.Add(this.btnNonSelect);
            this.spcMain.Panel1.Controls.Add(this.btnAllSelect);
            this.spcMain.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.spcMain.Panel1.Controls.Add(this.label5);
            this.spcMain.Panel1.Controls.Add(this.label4);
            this.spcMain.Panel1.Controls.Add(this.tbxOutputFileName);
            this.spcMain.Panel1.Controls.Add(this.label3);
            this.spcMain.Panel1.Controls.Add(this.tbxOutputPath);
            this.spcMain.Panel1.Controls.Add(this.label7);
            this.spcMain.Panel1.Controls.Add(this.tbxMemo);
            this.spcMain.Panel1.Controls.Add(this.btnFolder);
            this.spcMain.Panel1.Controls.Add(this.btnOutput);
            this.spcMain.Panel1.Controls.Add(this.btnCreate);
            this.spcMain.Panel1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.dgvDetial);
            this.spcMain.Size = new System.Drawing.Size(988, 600);
            this.spcMain.SplitterDistance = 300;
            this.spcMain.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(287, 201);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(135, 19);
            this.label13.TabIndex = 39;
            this.label13.Text = "等待製作數量";
            // 
            // Nontbx1
            // 
            this.Nontbx1.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Nontbx1.ForeColor = System.Drawing.Color.Red;
            this.Nontbx1.Location = new System.Drawing.Point(424, 198);
            this.Nontbx1.Name = "Nontbx1";
            this.Nontbx1.ReadOnly = true;
            this.Nontbx1.Size = new System.Drawing.Size(107, 30);
            this.Nontbx1.TabIndex = 38;
            // 
            // btnOutput2
            // 
            this.btnOutput2.BackColor = System.Drawing.Color.Transparent;
            this.btnOutput2.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOutput2.ForeColor = System.Drawing.Color.Red;
            this.btnOutput2.Location = new System.Drawing.Point(159, 262);
            this.btnOutput2.Name = "btnOutput2";
            this.btnOutput2.Size = new System.Drawing.Size(112, 40);
            this.btnOutput2.TabIndex = 34;
            this.btnOutput2.Text = "工單輸出";
            this.btnOutput2.UseVisualStyleBackColor = false;
            this.btnOutput2.Click += new System.EventHandler(this.btnOutput2_Click);
            // 
            // tbxCustcName
            // 
            this.tbxCustcName.Location = new System.Drawing.Point(424, 25);
            this.tbxCustcName.Name = "tbxCustcName";
            this.tbxCustcName.ReadOnly = true;
            this.tbxCustcName.Size = new System.Drawing.Size(305, 30);
            this.tbxCustcName.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(163, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "客戶編號";
            // 
            // tbxCustomName
            // 
            this.tbxCustomName.Location = new System.Drawing.Point(262, 24);
            this.tbxCustomName.MaxLength = 5;
            this.tbxCustomName.Name = "tbxCustomName";
            this.tbxCustomName.Size = new System.Drawing.Size(160, 30);
            this.tbxCustomName.TabIndex = 1;
            this.tbxCustomName.TextChanged += new System.EventHandler(this.tbxCustomName_TextChanged);
            // 
            // btnNonSelect
            // 
            this.btnNonSelect.BackColor = System.Drawing.Color.PowderBlue;
            this.btnNonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNonSelect.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNonSelect.Location = new System.Drawing.Point(380, 266);
            this.btnNonSelect.Name = "btnNonSelect";
            this.btnNonSelect.Size = new System.Drawing.Size(100, 30);
            this.btnNonSelect.TabIndex = 31;
            this.btnNonSelect.Text = "全不選";
            this.btnNonSelect.UseVisualStyleBackColor = false;
            this.btnNonSelect.Click += new System.EventHandler(this.btnNonSelect_Click);
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAllSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAllSelect.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAllSelect.Location = new System.Drawing.Point(274, 266);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(100, 30);
            this.btnAllSelect.TabIndex = 30;
            this.btnAllSelect.Text = "全選";
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxWorkNumber, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxRightDegree, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbx222, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbxLeftDegree, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxAddDegree, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxCreateMan, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxGlassType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxFrameMode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 3);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(159, 57);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 133);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tbxWorkNumber
            // 
            this.tbxWorkNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxWorkNumber.Location = new System.Drawing.Point(103, 3);
            this.tbxWorkNumber.MaxLength = 8;
            this.tbxWorkNumber.Name = "tbxWorkNumber";
            this.tbxWorkNumber.Size = new System.Drawing.Size(159, 30);
            this.tbxWorkNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "R度數";
            // 
            // tbxRightDegree
            // 
            this.tbxRightDegree.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxRightDegree.Location = new System.Drawing.Point(371, 36);
            this.tbxRightDegree.MaxLength = 14;
            this.tbxRightDegree.Name = "tbxRightDegree";
            this.tbxRightDegree.Size = new System.Drawing.Size(199, 30);
            this.tbxRightDegree.TabIndex = 7;
            // 
            // tbx222
            // 
            this.tbx222.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbx222.AutoSize = true;
            this.tbx222.Location = new System.Drawing.Point(303, 73);
            this.tbx222.Name = "tbx222";
            this.tbx222.Size = new System.Drawing.Size(62, 19);
            this.tbx222.TabIndex = 10;
            this.tbx222.Text = "L度數";
            // 
            // tbxLeftDegree
            // 
            this.tbxLeftDegree.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxLeftDegree.Location = new System.Drawing.Point(371, 69);
            this.tbxLeftDegree.MaxLength = 14;
            this.tbxLeftDegree.Name = "tbxLeftDegree";
            this.tbxLeftDegree.Size = new System.Drawing.Size(199, 30);
            this.tbxLeftDegree.TabIndex = 8;
            // 
            // cbxAddDegree
            // 
            this.cbxAddDegree.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxAddDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAddDegree.FormattingEnabled = true;
            this.cbxAddDegree.Location = new System.Drawing.Point(371, 105);
            this.cbxAddDegree.Name = "cbxAddDegree";
            this.cbxAddDegree.Size = new System.Drawing.Size(199, 27);
            this.cbxAddDegree.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(272, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 19);
            this.label10.TabIndex = 31;
            this.label10.Text = "焦點設定";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbtnMulti);
            this.panel1.Controls.Add(this.rbtnSignal);
            this.panel1.Location = new System.Drawing.Point(371, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 27);
            this.panel1.TabIndex = 6;
            // 
            // rbtnMulti
            // 
            this.rbtnMulti.AutoSize = true;
            this.rbtnMulti.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnMulti.Location = new System.Drawing.Point(85, 3);
            this.rbtnMulti.Name = "rbtnMulti";
            this.rbtnMulti.Size = new System.Drawing.Size(60, 20);
            this.rbtnMulti.TabIndex = 34;
            this.rbtnMulti.Text = "多焦";
            this.rbtnMulti.UseVisualStyleBackColor = true;
            // 
            // rbtnSignal
            // 
            this.rbtnSignal.AutoSize = true;
            this.rbtnSignal.Checked = true;
            this.rbtnSignal.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnSignal.Location = new System.Drawing.Point(3, 3);
            this.rbtnSignal.Name = "rbtnSignal";
            this.rbtnSignal.Size = new System.Drawing.Size(60, 20);
            this.rbtnSignal.TabIndex = 34;
            this.rbtnSignal.TabStop = true;
            this.rbtnSignal.Text = "單焦";
            this.rbtnSignal.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(25, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 19);
            this.label9.TabIndex = 25;
            this.label9.Text = "製作人";
            // 
            // cbxCreateMan
            // 
            this.cbxCreateMan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxCreateMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCreateMan.FormattingEnabled = true;
            this.cbxCreateMan.Location = new System.Drawing.Point(103, 105);
            this.cbxCreateMan.Name = "cbxCreateMan";
            this.cbxCreateMan.Size = new System.Drawing.Size(159, 27);
            this.cbxCreateMan.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(46, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 19);
            this.label12.TabIndex = 30;
            this.label12.Text = "片種";
            // 
            // tbxGlassType
            // 
            this.tbxGlassType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxGlassType.Location = new System.Drawing.Point(103, 36);
            this.tbxGlassType.Name = "tbxGlassType";
            this.tbxGlassType.Size = new System.Drawing.Size(159, 30);
            this.tbxGlassType.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(4, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 19);
            this.label8.TabIndex = 22;
            this.label8.Text = "框型種類";
            // 
            // cbxFrameMode
            // 
            this.cbxFrameMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxFrameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFrameMode.FormattingEnabled = true;
            this.cbxFrameMode.Location = new System.Drawing.Point(103, 72);
            this.cbxFrameMode.Name = "cbxFrameMode";
            this.cbxFrameMode.Size = new System.Drawing.Size(159, 27);
            this.cbxFrameMode.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(314, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 19);
            this.label11.TabIndex = 29;
            this.label11.Text = "類型";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(809, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = ".xlsx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(583, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "輸出檔名";
            // 
            // tbxOutputFileName
            // 
            this.tbxOutputFileName.Location = new System.Drawing.Point(678, 234);
            this.tbxOutputFileName.Name = "tbxOutputFileName";
            this.tbxOutputFileName.Size = new System.Drawing.Size(125, 30);
            this.tbxOutputFileName.TabIndex = 18;
            this.tbxOutputFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(486, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "輸出路徑";
            // 
            // tbxOutputPath
            // 
            this.tbxOutputPath.Location = new System.Drawing.Point(581, 270);
            this.tbxOutputPath.Name = "tbxOutputPath";
            this.tbxOutputPath.ReadOnly = true;
            this.tbxOutputPath.Size = new System.Drawing.Size(222, 30);
            this.tbxOutputPath.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "備註";
            // 
            // tbxMemo
            // 
            this.tbxMemo.Location = new System.Drawing.Point(331, 234);
            this.tbxMemo.Multiline = true;
            this.tbxMemo.Name = "tbxMemo";
            this.tbxMemo.Size = new System.Drawing.Size(246, 27);
            this.tbxMemo.TabIndex = 10;
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(809, 270);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(34, 28);
            this.btnFolder.TabIndex = 16;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.BackColor = System.Drawing.Color.Transparent;
            this.btnOutput.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOutput.ForeColor = System.Drawing.Color.Red;
            this.btnOutput.Location = new System.Drawing.Point(159, 213);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(112, 44);
            this.btnOutput.TabIndex = 12;
            this.btnOutput.Text = "條碼輸出";
            this.btnOutput.UseVisualStyleBackColor = false;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
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
            this.dgvDetial.Size = new System.Drawing.Size(988, 296);
            this.dgvDetial.TabIndex = 0;
            // 
            // WorkCreateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorkCreateControl";
            this.Size = new System.Drawing.Size(988, 600);
            this.Load += new System.EventHandler(this.WorkCreateControl_Load);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxMemo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxCustomName;
        private NumberTextBox tbxWorkNumber;
        private System.Windows.Forms.Label tbx222;
        private System.Windows.Forms.TextBox tbxLeftDegree;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxRightDegree;
        private System.Windows.Forms.DataGridView dgvDetial;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxOutputFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxOutputPath;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxFrameMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbxCreateMan;
        private System.Windows.Forms.TextBox tbxGlassType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxAddDegree;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnMulti;
        private System.Windows.Forms.RadioButton rbtnSignal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnNonSelect;
        private System.Windows.Forms.Button btnAllSelect;
        private System.Windows.Forms.TextBox tbxCustcName;
        private System.Windows.Forms.Button btnOutput2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Nontbx1;
    }
}
