namespace EpiDataNavigator
{
    partial class FrmDataCompare
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
            this.btnLoad1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery1 = new System.Windows.Forms.TextBox();
            this.g1 = new System.Windows.Forms.DataGridView();
            this.g2 = new System.Windows.Forms.DataGridView();
            this.txtQuery2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoad2 = new System.Windows.Forms.Button();
            this.g3 = new System.Windows.Forms.DataGridView();
            this.btnCompare = new System.Windows.Forms.Button();
            this.Row_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Header_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.g1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad1
            // 
            this.btnLoad1.Location = new System.Drawing.Point(335, 17);
            this.btnLoad1.Name = "btnLoad1";
            this.btnLoad1.Size = new System.Drawing.Size(57, 23);
            this.btnLoad1.TabIndex = 0;
            this.btnLoad1.Text = "Load 1";
            this.btnLoad1.UseVisualStyleBackColor = true;
            this.btnLoad1.Click += new System.EventHandler(this.btnLoad1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Query 1:";
            // 
            // txtQuery1
            // 
            this.txtQuery1.Location = new System.Drawing.Point(66, 19);
            this.txtQuery1.Name = "txtQuery1";
            this.txtQuery1.Size = new System.Drawing.Size(262, 20);
            this.txtQuery1.TabIndex = 2;
            // 
            // g1
            // 
            this.g1.AllowUserToAddRows = false;
            this.g1.AllowUserToDeleteRows = false;
            this.g1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.g1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g1.Location = new System.Drawing.Point(16, 44);
            this.g1.Name = "g1";
            this.g1.ReadOnly = true;
            this.g1.RowHeadersVisible = false;
            this.g1.Size = new System.Drawing.Size(376, 501);
            this.g1.TabIndex = 3;
            this.g1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.g1_DataError);
            // 
            // g2
            // 
            this.g2.AllowUserToAddRows = false;
            this.g2.AllowUserToDeleteRows = false;
            this.g2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.g2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g2.Location = new System.Drawing.Point(419, 44);
            this.g2.Name = "g2";
            this.g2.ReadOnly = true;
            this.g2.RowHeadersVisible = false;
            this.g2.Size = new System.Drawing.Size(376, 501);
            this.g2.TabIndex = 7;
            this.g2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.g2_DataError);
            // 
            // txtQuery2
            // 
            this.txtQuery2.Location = new System.Drawing.Point(469, 19);
            this.txtQuery2.Name = "txtQuery2";
            this.txtQuery2.Size = new System.Drawing.Size(262, 20);
            this.txtQuery2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Query 2:";
            // 
            // btnLoad2
            // 
            this.btnLoad2.Location = new System.Drawing.Point(738, 17);
            this.btnLoad2.Name = "btnLoad2";
            this.btnLoad2.Size = new System.Drawing.Size(57, 23);
            this.btnLoad2.TabIndex = 4;
            this.btnLoad2.Text = "Load 2";
            this.btnLoad2.UseVisualStyleBackColor = true;
            this.btnLoad2.Click += new System.EventHandler(this.btnLoad2_Click);
            // 
            // g3
            // 
            this.g3.AllowUserToAddRows = false;
            this.g3.AllowUserToDeleteRows = false;
            this.g3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.g3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row_,
            this.Col_,
            this.Header_,
            this.Value1,
            this.Value2});
            this.g3.Location = new System.Drawing.Point(811, 44);
            this.g3.Name = "g3";
            this.g3.ReadOnly = true;
            this.g3.RowHeadersVisible = false;
            this.g3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g3.Size = new System.Drawing.Size(403, 501);
            this.g3.TabIndex = 9;
            this.g3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.g3_CellClick);
            this.g3.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.g3_DataError);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(811, 16);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(57, 23);
            this.btnCompare.TabIndex = 8;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // Row_
            // 
            this.Row_.HeaderText = "Row";
            this.Row_.Name = "Row_";
            this.Row_.ReadOnly = true;
            this.Row_.Width = 30;
            // 
            // Col_
            // 
            this.Col_.HeaderText = "Col";
            this.Col_.Name = "Col_";
            this.Col_.ReadOnly = true;
            this.Col_.Width = 30;
            // 
            // Header_
            // 
            this.Header_.HeaderText = "Header";
            this.Header_.Name = "Header_";
            this.Header_.ReadOnly = true;
            // 
            // Value1
            // 
            this.Value1.HeaderText = "Value1";
            this.Value1.Name = "Value1";
            this.Value1.ReadOnly = true;
            // 
            // Value2
            // 
            this.Value2.HeaderText = "Value2";
            this.Value2.Name = "Value2";
            this.Value2.ReadOnly = true;
            // 
            // FrmDataCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 557);
            this.Controls.Add(this.g3);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.g2);
            this.Controls.Add(this.txtQuery2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoad2);
            this.Controls.Add(this.g1);
            this.Controls.Add(this.txtQuery1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoad1);
            this.Name = "FrmDataCompare";
            this.Text = "FrmDataCompare";
            this.Load += new System.EventHandler(this.FrmDataCompare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.g1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery1;
        private System.Windows.Forms.DataGridView g1;
        private System.Windows.Forms.DataGridView g2;
        private System.Windows.Forms.TextBox txtQuery2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoad2;
        private System.Windows.Forms.DataGridView g3;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Header_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value2;
    }
}