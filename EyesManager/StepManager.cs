using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EyesManager
{
    public class StepManager //步驟管理
    {
        public Dictionary<int, string> GetAllStep()
        {
            Dictionary<int, string> step = new Dictionary<int, string>();

            if (File.Exists(DefineSeting.ServerStepFullPath))
            {
                string[] data = File.ReadAllLines(DefineSeting.ServerStepFullPath,Encoding.Default);

                for (int i = 0; i < data.Length; i++)
                {
                    string[] a = data[i].Split(',');
                    step.Add(Convert.ToInt16(a[0]), a[1]);
                }
            }
            return step;
        }

    }
}
