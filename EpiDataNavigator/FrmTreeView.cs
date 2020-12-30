using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpiDataNavigator
{
    public partial class FrmTreeView : Form
    {
        public FrmTreeView()
        {
            InitializeComponent();
        }

        private void FrmTreeView_Load(object sender, EventArgs e)
        {

        }

        public void LoadFromCaller()
        {
            LoadTree();
        }

        private void LoadTree()
        {
            Boolean onlyWithRow = chkOnlyWithRows.Checked;

            string queryLevel12 = @"
 CREATE TABLE #Tmp
 (Key1 varchar(2),
  Key2 varchar(4),
  Key3 varchar(100),
  Level_ smallint,	
  tbName varchar(100),
  dbName varchar(100),
  Descr varchar(200),
  RowNum integer)

  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'00','System objects')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'AM','Asset Management')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'CM','Contract Management')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'CO','Configuration BOM')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'DI','Direct Invoicing')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'GL','General Ledger')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'HR','Resourse Management')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'MA','Market Database')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'MP','Material Production Control')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'OR','Sales Order')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'PA','Payroll')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'PC','Purchase Order')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'PL','Purchase Ledger')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'PN','Promissory Notes')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'PR','Project Management')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'SC','Stock Control')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'SL','Sales Ledger')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'SM','Service Order Management')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'SO','Other objects')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'ST','Statistics')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'SY','System Utilities/Office Autom.')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'UD','User-defined')
  INSERT INTO #Tmp (Level_, Key1, Descr) VALUES (1,'ZZ','UNKNOW')

  INSERT INTO #Tmp (Level_,Key1,Key2,tbName, Descr)
  SELECT 2,SUBSTRING(ObjectName,1,2),  ObjectName,NameMask,Comment 
  FROM dbo.ScaDBObjects 
  WHERE TypeCode='ST' AND len(ObjectName) = 4

  UPDATE #Tmp
  SET Key1='ZZ'
  WHERE Level_=2
  AND Key1 NOT IN (SELECT Key1 FROM #Tmp WHERE Level_=1)

  UPDATE #Tmp SET RowNum=0;

";

            string queryLevel3 = @"
  INSERT INTO #Tmp (Level_, Key2, Key3, tbName, dbName, Descr, RowNum)
  SELECT 3,SUBSTRING(o.name,1,4) , '##DB##.' + o.name,  o.name,'##DB##' AS dbName, '##DB##.' + o.name, ddps.row_count 
FROM ##DB##.sys.indexes AS i
  INNER JOIN ##DB##.sys.objects AS o ON i.OBJECT_ID = o.OBJECT_ID
  INNER JOIN ##DB##.sys.dm_db_partition_stats AS ddps ON i.OBJECT_ID = ddps.OBJECT_ID
  AND i.index_id = ddps.index_id 
WHERE i.index_id < 2  AND o.is_ms_shipped = 0 
AND len(o.name)=8";

            string queryLevel3filterOnlyRow = " AND ddps.row_count>0";

            string querySumRowCount = @"
DELETE FROM #Tmp
WHERE Level_ = 3
AND Key2 NOT IN (SELECT DISTINCT Key2 FROM #Tmp WHERE Level_ = 2)

UPDATE #Tmp SET RowNum =totRow
FROM #Tmp a
INNER JOIN (SELECT Key2,sum(RowNum) totRow FROM #Tmp WHERE Level_=3 GROUP BY Key2) b ON a.Key2=b.Key2
WHERE Level_=2

UPDATE #Tmp SET RowNum =totRow
FROM #Tmp a
INNER JOIN (SELECT Key1,sum(RowNum) totRow FROM #Tmp WHERE Level_=2 GROUP BY Key1) b ON a.Key1=b.Key1
WHERE Level_=1;

";
            string queryDeleteNoRow = "delete from #Tmp where RowNum=0 or RowNum is null; ";

            string queryReturn = "select * from #Tmp order by Level_, Key1, Key2,Key3 ";

            //Begin

            string query = queryLevel12;

            using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select distinct DBName from ScaCompanies", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string dbName = reader.GetString(0);
                    query = query + queryLevel3.Replace("##DB##", dbName);
                    if (onlyWithRow)
                        query = query + queryLevel3filterOnlyRow;
                }
                reader.Close();
            }

            query = query + querySumRowCount;

            if (onlyWithRow)
                query = query + queryDeleteNoRow;

            query = query + queryReturn;

            //Load Tree
            tv1.Nodes.Clear();

            using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int level_ = rd.GetInt16(rd.GetOrdinal("Level_"));
                    if (level_ == 1)
                    {
                        string nodeDescr = rd.GetString(rd.GetOrdinal("Descr"));
                        string key = rd.GetString(rd.GetOrdinal("Key1"));
                        TreeNode node = tv1.Nodes.Add(key, key + "-" + nodeDescr);
                        node.Tag = "";
                    }

                    if (level_ == 2)
                    {

                        string nodeDescr = rd.GetString(rd.GetOrdinal("Descr"));
                        string keyParent = rd.GetString(rd.GetOrdinal("Key1"));
                        string keyChild = rd.GetString(rd.GetOrdinal("Key2"));
                        int RowNum = rd.GetInt32(rd.GetOrdinal("RowNum"));
                        TreeNode parentNode = tv1.Nodes.Find(keyParent, true).First();
                        TreeNode childNode = parentNode.Nodes.Add(keyChild, keyChild + "-" + nodeDescr + " (" + RowNum.ToString() + ")");
                        childNode.Tag = "";
                    }

                    if (level_ == 3)
                    {
                        string nodeDescr = rd.GetString(rd.GetOrdinal("Descr"));
                        string keyParent = rd.GetString(rd.GetOrdinal("Key2"));
                        string keyChild = rd.GetString(rd.GetOrdinal("Key3"));
                        int RowNum = rd.GetInt32(rd.GetOrdinal("RowNum"));
                        TreeNode parentNode = tv1.Nodes.Find(keyParent, true).First();
                        TreeNode childNode = parentNode.Nodes.Add(nodeDescr + " (" + RowNum.ToString() + ")");
                        childNode.Tag = nodeDescr;
                    }
                }
                rd.Close();
            }
        }

        private void chkOnlyWithRows_CheckedChanged(object sender, EventArgs e)
        {
            LoadTree();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                SearchText();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchText();
        }

        private void SearchText()
        {
            string toSearch = txtSearch.Text;
            tv1.CollapseAll();
            foreach (TreeNode nodeParent in tv1.Nodes)
            {
                foreach (TreeNode node in nodeParent.Nodes)
                {
                    string nodeDesc = node.Text;
                    if (nodeDesc.IndexOf(toSearch, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        node.BackColor = Color.Green;
                        nodeParent.Expand();
                        node.Expand();
                    }
                    else
                        node.BackColor = Color.White;
                }
            }
        }

        private void tv1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadG1();
        }


        private void LoadG1()
        {
            g1.Rows.Clear();
            g1.Columns.Clear();
            string tag = tv1.SelectedNode.Tag.ToString();
            if (string.IsNullOrWhiteSpace(tag))
                return;

            string topRec = txtTop.Text.Trim();
            if (!string.IsNullOrWhiteSpace(topRec))
                topRec = " top " + topRec;

            string query = Utility.QueryTableStructure(tag, topRec) + " " + txtFilter.Text;

            GridLoader gl = new GridLoader(GlobalVar.connString, query, g1);
            gl.SetStdLink();
            gl.SetGridCol();
            gl.LoadGrid();
        }

        private void txtTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                LoadG1();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                LoadG1();
        }
    }
}
