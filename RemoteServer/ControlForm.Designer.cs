namespace RemoteServer
{
    partial class ControlForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            this.ConnectionStringTxt = new System.Windows.Forms.TextBox();
            this.SaveConnectionStringBtn = new System.Windows.Forms.Button();
            this.RunStopServerBtn = new System.Windows.Forms.Button();
            this.LogTxt = new System.Windows.Forms.TextBox();
            this.ConnectionStringGroup = new System.Windows.Forms.GroupBox();
            this.LogGroup = new System.Windows.Forms.GroupBox();
            this.RemoteGroup = new System.Windows.Forms.GroupBox();
            this.UrlTxt = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PortTxt = new System.Windows.Forms.TextBox();
            this.SavePortBtn = new System.Windows.Forms.Button();
            this.portNumberError = new System.Windows.Forms.ErrorProvider(this.components);
            this.ConnectionStringGroup.SuspendLayout();
            this.LogGroup.SuspendLayout();
            this.RemoteGroup.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNumberError)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectionStringTxt
            // 
            this.ConnectionStringTxt.Location = new System.Drawing.Point(150, 30);
            this.ConnectionStringTxt.Multiline = true;
            this.ConnectionStringTxt.Name = "ConnectionStringTxt";
            this.ConnectionStringTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConnectionStringTxt.Size = new System.Drawing.Size(611, 77);
            this.ConnectionStringTxt.TabIndex = 0;
            this.ConnectionStringTxt.TextChanged += new System.EventHandler(this.ConnectionStringTxt_TextChanged);
            // 
            // SaveConnectionStringBtn
            // 
            this.SaveConnectionStringBtn.Enabled = false;
            this.SaveConnectionStringBtn.Location = new System.Drawing.Point(26, 57);
            this.SaveConnectionStringBtn.Name = "SaveConnectionStringBtn";
            this.SaveConnectionStringBtn.Size = new System.Drawing.Size(102, 23);
            this.SaveConnectionStringBtn.TabIndex = 1;
            this.SaveConnectionStringBtn.Text = "Save";
            this.SaveConnectionStringBtn.UseVisualStyleBackColor = true;
            this.SaveConnectionStringBtn.Click += new System.EventHandler(this.SaveConnectionStringBtn_Click);
            // 
            // RunStopServerBtn
            // 
            this.RunStopServerBtn.Location = new System.Drawing.Point(15, 24);
            this.RunStopServerBtn.Name = "RunStopServerBtn";
            this.RunStopServerBtn.Size = new System.Drawing.Size(102, 23);
            this.RunStopServerBtn.TabIndex = 0;
            this.RunStopServerBtn.Text = "Run server";
            this.RunStopServerBtn.UseVisualStyleBackColor = true;
            this.RunStopServerBtn.Click += new System.EventHandler(this.RunStopServerBtn_Click);
            // 
            // LogTxt
            // 
            this.LogTxt.Location = new System.Drawing.Point(6, 19);
            this.LogTxt.Multiline = true;
            this.LogTxt.Name = "LogTxt";
            this.LogTxt.ReadOnly = true;
            this.LogTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTxt.Size = new System.Drawing.Size(755, 210);
            this.LogTxt.TabIndex = 11;
            this.LogTxt.TabStop = false;
            // 
            // ConnectionStringGroup
            // 
            this.ConnectionStringGroup.Controls.Add(this.ConnectionStringTxt);
            this.ConnectionStringGroup.Controls.Add(this.SaveConnectionStringBtn);
            this.ConnectionStringGroup.Location = new System.Drawing.Point(12, 12);
            this.ConnectionStringGroup.Name = "ConnectionStringGroup";
            this.ConnectionStringGroup.Size = new System.Drawing.Size(776, 113);
            this.ConnectionStringGroup.TabIndex = 0;
            this.ConnectionStringGroup.TabStop = false;
            this.ConnectionStringGroup.Text = "Database connection string";
            // 
            // LogGroup
            // 
            this.LogGroup.Controls.Add(this.LogTxt);
            this.LogGroup.Location = new System.Drawing.Point(12, 218);
            this.LogGroup.Name = "LogGroup";
            this.LogGroup.Size = new System.Drawing.Size(776, 235);
            this.LogGroup.TabIndex = 7;
            this.LogGroup.TabStop = false;
            this.LogGroup.Text = "Log";
            // 
            // RemoteGroup
            // 
            this.RemoteGroup.Controls.Add(this.UrlTxt);
            this.RemoteGroup.Controls.Add(this.RunStopServerBtn);
            this.RemoteGroup.Location = new System.Drawing.Point(295, 138);
            this.RemoteGroup.Name = "RemoteGroup";
            this.RemoteGroup.Size = new System.Drawing.Size(493, 60);
            this.RemoteGroup.TabIndex = 2;
            this.RemoteGroup.TabStop = false;
            this.RemoteGroup.Text = "Remote";
            // 
            // UrlTxt
            // 
            this.UrlTxt.Location = new System.Drawing.Point(132, 9);
            this.UrlTxt.Multiline = true;
            this.UrlTxt.Name = "UrlTxt";
            this.UrlTxt.ReadOnly = true;
            this.UrlTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.UrlTxt.Size = new System.Drawing.Size(346, 45);
            this.UrlTxt.TabIndex = 0;
            this.UrlTxt.TabStop = false;
            this.UrlTxt.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PortTxt);
            this.groupBox4.Controls.Add(this.SavePortBtn);
            this.groupBox4.Location = new System.Drawing.Point(12, 138);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(277, 60);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Port";
            // 
            // PortTxt
            // 
            this.PortTxt.Location = new System.Drawing.Point(150, 27);
            this.PortTxt.Name = "PortTxt";
            this.PortTxt.Size = new System.Drawing.Size(100, 20);
            this.PortTxt.TabIndex = 0;
            this.PortTxt.TextChanged += new System.EventHandler(this.PortTxt_TextChanged);
            // 
            // SavePortBtn
            // 
            this.SavePortBtn.Enabled = false;
            this.SavePortBtn.Location = new System.Drawing.Point(26, 24);
            this.SavePortBtn.Name = "SavePortBtn";
            this.SavePortBtn.Size = new System.Drawing.Size(102, 23);
            this.SavePortBtn.TabIndex = 1;
            this.SavePortBtn.Text = "Save";
            this.SavePortBtn.UseVisualStyleBackColor = true;
            this.SavePortBtn.Click += new System.EventHandler(this.SavePortBtn_Click);
            // 
            // portNumberError
            // 
            this.portNumberError.ContainerControl = this;
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.RemoteGroup);
            this.Controls.Add(this.LogGroup);
            this.Controls.Add(this.ConnectionStringGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(578, 388);
            this.Name = "ControlForm";
            this.Text = "Control";
            this.Load += new System.EventHandler(this.ControlForm_Load);
            this.Resize += new System.EventHandler(this.ControlForm_Resize);
            this.ConnectionStringGroup.ResumeLayout(false);
            this.ConnectionStringGroup.PerformLayout();
            this.LogGroup.ResumeLayout(false);
            this.LogGroup.PerformLayout();
            this.RemoteGroup.ResumeLayout(false);
            this.RemoteGroup.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNumberError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox ConnectionStringTxt;
        private System.Windows.Forms.Button SaveConnectionStringBtn;
        private System.Windows.Forms.Button RunStopServerBtn;
        private System.Windows.Forms.TextBox LogTxt;
        private System.Windows.Forms.GroupBox ConnectionStringGroup;
        private System.Windows.Forms.GroupBox LogGroup;
        private System.Windows.Forms.GroupBox RemoteGroup;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox PortTxt;
        private System.Windows.Forms.Button SavePortBtn;
        private System.Windows.Forms.ErrorProvider portNumberError;
        private System.Windows.Forms.TextBox UrlTxt;
    }
}

