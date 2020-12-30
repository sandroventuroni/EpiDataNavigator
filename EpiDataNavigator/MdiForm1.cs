using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpiDataNavigator
{
    public partial class MdiForm1 : Form
    {

        public MdiForm1()
        {
            InitializeComponent();
        }

        #region TableSearch
        private void tableSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goTableSearch();
        }

        private void tsTableSearch_Click(object sender, EventArgs e)
        {
            goTableSearch();
        }

        private void goTableSearch()
        {
            FrmTableSearch frm = new FrmTableSearch();
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion

        #region ColumnsSearch

        private void columnsSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goColumnSearch();
        }


        private void tsColumnSearch_Click(object sender, EventArgs e)
        {
            goColumnSearch();
        }

        private void goColumnSearch()
        {
            frmColumnSearch frm = new frmColumnSearch();
            frm.MdiParent = this;
            frm.Show();
        }

        #endregion

        #region ChangeTracker
        private void tsChangeTracker_Click(object sender, EventArgs e)
        {
            goChangeTracker();
        }

        private void changeTrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goChangeTracker();
        }

        private void goChangeTracker()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "FrmChangeTracker")
                {
                    form.Focus();
                    return;
                }
            }

            FrmChangeTracker frm = new FrmChangeTracker();
            frm.MdiParent = this;
            frm.Show();
        }

        #endregion

        #region OtherMenu
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("selectDB: " + GlobalVar.selectDB + "\n connString:" + GlobalVar.connString,"About");
        }





        #endregion

        private void tsDataCompare_Click(object sender, EventArgs e)
        {
            FrmDataCompare frm = new FrmDataCompare();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsTreeView_Click(object sender, EventArgs e)
        {
            FrmTreeView frm = new FrmTreeView();
            frm.MdiParent = this;
            frm.LoadFromCaller();
            frm.Show();

        }
    }
}
