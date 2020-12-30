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
    public partial class FrmTableSearch : Form
    {
        public FrmTableSearch()
        {
            InitializeComponent();
        }

        private void FrmTableSearch_Load(object sender, EventArgs e)
        {
            cmbModule.Items.Clear();
            cmbModule.Items.Add("00 - System objects");
            cmbModule.Items.Add("AM Asset Management");
            cmbModule.Items.Add("CM Contract Management");
            cmbModule.Items.Add("DI Direct Invoicing");
            cmbModule.Items.Add("GL General Ledger");
            cmbModule.Items.Add("HR Resourse Management");
            cmbModule.Items.Add("MA Market Database");
            cmbModule.Items.Add("MP Material Production Control");
            cmbModule.Items.Add("OR Sales Order");
            cmbModule.Items.Add("PA Payroll");
            cmbModule.Items.Add("PC Purchase Order");
            cmbModule.Items.Add("PL Purchase Ledger");
            cmbModule.Items.Add("PN Promissory Notes");
            cmbModule.Items.Add("PR Project Management");
            cmbModule.Items.Add("SC Stock Control");
            cmbModule.Items.Add("SL Sales Ledger");
            cmbModule.Items.Add("SM Service Order Management");
            cmbModule.Items.Add("SO Other objects");
            cmbModule.Items.Add("ST Statistics");
            cmbModule.Items.Add("SY System Utilities/Office Autom.");
            cmbModule.Items.Add("UD User-defined");

        }

        private void cmbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTable.Text = cmbModule.Text.Substring(0,2);
        }

        private void txtTable_TextChanged(object sender, EventArgs e)
        {
            LoadDgw1();
        }
        private void rdAll_CheckedChanged(object sender, EventArgs e)
        {
             LoadDgw1();
        }
        private void rbExist_CheckedChanged(object sender, EventArgs e)
        {
            LoadDgw1();
        }
        private void rbRec_CheckedChanged(object sender, EventArgs e)
        {
            LoadDgw1();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadDgw1();
        }

        private void chkRowCnt_CheckedChanged(object sender, EventArgs e)
        {
            LoadDgw1();
        }
        private void LoadDgw1()
        {
            string subQuery = " (SELECT sc.name scName, ta.name tbName " +
                            " , SUM(pa.rows) RowCnt " +
                            " FROM sys.tables ta " +
                            " INNER JOIN sys.partitions pa " +
                            " ON pa.OBJECT_ID = ta.OBJECT_ID " +
                            " INNER JOIN sys.schemas sc " +
                            " ON ta.schema_id = sc.schema_id " +
                            " WHERE ta.is_ms_shipped = 0 AND pa.index_id IN(1, 0) " +
                            " GROUP BY sc.name, ta.name ";
            if (rbRec.Checked == true)
                subQuery = subQuery + " having SUM(pa.rows) > 0 ";

            subQuery = subQuery + " )" +
                            " x on SCHEMA_NAME(schema_id)=scName and name=tbName ";

            string query = " select top " + txtRows.Text + " SCHEMA_NAME(schema_id) as SchemaName, name TableName ";

            if (chkRowCnt.Checked == true)
                query = query + " , RowCnt ";

            query = query + " from sys.tables ";

            if (rbRec.Checked == true)
                query = query + " inner join " + subQuery;
            else if (chkRowCnt.Checked == true)
                query = query + " left outer join " + subQuery;
            
            query = query + " where name like '" + txtTable.Text.Trim() + "%'";
            if (rbExist.Checked==true)
                query = query + " and TableName<>''";

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

                Dgw1.DataSource = dtRecord;
                Dgw1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }

        }

        private void Dgw1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                string schema = Dgw1.Rows[e.RowIndex].Cells["SchemaName"].FormattedValue.ToString();
                string tableName = Dgw1.Rows[e.RowIndex].Cells["TableName"].FormattedValue.ToString();
                //string dataTableId = Dgw1.Rows[e.RowIndex].Cells["DataTableId"].FormattedValue.ToString();

                FrmTableDetails frm = new FrmTableDetails();
                frm.MdiParent = GlobalVar.MDIparent;
                frm.schema = schema;
                frm.tableName = tableName;
                //frm.dataTableId = dataTableId;
                frm.LoadData();
                frm.Show();
            }

        }


    }
}
