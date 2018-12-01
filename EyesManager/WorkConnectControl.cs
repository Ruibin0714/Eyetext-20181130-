using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace EyesManager
{
    public partial class WorkConnectControl : UserControl
    {
        MainController _mainController;
        WorkManager _workManager;

        List<WorkModel> _currentWorkModel = new List<WorkModel>();

        Queue<WorkModel> _inserWorkModel = new Queue<WorkModel>();
        ManualResetEvent _idleCommandSendEvent;
        Thread _threadUpdate;
        int _time = 0;

        public WorkConnectControl(MainController mainController)
        {
            InitializeComponent();

            _mainController = mainController;
            _workManager = mainController.WorkManager;
        }

        private void WorkConnectControl_Load(object sender, EventArgs e)
        {
            _workManager.CreateDataGridView(dgvDetial);
            dgvDetial.Columns[0].Visible = false;

            Thread t = new Thread(loadData);
            t.Name = "WorkLoad";
            t.IsBackground = true;
            t.Start();

            tbxWorkNumber.Focus();

            _idleCommandSendEvent = new ManualResetEvent(false);
            _threadUpdate = new Thread(UpdateData);
            _threadUpdate.IsBackground = true;
            _threadUpdate.Name = "WorkConnect";
            _threadUpdate.Start();


        }

        private void loadData()
        {


            _currentWorkModel = _workManager.GetNonFinishWork(int.Parse(DefineSeting.LoginStepNo));

            dgvInser(_currentWorkModel);


        } 
           
        

        private void dgvInser(List<WorkModel> workModels)
        {
            if (InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action<List<WorkModel>>(dgvInser), new object[] { workModels });
                }
                catch
                {


                }

            }
            else
            {
                try
                {
                    int index = 0;
                    foreach (var workModel in _currentWorkModel.OrderBy(x => x.WorkCreateDate).ToList())
                    {
                        _workManager.LoadDataToDgv(dgvDetial, workModel, index);
                        index++;
                        //     dgvDetial.Rows.Insert(0, new object[] { workModel.WorkCreateDate, workModel.WorkNumber, workModel.CustomName, workModel.RightDegree, workModel.LeftDegree, workModel.Memo });
                    }
                }
                catch //(Exception)
                {

                    // throw;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _time -= timer1.Interval;

            if (_time <= 0)
            {
                if (tbxWorkNumber.Text.Trim() != "")
                {
                    var curent = _currentWorkModel.Find(x => x.WorkNumber == tbxWorkNumber.Text);
                    if (curent == null)
                    {
                        labStatus.Text = string.Format("工單號:{0} - 查無此工單!", tbxWorkNumber.Text);
                        tbxWorkNumber.Text = "";
                    }
                    else
                    {
                        labStatus.Text = string.Format("工單號:{0} - 完成!", tbxWorkNumber.Text);
                        curent.Step[int.Parse(DefineSeting.LoginStepNo)] = DateTime.Now;

                        setControl(true, curent);

                        _inserWorkModel.Enqueue(curent);
                        _idleCommandSendEvent.Set();
                    }
                }

                timer1.Enabled = false;
            }
        }

        private void tbxWorkNumber_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            _time = (int)(DefineSeting.FinishTime * 900);
        }

        private void setControl(bool working, WorkModel workModel)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool, WorkModel>(setControl), new object[] { working, workModel });

            }
            else
            {
                if (_workManager.Communication.Connected)
                {
                    tbxWorkNumber.Enabled = !working;

                    _mainController.DoWork(working);

                    if (working)
                    {

                    }
                    else
                    {
                        for (int i = 0; i < dgvDetial.Rows.Count; i++)
                        {
                            if (dgvDetial[1, i].Value.ToString() == tbxWorkNumber.Text)
                            {
                                dgvDetial.Rows.RemoveAt(i);
                                break;
                            }
                        }

                        tbxWorkNumber.Text = "";
                        tbxWorkNumber.Focus();
                    }
                }
                else
                {
                    tbxWorkNumber.Enabled = false;
                }
            }
        }

        private void UpdateData()
        {
            while (true)
            {
                if (_inserWorkModel.Count == 0)
                    _idleCommandSendEvent.WaitOne();
                else
                {
                    WorkModel workModel = _inserWorkModel.Dequeue();

                    if (_workManager.UpdateWorkNumber(workModel, int.Parse(DefineSeting.LoginStepNo)))
                    {
                        // 如果是最後一站，將未完成的搬到已完成
                        if (int.Parse(DefineSeting.LoginStepNo) == _workManager.StepList.Count)
                        {
                            if (_workManager.changeToFinish(tbxWorkNumber.Text))
                            {

                            }
                        }

                        _currentWorkModel.Remove(workModel);

                        setControl(false, workModel);
                    }
                }

            }
        }

       
    }
}
