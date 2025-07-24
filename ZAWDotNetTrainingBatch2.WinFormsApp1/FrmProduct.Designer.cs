namespace ZAWDotNetTrainingBatch2.WinFormsApp1
{
    partial class FrmProduct
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
            label1 = new Label();
            txtProductCode = new TextBox();
            label2 = new Label();
            txtProductItem = new TextBox();
            label3 = new Label();
            txtPrice = new TextBox();
            label4 = new Label();
            cheIsDelete = new CheckBox();
            btnSave = new Button();
            label5 = new Label();
            dgvProductList = new DataGridView();
            colEdit = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProductList).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 9;
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(18, 32);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(207, 31);
            txtProductCode.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 65);
            label2.Name = "label2";
            label2.Size = new Size(130, 25);
            label2.TabIndex = 2;
            label2.Text = "Product Name:";
            // 
            // txtProductItem
            // 
            txtProductItem.Location = new Point(18, 92);
            txtProductItem.Name = "txtProductItem";
            txtProductItem.Size = new Size(207, 31);
            txtProductItem.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 125);
            label3.Name = "label3";
            label3.Size = new Size(53, 25);
            label3.TabIndex = 4;
            label3.Text = "Price:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(18, 152);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(207, 31);
            txtPrice.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 188);
            label4.Name = "label4";
            label4.Size = new Size(70, 25);
            label4.TabIndex = 6;
            label4.Text = "Disable";
            // 
            // cheIsDelete
            // 
            cheIsDelete.AutoSize = true;
            cheIsDelete.Location = new Point(203, 192);
            cheIsDelete.Name = "cheIsDelete";
            cheIsDelete.Size = new Size(22, 21);
            cheIsDelete.TabIndex = 7;
            cheIsDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(113, 219);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 8;
            btnSave.Text = "Saving";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 6);
            label5.Name = "label5";
            label5.Size = new Size(125, 25);
            label5.TabIndex = 10;
            label5.Text = "Product Code:";
            // 
            // dgvProductList
            // 
            dgvProductList.AllowUserToAddRows = false;
            dgvProductList.AllowUserToDeleteRows = false;
            dgvProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductList.Columns.AddRange(new DataGridViewColumn[] { colEdit });
            dgvProductList.Location = new Point(247, 12);
            dgvProductList.Name = "dgvProductList";
            dgvProductList.ReadOnly = true;
            dgvProductList.RowHeadersWidth = 62;
            dgvProductList.Size = new Size(674, 201);
            dgvProductList.TabIndex = 11;
            dgvProductList.CellClick += dgvProductList_CellClick;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Width = 150;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 450);
            Controls.Add(dgvProductList);
            Controls.Add(label5);
            Controls.Add(btnSave);
            Controls.Add(cheIsDelete);
            Controls.Add(label4);
            Controls.Add(txtPrice);
            Controls.Add(label3);
            Controls.Add(txtProductItem);
            Controls.Add(label2);
            Controls.Add(txtProductCode);
            Controls.Add(label1);
            Name = "FrmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmProduct";
            Load += frmProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtProductCode;
        private Label label2;
        private TextBox txtProductItem;
        private Label label3;
        private TextBox txtPrice;
        private Label label4;
        private CheckBox cheIsDelete;
        private Button btnSave;
        private Label label5;
        private DataGridView dgvProductList;
        private DataGridViewButtonColumn colEdit;
    }
}