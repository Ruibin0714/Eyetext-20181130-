using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace EyesManager
{
    public partial class WorkSeeControl : UserControl
    {
        MainController _mainController;
        WorkManager _workManager;
        IniManager _localIniManager;
        List<WorkModel> _workModel = new List<WorkModel>();

        bool _showFinish = false;
        Thread _thread;

        public WorkSeeControl(MainController mainController)
        {
            InitializeComponent();

            _mainController = mainController;
            _workManager = mainController.WorkManager;
            _localIniManager = mainController.LocalIniManager;
        }

        private void WorkSeeControl_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 60; i++)
                cbxDays.Items.Add(i + 1);
            cbxDays.Text = DefineSeting.Day.ToString();

            cbxSeconds.Items.AddRange(new string[] { "10", "20", "30", "40", "50", "60", "90", "120", "180", "300", "480", "600" });
            cbxSeconds.Text = DefineSeting.Second.ToString();

            _workManager.CreateDataGridView(dgvDetial);
            dgvDetial.Columns[0].Visible = false;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (btnRun.Text == "開始追蹤")
            {
                setControls(true);
                timer.Interval = Convert.ToInt32(cbxSeconds.Text) * 1000;
                _mainController.SetDay(cbxDays.Text);
                _mainController.SetSecond(cbxSeconds.Text);
                _showFinish = cbbShowFinish.Checked;

                timer_Tick(null, null);

                timer.Enabled = true;
                btnRun.Text = "結束";
            }
            else
            {
                if (_thread.ThreadState == ThreadState.Running)
                    _thread.Abort();
                setControls(false);
                timer.Enabled = false;
                btnRun.Text = "開始追蹤";
            }

        }

        private void setControls(bool running)
        {
            cbxDays.Enabled = !running;
            cbxSeconds.Enabled = !running;
            cbbShowFinish.Enabled = !running;

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _thread = new Thread(loadData);
            _thread.IsBackground = true;
            _thread.Start();
        }

        private void loadData()
        {
            _mainController.DoWork(true);
            _workModel = _workManager.GetWork(DefineSeting.Day, _showFinish);
            dgvInser(_workModel);
            _mainController.DoWork(false);
        }

        private void dgvInser(List<WorkModel> workModels)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<List<WorkModel>>(dgvInser), new object[] { workModels });
            }
            else
            {
               
                dgvDetial.Rows.Clear();
                for (int rowIndex = 0; rowIndex < _workModel.Count; rowIndex++)
                {
                    _workManager.LoadDataToDgv(dgvDetial, _workModel[rowIndex], rowIndex);
                }

                
            }
        }
    }
}
