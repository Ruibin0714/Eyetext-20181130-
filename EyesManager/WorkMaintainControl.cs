using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Threading;

namespace EyesManager
{
    public partial class WorkMaintainControl : UserControl//工作維護控制
    {
        MainController _mainController;
        WorkManager _workManager;
        string _outPutFullPath = "";
        string _status = "";
        string _workNumber = "";
        string _customName = "";
        string _type = "";      
        string _step="";
        string _create = "";






        private void btnSearch_Click(object sender, EventArgs e)
        {

            
            _status = cbxMode.Text;
            _workNumber = tbxWorkNumber.Text.Trim();
            _customName = tbxCustomName.Text.Trim();
            _type = cbxderge.Text.Trim();
            _create = cbxcreate.Text.Trim();
            tbxCustomName.Text = "";
            tbxWorkNumber.Text = "";
            
           
            
           
             Thread t = new Thread(loadData);
             
            t.IsBackground = true;
            t.Start();

        }

        public WorkMaintainControl(MainController mainController)
        {
            InitializeComponent();
            _mainController = mainController;
            _workManager = mainController.WorkManager;

            int Num, Fin;
            Num = _workManager.GetNoncont();

            Fin = _workManager.GetFincont();

            Nontbx1.Text = Convert.ToString(Num);

            Fintbx1.Text = Convert.ToString(Fin);


        }

        private void WorkMaintainControl_Load(object sender, EventArgs e)
        {
            // laod field
            int a, b;
            _workManager.CreateDataGridView(dgvWorkHead);
            
            cbxMode.Items.Add("全部");
            cbxMode.Items.Add("未完成");
            cbxMode.Items.Add("完成");

            List<string> items = _workManager.LoadFrameMode();
            items = _workManager.LoadDegree();
            for (int i = 0; i < items.Count; i++)    
            {
                cbxderge.Items.Add(items[i]);
            }
           


            List<string> item = _workManager.LoadFrameMode();
            item = _workManager.LoadCreateMan();
            for (int i = 0; i < item.Count; i++)
            {
                cbxcreate.Items.Add(item[i]);
            }
           




            cbxMode.SelectedIndex = 0;

            tbxOutputFileName.Text = DateTime.Now.ToString("HHmmss");
            tbxOutputPath.Text = DefineSeting.OutPath;
           

            for (int i = 1; i < dgvWorkHead.Columns.Count; i++)
			{
                
                dgvWorkHead.Columns[i].ReadOnly = true;
			}

        }

        private void loadData()
        {
            List<WorkModel> workModels = new List<WorkModel>();


            if (_status == "未完成" | _status == "全部")
            {
                workModels.AddRange(_workManager.GetNonFinishWork());

                foreach (WorkModel item in workModels)
                {
                    
                    item.Status = "未完成";
                }
            }

            if (_status == "完成" | _status == "全部")
            {
                workModels.AddRange(_workManager.GetFinishWork());
                foreach (WorkModel item in workModels)
                {
                    if (item.Status == "")
                        item.Status = "完成";
                }
            }

            if (_workNumber != "")
            {
                workModels = workModels.FindAll(x => x.WorkNumber.Contains(_workNumber));
               
            }

            if (_customName != "")
            {
                workModels = workModels.FindAll(x => x.CustomName.Contains(_customName));

            }
            if (_step != "")
            {
                workModels = workModels.FindAll(x => x.CustomName.Contains(_customName));

            }

            if (_type != "")
            {
                workModels = workModels.FindAll(x => x.AddDegree.Contains(_type));

            }

            if (_create != "")
            {
                workModels = workModels.FindAll(x => x.CreateMan.Contains(_create));

            }


            workModels = workModels.OrderBy(x => x.WorkCreateDate).ToList();

            dgvInser(workModels);

            int con;
            con = workModels.Count;
            tbxnom.Text = Convert.ToString(con);

        }

        private void dgvInser(List<WorkModel> workModels)
        {   
            
            if (InvokeRequired)
            {
                this.Invoke(new Action<List<WorkModel>>(dgvInser), new object[] { workModels });
            }
            else
            {
                dgvWorkHead.Rows.Clear();
                if (workModels.Count > 0)
                {
                    int rowIndex = 0;
                    foreach (WorkModel workModel in workModels)
                    {
                        _workManager.LoadDataToDgv(dgvWorkHead, workModel, rowIndex);
                        //dgvWorkHead.Rows.Add(new object[] { false, 
                        //                             //   workModel.WorkCreateDate,
                        //                                workModel.WorkNumber,
                        //                                workModel.CustomName, 
                        //                                workModel.RightDegree, 
                        //                                workModel.LeftDegree,
                        //                                workModel.FrameMode,
                        //                                workModel.Degree,
                        //                                workModel.GlassType,
                        //                                workModel.AddDegree,
                        //                                workModel.CreateMan,
                        //                                workModel.Memo });
                        //int startcol = dgvWorkHead.Columns.Count - workModel.Step.Count;
                        //for (int stepNo = 0; stepNo < workModel.Step.Count; stepNo++)
                        //{
                        //    if (workModel.Step[stepNo + 1] != DateTime.MinValue)
                        //        dgvWorkHead[startcol, rowIndex].Value = workModel.Step[stepNo + 1];
                        //    startcol++;
                        //}
                        rowIndex++;
                    }
                }
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (dgvWorkHead.Rows.Count == 0)
            {
                MessageBox.Show("沒有檔案可以輸出!");
                return;
            }

            List<WorkModel> workModels = _workManager.ReadDgvToModel(dgvWorkHead);

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

            if (Directory.Exists(tbxOutputPath.Text) == false)
            {
                MessageBox.Show(tbxOutputPath.Text + "找不到此路徑!");
                return;
            }

            
            _mainController.SetSavePath(tbxOutputPath.Text);

            setControl(true);

            _outPutFullPath = tbxOutputPath.Text + "\\" + tbxOutputFileName.Text + ".xlsx";
            Thread thread = new Thread(output);
            thread.IsBackground = true;
            thread.Start(workModels);
        }

        private void output(object i)
        {
            string message = _workManager.OutputFullFile((List<WorkModel>)i, _outPutFullPath);
            setControl(false);
        }

        private void setControl(bool working)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(setControl), new object[] { working });
            }
            else
            {
                _mainController.DoWork(working);
                btnFolder.Enabled = !working;
                btnOutput.Enabled = !working;
                btnSearch.Enabled = !working;
                cbxMode.Enabled = !working;
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbxOutputPath.Text = fbd.SelectedPath;
            }
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvWorkHead.Rows.Count; i++)
            {
                dgvWorkHead[0, i].Value = true;
            }
        }

        private void btnNonSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvWorkHead.Rows.Count; i++)
            {
                dgvWorkHead[0, i].Value = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            List<string> indexList = getSelectList();

            if (indexList.Count == 0)
            {
                MessageBox.Show("請選擇工單!");
                return;
            }
            else if (indexList.Count > 1)
            {
                MessageBox.Show("一次只能編輯一張工單!");
                return;
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> indexList = getSelectList();

            if (indexList.Count == 0)
            {
                MessageBox.Show("請選擇工單!");
                return;
            }

            if (MessageBox.Show(string.Format("您確定要刪除以下工單嗎?\n{0}", string.Join("\n", indexList)), "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                setControl(true);
                Thread thread = new Thread(deleteData);
                thread.IsBackground = true;
                thread.Start(indexList);
                tbxWorkNumber.Text = "";

            }
        }

        private void deleteData(object indexList)
        {
            _workManager.Delete((List<string>)indexList);
            _workManager.Delete1((List<string>)indexList);
            deleteRow((List<string>)indexList);
            setControl(false);
        }

        private void deleteRow(List<string> indexList)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<List<string>>(deleteRow), new object[] { indexList });
            }
            else
            {
                for (int rowIndex = dgvWorkHead.Rows.Count - 1; rowIndex >= 0; rowIndex--)
                {
                    if ((bool)dgvWorkHead[0, rowIndex].Value == true)
                        dgvWorkHead.Rows.RemoveAt(rowIndex);
                }
            }
        }

        private List<string> getSelectList()
        {
            List<string> indexList = new List<string>();

            for (int rowIndex = 0; rowIndex < dgvWorkHead.Rows.Count; rowIndex++)
            {
                if ((bool)dgvWorkHead[0, rowIndex].Value == true)
                {
                    indexList.Add(dgvWorkHead[1, rowIndex].Value.ToString());
                }
            }

            return indexList;
        }

        private void btnOutput2_Click(object sender, EventArgs e)
        {
            if (dgvWorkHead.Rows.Count == 0)
            {
                MessageBox.Show("沒有檔案可以輸出!");
                return;
            }

            List<WorkModel> workModels = _workManager.ReadDgvToModel(dgvWorkHead);

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
        private void output2(object i)
        {
            string message = _workManager.Output2((List<WorkModel>)i, _outPutFullPath);
            setControl(false, null);
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

                btnSearch.Enabled = !working;
                btnFolder.Enabled = !working;
                btnOutput.Enabled = !working;

                if (working == false & workModel != null)

                    _workManager.LoadDataToDgv(dgvWorkHead, workModel, 0);

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

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            Nontbx1.Text = "";
            Fintbx1.Text = "";
            tbxnom.Text = "";
                  
            int Num ,Fin,Non;
            Non =

            Num = _workManager.GetNoncont();

            Fin = _workManager.GetFincont();

            Nontbx1.Text = Convert.ToString(Num);

            Fintbx1.Text = Convert.ToString(Fin);


        }
    }

    }

