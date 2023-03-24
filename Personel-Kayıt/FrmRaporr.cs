using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_Kayıt
{
    public partial class FrmRaporr : Form
    {
        public FrmRaporr()
        {
            InitializeComponent();
        }

        private void FrmRaporr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet4.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet4.Tbl_Personel);

            this.reportViewer1.RefreshReport();
        }
    }
}
