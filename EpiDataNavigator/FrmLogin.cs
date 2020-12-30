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
    public partial class FrmLogin : Form
    {
        public string selectDB { get; set; }

        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Text = "Login 1.1";
            txtUser.Text = Environment.UserName;
            cmbDb.Items.Clear();
            cmbDb.Items.Add(new Item("TESTSYS", 1));
            cmbDb.Items.Add(new Item("TEST", 2));
            cmbDb.SelectedIndex = 0;
            selectDB = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string db= cmbDb.Text.ToString();
            if (db == "")
            {
                MessageBox.Show("Select a database");
                return;
            }

            selectDB = db;
            this.Close();

            /*

            string ListUsers = "";
            
            if (db == "TEST")
                ListUsers = "sandro.venturoni,";

            if (!ListUsers.Contains(txtUser.Text.ToLower() + ","))
            {
                MessageBox.Show("User not allowed");
            }
            else
            {
                selectDB = db;
                this.Close();
            }

            */
        }  
    }
}
