namespace ZAWDotNetTrainingBatch2.WinFormsApp1
{
    partial class FrmStaff
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            StaffCode = new Label();
            txtCode = new TextBox();
            txtEmail = new TextBox();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtMobileNo = new TextBox();
            label5 = new Label();
            cobPosition = new ComboBox();
            dgvData = new DataGridView();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colId = new DataGridViewTextBoxColumn();
            colCode = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(419, 404);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // StaffCode
            // 
            StaffCode.AutoSize = true;
            StaffCode.Location = new Point(271, 30);
            StaffCode.Name = "StaffCode";
            StaffCode.Size = new Size(99, 25);
            StaffCode.TabIndex = 1;
            StaffCode.Text = "Staff Code:";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(271, 58);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(260, 31);
            txtCode.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(271, 180);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(260, 31);
            txtEmail.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(271, 152);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 3;
            label1.Text = "Email:";
            // 
            // txtName
            // 
            txtName.Location = new Point(271, 118);
            txtName.Name = "txtName";
            txtName.Size = new Size(260, 31);
            txtName.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(271, 90);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 5;
            label2.Text = "Staff Name:";
            label2.Click += btnSave_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(271, 242);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(260, 31);
            txtPassword.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(271, 214);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 7;
            label3.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(271, 276);
            label4.Name = "label4";
            label4.Size = new Size(79, 25);
            label4.TabIndex = 9;
            label4.Text = "Position:";
            // 
            // txtMobileNo
            // 
            txtMobileNo.Location = new Point(271, 366);
            txtMobileNo.Name = "txtMobileNo";
            txtMobileNo.Size = new Size(260, 31);
            txtMobileNo.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(271, 338);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 11;
            label5.Text = "MoibleNo";
            // 
            // cobPosition
            // 
            cobPosition.FormattingEnabled = true;
            cobPosition.Items.AddRange(new object[] { "--Select One--", "Admin", "User" });
            cobPosition.Location = new Point(271, 302);
            cobPosition.Name = "cobPosition";
            cobPosition.Size = new Size(258, 33);
            cobPosition.TabIndex = 13;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete, colId, colCode, colName });
            dgvData.Location = new Point(538, -1);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 62;
            dgvData.Size = new Size(529, 274);
            dgvData.TabIndex = 14;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Resizable = DataGridViewTriState.True;
            colEdit.SortMode = DataGridViewColumnSortMode.Automatic;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Width = 150;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.MinimumWidth = 8;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            colDelete.Width = 150;
            // 
            // colId
            // 
            colId.DataPropertyName = "StaffId";
            colId.HeaderText = "StaffId";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 150;
            // 
            // colCode
            // 
            colCode.DataPropertyName = "StaffCode";
            colCode.HeaderText = "Staff code";
            colCode.MinimumWidth = 8;
            colCode.Name = "colCode";
            colCode.ReadOnly = true;
            colCode.Width = 150;
            // 
            // colName
            // 
            colName.DataPropertyName = "StaffName";
            colName.HeaderText = "Staff Name";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 150;
            // 
            // FrmStaff
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 450);
            Controls.Add(dgvData);
            Controls.Add(cobPosition);
            Controls.Add(txtMobileNo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Controls.Add(txtCode);
            Controls.Add(StaffCode);
            Controls.Add(btnSave);
            Name = "FrmStaff";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff Register";
            Load += FrmStaff_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Label StaffCode;
        private TextBox txtCode;
        private TextBox txtEmail;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtPassword;
        private Label label3;
        private Label label4;
        private TextBox txtMobileNo;
        private Label label5;
        private ComboBox cobPosition;
        private DataGridView dgvData;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colName;
    }
}
