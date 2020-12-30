using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;

namespace EpiDataNavigator
{
    public static class Utility
    {
        public static string str2Sql(string txt, bool LikeEnd = false, bool LikeStart = false)
        {
            txt = txt.Trim();

            return "'" +
                (LikeStart ? "%" : "") +
                txt.Replace("'", "''") +
                (LikeEnd ? "%" : "") +
                "'";
        }


        public static int GetScalarInt(string query, string conn = "")
        {
            if (string.IsNullOrWhiteSpace(conn))
                conn = GlobalVar.connString;
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    object obj = cmd.ExecuteScalar();
                    if (obj.GetType() != typeof(DBNull))
                        return Convert.ToInt32(obj.ToString());
                    else
                        return 0;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetScalarString(string query, string conn = "")
        {
            if (string.IsNullOrWhiteSpace(conn))
                conn = GlobalVar.connString;
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        return obj.ToString();
                    else
                        return "";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal GetScalarDecimal(string query, string conn = "")
        {
            if (string.IsNullOrWhiteSpace(conn))
                conn = GlobalVar.connString;
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    object obj = cmd.ExecuteScalar();
                    if (obj == null)
                        return 0;
                    else
                    if (obj.GetType() != typeof(DBNull))
                        return Convert.ToDecimal(obj);
                    else
                        return 0;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ExecNonQuery(string query, string conn = "")
        {
            if (string.IsNullOrWhiteSpace(conn))
                conn = GlobalVar.connString;
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CopyGrid2Clip(DataGridView g1)
        {

            bool hRowVis = g1.RowHeadersVisible;
            bool hColVis = g1.ColumnHeadersVisible;

            string result = "";
            string value = "";
            //Header
            if (hColVis)
                result = result + "\t";

            foreach (DataGridViewColumn column in g1.Columns)
            {
                DataGridViewColumnHeaderCell headerCell = column.HeaderCell;
                string headerCaptionText = column.HeaderText;
                result = result + headerCaptionText + "\t";
            }
            result = result + "\n";

            //Body
            for (int x = 0; x < g1.RowCount; x++)
            {
                if (hColVis)
                {
                    value = "";
                    try
                    { value = g1.Rows[x].HeaderCell.Value.ToString(); }
                    catch (Exception ex)
                    {
                        if (ex.Message == "")
                            value = "";
                    }

                    result = result + value + "\t";
                }

                for (int y = 0; y < g1.ColumnCount; y++)
                {
                    value = g1.Rows[x].Cells[y].FormattedValue.ToString();
                    //value = value.Replace("/n", "");
                    //value = value.Replace("/r", "");
                    //value = value.Replace("/t", "");
                    value = value.Replace(char.ConvertFromUtf32(30), "");
                    value = value.Replace(char.ConvertFromUtf32(10), "");
                    value = value.Replace(char.ConvertFromUtf32(13), "");

                    result = result + value + "\t";
                }
                result = result + "\n";
            }
            Clipboard.Clear();
            Clipboard.SetDataObject(result);
            MessageBox.Show("Data grid was copied into clipboard!");

        }

        public static string GetMd5Hash(string password)
        {
            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
               // without dashes
               .Replace("-", string.Empty)
               // make lowercase
               .ToLower();

            return encoded;
        }

        public static string GetNextString(string inString)
        {
            string result = "";
            inString = inString.Trim();
            if (string.IsNullOrWhiteSpace(inString))
                result = "A";
            else
            {
                int i = inString.Length - 1;
                char lastChar = Char.ToUpper(inString[i]);

                string newChar = "";
                if (lastChar == '9')
                    newChar = "A";
                else if (lastChar == 'Z')
                    newChar = "Z0";
                else
                {
                    lastChar = (char)((int)lastChar + 1);
                    newChar = lastChar.ToString();
                }

                if (i == 0)
                    result = newChar;
                else
                    result = inString.Substring(0, i) + newChar;
            }

            return result;
        }


        public static string GetPartDescription(string partNum)
        {
            return Utility.GetScalarString("select PartDescription from erp.part where company='GURALP' " +
                                                            " and partnum=" + Utility.str2Sql(partNum));
        }
        public static string GetPartRevision(string partNum)
        {
            return Utility.GetScalarString("select top 1 RevisionNum from erp.partrev where company='GURALP' " +
                                                            " and partnum=" + Utility.str2Sql(partNum) + " and approved=1 " +
                                                            " order by ApprovedDate desc, RevisionNum desc");
        }

        public static bool MsgBoxYesNo(string message, string title = "Warning")
        {
            DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            return (dialogResult == DialogResult.Yes);
        }

        public static void RunLeoUpdater()
        {
            Process p = new Process();
            p.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\LeoUpdater.exe";
            p.StartInfo.Verb = "runas";
            p.Start();
            Application.Exit();
        }






        public static void DataGridEnaDisable(DataGridView dgv)
        {
            if (!dgv.Enabled)
            {
                dgv.ClearSelection();
                dgv.DefaultCellStyle.BackColor = SystemColors.Control;
                dgv.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText;
                dgv.ReadOnly = true;
                dgv.EnableHeadersVisualStyles = false;
            }
            else
            {
                dgv.DefaultCellStyle.BackColor = SystemColors.Window;
                dgv.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Window;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
                dgv.ReadOnly = false;
                dgv.EnableHeadersVisualStyles = true;
            }
        }

        public static void OpenPath(string file)
        {
            file = file.Trim();
            string uCaseFile = file.ToUpper();
            if (uCaseFile.StartsWith("C:") || uCaseFile.StartsWith("D:") || uCaseFile.StartsWith("E:") || uCaseFile.StartsWith("U:"))
            {
                MessageBox.Show(string.Format("File name {0} is not in a network path!", file));
                return;
            }

            if (file.StartsWith("http"))
            {
                System.Diagnostics.Process.Start(file);
                /*
                if (WebPageExists(file))
                    System.Diagnostics.Process.Start(file);
                else
                    MessageBox.Show(string.Format("Can't reach web page {0} !", file));

                return;
                */

            }


            //File name
            string newFile = file;
            while (true)
            {
                if (File.Exists(newFile) || Directory.Exists(newFile))
                {
                    System.Diagnostics.Process.Start(newFile);
                    break;
                }

                int pos = newFile.LastIndexOf("\\");
                if (pos <= 1)
                {
                    MessageBox.Show(string.Format("File not valid {0} !", file));
                    return;
                }

                newFile = newFile.Substring(0, pos);
            }
        }

        public static bool WebPageExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }

        public static string QueryTableStructure(string dbTable, string TopRec)
        {
            String[] elements = dbTable.Split('.');
            string db = elements[0];
            string table = elements[1];
            int objId = Utility.GetScalarInt("SELECT ObjectID FROM ScaDBObjects WHERE ObjectName='" + table.Substring(0, 4) + "'");

            string result = "select " + TopRec;
            string query = "SELECT ColumnName,Comment FROM dbo.ScaColumns WHERE dbo.ScaColumns.ObjectID=" + objId.ToString() + " ORDER BY OrderID";
            using (SqlConnection connection = new SqlConnection(GlobalVar.connString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string colName = rd.GetString(rd.GetOrdinal("ColumnName"));
                    string colDesc = rd.GetString(rd.GetOrdinal("Comment"));
                    colDesc = colDesc.Trim();

                    result = result + " " + colName + " [" + colDesc + "],";
                }
            }

            result = result.Substring(0, result.Length - 1);
            result = result + " from " + db + ".dbo." + table;

            return result;

        }
    }
}
