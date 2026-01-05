using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamphan_WorkingBCMBP_WF
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnHopdongThoathuan_Click(object sender, EventArgs e)
        {

        }

        private void btnEVNSPC_Click(object sender, EventArgs e)
        {
            FormEVNSPC frm = new FormEVNSPC();
            frm.Show();
        }
    }
}
