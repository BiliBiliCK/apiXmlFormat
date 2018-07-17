namespace apiDoc
{
    partial class frmParams
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCsCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCsCode
            // 
            this.txtCsCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCsCode.Location = new System.Drawing.Point(0, 0);
            this.txtCsCode.MaxLength = 0;
            this.txtCsCode.Multiline = true;
            this.txtCsCode.Name = "txtCsCode";
            this.txtCsCode.Size = new System.Drawing.Size(872, 414);
            this.txtCsCode.TabIndex = 0;
            this.txtCsCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCsCode_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Confirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 108);
            this.panel1.TabIndex = 1;
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Confirm.Location = new System.Drawing.Point(0, 0);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(872, 108);
            this.btn_Confirm.TabIndex = 0;
            this.btn_Confirm.Text = "提取";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // frmParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 522);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCsCode);
            this.Name = "frmParams";
            this.Text = "frmParams";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCsCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Confirm;
    }
}