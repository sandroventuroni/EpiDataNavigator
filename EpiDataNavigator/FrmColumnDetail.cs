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
    public partial class FrmColumnDetail : Form
    {
        public string colName { get; set; }
        public string searchValue { get; set; }
        public FrmColumnDetail()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            this.Text = " Detail column: " + colName;

            txtSearch.Text = searchValue;

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

                subQuery = subQuery + " ) x on SystemCode=scName and DbtableName=tbName  ";

                query = "select SystemCode, DataTableID, DBTableName TableName,RowCnt " +
                        " from ice.ZDataField " +
                          ((chkWithRow.Checked == true) ? " INNER JOIN " : " LEFT OUTER JOIN ") +
                        subQuery +
                        " where DBFieldName <> ''  " +
                        "  and fieldname ='" + colName + "'";

                using (SqlCommand sqlCmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Fill(dtRecord);

                    dgwCol.DataSource = dtRecord;
                    dgwCol.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                dgwCol.Columns[0].Visible = false;
                //dgwCol.Columns[1].Visible = false;
                dgwCol.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

             
            }



        }

        private void dgwCol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string schema = dgwCol.Rows[e.RowIndex].Cells["Systemcode"].FormattedValue.ToString();
                string tableName = dgwCol.Rows[e.RowIndex].Cells["TableName"].FormattedValue.ToString();
                string dataTableId = dgwCol.Rows[e.RowIndex].Cells["DataTableId"].FormattedValue.ToString();

                FrmTableDetails frm = new FrmTableDetails();
                frm.MdiParent = GlobalVar.MDIparent;
                frm.schema = schema;
                frm.tableName = tableName;
                frm.dataTableId = dataTableId;
                frm.LoadData();
                frm.Show();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgwSearch.ColumnCount = 2;
            dgwSearch.RowCount = 0;
            dgwSearch.Columns[0].Name = "Table";
            dgwSearch.Columns[1].Name = "Count";

            using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
            {
                List<string> tb = new List<string>();

                connection.Open();
                SqlCommand cmdCount = new SqlCommand("", connection);
                string query = "select distinct systemcode,dbtablename " +
                                " from ice.ZDataField " +
                                " where FieldName='" + colName + "' " +
                                " and dbtablename<>'' order by 1";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tb.Add(reader.GetString(0) + "." + reader.GetString(1));  
                }
                reader.Close();

                for (int i = 0; i < tb.Count; i++)
                {
                    cmdCount.CommandText = "select count(*) from " + tb[i] + " where " + colName + "='" + txtSearch.Text.Trim() + "'";
                    int result=0;
                    try
                    {
                        result = (int)cmdCount.ExecuteScalar();
                    }
                    catch(System.Data.SqlClient.SqlException)
                    { }

                    if (result != 0)
                    {
                        dgwSearch.Rows.Add();
                        dgwSearch.Rows[dgwSearch.RowCount - 1].Cells[0].Value = tb[i];
                        dgwSearch.Rows[dgwSearch.RowCount - 1].Cells[1].Value = result.ToString();
                    }
                }
              
            }
        }
    }
}
