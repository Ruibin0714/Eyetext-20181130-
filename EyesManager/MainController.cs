using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EyesManager
{
    public class MainController//主要調節器
    {
        private WorkManager _workManager;
        private Communication _communication;
        private IniManager _localIniManager;
        private StepManager _stepManager;

        public StepManager StepManager
        {
            get { return _stepManager; }
            set { _stepManager = value; }
        }

        public IniManager LocalIniManager
        {
            get { return _localIniManager; }
            set { _localIniManager = value; }
        }

        public Communication Communication
        {
            get { return _communication; }
            set { _communication = value; }
        }

        public WorkManager WorkManager
        {
            get { return _workManager; }
            set { _workManager = value; }
        }

        public event Action<bool> OnWorking;

        public MainController()
        {
            _stepManager = new StepManager();
            _workManager = new WorkManager();
            _communication = new Communication();
            ReadLocalIni();

            _workManager.Communication = _communication;
            _workManager.StepList = _stepManager.GetAllStep();
        }

        public void ReadLocalIni()
        {
            _localIniManager = new IniManager(DefineSeting.LocalSettingIniFullPath);

            DefineSeting.LoginStepNo = _localIniManager.GetKeyValue("Step", "step");
            DefineSeting.LoginStepName = _localIniManager.GetKeyValue("Step", "stepName");
            DefineSeting.OutPath = _localIniManager.GetKeyValue("Output", "path");
            if (Directory.Exists(DefineSeting.OutPath) == false)
            {
                DefineSeting.OutPath = "";
            }
            DefineSeting.SetServerPath(_localIniManager.GetKeyValue("Setting", "serverPath"));


            int value;
            DefineSeting.Day = 1;
            if (int.TryParse(_localIniManager.GetKeyValue("See", "day"), out value))
                DefineSeting.Day = value;

            DefineSeting.Second = 30;
            if (int.TryParse(_localIniManager.GetKeyValue("See", "second"), out value))
                DefineSeting.Second = value;

            DefineSeting.TimeOutSecond = 20;
            if (int.TryParse(_localIniManager.GetKeyValue("Setting", "timeout"), out value))
                DefineSeting.TimeOutSecond = value;

            DefineSeting.FinishTime = 1;
            double value2;
            if (double.TryParse(_localIniManager.GetKeyValue("Setting", "finishTime"), out value2))
                DefineSeting.FinishTime = value2;
        }

        public void SetSavePath(string folder)
        {
            _localIniManager.SetKeyValue("Output", "path", folder);
            DefineSeting.OutPath = folder;
        }

        public void SetServerPath(string folderPath)
        {
            _localIniManager.SetKeyValue("Setting", "serverPath", folderPath);
            DefineSeting.SetServerPath(folderPath);
        }

        public void SetTimeout(string value)
        {
            _localIniManager.SetKeyValue("Setting", "timeout", value);
            DefineSeting.TimeOutSecond = Convert.ToInt32(value);
        }

        public void SetDay(string value)
        {
            _localIniManager.SetKeyValue("See", "day", value);
            DefineSeting.Day = Convert.ToInt32(value);
        }

        public void SetSecond(string value)
        {
            _localIniManager.SetKeyValue("See", "second", value);
            DefineSeting.Second = Convert.ToInt32(value);
        }

        public void SetFinishTime(string value)
        {
            _localIniManager.SetKeyValue("Setting", "finishTime", value);
            DefineSeting.FinishTime = Convert.ToDouble(value);
        }

        public void DoWork(bool working)
        {
            if (OnWorking != null)
                OnWorking.Invoke(working);
        }

        // 檢查工單是否已建立
        public bool IsExistWorkId(string workId)
        {
            return _workManager.IsExistWorkId(workId);
        }

        public bool IsExitsWorkNom(string WorkId)
        {
            if (WorkId.Length != 8)
            {
                return true;
            }
            else return false;
        }


       

    }
}
