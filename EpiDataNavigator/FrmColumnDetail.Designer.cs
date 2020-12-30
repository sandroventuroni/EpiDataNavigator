namespace EpiDataNavigator
{
    partial class FrmColumnDetail
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
            this.chkWithRow = new System.Windows.Forms.CheckBox();
            this.dgwCol = new System.Windows.Forms.DataGridView();
            this.dgwSearch = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // chkWithRow
            // 
            this.chkWithRow.AutoSize = true;
            this.chkWithRow.Checked = true;
            this.chkWithRow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWithRow.Location = new System.Drawing.Point(13, 14);
            this.chkWithRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkWithRow.Name = "chkWithRow";
            this.chkWithRow.Size = new System.Drawing.Size(135, 24);
            this.chkWithRow.TabIndex = 9;
            this.chkWithRow.Text = "Only with rows";
            this.chkWithRow.UseVisualStyleBackColor = true;
            // 
            // dgwCol
            // 
            this.dgwCol.AllowUserToAddRows = false;
            this.dgwCol.AllowUserToDeleteRows = false;
            this.dgwCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgwCol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwCol.Location = new System.Drawing.Point(13, 48);
            this.dgwCol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgwCol.Name = "dgwCol";
            this.dgwCol.ReadOnly = true;
            this.dgwCol.Size = new System.Drawing.Size(485, 473);
            this.dgwCol.TabIndex = 8;
            this.dgwCol.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwCol_CellDoubleClick);
            // 
            // dgwSearch
            // 
            this.dgwSearch.AllowUserToAddRows = false;
            this.dgwSearch.AllowUserToDeleteRows = false;
            this.dgwSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgwSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSearch.Location = new System.Drawing.Point(521, 48);
            this.dgwSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgwSearch.Name = "dgwSearch";
            this.dgwSearch.ReadOnly = true;
            this.dgwSearch.Size = new System.Drawing.Size(314, 473);
            this.dgwSearch.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(724, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 38);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Text search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(524, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(184, 26);
            this.txtSearch.TabIndex = 12;
            // 
            // FrmColumnDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 535);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgwSearch);
            this.Controls.Add(this.chkWithRow);
            this.Controls.Add(this.dgwCol);
            this.Name = "FrmColumnDetail";
            this.Text = "FrmColumnDetail";
            ((System.ComponentModel.ISupportInitialize)(this.dgwCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkWithRow;
        private System.Windows.Forms.DataGridView dgwCol;
        private System.Windows.Forms.DataGridView dgwSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}