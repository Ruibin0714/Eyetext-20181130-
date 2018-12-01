using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EyesManager
{
    public partial class LoginForm : Form
    {

        public LoginForm(MainController maincontroller)
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string step = DefineSeting.LoginStepName;

            if (step != "")
            {
                cbxStepNo.Items.Add(step);
                cbxStepNo.SelectedIndex = 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbxStepNo.SelectedIndex == -1)
            {
                MessageBox.Show("請選擇站別!", "Error");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cbxStepNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
