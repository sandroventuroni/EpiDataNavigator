using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EpiDataNavigator
{
    public partial class FrmChangeTracker : Form
    {
        public string dbname;
        public string changeVersion = "0";
        public FrmChangeTracker()
        {
            InitializeComponent();
        }
        private void FrmChangeTracker_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(GlobalVar.connString);
            dbname = builder.InitialCatalog;
            this.Text = "Change Tracker SERVER=" + builder.DataSource + "  database:" + dbname;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            StatusLabel1.Text = "Starting...";
            this.Refresh();
            Cursor.Current = Cursors.WaitCursor;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("", connection);
                    cmd.CommandTimeout = 6000;
                    cmd.CommandText = "execute sandro.DbTrackEnable ";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "select CHANGE_TRACKING_CURRENT_VERSION()";
                    long rec = (long)cmd.ExecuteScalar();
                    changeVersion = rec.ToString();
                    lblVersion.Text = string.Format("Version: {0} ", changeVersion);
                }

                StatusLabel1.Text = "Start completed";
                MessageBox.Show("Start completed");
                btnLoad.Enabled = true;
                btnStop.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            /*
            if (MessageBox.Show("It may takes a couple of minutes, do you confirm?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            */

            btnLoad.Enabled = false;
            StatusLabel1.Text = "Loading...";
            this.Refresh();
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
                {
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandTimeout = 6000;
                    sqlCmd.Connection = connection;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "execute sandro.DbTrackGet " + changeVersion;

                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Fill(dtRecord);

                    dgw1.DataSource = dtRecord;
                    dgw1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                }

                StatusLabel1.Text = "Loading completed";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;
            btnLoad.Enabled = true;
        }


        private void btnStop_Click(object sender, EventArgs e)
        {

            StatusLabel1.Text = "Stopping...";
            this.Refresh();
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("", connection);
                    cmd.CommandTimeout = 6000;
                    cmd.CommandText = "execute sandro.DbTrackDisable ";
                    cmd.ExecuteNonQuery();

                    StatusLabel1.Text = "Stop completed";
                    MessageBox.Show("Stop completed");
                    btnLoad.Enabled = true;
                    btnStop.Enabled = true;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;
            btnStart.Enabled = true;
            btnLoad.Enabled = false;
            btnStop.Enabled = false;

            dgw1.DataSource = null;
            dgw1.Rows.Clear();

            dgw2.DataSource = null;
            dgw2.Rows.Clear();

        }

        private void dgw1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnStart.Enabled)
            {
                if (e.RowIndex >= 0)
                {
                    //if (e.ColumnIndex == 0)
                    {
                        string table = dgw1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                        lblDetails.Text = "details of table: " + table;

                        string query = "select * from CHANGETABLE(CHANGES "
                            + table
                            + ", " + changeVersion.ToString() + ") x ";

                        using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
                        {
                            connection.Open();

                            SqlCommand sqlCmd = new SqlCommand();
                            sqlCmd.Connection = connection;
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.CommandText = query;

                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);

                            dgw2.DataSource = dtRecord;
                            dgw2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

                        }
                    }

                    if (e.ColumnIndex == 1)
                    {
                        string query = " select * from " + dgw1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();

                        for (int row = 0; row < dgw2.RowCount; row++)
                        {
                            query += (row == 0) ? " where (" : " or (";
                            for (int col = 5; col < dgw2.ColumnCount; col++)
                            {
                                query += (col == 5) ? "" : " and ";
                                query += dgw2.Columns[col].HeaderText.ToString() + "=";
                                query += "'" + dgw2.Rows[row].Cells[col].FormattedValue.ToString() + "'";

                            }
                            query += ") ";
                        }

                       
                        FrmDataCompare frm = new FrmDataCompare();
                        frm.LoadFromCaller(query);
                        frm.MdiParent = this.MdiParent;
                        frm.Show();
                       
                    }
                }

            }
        }
        private void dgw2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        private void btnTest_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("", connection);

                cmd.CommandText = " update customers set birthdate=getdate()  ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = " update docmast set date=getdate()  ";
                cmd.ExecuteNonQuery();
            }
        }

        private void FrmChangeTracker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnStart.Enabled == false)
            {
                MessageBox.Show("Stop tracking before close this form");
                e.Cancel = true;
            }
        }
    }
}
