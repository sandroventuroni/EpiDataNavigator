namespace EpiDataNavigator
{
    partial class FrmTreeView
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
            this.tv1 = new System.Windows.Forms.TreeView();
            this.chkOnlyWithRows = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.g1 = new System.Windows.Forms.DataGridView();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.g1)).BeginInit();
            this.SuspendLayout();
            // 
            // tv1
            // 
            this.tv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tv1.Location = new System.Drawing.Point(12, 40);
            this.tv1.Name = "tv1";
            this.tv1.Size = new System.Drawing.Size(447, 530);
            this.tv1.TabIndex = 0;
            this.tv1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterSelect);
            // 
            // chkOnlyWithRows
            // 
            this.chkOnlyWithRows.AutoSize = true;
            this.chkOnlyWithRows.Checked = true;
            this.chkOnlyWithRows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyWithRows.Location = new System.Drawing.Point(23, 13);
            this.chkOnlyWithRows.Name = "chkOnlyWithRows";
            this.chkOnlyWithRows.Size = new System.Drawing.Size(120, 21);
            this.chkOnlyWithRows.TabIndex = 1;
            this.chkOnlyWithRows.Text = "Only with rows";
            this.chkOnlyWithRows.UseVisualStyleBackColor = true;
            this.chkOnlyWithRows.CheckedChanged += new System.EventHandler(this.chkOnlyWithRows_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(199, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(198, 22);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(403, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // g1
            // 
            this.g1.AllowUserToAddRows = false;
            this.g1.AllowUserToDeleteRows = false;
            this.g1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.g1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g1.Location = new System.Drawing.Point(466, 41);
            this.g1.Name = "g1";
            this.g1.ReadOnly = true;
            this.g1.RowTemplate.Height = 24;
            this.g1.Size = new System.Drawing.Size(648, 529);
            this.g1.TabIndex = 4;
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(566, 12);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(46, 22);
            this.txtTop.TabIndex = 5;
            this.txtTop.Text = "20";
            this.txtTop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTop_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Top";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(670, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filter";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(715, 13);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(399, 22);
            this.txtFilter.TabIndex = 7;
            this.txtFilter.Text = "where 1=1";
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // FrmTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 582);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTop);
            this.Controls.Add(this.g1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.chkOnlyWithRows);
            this.Controls.Add(this.tv1);
            this.Name = "FrmTreeView";
            this.Text = "FrmTreeView";
            this.Load += new System.EventHandler(this.FrmTreeView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.g1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv1;
        private System.Windows.Forms.CheckBox chkOnlyWithRows;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView g1;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilter;
    }
}