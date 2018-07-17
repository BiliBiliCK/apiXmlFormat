using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apiDoc
{
    public partial class frmMsg : Form
    {
        public int Result = 1;  //0-确认 1-取消
        public frmMsg(string msg)
        {
          
            InitializeComponent();
            this.textBox1.Text = msg;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Result = 0;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Result = 1;
            this.Close();
        }
    }
}
