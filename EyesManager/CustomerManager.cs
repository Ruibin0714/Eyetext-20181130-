using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Threading;

namespace EyesManager
{
    public class CustomerManager
    {
        private Communication _comm;

        public CustomerManager()
        {
            _comm = new Communication();
            ConnectTest();
        }

        public List<Customer> GetAll()
        {
            _comm.Status = "檔案讀取中...";
            List<Customer> models = new List<Customer>();

            FileStream fs;// = new FileStream(DefineSeting.ServerFinish, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            if (doConnect(out fs, DefineSeting.ServerCustomer, false))
            {
                ExcelPackage ep = new ExcelPackage(fs);
                ExcelWorksheet sheet1 = ep.Workbook.Worksheets[1]; // 取得Sheet1

                for (int rowIndex = 2; rowIndex <= sheet1.Dimension.End.Row; rowIndex++)
                {
                    models.Add(getRowData(sheet1, rowIndex));
                }

                fs.Close();
            }
            _comm.Status = "檔案載入完畢";
            return models;
        }

        private Customer getRowData(ExcelWorksheet sheet, int rowIndex)
        {
            Customer model = new Customer();

            model.CustomerNo = sheet.Cells[rowIndex, 1].Text;
            model.CustomerName = sheet.Cells[rowIndex, 4].Text;

            return model;

        }

        #region Base

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

        private void backup(string filePath)
        {
            //if (Directory.Exists(DefineSeting.ServerWorkFolder + "\\tmp") == false)
            //    Directory.CreateDirectory(DefineSeting.ServerWorkFolder + "\\tmp");
            //File.Copy(filePath, DefineSeting.ServerWorkFolder + "\\tmp\\" + Path.GetFileName(filePath), true);
        }

        public bool ConnectTest()
        {
            _comm.Connected = File.Exists(DefineSeting.ServerCustomer);

            return _comm.Connected;
        }
        #endregion
    }
}
