using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace EpiDataNavigator
{
    public class GridLoader
    {
        public List<GridLoaderRecord> myList = new List<GridLoaderRecord>();

        public DataTable myDt = new DataTable();

        public string ConnectionString { get; set; }
        public string QueryString { get; set; }
        public Boolean AddIfNotExists { get; set; }
        public DataGridView myGrid { get; set; }

        public GridLoader(string connString, string qryString, DataGridView grd, Boolean addIfNotExists=true )
        {
            ConnectionString = connString;
            QueryString = qryString;
            myGrid = grd;
            AddIfNotExists = addIfNotExists;

            if (!string.IsNullOrWhiteSpace(ConnectionString))
                LoadDataTable();
        }

        /*
        public GridLoader(string connString, string qryString, DataGridView grd, bool addIfNotExists = true) : this(connString, qryString, grd, addIfNotExists)
        {
        }

        public GridLoader(string connString, string v, DataGridView g1)
        {
            this.connString = connString;
            this.v = v;
            this.g1 = g1;
        }
        */

        //1st Step: Called by GridLoader: execute query and populate MyList 
        public void LoadDataTable()
        {
            myList.Clear();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(QueryString, connection))
                {
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    try
                    {
                        ada.Fill(myDt);
                    }
                    catch
                    {
                        MessageBox.Show("Query error: " + QueryString);
                    }
                    int i = 1000;
                    foreach (DataColumn col in myDt.Columns)
                    {
                        i++;
                        myList.Add(new GridLoaderRecord {columnOrder = i, columnName = col.ColumnName.ToString().Trim(), dataType = ConvDataType(col.DataType.ToString()),
                                                        gridCol = -1, isLink=false, isHidden=false , isMerge=false});
                    }
                }
            }
        }


        //2nd step: after loading MyList, is possible to customize, like set a column as link 
        public void SetLink(string colName)
        {
            var item = myList.FirstOrDefault(x => x.columnName.ToLower() == colName.ToLower());
            if (item != null)
                item.isLink = true;
        }

        public void SetStdLink()
        {
            foreach (var item in myList)
            {
                /*
                if (CallForms.isStdClick(item.columnName.ToLower()))
                    item.isLink = true;
                    */
            }
        }

        public void SetHidden(string colName)
        {
            var item = myList.FirstOrDefault(x => x.columnName.ToLower() == colName.ToLower());
            if (item != null)
                item.isHidden = true;
        }

        public void SetMerge(string colName)
        {
            var item = myList.FirstOrDefault(x => x.columnName.ToLower() == colName.ToLower());
            if (item != null)
                item.isMerge = true;
        }

        //3rd step: set grid column: set (populate gridCol) or add column into the grid
        public void SetGridCol()
        {
            foreach (GridLoaderRecord rec in myList.OrderBy(t=>t.columnOrder))
            {
                int iFound = -1;

                for (int i = 0; i < myGrid.Columns.Count; i++)
                {
                    if (rec.columnName.ToLower() == myGrid.Columns[i].Name.ToLower())
                    {
                        iFound = i;
                        break;
                    }
                }

                if (iFound > -1)
                    rec.gridCol = iFound;
                else
                {
                    if (AddIfNotExists)
                    {
                        int newCol = 0;
                        if (!rec.isLink)
                        {
                            newCol = myGrid.Columns.Add(rec.columnName, rec.columnName);
                            if (rec.dataType == "Int")
                            {
                                myGrid.Columns[newCol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                                myGrid.Columns[newCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }
                        else
                        {
                            DataGridViewLinkColumn col = new DataGridViewLinkColumn();
                            col.DataPropertyName = rec.columnName;
                            col.Name = rec.columnName;
                            newCol = myGrid.Columns.Add(col);
                        }
                        rec.gridCol = newCol;

                        if (rec.isHidden)
                            myGrid.Columns[newCol].Visible = false;

                        myGrid.Columns[newCol].SortMode= DataGridViewColumnSortMode.Automatic;

                    }
                }
            }
        }


        //4th step: load data into grid
        public void LoadGrid()
        {
            myGrid.Rows.Clear();
            String[] oldVal = new String[1000];

            foreach (DataRow row in myDt.Rows)
            {
                int r = myGrid.Rows.Add();

                if (r == 0) // Save old values
                    foreach (var x in myList)
                        if (x.gridCol != -1)
                            oldVal[x.gridCol] = row[x.columnName].ToString();

                foreach (var x in myList)
                {
                    if (x.gridCol != -1)
                    {
                        string value = row[x.columnName].ToString();

                        if ((r != 0) && (x.isMerge))
                        {
                            if (value == oldVal[x.gridCol])
                            {
                                value = "";
                            }
                            else
                                oldVal[x.gridCol] = value;
                        }

                        if (x.dataType == "Date")
                        {
                            if (!x.columnName.Contains("Time"))
                            {
                                if (value.Length > 11)
                                    value = value.Substring(0, 6) + value.Substring(8, 2);
                            }
                            else
                                if (value.Length > 16)
                                    value = value.Substring(0, 16);
                        }  

                        if (x.dataType == "Decimal")
                        {
                            Decimal test = 0;
                            Decimal.TryParse(value, out test);
                            if (x.columnName.Contains("Cost"))
                                value = test.ToString("#.####");
                            else
                                value = test.ToString("#.##");
                        }

                        if (x.dataType == "Int")
                        {
                            int test = 0;
                            int.TryParse(value, out test);
                            value = test.ToString("#"); 
                        }

                        if (x.dataType == "Boolean")
                        {
                            if (value == "True") value = "Y";
                            if (value == "False") value = "N";
                        }


                        myGrid.Rows[r].Cells[x.gridCol].Value = value;
                    }
                }

            }

            myGrid.ClearSelection();

        }

        private string ConvDataType(string strInput)
        {
            string result=strInput;

            if (strInput == "System.String")
                result = "String";

            if (strInput == "System.DateTime")
                result = "Date";

            if (strInput == "System.Decimal")
                result = "Decimal";

            if (strInput == "System.Int16" || strInput == "System.Int32" || strInput == "System.Int64")
                result = "Int";

            if (strInput == "System.Boolean")
                result = "Boolean";

            if (result == strInput)
                MessageBox.Show(strInput);

            return result;
        }

    }
}
