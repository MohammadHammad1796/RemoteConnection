namespace RemoteClient
{
    partial class EmployeesManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeesManagementForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.GetByIdButton = new System.Windows.Forms.Button();
            this.GetAllButton = new System.Windows.Forms.Button();
            this.EmployeesGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UrlTxt = new System.Windows.Forms.TextBox();
            this.SaveUrlBtn = new System.Windows.Forms.Button();
            this.ActionsGroupBox = new System.Windows.Forms.GroupBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.AgeTextBox = new System.Windows.Forms.TextBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IdErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.FirstNameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.LastNameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.AgeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.LoaderPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.ActionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgeErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IdTextBox);
            this.groupBox1.Controls.Add(this.GetByIdButton);
            this.groupBox1.Controls.Add(this.GetAllButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 167);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Queries";
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(88, 92);
            this.IdTextBox.MaxLength = 3333333;
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(100, 20);
            this.IdTextBox.TabIndex = 2;
            this.IdTextBox.TextChanged += new System.EventHandler(this.IdTextBox_TextChanged);
            // 
            // GetByIdButton
            // 
            this.GetByIdButton.Enabled = false;
            this.GetByIdButton.Location = new System.Drawing.Point(6, 90);
            this.GetByIdButton.Name = "GetByIdButton";
            this.GetByIdButton.Size = new System.Drawing.Size(75, 23);
            this.GetByIdButton.TabIndex = 1;
            this.GetByIdButton.Text = "Get by id";
            this.GetByIdButton.UseVisualStyleBackColor = true;
            this.GetByIdButton.Click += new System.EventHandler(this.GetByIdButton_Click);
            // 
            // GetAllButton
            // 
            this.GetAllButton.Location = new System.Drawing.Point(6, 44);
            this.GetAllButton.Name = "GetAllButton";
            this.GetAllButton.Size = new System.Drawing.Size(75, 23);
            this.GetAllButton.TabIndex = 0;
            this.GetAllButton.Text = "Get all";
            this.GetAllButton.UseVisualStyleBackColor = true;
            this.GetAllButton.Click += new System.EventHandler(this.GetAllButton_Click);
            // 
            // EmployeesGridView
            // 
            this.EmployeesGridView.AllowUserToAddRows = false;
            this.EmployeesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EmployeesGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.EmployeesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeesGridView.Location = new System.Drawing.Point(12, 242);
            this.EmployeesGridView.Name = "EmployeesGridView";
            this.EmployeesGridView.ReadOnly = true;
            this.EmployeesGridView.Size = new System.Drawing.Size(557, 254);
            this.EmployeesGridView.TabIndex = 2;
            this.EmployeesGridView.TabStop = false;
            this.EmployeesGridView.Visible = false;
            this.EmployeesGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.EmployeesGridView_UserDeletingRow);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UrlTxt);
            this.groupBox2.Controls.Add(this.SaveUrlBtn);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 51);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Service url";
            // 
            // UrlTxt
            // 
            this.UrlTxt.Location = new System.Drawing.Point(88, 21);
            this.UrlTxt.Name = "UrlTxt";
            this.UrlTxt.Size = new System.Drawing.Size(463, 20);
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
            // ActionsGroupBox
            // 
            this.ActionsGroupBox.Controls.Add(this.UpdateButton);
            this.ActionsGroupBox.Controls.Add(this.AddButton);
            this.ActionsGroupBox.Controls.Add(this.AgeTextBox);
            this.ActionsGroupBox.Controls.Add(this.LastNameTextBox);
            this.ActionsGroupBox.Controls.Add(this.FirstNameTextBox);
            this.ActionsGroupBox.Controls.Add(this.label3);
            this.ActionsGroupBox.Controls.Add(this.label2);
            this.ActionsGroupBox.Controls.Add(this.label1);
            this.ActionsGroupBox.Location = new System.Drawing.Point(232, 69);
            this.ActionsGroupBox.Name = "ActionsGroupBox";
            this.ActionsGroupBox.Size = new System.Drawing.Size(337, 167);
            this.ActionsGroupBox.TabIndex = 3;
            this.ActionsGroupBox.TabStop = false;
            this.ActionsGroupBox.Text = "Actions";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Enabled = false;
            this.UpdateButton.Location = new System.Drawing.Point(152, 131);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 7;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(38, 131);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AgeTextBox
            // 
            this.AgeTextBox.Location = new System.Drawing.Point(76, 98);
            this.AgeTextBox.MaxLength = 3;
            this.AgeTextBox.Name = "AgeTextBox";
            this.AgeTextBox.Size = new System.Drawing.Size(207, 20);
            this.AgeTextBox.TabIndex = 5;
            this.AgeTextBox.TextChanged += new System.EventHandler(this.AgeTextBox_TextChanged);
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(76, 62);
            this.LastNameTextBox.MaxLength = 50;
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(207, 20);
            this.LastNameTextBox.TabIndex = 4;
            this.LastNameTextBox.TextChanged += new System.EventHandler(this.LastNameTextBox_TextChanged);
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(76, 22);
            this.FirstNameTextBox.MaxLength = 50;
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(207, 20);
            this.FirstNameTextBox.TabIndex = 3;
            this.FirstNameTextBox.TextChanged += new System.EventHandler(this.FirstNameTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Age";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First name";
            // 
            // IdErrorProvider
            // 
            this.IdErrorProvider.ContainerControl = this;
            // 
            // FirstNameErrorProvider
            // 
            this.FirstNameErrorProvider.ContainerControl = this;
            // 
            // LastNameErrorProvider
            // 
            this.LastNameErrorProvider.ContainerControl = this;
            // 
            // AgeErrorProvider
            // 
            this.AgeErrorProvider.ContainerControl = this;
            // 
            // LoaderPictureBox
            // 
            this.LoaderPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LoaderPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoaderPictureBox.Image = global::RemoteClient.Properties.Resources.loader;
            this.LoaderPictureBox.ImageLocation = "";
            this.LoaderPictureBox.InitialImage = null;
            this.LoaderPictureBox.Location = new System.Drawing.Point(0, 0);
            this.LoaderPictureBox.Name = "LoaderPictureBox";
            this.LoaderPictureBox.Size = new System.Drawing.Size(578, 508);
            this.LoaderPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.LoaderPictureBox.TabIndex = 4;
            this.LoaderPictureBox.TabStop = false;
            this.LoaderPictureBox.UseWaitCursor = true;
            this.LoaderPictureBox.Visible = false;
            // 
            // EmployeesManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 508);
            this.Controls.Add(this.LoaderPictureBox);
            this.Controls.Add(this.ActionsGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.EmployeesGridView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(360, 300);
            this.Name = "EmployeesManagementForm";
            this.Text = "Employees Management";
            this.Load += new System.EventHandler(this.EmployeesManagementForm_Load);
            this.Resize += new System.EventHandler(this.EmployeesManagementForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ActionsGroupBox.ResumeLayout(false);
            this.ActionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgeErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView EmployeesGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox UrlTxt;
        private System.Windows.Forms.Button SaveUrlBtn;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.Button GetByIdButton;
        private System.Windows.Forms.Button GetAllButton;
        private System.Windows.Forms.GroupBox ActionsGroupBox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox AgeTextBox;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider IdErrorProvider;
        private System.Windows.Forms.ErrorProvider FirstNameErrorProvider;
        private System.Windows.Forms.ErrorProvider LastNameErrorProvider;
        private System.Windows.Forms.ErrorProvider AgeErrorProvider;
        private System.Windows.Forms.PictureBox LoaderPictureBox;
    }
}

