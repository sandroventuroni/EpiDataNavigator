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
    public partial class FrmTableDetails : Form
    {
        public string schema { get; set; }
        public string tableName { get; set; }
        public string dataTableId { get; set; }
        public FrmTableDetails()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            this.Text = " Detail table: " + schema + "." + tableName + "   datatableID: " + dataTableId;

            LoadDgwData();

            LoadDgwLink();
        }
        private void chkWithRow_CheckedChanged(object sender, EventArgs e)
        {
            LoadDgwLink();
        }
        public void LoadDgwLink()
        {
            using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
            {
                connection.Open();
                string query;

                //SubQuery
                string subQuery = " (SELECT sc.name scName, ta.name tbName " +
                            " , SUM(pa.rows) RowCnt " +
                            " FROM sys.tables ta " +
                            " INNER JOIN sys.partitions pa " +
                            " ON pa.OBJECT_ID = ta.OBJECT_ID " +
                            " INNER JOIN sys.schemas sc " +
                            " ON ta.schema_id = sc.schema_id " +
                            " WHERE ta.is_ms_shipped = 0 AND pa.index_id IN(1, 0) " +
                            " GROUP BY sc.name, ta.name ";
                if (chkWithRow.Checked == true)
                    subQuery = subQuery + " having SUM(pa.rows) > 0 ";

                subQuery = subQuery + " ) x on d.schemaname=scName and d.DbtableName=tbName ";


                //Query IN

                query = "select L.LookupID,d.DataTableID,d.SchemaName,d.DBTableName,RowCnt " +
                        " from ice.ZLookupLink L " +
                        " inner join Ice.ZDataTable D on l.ForeignSystemCode = d.SystemCode and l.ForeignDataTableID = d.DataTableID " +
                        ((chkWithRow.Checked == true) ? " INNER JOIN " : " LEFT OUTER JOIN ") +
                        subQuery +
                         " where L.DataTableId='" + dataTableId + "'";
                using (SqlCommand sqlCmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Fill(dtRecord);

                    dgwLinkIn.DataSource = dtRecord;
                    dgwLinkIn.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                dgwLinkIn.Columns[0].Visible = false;
                dgwLinkIn.Columns[1].Visible = false;
                dgwLinkIn.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                //Query OUT
                query = "select L.LookupID,d.DataTableID,d.SchemaName,d.DBTableName,RowCnt " +
                            " from ice.ZLookupLink L " +
                            " inner join Ice.ZDataTable D on l.SystemCode = d.SystemCode and l.DataTableID = d.DataTableID " +
                             ((chkWithRow.Checked == true) ? " INNER JOIN " : " LEFT OUTER JOIN ") +
                            subQuery +
                            " where ForeignDataTableID='" + dataTableId + "'";
                if (GlobalVar.OnlyPhisicalTables)
                    query = query + " and D.DBTableName=D.DataTableID ";

                using (SqlCommand sqlCmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Fill(dtRecord);

                    dgwLinkOut.DataSource = dtRecord;
                    dgwLinkOut.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                dgwLinkOut.Columns[0].Visible = false;
                dgwLinkOut.Columns[1].Visible = false;
                dgwLinkOut.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void dgwLinkIn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string schema = dgwLinkIn.Rows[e.RowIndex].Cells["SchemaName"].FormattedValue.ToString();
                string tableName = dgwLinkIn.Rows[e.RowIndex].Cells["DBTableName"].FormattedValue.ToString();
                string dataTableId = dgwLinkIn.Rows[e.RowIndex].Cells["DataTableID"].FormattedValue.ToString();

                FrmTableDetails frm = new FrmTableDetails();
                frm.MdiParent = GlobalVar.MDIparent;
                frm.schema = schema;
                frm.tableName = tableName;
                frm.dataTableId = dataTableId;
                frm.LoadData();
                frm.Show();
            }
        }

        private void dgwLinkOut_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string schema = dgwLinkOut.Rows[e.RowIndex].Cells["SchemaName"].FormattedValue.ToString();
                string tableName = dgwLinkOut.Rows[e.RowIndex].Cells["DBTableName"].FormattedValue.ToString();
                string dataTableId = dgwLinkOut.Rows[e.RowIndex].Cells["DataTableID"].FormattedValue.ToString();

                FrmTableDetails frm = new FrmTableDetails();
                frm.MdiParent = GlobalVar.MDIparent;
                frm.schema = schema;
                frm.tableName = tableName;
                frm.dataTableId = dataTableId;
                frm.LoadData();
                frm.Show();
            }
        }
        private void dgwLinkIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string schema = dgwLinkIn.Rows[e.RowIndex].Cells["SchemaName"].FormattedValue.ToString();
            //string dataTableId = dgwLinkIn.Rows[e.RowIndex].Cells["DataTableID"].FormattedValue.ToString();
            string lookupId = dgwLinkIn.Rows[e.RowIndex].Cells["LookupId"].FormattedValue.ToString();

            LoadLinkDetail(schema, dataTableId, lookupId);
        }
        private void dgwLinkOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string schema = dgwLinkOut.Rows[e.RowIndex].Cells["SchemaName"].FormattedValue.ToString();
            string dataTableId = dgwLinkOut.Rows[e.RowIndex].Cells["DataTableID"].FormattedValue.ToString();
            string lookupId = dgwLinkOut.Rows[e.RowIndex].Cells["LookupId"].FormattedValue.ToString();

            LoadLinkDetail(schema, dataTableId, lookupId);
        }

        private void LoadLinkDetail(string systemCode,string dataTableId, string LookUpId )
        {
            lblLinkDt.Text = "Link Detail table: " + systemCode + "." + dataTableId + " lookupid=" + LookUpId;


            using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
            { 
                connection.Open();
                string query = "select Seq,Fieldname " +
                                " from ice.ZLookupField" +
                                " where systemcode = '" + systemCode + "' " +
                                " and DataTableID = '" + dataTableId + "' " +
                                " and lookupid = '" + LookUpId + "'" +
                                " Order by 1";

                using (SqlCommand sqlCmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Fill(dtRecord);

                    dgwLinkDt.DataSource = dtRecord;
                    dgwLinkDt.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
        }


        private void cmbUpdate_Click(object sender, EventArgs e)
        {
            LoadDgwData();
        }

        public void LoadDgwData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
                {
                    connection.Open();
                    string query;

                    if ((schema != "") && (tableName != ""))
                    {
                        query = "select top " + txtRows.Text + " * from " + schema + "." + tableName + " " + txtWhere.Text;
                        using (SqlCommand sqlCmd = new SqlCommand(query, connection))
                        {
                            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
                            DataTable dtRecord = new DataTable();
                            sqlDataAdap.Fill(dtRecord);

                            dgwData.DataSource = dtRecord;
                            dgwData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Comando sql errato");
            }
        }
        private void dgwData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgwData.Columns[e.ColumnIndex].HeaderText;

            if (e.RowIndex == -1)
            {
                FrmColumnDetail frm = new FrmColumnDetail();
                frm.MdiParent = GlobalVar.MDIparent;
                frm.colName = colName;
                //frm.searchValue = cellvalue;
                frm.LoadData();
                frm.Show();
            }
            else
            {
                string cellvalue = dgwData.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();
                txtWhere.Text = txtWhere.Text.Trim();
                string Str = (txtWhere.Text.Length==0) ?"WHERE ":" AND ";
                txtWhere.Text = txtWhere.Text + Str + colName + "='" + cellvalue + "'";
                LoadDgwData();
            }
        }

        private void dgwData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //For special fields may be some errors, so this function is just to avoid to show the error 
        }
    }
}
