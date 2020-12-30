using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpiDataNavigator;

namespace EpiDataNavigator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
            string selectDB= frm.selectDB;

            if (selectDB != "")
            {
                MdiForm1 mdi = new MdiForm1();
                /*
                mdi.selectDB = selectDB;
                if (selectDB == "PROD")
                    mdi.connString = "Data Source=HIZMET11;Initial Catalog=Epicor10Production;Integrated Security=True";
                if (selectDB == "PILOT")
                    mdi.connString = "Data Source=HIZMET11;Initial Catalog=Epicor10Pilot;Integrated Security=True";
                */
                GlobalVar.selectDB = selectDB;
                if (GlobalVar.selectDB == "TESTSYS")
                    GlobalVar.connString = "Data Source=100.0.0.25;Initial Catalog=ScaSystemDB;Integrated Security=True";
                if (GlobalVar.selectDB == "TEST")
                    GlobalVar.connString = "Data Source=100.0.0.25;Initial Catalog=scalaDB;Integrated Security=True";
                if (GlobalVar.selectDB == "PROD")
                    GlobalVar.connString = "Data Source=HIZMET11;Initial Catalog=Epicor10Production;Integrated Security=True";
                if (GlobalVar.selectDB == "TRAIN")
                    GlobalVar.connString = "Data Source=HIZMET11;Initial Catalog=Epicor10Train;Integrated Security=True";
                if (GlobalVar.selectDB == "SANDRO")
                    GlobalVar.connString = "Data Source=lewa\\sqlexpress;Initial Catalog=sampleDB;Integrated Security=True";
                GlobalVar.MDIparent = mdi;

                mdi.WindowState = FormWindowState.Maximized;
                Application.Run(mdi);
            }
        }
    }
}
