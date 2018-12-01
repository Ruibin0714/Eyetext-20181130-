using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyesManager
{
    public class WorkModel　//工作模型
    {
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime WorkCreateDate { get; set; }
        /// <summary>
        /// 工單單號
        /// </summary>
        public string WorkNumber { get; set; }
        /// <summary>
        /// 客戶編號
        /// </summary>
        public string CustomName { get; set; }
        ///<summary>
        ///客戶名稱
        ///</summary>
        public string CustcName { get; set; }//新加入
        /// <summary>
        /// R度數
        /// </summary>
        public string RightDegree { get; set; }
        /// <summary>
        /// L度數
        /// </summary>
        public string LeftDegree { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 步驟完成時間
        /// </summary>
        public Dictionary<int,DateTime> Step { get; set; }
        /// <summary>
        /// 框型種類
        /// </summary>
        public string FrameMode { get; set; }
        /// <summary>
        /// 焦點設定
        /// </summary>
        public string Degree { get; set; }
        /// <summary>
        /// 片種
        /// </summary>
        public string GlassType { get; set; }
        /// <summary>
        /// 製作人
        /// </summary>
        public string CreateMan { get; set; }
        /// <summary>
        /// 類型
        /// </summary>
        public string AddDegree { get; set; }


        public string Status { get; set; }

        public WorkModel()
        {
            WorkCreateDate = DateTime.Now;
            WorkNumber = "";
            CustomName = "";
            CustcName = "";
            RightDegree = "";
            LeftDegree = "";
            Memo = "";
            Step = new Dictionary<int, DateTime>();

            Status = "";

            FrameMode = "";
            Degree = "";
            GlassType = "";
            CreateMan = "";
            AddDegree = "";

        }
    }
}
