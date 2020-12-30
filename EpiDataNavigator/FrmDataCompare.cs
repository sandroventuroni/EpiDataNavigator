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
    public partial class FrmDataCompare : Form
    {
        public FrmDataCompare()
        {
            InitializeComponent();
        }

        public void LoadFromCaller(string query)
        {
            txtQuery1.Text = query;
        }

        private void btnLoad1_Click(object sender, EventArgs e)
        {
            string query = txtQuery1.Text.Trim();

            if (query == "")
            {
                MessageBox.Show("please enter a query");
                return;
            }

            if (g1.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Confirm reload?", "Confirm", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
                {
                    connection.Open();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = connection;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = query;

                    SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                    DataTable dtTable = new DataTable();
                    sqlAdp.Fill(dtTable);

                    g1.DataSource = dtTable;
                    //g1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                g1.DataSource = null;
                g1.Rows.Clear();
            }
            g1.CurrentCell = null;
        }

        private void btnLoad2_Click(object sender, EventArgs e)
        {
            if (txtQuery2.Text == "")
                txtQuery2.Text = txtQuery1.Text;


            string query = txtQuery2.Text.Trim();
            if (query == "")
            {
                MessageBox.Show("please enter a query");
                return;
            }

            if (g2.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Confirm reload?", "Confirm", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
                {
                    connection.Open();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = connection;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = query;

                    SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                    DataTable dtTable = new DataTable();
                    sqlAdp.Fill(dtTable);

                    g2.DataSource = dtTable;
                    //g1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                g2.DataSource = null;
                g2.Rows.Clear();
            }
            g2.CurrentCell = null;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            ResetColor(g1);
            ResetColor(g2);

            g3.Rows.Clear();

            for (int x = 0; x < Math.Max(g1.Rows.Count, g2.Rows.Count); x++)
            {
                for (int y = 0; y < Math.Max(g1.Columns.Count, g2.Columns.Count); y++)
                {
                    string value1 = getCellValue(g1, x, y);
                    string value2 = getCellValue(g2, x, y);

                    if (value1 != value2)
                    {
                        string head1 = getCellHeader(g1, y);
                        string head2 = getCellHeader(g2, y);
                        string head = (head1 == head2) ? head1 : head1 + "/" + head2;

                        g3.Rows.Add(x, y,head, value1, value2);
                        PaintRedCell(g1, x, y);
                        PaintRedCell(g2, x, y);
                    }
                        
                } 
            }
            g1.ClearSelection();
            g2.ClearSelection();
            g3.ClearSelection();

        }

        private void g3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int row = Convert.ToInt32(g3.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
            int col = Convert.ToInt32(g3.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());

            SelectCell(g1, row, col);
            SelectCell(g2, row, col);

            g1.ClearSelection();
            g2.ClearSelection();
        }

        private string getCellValue(DataGridView g, int row, int col)
        {
            if (row < g.RowCount && col < g.ColumnCount)
                return g.Rows[row].Cells[col].FormattedValue.ToString();
            else
                return "<NF>";
            
        }

        private string getCellHeader(DataGridView g, int col)
        {
            if (col < g.ColumnCount)
                return g.Columns[col].HeaderText.ToString();
            else
                return "<NF>";

        }


        private void SelectCell(DataGridView g, int row, int col)
        {
            if (row < g.RowCount && col < g.ColumnCount)
            {
                g.CurrentCell = g.Rows[row].Cells[col];
            }
            else
            {
                g.CurrentCell = null;
            }
        }

        private void PaintRedCell(DataGridView g, int row, int col)
        {
            if (row < g.RowCount && col < g.ColumnCount)
            {
                g[col,row].Style.BackColor = Color.Red;
            }
        }

        private void ResetColor(DataGridView g)
        {
            foreach (DataGridViewRow row in g.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }

        }

        private void FrmDataCompare_Load(object sender, EventArgs e)
        {
            
        }

        private void g1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void g2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void g3_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
