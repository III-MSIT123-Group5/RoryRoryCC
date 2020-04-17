using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.lblMaster.Text = "LOG Files";

            System.IO.DirectoryInfo dirs = new System.IO.DirectoryInfo(@"c:\windows");
            FileInfo[] files = dirs.GetFiles();

            this.dataGridView1.DataSource = files;

        }
    }
}
