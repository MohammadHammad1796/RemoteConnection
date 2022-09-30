namespace RemoteClient
{
    partial class ExecuteSqlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecuteSqlForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CommandTxt = new System.Windows.Forms.TextBox();
            this.ExecuteBtn = new System.Windows.Forms.Button();
            this.SelectGrid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UrlTxt = new System.Windows.Forms.TextBox();
            this.SaveUrlBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CommandTxt);
            this.groupBox1.Controls.Add(this.ExecuteBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command";
            // 
            // CommandTxt
            // 
            this.CommandTxt.Location = new System.Drawing.Point(88, 19);
            this.CommandTxt.Multiline = true;
            this.CommandTxt.Name = "CommandTxt";
            this.CommandTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CommandTxt.Size = new System.Drawing.Size(682, 75);
            this.CommandTxt.TabIndex = 0;
            this.CommandTxt.TextChanged += new System.EventHandler(this.CommandTxt_TextChanged);
            // 
            // ExecuteBtn
            // 
            this.ExecuteBtn.Enabled = false;
            this.ExecuteBtn.Location = new System.Drawing.Point(6, 41);
            this.ExecuteBtn.Name = "ExecuteBtn";
            this.ExecuteBtn.Size = new System.Drawing.Size(75, 23);
            this.ExecuteBtn.TabIndex = 1;
            this.ExecuteBtn.Text = "Execute";
            this.ExecuteBtn.UseVisualStyleBackColor = true;
            this.ExecuteBtn.Click += new System.EventHandler(this.ExecuteBtn_Click);
            // 
            // SelectGrid
            // 
            this.SelectGrid.AllowUserToAddRows = false;
            this.SelectGrid.AllowUserToDeleteRows = false;
            this.SelectGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectGrid.Location = new System.Drawing.Point(12, 187);
            this.SelectGrid.Name = "SelectGrid";
            this.SelectGrid.ReadOnly = true;
            this.SelectGrid.Size = new System.Drawing.Size(776, 309);
            this.SelectGrid.TabIndex = 2;
            this.SelectGrid.TabStop = false;
            this.SelectGrid.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UrlTxt);
            this.groupBox2.Controls.Add(this.SaveUrlBtn);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 51);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Service url";
            // 
            // UrlTxt
            // 
            this.UrlTxt.Location = new System.Drawing.Point(88, 21);
            this.UrlTxt.Name = "UrlTxt";
            this.UrlTxt.Size = new System.Drawing.Size(682, 20);
            this.UrlTxt.TabIndex = 0;
            this.UrlTxt.TextChanged += new System.EventHandler(this.UrlTxt_TextChanged);
            // 
            // SaveUrlBtn
            // 
            this.SaveUrlBtn.Enabled = false;
            this.SaveUrlBtn.Location = new System.Drawing.Point(6, 19);
            this.SaveUrlBtn.Name = "SaveUrlBtn";
            this.SaveUrlBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveUrlBtn.TabIndex = 1;
            this.SaveUrlBtn.Text = "Save";
            this.SaveUrlBtn.UseVisualStyleBackColor = true;
            this.SaveUrlBtn.Click += new System.EventHandler(this.SaveUrlBtn_Click);
            // 
            // ExecuteSqlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SelectGrid);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(360, 300);
            this.Name = "ExecuteSqlForm";
            this.Text = "SQL";
            this.Load += new System.EventHandler(this.ExecuteSqlForm_Load);
            this.Resize += new System.EventHandler(this.ExecuteSqlForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView SelectGrid;
        private System.Windows.Forms.TextBox CommandTxt;
        private System.Windows.Forms.Button ExecuteBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox UrlTxt;
        private System.Windows.Forms.Button SaveUrlBtn;
    }
}

