using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace EyesManager
{
    public class WorkManager//工作管理
    {
        const int _workNumber = 1;
        const int _workNo = 2;
        const int _workCreateDate = 3;
        const int _customName = 4;
        const int _custcName = 5;
        const int _r = 6;
        const int _l = 7;
        const int _frameMode = 8;
        const int _degree = 9;
        const int _glassType = 10;
        const int _addDegree = 11;
        const int _createMan = 12;
        const int _memo = 13;
        const int _stepStart = 14;


        #region DGV

        const int _col_check = 0;
        const int _colWorkNumber = 1;
        const int _colworkCreateDate = 3;
        const int _colcustomName = 4;
        const int _colcustcName = 5;//新加入        
        const int _colr = 6;
        const int _coll = 7;
        const int _colframeMode = 8;
        const int _coldegree = 8;
        const int _colglassType = 9;
        const int _coladdDegree = 10;
        const int _colcreateMan = 11;
        const int _colmemo = 12;

        const int _colStep1 = 13;
        const int _colStep2 = 14;
        const int _colStep3 = 15;
        const int _colStep4 = 16;

        #endregion

        private Communication _comm;

        public Communication Communication
        {
            get { return _comm; }
            set { _comm = value; }
        }

        

        private Dictionary<int, string> _stepList;

        public Dictionary<int, string> StepList
        {
            get { return _stepList; }
            set { _stepList = value; }
        }

        public WorkManager()
        {

        }

        #region Get

        /// <summary>
        ///  取得未完成的工單
        /// </summary>
        /// <returns></returns>
        public List<WorkModel> GetNonFinishWork()
        {
            _comm.Status = "檔案讀取中...";
            List<WorkModel> models = new List<WorkModel>();


            FileStream fs;// = new FileStream(DefineSeting.ServerNonFinish, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

            if (doConnect(out fs, DefineSeting.ServerNonFinish, false))
            {
                ExcelPackage ep = new ExcelPackage(fs);
                ExcelWorksheet sheet1 = ep.Workbook.Worksheets[1]; // 取得Sheet1

                for (int rowIndex = 2; rowIndex <= sheet1.Dimension.End.Row; rowIndex++)
                {
                    models.Add(getRowData(sheet1, rowIndex, _stepList));
                }

                fs.Close();
            }
            _comm.Status = "檔案載入完畢";
            return models;
        }

        public List<WorkModel> GetNonFinishWork(int step)//參考
        {
            _comm.Status = "檔案讀取中...";
            List<WorkModel> data = GetNonFinishWork();
            int lastStep = 0;

            // 本站 = step
            if (data.Count > 0 & step > 0)
            {
                if (step == 1)
                {
                    // 下一站為null的
                    data = data.Where(x => x.Step[step + 1] == DateTime.MinValue).ToList();
                }
                else
                {
                    lastStep = data[0].Step.Count;

                    // 先取本站為null
                    data = data.Where(x => x.Step[step] == DateTime.MinValue).ToList();

                    // 再取前一站非null
                    data = data.Where(x => x.Step[step - 1] != DateTime.MinValue).ToList();
                }
            }

            _comm.Status = "檔案載入完畢";
            return data;
        }
        public int GetNoncont()//未完成數量
        {                   
            int Num;
            _comm.Status = "檔案讀取中...";
            List<WorkModel> data =GetNonFinishWork();

            {
                if (data.Count > 0)
                {
                    return data.Count;
                }
                else
                {
                    Console.WriteLine("資料夾中無資料");
                }
            }
            Num = data.Count;
            _comm.Status = "檔案載入完畢";
            return Num;
          
        }
        /// <summary>
        /// 取得完成的工單
        /// </summary>
        /// <returns></returns>
        public List<WorkModel> GetFinishWork()
        {
            _comm.Status = "檔案讀取中...";
            List<WorkModel> models = new List<WorkModel>();

            FileStream fs;// = new FileStream(DefineSeting.ServerFinish, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            if (doConnect(out fs, DefineSeting.ServerNonFinish, false))
            {
                ExcelPackage ep = new ExcelPackage(fs);
                ExcelWorksheet sheet1 = ep.Workbook.Worksheets[2]; // 取得Sheet1

                for (int rowIndex = 2; rowIndex <= sheet1.Dimension.End.Row; rowIndex++)
                {
                    models.Add(getRowData(sheet1, rowIndex, _stepList));
                }

                fs.Close();
            }
            _comm.Status = "檔案載入完畢";
            return models;
        }
        public int GetFincont()//完成數量
        {
            int Num;
            _comm.Status = "檔案讀取中...";
            List<WorkModel> data = GetFinishWork();
            
            {
                if (data.Count > 0)
                {
                    return data.Count;
                }
                else
                {
                    Console.WriteLine("資料夾中無資料");
                }
            }
            Num = data.Count;
            _comm.Status = "檔案載入完畢";
            return Num;
        }
        /// <summary>
        /// 取得客戶資料//新加入
        /// </summary>
        /// <returns></returns>
        public List<WorkModel> GetCName()
        {
            _comm.Status = "檔案讀取中...";
            List<WorkModel> models = new List<WorkModel>();

            FileStream fs;// = new FileStream(DefineSeting.ServerCustcName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            if (doConnect(out fs, DefineSeting.ServerCustName, false))
            {
                ExcelPackage ep = new ExcelPackage(fs);
                ExcelWorksheet sheet1 = ep.Workbook.Worksheets[1]; // 取得Sheet1

                for (int rowIndex = 1; rowIndex <= sheet1.Dimension.End.Row; rowIndex++)
                {
                    models.Add(getRowData(sheet1, rowIndex, _stepList));
                }

                fs.Close();
            }
            _comm.Status = "檔案載入完畢";
            return models;
        }

        private WorkModel getRowData(ExcelWorksheet sheet, int rowIndex, Dictionary<int, string> stepList)
        {
            WorkModel model = new WorkModel();
            model.WorkCreateDate = sheet.GetValue<DateTime>(rowIndex, _workCreateDate);
            model.WorkNumber = sheet.Cells[rowIndex, _workNumber].Text;
            model.CustomName = sheet.Cells[rowIndex, _customName].Text;
            model.CustcName = sheet.Cells[rowIndex, _colcustcName].Text;//新加入
            model.RightDegree = sheet.Cells[rowIndex, _r].Text;
            model.LeftDegree = sheet.Cells[rowIndex, _l].Text;
            model.Memo = sheet.Cells[rowIndex, _memo].Text;

            model.FrameMode = sheet.Cells[rowIndex, _frameMode].Text;
            model.Degree = sheet.Cells[rowIndex, _degree].Text;
            model.GlassType = sheet.Cells[rowIndex, _glassType].Text;
            model.AddDegree = sheet.Cells[rowIndex, _addDegree].Text;
            model.CreateMan = sheet.Cells[rowIndex, _createMan].Text;


            model.Step = new Dictionary<int, DateTime>();
            for (int i = 0; i < stepList.Count; i++)
            {
                model.Step.Add(i + 1, sheet.GetValue<DateTime>(rowIndex, _stepStart + i));
            }



            return model;
        }

        /// <summary>
        /// 取得全部工單
        /// </summary>
        /// <returns></returns>
        public List<WorkModel> GetAllWork()
        {
            List<WorkModel> models = new List<WorkModel>();

            models.AddRange(GetNonFinishWork());
            models.AddRange(GetFinishWork());

            return models;
        }

        public List<WorkModel> GetWork(int days, bool isFinish)
        {
            List<WorkModel> workModels = new List<WorkModel>();
            List<WorkModel> tmp = new List<WorkModel>();

            workModels = GetNonFinishWork();
            if (isFinish)
            {
                tmp = GetFinishWork();
                tmp = tmp.FindAll(x => x.WorkCreateDate.Date.AddDays(days - 1) >= DateTime.Today);
                workModels.AddRange(tmp);
            }
            workModels = workModels.OrderByDescending(x => x.WorkCreateDate).ToList();

            return workModels;
        }

        public int GetNonCount(int step)//Text 
        {
            _comm.Status = "檔案讀取中...";
            List<WorkModel> data = GetNonFinishWork();
            WorkModel s = new WorkModel();

            foreach (var item in data)
            {
                if (data.Count > 0 & 0 < _colStep4)
                {
                    return data.Count;
                }
                else
                {
                    Console.WriteLine("資料夾中無資料");
                }
            }
            int Num;
            Num = data.Count;
            _comm.Status = "檔案載入完畢";
            return Num;


        }




        #endregion

        #region Set

        public bool CreateWorkNumber(WorkModel workModel)
        {
            bool result = false;

            ExcelPackage pkgXLS;

            if (doConnect(out pkgXLS, DefineSeting.ServerNonFinish, true))
            {
                ExcelWorksheet sheet1 = pkgXLS.Workbook.Worksheets[1]; // 取得Sheet1

                int currentRow = 1;
                if (sheet1.Dimension != null)
                    currentRow = sheet1.Dimension.End.Row + 1;

                foreach (var item in _stepList.OrderBy(x => x.Key).ToList())
                {
                    workModel.Step.Add(item.Key, workModel.WorkCreateDate);
                    break;
                }

                logWork("工單建立", workModel);
                setRowData(sheet1, currentRow, workModel);

                pkgXLS.Save();
                pkgXLS.Dispose();
                result = true;
            }

            return result;
        }

        private void logWork(string logMode, WorkModel workModel)
        {
            Logger.Info(logMode);
            Logger.Info(string.Format("建立時間:{0}", workModel.WorkCreateDate.ToString("yyyy-MM-dd HH:mm:ss")));
            Logger.Info(string.Format("客戶名稱:{0}", workModel.CustomName));
            Logger.Info(string.Format("客戶名稱{0}", workModel.CustcName));//新加入
            Logger.Info(string.Format("R度數:{0}", workModel.RightDegree));
            Logger.Info(string.Format("L度數:{0}", workModel.LeftDegree));
            Logger.Info(string.Format("框型:{0}", workModel.FrameMode));
            Logger.Info(string.Format("焦點:{0}", workModel.Degree));
            Logger.Info(string.Format("片種:{0}", workModel.GlassType));
            Logger.Info(string.Format("加入度:{0}", workModel.AddDegree));
            Logger.Info(string.Format("製作人:{0}", workModel.CreateMan));
            Logger.Info(string.Format("備註:{0}", workModel.Memo));
            Logger.Info("");
        }

        public bool UpdateWorkNumber(WorkModel workModel, int stepNumber)
        {
            bool result = false;

            ExcelPackage pkgXLS;

            if (result = doConnect(out pkgXLS, DefineSeting.ServerNonFinish, true))
            {
                ExcelWorksheet sheet1 = pkgXLS.Workbook.Worksheets[1]; // 取得Sheet1

                for (int rowIndex = 2; rowIndex <= sheet1.Dimension.End.Row; rowIndex++)
                {
                    if (sheet1.Cells[rowIndex, _workNumber].Text == workModel.WorkNumber)
                    {
                        logWork(DefineSeting.LoginStepName + "完成", workModel);
                        sheet1.Cells[rowIndex, _stepStart + stepNumber - 1].Value = workModel.Step[stepNumber];
                        break;
                    }
                }

                pkgXLS.Save();
                pkgXLS.Dispose();
            }

            return result;
        }

        private void setRowData(ExcelWorksheet sheet, int rowIndex, WorkModel workModel)
        {
            sheet.Cells[rowIndex, _workCreateDate].Value = workModel.WorkCreateDate;
            sheet.Cells[rowIndex, _workNumber].Value = workModel.WorkNumber;
            sheet.Cells[rowIndex, _workNo].Formula = string.Format("\"d\"&{0}&\"d\"", sheet.Cells[rowIndex, _workNumber].Address);

            sheet.Cells[rowIndex, _customName].Value = workModel.CustomName;
            sheet.Cells[rowIndex, _custcName].Value = workModel.CustcName;
            sheet.Cells[rowIndex, _r].Value = workModel.RightDegree;
            sheet.Cells[rowIndex, _l].Value = workModel.LeftDegree;

            sheet.Cells[rowIndex, _frameMode].Value = workModel.FrameMode;
            sheet.Cells[rowIndex, _degree].Value = workModel.Degree;
            sheet.Cells[rowIndex, _glassType].Value = workModel.GlassType;
            sheet.Cells[rowIndex, _addDegree].Value = workModel.AddDegree;
            sheet.Cells[rowIndex, _createMan].Value = workModel.CreateMan;

            sheet.Cells[rowIndex, _memo].Value = workModel.Memo;

            for (int i = 0; i < workModel.Step.Count; i++)
            {
                sheet.Cells[rowIndex, _stepStart + i].Value = workModel.Step[i + 1];
            }


            string range = string.Format("{0}:{1}", sheet.Cells[rowIndex, 1].Address, sheet.Cells[rowIndex, _stepStart + _stepList.Count - 1].Address);
            sheet.Cells[range].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            sheet.Cells[range].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells[range].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[range].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }



        #endregion


        public bool Delete(List<string> workNumbers)
        {
            bool result = false;
            //  WorkModel model = new WorkModel();
            ExcelPackage pkgXLS;

            if (result = doConnect(out pkgXLS, DefineSeting.ServerNonFinish, true))
            {
                ExcelWorksheet sheet1 = pkgXLS.Workbook.Worksheets[1]; // 取得Sheet1

                for (int rowIndex = 2; rowIndex <= sheet1.Dimension.End.Row; rowIndex++)
                {
                    if (workNumbers.Find(x => x == sheet1.Cells[rowIndex, _workNumber].Text) != null)
                        sheet1.DeleteRow(rowIndex, 1, true);
                }

                pkgXLS.Save();
                pkgXLS.Dispose();
            }

            return result;
        }

        public bool Delete1(List<string> workNumbers)//刪除已完成
        {
            bool result = false;
            //  WorkModel model = new WorkModel();
            ExcelPackage pkgXLS;

            if (result = doConnect(out pkgXLS, DefineSeting.ServerNonFinish, true))
            {
                ExcelWorksheet sheet1 = pkgXLS.Workbook.Worksheets[2]; // 取得Sheet1

                for (int rowIndex = 2; rowIndex <= sheet1.Dimension.End.Row; rowIndex++)
                {
                    if (workNumbers.Find(x => x == sheet1.Cells[rowIndex, _workNumber].Text) != null)
                        sheet1.DeleteRow(rowIndex, 1, true);
                }

                pkgXLS.Save();
                pkgXLS.Dispose();
            }

            return result;
        }

        public bool changeToFinish(string workNumber)
        {
            bool result = false;
            WorkModel workModel = new WorkModel();
            ExcelPackage pkgXLS;

            if (result = doConnect(out pkgXLS, DefineSeting.ServerNonFinish, true))
            {
                ExcelWorksheet sheet1 = pkgXLS.Workbook.Worksheets[1]; // 取得Sheet1

                for (int rowIndex = 2; rowIndex <= sheet1.Dimension.End.Row; rowIndex++)
                {
                    if (sheet1.Cells[rowIndex, _workNumber].Text == workNumber)
                    {
                        workModel = getRowData(sheet1, rowIndex, _stepList);
                        sheet1.DeleteRow(rowIndex, 1, true);
                        break;
                    }

                }

                pkgXLS.Save();
                pkgXLS.Dispose();
            }

            // 2. 加入到Finish

            if (result = doConnect(out pkgXLS, DefineSeting.ServerNonFinish, true))
            {
                ExcelWorksheet sheet1 = pkgXLS.Workbook.Worksheets[2]; // 取得Sheet1

                sheet1.InsertRow(2, 1, 3);
                logWork("工單出貨", workModel);
                setRowData(sheet1, 2, workModel);

                pkgXLS.Save();
                pkgXLS.Dispose();
            }

            return result;
        }

        #region Output

        public string Output(List<WorkModel> workModels, string savePath)
        {
            string result = "";

            _comm.Status = "檔案產生中...";

            if (File.Exists(DefineSeting.ServerSampleFile))
            {
                File.Copy(DefineSeting.ServerSampleFile, savePath, true);
                ExcelPackage pkgXLS;

                if (doConnect(out pkgXLS, savePath, false))
                {
                    ExcelWorksheet sheet1 = pkgXLS.Workbook.Worksheets[1]; // 取得Sheet1

                    int startrow = 2;
                    int currentRow = startrow;
                    if (sheet1.Dimension != null)
                        currentRow = sheet1.Dimension.End.Row + 1;

                    foreach (var item in workModels)
                    {
                        sheet1.Cells[currentRow, 1].Value = item.WorkNumber;
                        sheet1.Cells[currentRow, 2].Formula = string.Format("\"d\"&{0}&\"d\"", sheet1.Cells[currentRow, 1].Address);

                        sheet1.Row(currentRow).Height = 30;

                        currentRow++;
                    }

                    string range = string.Format("{0}:{1}", sheet1.Cells[startrow, 1].Address, sheet1.Cells[currentRow - 1, 2].Address);
                    //   sheet1.Cells[range].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    sheet1.Cells[range].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    sheet1.Cells[range].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    sheet1.Cells[range].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    pkgXLS.Save();
                    pkgXLS.Dispose();

                    _comm.Status = "檔案產生完畢";
                }

            }
            else
            {
                result = "Sample.xlsx檔案遺失!";
                _comm.Status = "檔案遺失!";
                _comm.Connected = false;
            }
            return result;
        }

        public string Output2(List<WorkModel> workModels, string savePath)
        {
            string result = "";

            _comm.Status = "檔案產生中...";

            if (File.Exists(DefineSeting.ServerWork01SampleFile))
            {
                File.Copy(DefineSeting.ServerWork01SampleFile, savePath, true);
                ExcelPackage pkgXLS;

                if (doConnect(out pkgXLS, savePath, false))
                {
                    if (workModels.Count > 1)
                    {
                        int workIndex = 0;
                        ExcelWorksheet sheet1 = null;
                        foreach (var item in workModels)
                        {
                            if (workIndex % 2 == 0)
                            {
                                sheet1 = pkgXLS.Workbook.Worksheets.Copy("Sample02", ((workIndex / 2) + 1).ToString());
                            }

                            int rowIndex = (workIndex % 2) * 23;
                            sheet1.Cells[rowIndex + 4, 2].Value = item.CreateMan;
                            sheet1.Cells[rowIndex + 6, 2].Value = item.FrameMode;
                            sheet1.Cells[rowIndex + 8, 2].Value = item.AddDegree;
                            sheet1.Cells[rowIndex + 10, 2].Value = item.GlassType;
                            sheet1.Cells[rowIndex + 12, 2].Value = item.Memo;

                            sheet1.Cells[rowIndex + 4, 7].Value = item.WorkNumber;
                            sheet1.Cells[rowIndex + 8, 7].Value = item.CustomName;
                            sheet1.Cells[rowIndex + 10, 7].Value = item.CustcName;

                            workIndex++;
                        }
                        List<string> a = pkgXLS.Workbook.Worksheets.Select(x => x.Name).ToList();
                        pkgXLS.Workbook.Worksheets.Delete("Sample01");
                        pkgXLS.Workbook.Worksheets.Delete("Sample02");
                    }
                    else
                    {
                        ExcelWorksheet sheet1 = pkgXLS.Workbook.Worksheets["Sample01"]; // 取得Sheet1

                        int workIndex = 0;

                        foreach (var item in workModels)
                        {
                            int rowIndex = workIndex * 23;
                            sheet1.Cells[rowIndex + 4, 2].Value = item.CreateMan;
                            sheet1.Cells[rowIndex + 6, 2].Value = item.FrameMode;
                            sheet1.Cells[rowIndex + 8, 2].Value = item.AddDegree;
                            sheet1.Cells[rowIndex + 10, 2].Value = item.GlassType;
                            sheet1.Cells[rowIndex + 12, 2].Value = item.Memo;

                            sheet1.Cells[rowIndex + 4, 7].Value = item.WorkNumber;
                            sheet1.Cells[rowIndex + 8, 7].Value = item.CustomName;
                            sheet1.Cells[rowIndex + 10, 7].Value = item.CustcName;

                            workIndex++;
                        }

                        if (sheet1.Cells[4, 7].Value != null)
                        {
                            if (sheet1.Cells[4, 7].Value.ToString().Trim() != "")
                                sheet1.Name = sheet1.Cells[4, 7].Value.ToString();
                        }

                        pkgXLS.Workbook.Worksheets.Delete("Sample02");
                    }

                    pkgXLS.Save();
                    pkgXLS.Dispose();

                    _comm.Status = "檔案產生完畢";
                }

            }
            else
            {
                result = "Sample.xlsx檔案遺失!";
                _comm.Status = "檔案遺失!";
                _comm.Connected = false;
            }
            return result;
        }

        public string OutputFullFile(List<WorkModel> workModels, string savePath)
        {
            string result = "";

            _comm.Status = "檔案產生中...";

            if (File.Exists(DefineSeting.ServerBlankSamplePath))
            {
                File.Copy(DefineSeting.ServerBlankSamplePath, savePath, true);
                ExcelPackage pkgXLS;

                if (doConnect(out pkgXLS, savePath, false))
                {
                    ExcelWorksheet sheet1 = pkgXLS.Workbook.Worksheets[1]; // 取得Sheet1

                    int startrow = 2;
                    int currentRow = startrow;

                    foreach (var item in workModels)
                    {
                        setRowData(sheet1, currentRow, item);
                        sheet1.Row(currentRow).Height = 20;
                        currentRow++;
                    }

                    string range = string.Format("{0}:{1}", sheet1.Cells[startrow, 1].Address, sheet1.Cells[currentRow - 1, 16].Address);
                    //   sheet1.Cells[range].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    sheet1.Cells[range].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    sheet1.Cells[range].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    sheet1.Cells[range].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    pkgXLS.Save();
                    pkgXLS.Dispose();

                    _comm.Status = "檔案產生完畢";
                }

            }
            else
            {
                result = "Sample.xlsx檔案遺失!";
                _comm.Status = "檔案遺失!";
                _comm.Connected = false;
            }
            return result;
        }

        #endregion

        public bool ConnectTest()
        {
            _comm.Connected = File.Exists(DefineSeting.ServerNonFinish);

            return _comm.Connected;
        }

        private bool doConnect(out FileStream fs, string path, bool isBackup)
        {
            fs = null;
            int time = DefineSeting.TimeOutSecond * 2;
            bool result = false;

            if (_comm.Connected)
            {
                if (File.Exists(path) == false)
                {
                    _comm.Status = "找不到檔案!";
                    _comm.Connected = false;
                }
                else
                {
                    while (time > 0)
                    {
                        try
                        {
                            if (isBackup)
                                backup(path);

                            fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                            _comm.Status = "資料載入成功";
                            result = true;
                            break;
                        }
                        catch
                        {
                            _comm.Status = "資料載入中...";
                        }

                        Thread.Sleep(500);
                        time--;
                    }

                    if (result == false)
                    {
                        _comm.Connected = false;
                        _comm.Status = "Server檔案開啟中，無法作業!請先關掉Server檔案後重新啟動!";
                    }
                }
            }

            return result;
        }

        private bool doConnect(out ExcelPackage excelPackage, string path, bool isBackup)
        {
            excelPackage = null;
            bool result = false;

            int time = DefineSeting.TimeOutSecond * 2;

            if (_comm.Connected)
            {
                if (File.Exists(DefineSeting.ServerNonFinish) == false)
                {
                    _comm.Connected = false;
                    _comm.Status = "檔案遺失!";
                }
                else
                {
                    while (time > 0)
                    {
                        try
                        {
                            if (isBackup)
                                backup(path);
                            FileInfo FileInfoXLS = new FileInfo(path);
                            excelPackage = new ExcelPackage(FileInfoXLS);
                            _comm.Status = "資料載入成功";
                            result = true;
                            break;
                        }
                        catch
                        {
                            _comm.Status = "資料載入中...";
                        }

                        Thread.Sleep(500);
                        time--;
                    }

                    if (result == false)
                    {
                        _comm.Connected = false;
                        _comm.Status = "Server檔案開啟中，無法作業!請先關掉Server檔案後重新啟動!";
                    }
                }
            }

            return result;
        }

        private void backup(string filePath)
        {
            if (Directory.Exists(DefineSeting.ServerWorkFolder + "\\tmp") == false)
                Directory.CreateDirectory(DefineSeting.ServerWorkFolder + "\\tmp");
            File.Copy(filePath, DefineSeting.ServerWorkFolder + "\\tmp\\" + Path.GetFileName(filePath), true);
        }

        public List<string> LoadFrameMode()
        {
            List<string> data = new List<string>();

            if (File.Exists(DefineSeting.ServerFrameModePath))
            {
                data = File.ReadAllLines(DefineSeting.ServerFrameModePath, Encoding.Default).ToList();
            }

            return data;
        }

        public List<string> LoadDegree()
        {
            List<string> data = new List<string>();

            if (File.Exists(DefineSeting.ServerDegreePath))
            {
                data = File.ReadAllLines(DefineSeting.ServerDegreePath, Encoding.Default).ToList();
            }

            return data;
        }

        public List<string> LoadCreateMan()
        {
            List<string> data = new List<string>();

            if (File.Exists(DefineSeting.ServerCreateManPath))
            {
                data = File.ReadAllLines(DefineSeting.ServerCreateManPath, Encoding.Default).ToList();
            }

            return data;
        }

        public void CreateDataGridView(DataGridView dgv)
        {

            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Name = "Check";
            colCheck.HeaderText = "選取";
            colCheck.Width = 50;
            colCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;                     
            dgv.Columns.Add(colCheck);

            DataGridViewTextBoxColumn colWorkNumber = new DataGridViewTextBoxColumn();
            colWorkNumber.Name = "WorkNumber";
            colWorkNumber.HeaderText = "工單單號";
            colWorkNumber.DefaultCellStyle.Format = "@";
            colWorkNumber.Width = 100;
            colWorkNumber.DefaultCellStyle.Font = new System.Drawing.Font("標楷體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            colWorkNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;       
            colWorkNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           
            dgv.Columns.Add(colWorkNumber);

            DataGridViewTextBoxColumn colCustomName = new DataGridViewTextBoxColumn();
            colCustomName.Name = "CustomName";
            colCustomName.HeaderText = "客戶編號";
            colCustomName.Width = 40;
            colCustomName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
          
            dgv.Columns.Add(colCustomName);

            DataGridViewTextBoxColumn colCustcName = new DataGridViewTextBoxColumn();//新加入
            colCustcName.Name = "CustcName";
            colCustcName.HeaderText = "客戶名稱";
            colCustcName.Width = 110;
            colCustcName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;          
            dgv.Columns.Add(colCustcName);

            DataGridViewTextBoxColumn colCreateTime = new DataGridViewTextBoxColumn();
            colCreateTime.Name = "CreateTime";
            colCreateTime.HeaderText = "建立時間";
            colCreateTime.DefaultCellStyle.Format = "MM/dd HH:mm:ss";
            colCreateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;           
            colCreateTime.Width = 70;
            colCreateTime.Visible = false;
            dgv.Columns.Add(colCreateTime);

            DataGridViewTextBoxColumn colRightDegree = new DataGridViewTextBoxColumn();
            colRightDegree.Name = "RightDegree";
            colRightDegree.HeaderText = "R度數";
            colRightDegree.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            colRightDegree.Width = 80;
            dgv.Columns.Add(colRightDegree);

            DataGridViewTextBoxColumn colLeftDegree = new DataGridViewTextBoxColumn();
            colLeftDegree.Name = "LeftDegree";
            colLeftDegree.HeaderText = "L度數";
            colLeftDegree.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           
            colLeftDegree.Width = 80;
            dgv.Columns.Add(colLeftDegree);

            DataGridViewTextBoxColumn colFrameMode = new DataGridViewTextBoxColumn();
            colFrameMode.Name = "FrameMode";
            colFrameMode.HeaderText = "框型種類";
            colFrameMode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           
            colFrameMode.Width = 80;
            dgv.Columns.Add(colFrameMode);

            DataGridViewTextBoxColumn colDegree = new DataGridViewTextBoxColumn();
            colDegree.Name = "Degree";
            colDegree.HeaderText = "焦點設定";
            colDegree.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
          
            colDegree.Width = 50;
            dgv.Columns.Add(colDegree);

            DataGridViewTextBoxColumn colGlassType = new DataGridViewTextBoxColumn();
            colGlassType.Name = "GlassType";
            colGlassType.HeaderText = "片種";
            colGlassType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           
            colGlassType.Width = 100;
            dgv.Columns.Add(colGlassType);

            DataGridViewTextBoxColumn colAddDegree = new DataGridViewTextBoxColumn();
            colAddDegree.Name = "AddDegree";
            colAddDegree.HeaderText = "鏡片類型";
            colAddDegree.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           
            colAddDegree.Width = 100;
            dgv.Columns.Add(colAddDegree);

            DataGridViewTextBoxColumn colcreateMan = new DataGridViewTextBoxColumn();
            colcreateMan.Name = "createMan";
            colcreateMan.HeaderText = "製作人";
            colcreateMan.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           
            colcreateMan.Width = 60;
            dgv.Columns.Add(colcreateMan);

            DataGridViewTextBoxColumn colMemo = new DataGridViewTextBoxColumn();
            colMemo.Name = "Memo";
            colMemo.HeaderText = "備註";
            colMemo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           
            colMemo.Width = 120;
            dgv.Columns.Add(colMemo);

            foreach (KeyValuePair<int, string> item in StepList)
            {
                DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                dgvc.HeaderText = item.Value;
                dgvc.Name = "colStep" + item.Key.ToString();

                dgvc.DefaultCellStyle.Format = "MM/dd HH:mm:ss";
                dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvc.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvc.Width = 90;
             

                dgv.Columns.Add(dgvc);

                if (Convert.ToInt16(DefineSeting.LoginStepNo) > 0)
                    dgvc.Visible = false;
            }


        }

        public void LoadDataToDgv(DataGridView dgv, WorkModel workModel, int rowIndex)
        {
            bool export = false; // 判斷是否已出貨

            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr.CreateCells(dgv, new object[] { false,
                                                    workModel.WorkNumber,

                                                    workModel.CustomName,

                                                    workModel.CustcName,//新加入
                                                    workModel.WorkCreateDate,
                                                    workModel.RightDegree,
                                                    workModel.LeftDegree,
                                                    workModel.FrameMode,
                                                    workModel.Degree,
                                                    workModel.GlassType,
                                                    workModel.AddDegree,
                                                    workModel.CreateMan,
                                                    workModel.Memo,"","","","" });

            int startcol = dgv.Columns.Count - 4;
            for (int stepNo = 0; stepNo < workModel.Step.Count; stepNo++)
            {
                if (workModel.Step[stepNo + 1] != DateTime.MinValue)
                    dgvr.Cells[startcol].Value = workModel.Step[stepNo + 1];

                //判斷是否已出貨
                if (stepNo == (workModel.Step.Count - 1))
                {
                    if (workModel.Step[stepNo + 1] != DateTime.MinValue)
                        export = true;
                }
                startcol++;
            }

            if (rowIndex == 0)
            {
                dgv.Rows.Insert(0, dgvr);
            }
            else
            {
                dgv.Rows.Add(dgvr);
            }

            // 已出貨設定顏色不一樣
            if (export == true)
            {
                for (int i = 0; i < dgvr.Cells.Count; i++)
                {
                    dgvr.Cells[i].Style.BackColor = Color.SpringGreen;
                }

            }
            if (export == false)
            {
                for (int i = 0; i < dgvr.Cells.Count; i++)
                {
                    dgvr.Cells[i].Style.BackColor = Color.Wheat;
                }

            }


        }

        public List<WorkModel> ReadDgvToModel(DataGridView dgv)
        {
            List<WorkModel> workModels = new List<WorkModel>();

            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                if ((bool)dgv[_col_check, rowIndex].Value == true)
                {
                    WorkModel w = new WorkModel();
                    w.WorkNumber = dgv[dgv.Columns["WorkNumber"].Index, rowIndex].Value.ToString();

                    w.CustomName = dgv[dgv.Columns["CustomName"].Index, rowIndex].Value.ToString();
                    w.CustcName = dgv[dgv.Columns["CustcName"].Index, rowIndex].Value.ToString();//新加入
                    w.RightDegree = dgv[dgv.Columns["RightDegree"].Index, rowIndex].Value.ToString();
                    w.LeftDegree = dgv[dgv.Columns["LeftDegree"].Index, rowIndex].Value.ToString();
                    w.FrameMode = dgv[dgv.Columns["FrameMode"].Index, rowIndex].Value.ToString();
                    w.Degree = dgv[dgv.Columns["Degree"].Index, rowIndex].Value.ToString();
                    w.GlassType = dgv[dgv.Columns["GlassType"].Index, rowIndex].Value.ToString();
                    w.AddDegree = dgv[dgv.Columns["AddDegree"].Index, rowIndex].Value.ToString();
                    w.CreateMan = dgv[dgv.Columns["createMan"].Index, rowIndex].Value.ToString();
                    w.Memo = dgv[dgv.Columns["Memo"].Index, rowIndex].Value.ToString();

                    if (dgv[_colStep1, rowIndex].Value.ToString() != "")
                        w.Step.Add(1, (DateTime)dgv[_colStep1, rowIndex].Value);
                    if (dgv[_colStep2, rowIndex].Value.ToString() != "")
                        w.Step.Add(2, (DateTime)dgv[_colStep2, rowIndex].Value);
                    if (dgv[_colStep3, rowIndex].Value.ToString() != "")
                        w.Step.Add(3, (DateTime)dgv[_colStep3, rowIndex].Value);
                    if (dgv[_colStep4, rowIndex].Value.ToString() != "")
                        w.Step.Add(4, (DateTime)dgv[_colStep4, rowIndex].Value);

                    workModels.Add(w);
                }
            }

            return workModels;
        }

        public List<WorkModel> ReadDgvToModel2(DataGridView dgv)
        {
            List<WorkModel> workModels = new List<WorkModel>();

            for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
            {
                if ((bool)dgv[_col_check, rowIndex].Value == true)
                {
                    WorkModel w = new WorkModel();
                    w.WorkNumber = dgv[_colWorkNumber, rowIndex].Value.ToString();
                    //     if (string.IsNullOrWhiteSpace((string)dgv[_colworkCreateDate, rowIndex].Value) == false)
                    //        w.WorkCreateDate = (DateTime)dgv[_colworkCreateDate, rowIndex].Value;
                    w.CustomName = dgv[_colcustomName, rowIndex].Value.ToString();
                    w.CustcName = dgv[_colcustcName, rowIndex].Value.ToString();//新加入
                    w.RightDegree = dgv[_colr, rowIndex].Value.ToString();
                    w.LeftDegree = dgv[_coll, rowIndex].Value.ToString();
                    w.FrameMode = dgv[_colframeMode, rowIndex].Value.ToString();
                    w.Degree = dgv[_coldegree, rowIndex].Value.ToString();
                    w.GlassType = dgv[_colglassType, rowIndex].Value.ToString();
                    w.AddDegree = dgv[_coladdDegree, rowIndex].Value.ToString();
                    w.CreateMan = dgv[_colcreateMan, rowIndex].Value.ToString();
                    w.Memo = dgv[_colmemo, rowIndex].Value.ToString();

                    if (dgv[_colStep1, rowIndex].Value.ToString() != "")
                        w.Step.Add(1, (DateTime)dgv[_colStep1, rowIndex].Value);
                    if (dgv[_colStep2, rowIndex].Value.ToString() != "")
                        w.Step.Add(2, (DateTime)dgv[_colStep2, rowIndex].Value);
                    if (dgv[_colStep3, rowIndex].Value.ToString() != "")
                        w.Step.Add(3, (DateTime)dgv[_colStep3, rowIndex].Value);
                    if (dgv[_colStep4, rowIndex].Value.ToString() != "")
                        w.Step.Add(4, (DateTime)dgv[_colStep4, rowIndex].Value);

                    workModels.Add(w);
                }
            }

            return workModels;
        }

        public bool IsExistWorkId(string workId)
        {
            bool result = false; // false 不存在，true 存在

            // 撈出未完成工單
            List<WorkModel> nonWorks = GetNonFinishWork();
            List<WorkModel> finishWorks = GetFinishWork();

            // 用LINQ手法比對看看未完成工單有沒有新建的單號
            if (nonWorks.Find(x => x.WorkNumber == workId) != null)
            {
                // 表示存在，重覆了
                result = true;
            }
            else if (finishWorks.Find(x => x.WorkNumber == workId) != null)
            {
                // 表示存在，重覆了
                result = true;
            }

            return result;
        }
       
        }
    }

