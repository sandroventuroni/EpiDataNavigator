namespace EpiDataNavigator
{
    partial class FrmTableDetails
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
            this.dgwData = new System.Windows.Forms.DataGridView();
            this.dgwLinkIn = new System.Windows.Forms.DataGridView();
            this.dgwLinkOut = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkWithRow = new System.Windows.Forms.CheckBox();
            this.dgwLinkDt = new System.Windows.Forms.DataGridView();
            this.lblLinkDt = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWhere = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLinkIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLinkOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLinkDt)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwData
            // 
            this.dgwData.AllowUserToAddRows = false;
            this.dgwData.AllowUserToDeleteRows = false;
            this.dgwData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwData.Location = new System.Drawing.Point(18, 373);
            this.dgwData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgwData.Name = "dgwData";
            this.dgwData.ReadOnly = true;
            this.dgwData.Size = new System.Drawing.Size(1415, 327);
            this.dgwData.TabIndex = 0;
            this.dgwData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwData_CellDoubleClick);
            this.dgwData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgwData_DataError);
            // 
            // dgwLinkIn
            // 
            this.dgwLinkIn.AllowUserToAddRows = false;
            this.dgwLinkIn.AllowUserToDeleteRows = false;
            this.dgwLinkIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwLinkIn.Location = new System.Drawing.Point(18, 34);
            this.dgwLinkIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgwLinkIn.Name = "dgwLinkIn";
            this.dgwLinkIn.ReadOnly = true;
            this.dgwLinkIn.Size = new System.Drawing.Size(523, 292);
            this.dgwLinkIn.TabIndex = 1;
            this.dgwLinkIn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwLinkIn_CellClick);
            this.dgwLinkIn.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwLinkIn_CellDoubleClick);
            // 
            // dgwLinkOut
            // 
            this.dgwLinkOut.AllowUserToAddRows = false;
            this.dgwLinkOut.AllowUserToDeleteRows = false;
            this.dgwLinkOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwLinkOut.Location = new System.Drawing.Point(549, 34);
            this.dgwLinkOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgwLinkOut.Name = "dgwLinkOut";
            this.dgwLinkOut.ReadOnly = true;
            this.dgwLinkOut.Size = new System.Drawing.Size(518, 292);
            this.dgwLinkOut.TabIndex = 2;
            this.dgwLinkOut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwLinkOut_CellClick);
            this.dgwLinkOut.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwLinkOut_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "links (IN)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(549, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "links (OUT)";
            // 
            // chkWithRow
            // 
            this.chkWithRow.AutoSize = true;
            this.chkWithRow.Checked = true;
            this.chkWithRow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWithRow.Location = new System.Drawing.Point(406, 5);
            this.chkWithRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkWithRow.Name = "chkWithRow";
            this.chkWithRow.Size = new System.Drawing.Size(135, 24);
            this.chkWithRow.TabIndex = 7;
            this.chkWithRow.Text = "Only with rows";
            this.chkWithRow.UseVisualStyleBackColor = true;
            this.chkWithRow.CheckedChanged += new System.EventHandler(this.chkWithRow_CheckedChanged);
            // 
            // dgwLinkDt
            // 
            this.dgwLinkDt.AllowUserToAddRows = false;
            this.dgwLinkDt.AllowUserToDeleteRows = false;
            this.dgwLinkDt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwLinkDt.Location = new System.Drawing.Point(1075, 34);
            this.dgwLinkDt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgwLinkDt.Name = "dgwLinkDt";
            this.dgwLinkDt.ReadOnly = true;
            this.dgwLinkDt.Size = new System.Drawing.Size(358, 292);
            this.dgwLinkDt.TabIndex = 8;
            // 
            // lblLinkDt
            // 
            this.lblLinkDt.AutoSize = true;
            this.lblLinkDt.Location = new System.Drawing.Point(1071, 5);
            this.lblLinkDt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLinkDt.Name = "lblLinkDt";
            this.lblLinkDt.Size = new System.Drawing.Size(83, 20);
            this.lblLinkDt.TabIndex = 9;
            this.lblLinkDt.Text = "Link Detail";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(115, 342);
            this.txtRows.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(32, 26);
            this.txtRows.TabIndex = 11;
            this.txtRows.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 345);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rows in grid";
            // 
            // txtWhere
            // 
            this.txtWhere.Location = new System.Drawing.Point(249, 339);
            this.txtWhere.Name = "txtWhere";
            this.txtWhere.Size = new System.Drawing.Size(1103, 26);
            this.txtWhere.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Filter:";
            // 
            // cmbUpdate
            // 
            this.cmbUpdate.Location = new System.Drawing.Point(1358, 334);
            this.cmbUpdate.Name = "cmbUpdate";
            this.cmbUpdate.Size = new System.Drawing.Size(75, 31);
            this.cmbUpdate.TabIndex = 14;
            this.cmbUpdate.Text = "Update";
            this.cmbUpdate.UseVisualStyleBackColor = true;
            this.cmbUpdate.Click += new System.EventHandler(this.cmbUpdate_Click);
            // 
            // FrmTableDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 713);
            this.Controls.Add(this.cmbUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWhere);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLinkDt);
            this.Controls.Add(this.dgwLinkDt);
            this.Controls.Add(this.chkWithRow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwLinkOut);
            this.Controls.Add(this.dgwLinkIn);
            this.Controls.Add(this.dgwData);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmTableDetails";
            this.Text = "FrmTableDetails";
            ((System.ComponentModel.ISupportInitialize)(this.dgwData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLinkIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLinkOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLinkDt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwData;
        private System.Windows.Forms.DataGridView dgwLinkIn;
        private System.Windows.Forms.DataGridView dgwLinkOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkWithRow;
        private System.Windows.Forms.DataGridView dgwLinkDt;
        private System.Windows.Forms.Label lblLinkDt;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWhere;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmbUpdate;
    }
}