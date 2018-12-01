using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyesManager
{
    public class Communication //通訊
    {
        private bool _connected;
        private string _status;

        public string Status
        {
            get { return _status; }
            set
            {
                if (value != _status)
                {
                    if (OnConnected != null)
                        OnStatusChanged.Invoke(value);
                    _status = value;
                }
            }
        }

        public bool Connected
        {
            get { return _connected; }
            set
            {
                if (value != _connected)
                {
                    if (OnConnected != null)
                        OnConnected.Invoke(value);
                    _connected = value;
                }

            }
        }

        public event Action<bool> OnConnected;
        public event Action<string> OnStatusChanged;

        public Communication()
        {
            _connected = false;
            _status = "";
        }

    }
}
