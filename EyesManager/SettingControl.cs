using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EyesManager
{
    public partial class SettingControl : UserControl
    {
        MainController _mainController;
        WorkManager _workManager;

        public SettingControl(MainController mainController)
        {
            InitializeComponent();
            _mainController = mainController;
            _workManager = mainController.WorkManager;

            tbxServerPath.Text = DefineSeting.ServerPath;

            cbxTimeout.Items.AddRange(new object[] { 10, 20, 30, 40, 50, 60 });
            cbxTimeout.Text = DefineSeting.TimeOutSecond.ToString();

            cbxFinishTime.Visible = false;
            label5.Visible = false;
            label4.Visible = false;

            if (DefineSeting.LoginStepNo.Trim() != "")
            {
                if (Convert.ToInt32(DefineSeting.LoginStepNo) > 0)
                {
                    cbxFinishTime.Visible = true;
                    label5.Visible = true;
                    label4.Visible = true;
                    cbxFinishTime.Items.AddRange(new object[] { 0.5, 1, 1.2, 1.4, 1.6, 1.8, 2, 2.2, 2.4, 2.6, 2.8, 3 });
                    cbxFinishTime.Text = DefineSeting.FinishTime.ToString();
                }
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbxServerPath.Text = fbd.SelectedPath;
                _mainController.SetServerPath(tbxServerPath.Text);
                _workManager.ConnectTest();
            }
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            bool connected = _workManager.Communication.Connected;

            if (_workManager.ConnectTest())
            {
                if (connected == false)
                    MessageBox.Show("成功!\n請重新啟動程式!", "連線測試");
                else
                    MessageBox.Show("成功!", "連線測試");
            }
            else
                MessageBox.Show("失敗!", "連線測試");
        }

        private void cbxTimeout_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mainController.SetTimeout(cbxTimeout.Text);
        }

        private void cbxFinishTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mainController.SetFinishTime(cbxFinishTime.Text);
        }

    }
}
