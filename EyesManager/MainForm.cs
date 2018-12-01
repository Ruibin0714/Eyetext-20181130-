using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EyesManager
{
    public partial class MainForm : Form
    {
        MainController _mainController;
        WorkManager _workManager;

        Control _current = new Control();

        public MainForm(MainController mainController)
        {
            InitializeComponent();
            _mainController = mainController;
            _workManager = mainController.WorkManager;

            _mainController.OnWorking += new Action<bool>(_mainController_OnWorking);
        }

        void _mainController_OnWorking(bool working)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(_mainController_OnWorking), new object[] { working });
            }
            else
            {
                toolSetting.Enabled = !working;
                toolWorkCreate.Enabled = !working;
                toolWorkMaintain.Enabled = !working;
                toolWorkSee.Enabled = !working;
                toolConnect.Enabled = !working;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += " - " + DefineSeting.LoginStepName + " - " + DefineSeting.Version;

            if (int.Parse(DefineSeting.LoginStepNo) == 0)
            {
                toolConnect.Visible = false;
                toolWorkCreate.Visible = false;
            }
            else if (int.Parse(DefineSeting.LoginStepNo) == 1)
            {
                toolConnect.Visible = false;
                toolWorkMaintain.Visible = false;
                toolWorkSee.Visible = false;
            }
            else
            {
                toolWorkCreate.Visible = false;
                toolWorkMaintain.Visible = false;
                toolWorkSee.Visible = false;
            }

            _mainController.Communication.OnConnected += new Action<bool>(_communication_OnConnected);
            _mainController.Communication.OnStatusChanged += new Action<string>(_communication_OnStatusChanged);

            if (_workManager.Communication.Connected == false)
            {
                toolConnect.Visible = false;
                toolWorkCreate.Visible = false;
                toolWorkMaintain.Visible = false;
                toolWorkSee.Visible = false;
            }


            _communication_OnConnected(_workManager.Communication.Connected);

        }

        void _communication_OnStatusChanged(string obj)
        {
            if (InvokeRequired)
                this.Invoke(new Action<string>(_communication_OnStatusChanged), new object[] { obj });
            else
                tssa.Text = obj;

        }

        void _communication_OnConnected(bool connected)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(_communication_OnConnected), new object[] { connected });
            }
            else
            {
                if (connected)
                {
                    tsspStatus.Text = "連線正常";
                    tsspStatus.ForeColor = Color.Green;
                }
                else
                {
                    tsspStatus.Text = "連線失敗";
                    tsspStatus.ForeColor = Color.Red;
                }
            }
        }

        private void toolSetting_Click(object sender, EventArgs e)
        {
            palMain.Controls.Clear();

            SettingControl usc = new SettingControl(_mainController);
            palMain.Controls.Add(usc);

        }

        private void toolConnect_Click(object sender, EventArgs e)
        {
            palMain.Controls.Clear();
            WorkConnectControl wcc = new WorkConnectControl(_mainController);
            palMain.Controls.Add(wcc);
            wcc.Dock = DockStyle.Fill;
        }

        private void toolWorkCreate_Click(object sender, EventArgs e)
        {
            palMain.Controls.Clear();
            WorkCreateControl wcc = new WorkCreateControl(_mainController);
            palMain.Controls.Add(wcc);
            wcc.Dock = DockStyle.Fill;
        }

        private void toolWorkMaintain_Click(object sender, EventArgs e)
        {
            palMain.Controls.Clear();
            WorkMaintainControl wmc = new WorkMaintainControl(_mainController);
            palMain.Controls.Add(wmc);
            wmc.Dock = DockStyle.Fill;
        }

        private void toolWorkSee_Click(object sender, EventArgs e)
        {
            palMain.Controls.Clear();
            WorkSeeControl wsc = new WorkSeeControl(_mainController);
            palMain.Controls.Add(wsc);
            wsc.Dock = DockStyle.Fill;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    {
                        System.Windows.Forms.SendKeys.Send("{TAB}");
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
