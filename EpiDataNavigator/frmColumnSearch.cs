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
    public partial class frmColumnSearch : Form
    {
        public frmColumnSearch()
        {
            InitializeComponent();
        }

        private void txtRows_TextChanged(object sender, EventArgs e)
        {
            LoadDgw1();
        }

        private void txtCol_TextChanged(object sender, EventArgs e)
        {
            LoadDgw1();
        }

        private void LoadDgw1()
        {
            string query = " select top " + txtRows.Text + " DESCRIPTION FieldName, count(*) Cnt " +
                            " from dbo.SCA_TAB_COLUMNS " +
                            " where DESCRIPTION <> '' " +
                            " and DESCRIPTION like '" + txtCol.Text.Trim() + "%'";
            query = query + " group by DESCRIPTION order by 1";

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
            if (e.RowIndex >= 0)
            {
                string colName = Dgw1.Rows[e.RowIndex].Cells["FieldName"].FormattedValue.ToString();

                FrmColumnDetail frm = new FrmColumnDetail();
                frm.MdiParent = GlobalVar.MDIparent;
                frm.colName = colName;
                frm.LoadData();
                frm.Show();
            }
        }
    }
}
