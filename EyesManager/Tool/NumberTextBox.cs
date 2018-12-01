using System.ComponentModel;
using System.Windows.Forms;

namespace EyesManager
{
    public partial class NumberTextBox : TextBox
    {
        public NumberTextBox()
        {
            InitializeComponent();
        }

        public NumberTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    {
                        System.Windows.Forms.SendKeys.Send("{TAB}");
                    }
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (e.KeyChar == '.' && this.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }

            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == '.' || e.KeyChar == 8))
            {
                e.Handled = true;
            }


        }

        protected override void OnValidating(CancelEventArgs e)
        {

            base.OnValidating(e);
        }
    }
}
