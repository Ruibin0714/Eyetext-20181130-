using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace EyesManager
{
    public partial class WorkCreateControl : UserControl //工作創建控制
    {
        MainController _mainController;
        WorkManager _workManager;
        Queue<WorkModel> _inserWorkModel = new Queue<WorkModel>();
        ManualResetEvent _idleCommandSendEvent;       
        Thread _threadUpdate;
        string _outPutFullPath = "";
        List<Customer> _customers = new List<Customer>();

        public WorkCreateControl(MainController mainController)
        {
            InitializeComponent();
            _mainController = mainController;
            _workManager = mainController.WorkManager;
           

        }

        private void WorkCreateControl_Load(object sender, EventArgs e)
        {
            _workManager.CreateDataGridView(dgvDetial);

            Thread t = new Thread(loadData);
            t.IsBackground = true;
            t.Start();

            tbxOutputFileName.Text = DateTime.Now.ToString("HHmmss");
            tbxOutputPath.Text = DefineSeting.OutPath;

            _idleCommandSendEvent = new ManualResetEvent(false);
            _threadUpdate = new Thread(UpdateData);
            _threadUpdate.IsBackground = true;
            _threadUpdate.Name = "WorkCreate";
            _threadUpdate.Start();

            // FrameMOde
            List<string> items = _workManager.LoadFrameMode();
            for (int i = 0; i < items.Count; i++)
                cbxFrameMode.Items.Add(items[i]);

            // Degree
            items = _workManager.LoadDegree();
            for (int i = 0; i < items.Count; i++)
                cbxAddDegree.Items.Add(items[i]);

            // FrameMOde
            items = _workManager.LoadCreateMan();
            for (int i = 0; i < items.Count; i++)
                cbxCreateMan.Items.Add(items[i]);

            tbxCustomName.Focus();
        }


        private void loadData()//動態參考
        {
                List<WorkModel> workModels = _workManager.GetNonFinishWork(int.Parse(DefineSeting.LoginStepNo));

                dgvInser(workModels);

                CustomerManager cm = new CustomerManager();
                _customers = cm.GetAll();          
           
        }

        private void dgvInser(List<WorkModel> workModels)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<List<WorkModel>>(dgvInser), new object[] { workModels });
            }
            else
            {

                foreach (WorkModel workModel in workModels)
                {
                    _workManager.LoadDataToDgv(dgvDetial, workModel, 0);
                    //dgvDetial.Rows.Insert(0, new object[] { false, 
                    //                                    workModel.WorkCreateDate,
                    //                                    workModel.WorkNumber,
                    //                                    workModel.CustomName, 
                    //                                    workModel.CustcName,
                    //                                    workModel.RightDegree, 
                    //                                    workModel.LeftDegree,
                    //                                    workModel.FrameMode,
                    //                                    workModel.Degree,
                    //                                    workModel.GlassType,
                    //                                    workModel.AddDegree,
                    //                                    workModel.CreateMan,
                    //                                    workModel.Memo });
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            bool success = true;
            string field = "";

            // 以下為防呆檢查
            if (tbxWorkNumber.Text.Trim() == "")
            {
                success = false;
                field += "工單單號、";
            }

            // 檢查工單號是否重覆
            if (_mainController.IsExistWorkId(tbxWorkNumber.Text.Trim()))
            {
                success = false;
                field += "工單單號重覆,請重新確認工單號碼";
            }

            if (_mainController.IsExitsWorkNom(tbxWorkNumber.Text.Trim()))
            {
                success = false;
                field += "工單單號未滿8碼,請重新確認工單號碼";
            }

            if (tbxCustomName.Text.Trim() == "")
            {
                success = false;
                field += "客戶編號、";
            }
            if (cbxFrameMode.Text.Trim() == "")
            {
                success = false;
                field += "框型種類、";
            }
            if (tbxGlassType.Text.Trim() == "")
            {
                success = false;
                field += "片種、";
            }
            if (cbxCreateMan.Text.Trim() == "")
            {
                success = false;
                field += "製作人、";
            }



            if (success == false)
            {
                success = false;
                MessageBox.Show(string.Format("資料不完整!\n{0}", field.TrimEnd('、')), "建立失敗");
                return;
            }

            //以下為載入資料
            WorkModel workModel = new WorkModel();
            workModel.WorkNumber = tbxWorkNumber.Text.Trim();
            workModel.CustomName = tbxCustomName.Text.Trim();        
            workModel.CustcName = tbxCustcName.Text.Trim();
            workModel.RightDegree = tbxRightDegree.Text.Trim();
            workModel.LeftDegree = tbxLeftDegree.Text.Trim();
            workModel.Memo = tbxMemo.Text.Trim();
            workModel.FrameMode = cbxFrameMode.Text;
            if (rbtnSignal.Checked)
                workModel.Degree = rbtnSignal.Text;

            else
                workModel.Degree = rbtnMulti.Text;
            workModel.GlassType = tbxGlassType.Text.Trim();
            workModel.CreateMan = cbxCreateMan.Text;
            workModel.AddDegree = cbxAddDegree.Text;
            
            setControl(true, workModel);

            _inserWorkModel.Enqueue(workModel);
            _idleCommandSendEvent.Set();
            textClear();

            WorkManager Text = new WorkManager();
            int Num;
            Num = _workManager.GetNoncont();
            Nontbx1.Text = Convert.ToString(Num);


        }


        private void textClear()
        {
            tbxWorkNumber.Text = "";
            tbxCustomName.Text = "";
            tbxCustcName.Text = "";
            tbxRightDegree.Text = "";
            tbxLeftDegree.Text = "";
            tbxMemo.Text = "";
            tbxGlassType.Text = "";
            Nontbx1.Text = "";

        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (dgvDetial.Rows.Count == 0)
            {
                MessageBox.Show("沒有檔案可以輸出!");
                return;
            }

            List<WorkModel> workModels = _workManager.ReadDgvToModel(dgvDetial);

            if (workModels.Count == 0)
            {
                MessageBox.Show("請選擇工單輸出!");
                return;
            }

            if (tbxOutputFileName.Text.Trim() == "")
            {
                MessageBox.Show("請輸入檔名!");
                return;
            }

            if (tbxOutputPath.Text.Trim() == "")
            {
                MessageBox.Show("請輸入路徑!");
                return;
            }

            _mainController.SetSavePath(tbxOutputPath.Text);

            setControl(true, null);

            _outPutFullPath = tbxOutputPath.Text + "\\" + tbxOutputFileName.Text + ".xlsx";
            Thread thread = new Thread(output);
            thread.IsBackground = true;
            thread.Start(workModels);
        }

        private void btnOutput2_Click(object sender, EventArgs e)
        {
            if (dgvDetial.Rows.Count == 0)
            {
                MessageBox.Show("沒有檔案可以輸出!");
                return;
            }

            List<WorkModel> workModels = _workManager.ReadDgvToModel(dgvDetial);

            if (workModels.Count == 0)
            {
                MessageBox.Show("請選擇工單輸出!");
                return;
            }

            if (tbxOutputFileName.Text.Trim() == "")
            {
                MessageBox.Show("請輸入檔名!");
                return;
            }

            if (tbxOutputPath.Text.Trim() == "")
            {
                MessageBox.Show("請輸入路徑!");
                return;
            }

            _mainController.SetSavePath(tbxOutputPath.Text);

            setControl(true, null);

            _outPutFullPath = tbxOutputPath.Text + "\\" + tbxOutputFileName.Text + ".xlsx";
            Thread thread = new Thread(output2);
            thread.IsBackground = true;
            thread.Start(workModels);
        }

        private void output(object i)
        {
            string message = _workManager.Output((List<WorkModel>)i, _outPutFullPath);
            setControl(false, null);
        }

        private void output2(object i)
        {
            string message = _workManager.Output2((List<WorkModel>)i, _outPutFullPath);
            setControl(false, null);
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbxOutputPath.Text = fbd.SelectedPath;
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

                    if (_workManager.CreateWorkNumber(workModel))
                        setControl(false, workModel);
                }

            }
        }

        private void setControl(bool working, WorkModel workModel)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool, WorkModel>(setControl), new object[] { working, workModel });
            }
            else
            {
                _mainController.DoWork(working);

                btnCreate.Enabled = !working;
                btnFolder.Enabled = !working;
                btnOutput.Enabled = !working;

                if (working == false & workModel != null)

                    _workManager.LoadDataToDgv(dgvDetial, workModel, 0);

                //dgvDetial.Rows.Insert(0, new object[] { true, 
                //                                    workModel.WorkCreateDate,
                //                                    workModel.WorkNumber,
                //                                    workModel.CustomName,
                //                                    workModel.CustcName,
                //                                    workModel.RightDegree, 
                //                                    workModel.LeftDegree,
                //                                    workModel.FrameMode,
                //                                    workModel.Degree,
                //                                    workModel.GlassType,
                //                                    workModel.AddDegree,
                //                                    workModel.CreateMan,
                //                                    workModel.Memo });
            }
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            for (int rowIndex = 0; rowIndex < dgvDetial.Rows.Count; rowIndex++)
            {
                dgvDetial[0, rowIndex].Value = true;
            }

        }

        private void btnNonSelect_Click(object sender, EventArgs e)
        {
            for (int rowIndex = 0; rowIndex < dgvDetial.Rows.Count; rowIndex++)
            {
                dgvDetial[0, rowIndex].Value = false;
            }
        }

        private void tbxCustomName_TextChanged(object sender, EventArgs e)
        {
            if (tbxCustomName.Text.Trim() == "")
            {
                tbxCustcName.Text = "";
            }
            else
            {
                Customer curr = _customers.Find(x => x.CustomerNo.Contains(tbxCustomName.Text.Trim()));
                if (curr == null)
                    tbxCustcName.Text = "";
                else
                    tbxCustcName.Text = curr.CustomerName;
            }
        }

      

        private void btnCreate_KeyDown(object sender, KeyEventArgs e)
        {
            Nontbx1.Text = "";
            WorkManager Text = new WorkManager();
            int Num;
            Num = _workManager.GetNoncont();
            Nontbx1.Text = Convert.ToString(Num);

        }
    }
}
