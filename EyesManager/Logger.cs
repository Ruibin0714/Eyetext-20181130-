//////////////////////////////////////////////////////////////////////
// Module	  : Logger.cs
// Long Name  : -
// Description: Log system information into file 
//
// Author	  : 肉鬆
// Version	  : 1.0
//
// Remark     : This Log file is synchorizoned
//              1) Build by using framework 4.0
//
// Reference  : http://cephas.net/blog/2003/10/26/logging-in-c-enumerations-thread-safe-streamwriter/
//
// History    : Initial
//			
//////////////////////////////////////////////////////////////////////
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace EyesManager
{
    /// <summary>
    /// <para>功能 : 記錄程式的運作</para>
    /// <para>                   .</para>
    /// <para>概要 : </para>
    /// <para>1. 檔案產生路徑 : 執行檔同一層名稱Log資料夾底下</para>
    /// <para>2. 當次log檔案名稱 : "Log" + 年月日 + ".txt" (ex. Log20140401.txt)</para>
    /// <para>3. 暫存log檔案名稱 : "Log" + 年月日 + ".txt" (ex. Log20140401.txt.backup)</para>
    /// <para>4. 暫存檔案概念 : 1) 每次啟動Logger時會清除"當次"檔案，所以會先將"當次"檔案複製到"暫存"檔</para>
    /// <para>                 2) 當"當次"檔案寫入次數到達上限時，會將內容複製到"暫存"檔，然後清除"當次"檔重新寫入</para>
    /// <para>5. 寫入次數上限為 100000 次</para>
    /// <para>6. Logger.LogLevel可以調整記錄等級(預設為Priority.OFF)</para>
    /// <para>                   .</para>
    /// <para>注意事項 : </para>
    /// <para>無</para>
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Logger訊息的等級
        /// </summary>
        public enum Priority : int
        {
            /// <summary>
            /// OFF級別，包含DEBUG、INFO、WARNING、ERROR、FATAL
            /// </summary>
            OFF = 200,
            /// <summary>
            /// DEBUG級別，包含INFO、WARNING、ERROR、FATAL
            /// </summary>
            DEBUG = 100,
            /// <summary>
            /// INFO級別，包含WARNING、ERROR、FATAL
            /// </summary>
            INFO = 75,
            /// <summary>
            /// WARNING級別，包含ERROR、FATAL
            /// </summary>
            WARNING = 50,
            /// <summary>
            /// ERROR級別，包含FATAL
            /// </summary>
            ERROR = 25,
            /// <summary>
            /// FATAL級別
            /// </summary>
            FATAL = 0
        }

        #region Variable

        /// <summary>
        /// Log檔案寫入次數的上限值
        /// </summary>
        static readonly int _MaxLineLimit = 100000;

        /// <summary>
        /// Log檔的資料夾名稱
        /// </summary>
        static readonly string _logFolderName = "Log";

        /// <summary>
        /// Log檔案資料夾的完整路徑
        /// </summary>
        static string _logFolderPath;

        /// <summary>
        /// 將訊息載入到檔案的資料流
        /// </summary>
        static TextWriter _logWrite;

        /// <summary>
        /// 目前的log等級
        /// </summary>
        static Priority _logLevel;

        /// <summary>
        /// 記錄目前檔案的行數
        /// </summary>
        static int _lineIndex;

        /// <summary>
        /// 開關
        /// </summary>
        static bool _isRecord;

        #endregion

        #region Property

        /// <summary>
        /// 設定Log級別
        /// </summary>
        public Priority LogLevel
        {
            get { return _logLevel; }
            set { _logLevel = value; }
        }

        #endregion

        #region Inital

        static Logger()
        {
            _logLevel = Priority.OFF;
            _isRecord = true;
            _lineIndex = _MaxLineLimit;
            _logFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + _logFolderName;

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            // 連接未預期的例外的事件
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        #endregion

        #region Public Method

        public static void SetPath(string folderPath)
        {
            _logFolderPath = folderPath + "\\" + _logFolderName;

            if (_isRecord)
                initialFile();
        }

        /// <summary>
        /// 設定是否紀錄資料
        /// </summary>
        /// <param name="isRecord"></param>
        public static void SetRecord(bool isRecord)
        {
            _isRecord = isRecord;
        }

        /// <summary>
        /// 記錄程式開發流程
        /// </summary>
        /// <param name="message">訊息</param>
        /// <example>
        /// <code>
        /// Logger.Debug("This is a 'Debug' message.");
        /// </code>
        /// </example>
        public static void Debug(string message)
        {
            append(Priority.DEBUG, message);
        }

        /// <summary>
        /// 記錄用者操作
        /// </summary>
        /// <param name="message">訊息</param>
        /// <example>
        /// <code>
        /// Logger.Info("This is a 'Info' message.");
        /// </code>
        /// </example>
        public static void Info(string message)
        {
            append(Priority.INFO, message);
        }

        /// <summary>
        /// 記錄警告資訊
        /// </summary>
        /// <param name="message">訊息</param>
        /// <example>
        /// <code>
        /// Logger.Warning("This is a 'Warning' message.");
        /// </code>
        /// </example>
        public static void Warning(string message)
        {
            append(Priority.WARNING, message);
        }

        /// <summary>
        /// 記錄錯誤資訊，程式仍然可以運作
        /// </summary>
        /// <param name="message">訊息</param>
        /// <example>
        /// <code>
        /// Logger.Error("This is a 'Error' message.");
        /// </code>
        /// </example>
        public static void Error(string message)
        {
            append(Priority.ERROR, message);
        }

        /// <summary>
        /// 記錄崩潰資訊，程式強制結束
        /// </summary>
        /// <param name="message">訊息</param>
        /// <example>
        /// <code>
        /// Logger.Fatal("This is a 'Fatal' message.");
        /// </code>
        /// </example>
        public static void Fatal(string message)
        {
            append(Priority.FATAL, message);
        }

        #endregion

        #region Private Method

        /// <summary>
        /// 處理例外，所有的錯誤情況都會觸發此方法(跑執行檔無法進來)
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            // 1. 遞迴紀錄例外資訊 
            Exception e = (Exception)args.ExceptionObject;

            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame(1);

            if (stackFrame.GetMethod().Name == "Application_ThreadException")
                return;

            Fatal("Unhandled Exception");

            _logWrite.WriteLine(string.Format("CLR terminating: {0}", args.IsTerminating));

            _logWrite.Flush();

            recursiveWriteError(e);
        }

        /// <summary>
        /// 處理例外，所有的錯誤情況都會觸發此方法(跑debug無法進來)
        /// </summary>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Fatal("Unhandled Exception");

            recursiveWriteError(e.Exception);
          
            // throw e.Exception;
        }

        /// <summary>
        ///  將訊息寫入檔案
        /// </summary>
        /// <param name="mFormat">訊息的類別</param>
        /// <param name="message">訊息</param>
        private static void append(Priority mFormat, string message)
        {
            if (_isRecord)
            {
                if ((int)_logLevel >= (int)mFormat)
                {
                    lock (_logWrite)
                    {
                        if (_lineIndex >= _MaxLineLimit)
                        {
                            initialFile();
                        }

                        _logWrite.WriteLine(string.Format("{0}{1}{2}", DateTime.Now.ToString("[HH:mm:ss]").PadRight(12, ' '), Enum.GetName(typeof(Priority), mFormat).PadRight(10, ' '), message));
                        _logWrite.Flush();
                        _lineIndex++;

                    }
                }
            }
        }

        private static void initialFile()
        {
            _lineIndex = 0;

            string logName = string.Format("Log{0}.txt", DateTime.Now.ToString("yyyy-MM-dd HHmmss fff"));
            string logPath = _logFolderPath + "\\" + logName;

            if (!Directory.Exists(_logFolderPath))
                Directory.CreateDirectory(_logFolderPath);
            
            if (File.Exists(logPath))
            {
                if ((new FileInfo(logPath)).Length != 0)
                {
                    // backup
                    File.Copy(logPath, logPath + ".backup", true);

                    if (_logWrite != null) // need to dispose
                    {
                        TextWriter.Synchronized(_logWrite).Close();
                    }

                    File.Delete(logPath);
                }
            }

            // open up the streamwriter for writing..
            _logWrite = TextWriter.Synchronized(File.AppendText(logPath));
        }

        /// <summary>
        /// Get Exception Message
        /// </summary>
        /// <param name="e"></param>
        private static void recursiveWriteError(Exception e)
        {
            _logWrite.WriteLine("Message : " + e.Message);
            _logWrite.WriteLine("Stack trace : " + e.StackTrace);
            _logWrite.WriteLine("Source : " + e.Source);
            _logWrite.Flush();

            if (e.InnerException != null)
            {
                _logWrite.WriteLine("Inner exception :");
                _logWrite.Flush();
                // 遞迴取得子內容
                recursiveWriteError(e.InnerException);
            }
        }

        #endregion

    }
}
