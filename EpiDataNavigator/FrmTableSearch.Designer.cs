namespace EpiDataNavigator
{
    partial class FrmTableSearch
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
            this.Dgw1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRec = new System.Windows.Forms.RadioButton();
            this.rbExist = new System.Windows.Forms.RadioButton();
            this.rdAll = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkRowCnt = new System.Windows.Forms.CheckBox();
            this.cmbModule = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dgw1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dgw1
            // 
            this.Dgw1.AllowUserToAddRows = false;
            this.Dgw1.AllowUserToDeleteRows = false;
            this.Dgw1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgw1.Location = new System.Drawing.Point(16, 87);
            this.Dgw1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Dgw1.Name = "Dgw1";
            this.Dgw1.ReadOnly = true;
            this.Dgw1.Size = new System.Drawing.Size(1036, 420);
            this.Dgw1.TabIndex = 0;
            this.Dgw1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgw1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table Name";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(104, 14);
            this.txtTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(216, 22);
            this.txtTable.TabIndex = 2;
            this.txtTable.TextChanged += new System.EventHandler(this.txtTable_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbModule);
            this.groupBox1.Controls.Add(this.rbRec);
            this.groupBox1.Controls.Add(this.rbExist);
            this.groupBox1.Controls.Add(this.rdAll);
            this.groupBox1.Controls.Add(this.txtTable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(610, 76);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // rbRec
            // 
            this.rbRec.AutoSize = true;
            this.rbRec.Location = new System.Drawing.Point(201, 46);
            this.rbRec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbRec.Name = "rbRec";
            this.rbRec.Size = new System.Drawing.Size(114, 21);
            this.rbRec.TabIndex = 2;
            this.rbRec.Text = "With Records";
            this.rbRec.UseVisualStyleBackColor = true;
            this.rbRec.CheckedChanged += new System.EventHandler(this.rbRec_CheckedChanged);
            // 
            // rbExist
            // 
            this.rbExist.AutoSize = true;
            this.rbExist.Location = new System.Drawing.Point(116, 46);
            this.rbExist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbExist.Name = "rbExist";
            this.rbExist.Size = new System.Drawing.Size(77, 21);
            this.rbExist.TabIndex = 1;
            this.rbExist.Text = "Existing";
            this.rbExist.UseVisualStyleBackColor = true;
            this.rbExist.CheckedChanged += new System.EventHandler(this.rbExist_CheckedChanged);
            // 
            // rdAll
            // 
            this.rdAll.AutoSize = true;
            this.rdAll.Location = new System.Drawing.Point(13, 46);
            this.rdAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdAll.Name = "rdAll";
            this.rdAll.Size = new System.Drawing.Size(91, 21);
            this.rdAll.TabIndex = 0;
            this.rdAll.Text = "All Tables";
            this.rdAll.UseVisualStyleBackColor = true;
            this.rdAll.CheckedChanged += new System.EventHandler(this.rdAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rows in grid";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(104, 47);
            this.txtRows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(40, 22);
            this.txtRows.TabIndex = 5;
            this.txtRows.Text = "20";
            this.txtRows.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkRowCnt);
            this.groupBox2.Controls.Add(this.txtRows);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(634, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(177, 76);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // chkRowCnt
            // 
            this.chkRowCnt.AutoSize = true;
            this.chkRowCnt.Location = new System.Drawing.Point(16, 18);
            this.chkRowCnt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRowCnt.Name = "chkRowCnt";
            this.chkRowCnt.Size = new System.Drawing.Size(114, 21);
            this.chkRowCnt.TabIndex = 6;
            this.chkRowCnt.Text = "show RowCnt";
            this.chkRowCnt.UseVisualStyleBackColor = true;
            this.chkRowCnt.CheckedChanged += new System.EventHandler(this.chkRowCnt_CheckedChanged);
            // 
            // cmbModule
            // 
            this.cmbModule.FormattingEnabled = true;
            this.cmbModule.Location = new System.Drawing.Point(328, 14);
            this.cmbModule.Name = "cmbModule";
            this.cmbModule.Size = new System.Drawing.Size(275, 24);
            this.cmbModule.TabIndex = 3;
            this.cmbModule.SelectedIndexChanged += new System.EventHandler(this.cmbModule_SelectedIndexChanged);
            // 
            // FrmTableSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 522);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Dgw1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmTableSearch";
            this.Text = "FrmTableSearch";
            this.Load += new System.EventHandler(this.FrmTableSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgw1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgw1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRec;
        private System.Windows.Forms.RadioButton rbExist;
        private System.Windows.Forms.RadioButton rdAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkRowCnt;
        private System.Windows.Forms.ComboBox cmbModule;
    }
}