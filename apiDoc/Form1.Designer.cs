namespace apiDoc
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Change = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ReadFiles = new System.Windows.Forms.Button();
            this.btn_Param = new System.Windows.Forms.Button();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1092, 278);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btn_Change
            // 
            this.btn_Change.Location = new System.Drawing.Point(223, 30);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(857, 45);
            this.btn_Change.TabIndex = 1;
            this.btn_Change.Text = "转换";
            this.btn_Change.UseVisualStyleBackColor = true;
            this.btn_Change.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(0, 374);
            this.txtResult.MaxLength = 0;
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(962, 280);
            this.txtResult.TabIndex = 0;
            this.txtResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResult_KeyPress);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(3, 30);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(104, 45);
            this.btn_Clear.TabIndex = 1;
            this.btn_Clear.Text = "清除源";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Clear);
            this.panel1.Controls.Add(this.btn_ReadFiles);
            this.panel1.Controls.Add(this.btn_Param);
            this.panel1.Controls.Add(this.btn_Copy);
            this.panel1.Controls.Add(this.btn_Change);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 278);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 376);
            this.panel1.TabIndex = 2;
            // 
            // btn_ReadFiles
            // 
            this.btn_ReadFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReadFiles.Location = new System.Drawing.Point(976, 147);
            this.btn_ReadFiles.Name = "btn_ReadFiles";
            this.btn_ReadFiles.Size = new System.Drawing.Size(104, 45);
            this.btn_ReadFiles.TabIndex = 1;
            this.btn_ReadFiles.Tag = "下";
            this.btn_ReadFiles.Text = "指定文件夹";
            this.toolTip1.SetToolTip(this.btn_ReadFiles, "指定文件夹，根据cs文件补齐结果参数");
            this.btn_ReadFiles.UseVisualStyleBackColor = true;
            this.btn_ReadFiles.Click += new System.EventHandler(this.btn_ReadFiles_Click);
            // 
            // btn_Param
            // 
            this.btn_Param.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Param.Location = new System.Drawing.Point(976, 96);
            this.btn_Param.Name = "btn_Param";
            this.btn_Param.Size = new System.Drawing.Size(104, 45);
            this.btn_Param.TabIndex = 1;
            this.btn_Param.Tag = "";
            this.btn_Param.Text = "补齐参数";
            this.toolTip1.SetToolTip(this.btn_Param, "根据cs文件内容补齐结果参数");
            this.btn_Param.UseVisualStyleBackColor = true;
            this.btn_Param.Click += new System.EventHandler(this.btn_Param_Click);
            // 
            // btn_Copy
            // 
            this.btn_Copy.Location = new System.Drawing.Point(113, 30);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(104, 45);
            this.btn_Copy.TabIndex = 1;
            this.btn_Copy.Text = "复制结果";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 654);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ReadFiles;
        private System.Windows.Forms.Button btn_Param;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

