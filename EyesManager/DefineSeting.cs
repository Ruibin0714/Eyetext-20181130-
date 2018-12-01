using System.Windows.Forms;

namespace EyesManager
{
    public static class DefineSeting //確定設置
    {
        public static string Version = "Version 1.3";
        public static string LocalSettingIniFullPath = Application.StartupPath + "\\LocalSetting.ini";
        public static string LoginStepNo = "";
        public static string LoginStepName = "";
        public static string OutPath = "";
        public static string ServerPath = "";
        public const string ServerSettinginiName = "ServerSetting.ini";


        public static string ServerSettingIniFullPath = "";// = ServerPath + "\\" + ServerSettinginiName;
        public static string ServerStepFullPath = "";// = ServerPath + "\\Step.txt";
        public static string ServerNonFinish = "";// = ServerPath + "\\工單\\未完成.xlsx";
       //public static string ServerFinish = "";// = ServerPath + "\\工單\\已完成.xlsx";
        public static string ServerSampleFile = "";// = ServerPath + "\\Sample.xlsx";
        public static string ServerWork01SampleFile = "";// = ServerPath + "\\工單Sample01.xlsx";
        public static string ServerCustName = "";//ServerPath+"\\客戶資料.xls";
        public static string ServerCustomer = ""; // = ServerPath + "\\工單\\客戶資料.xlsx";

        //上面為新加入的Server
        public static string ServerFrameModePath = "";
        public static string ServerDegreePath = "";
        public static string ServerCreateManPath = "";
        public static string ServerBlankSamplePath = "";
        public static string ServerWorkFolder = "";
        public static int TimeOutSecond = 30;
        public static int Day = 18;
        public static int Second = 600;
        public static double FinishTime = 1;

        public static void SetServerPath(string serverPath)
        {
            ServerPath = serverPath;
            ServerSettingIniFullPath = ServerPath + "\\" + ServerSettinginiName;
            ServerStepFullPath = ServerPath + "\\Step.txt";
            ServerWorkFolder = ServerPath + "\\工單";
            ServerNonFinish = ServerWorkFolder + "\\未完成.xlsx";
            //ServerFinish = ServerWorkFolder + "\\已完成.xlsx";
            ServerBlankSamplePath = ServerWorkFolder + "\\空白.xlsx";
            ServerCustomer = ServerWorkFolder + "\\客戶資料.xlsx";


            ServerSampleFile = ServerPath + "\\Sample.xlsx";
            ServerWork01SampleFile = ServerPath + "\\工單Sample01.xlsx";
            ServerFrameModePath = ServerPath + "\\FrameMode.txt";
            ServerDegreePath = ServerPath + "\\Degree.txt";
            ServerCreateManPath = ServerPath + "\\CreateMan.txt";
        }
    }
}
