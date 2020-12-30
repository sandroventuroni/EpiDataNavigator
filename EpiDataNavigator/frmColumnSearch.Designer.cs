namespace EpiDataNavigator
{
    partial class frmColumnSearch
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCol = new System.Windows.Forms.TextBox();
            this.Dgw1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgw1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRows);
            this.groupBox2.Location = new System.Drawing.Point(296, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(119, 57);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rows in grid";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(24, 21);
            this.txtRows.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(45, 26);
            this.txtRows.TabIndex = 5;
            this.txtRows.Text = "20";
            this.txtRows.TextChanged += new System.EventHandler(this.txtRows_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCol);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(275, 57);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Column name";
            // 
            // txtCol
            // 
            this.txtCol.Location = new System.Drawing.Point(17, 21);
            this.txtCol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCol.Name = "txtCol";
            this.txtCol.Size = new System.Drawing.Size(242, 26);
            this.txtCol.TabIndex = 2;
            this.txtCol.TextChanged += new System.EventHandler(this.txtCol_TextChanged);
            // 
            // Dgw1
            // 
            this.Dgw1.AllowUserToAddRows = false;
            this.Dgw1.AllowUserToDeleteRows = false;
            this.Dgw1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgw1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgw1.Location = new System.Drawing.Point(13, 81);
            this.Dgw1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Dgw1.Name = "Dgw1";
            this.Dgw1.ReadOnly = true;
            this.Dgw1.Size = new System.Drawing.Size(417, 553);
            this.Dgw1.TabIndex = 7;
            this.Dgw1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgw1_CellDoubleClick);
            // 
            // frmColumnSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 648);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Dgw1);
            this.Name = "frmColumnSearch";
            this.Text = "frmColumnSearch";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgw1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCol;
        private System.Windows.Forms.DataGridView Dgw1;
    }
}