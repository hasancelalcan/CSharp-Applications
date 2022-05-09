using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Sistemi
{
    public partial class Girişler : Form
    {
        public Girişler()
        {
            InitializeComponent();
        }

        private void btNHastaGiris_Click(object sender, EventArgs e)
        {
            HastaGiriş fr = new HastaGiriş();
            fr.Show();
            this.Hide();
        }

        private void btnDoktorGiris_Click(object sender, EventArgs e)
        {
            DoktorGiriş fr = new DoktorGiriş();
            fr.Show();
            this.Hide();
        }

        private void btnSekreterGiris_Click(object sender, EventArgs e)
        {
            SekreterGirişi fr = new SekreterGirişi();
            fr.Show();
            this.Hide();
        }
    }
}
