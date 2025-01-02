using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Sql;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLcasino
{


    public partial class formTQL : Form
    {
        public formTQL()
        {
            InitializeComponent();
        }
    

        private void bntKH_Click(object sender, EventArgs e)
        {
            formKhach formKhach = new formKhach();  
            formKhach.ShowDialog();
            this.Close();
        }

        private void bntNV_Click(object sender, EventArgs e)
        {
            this.Hide();
            formDK formDK = new formDK();
           formDK.ShowDialog();
     
        }

        private void formTQL_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }
    }
}
