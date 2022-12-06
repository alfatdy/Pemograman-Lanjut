using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkademikApp
{
    public partial class FrmMahasiswa : Form
    {
        private IList<Mahasiswa> listOfMahasiswa = new List<Mahasiswa>();

        // constructor
        public FrmMahasiswa()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            FrmEntryMahasiswa frmEntry = new FrmEntryMahasiswa("Tambah Data mahasiswa");
            FrmEntry_OnCreate += FrmEntry_OnCreate;


            
        }

        private void lvwMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void InisialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No. ", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Npm", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 300, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Angkatan", 80, HorizontalAlignment.Center);
        }

        private void FrmEntry_OnCreate(Mahasiswa mhs)
        {
            listOfMahasiswa.Add(mhs);

            int noUrut = lvwMahasiswa.Items.Count + 1;

            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(mhs.Npm);
            item.SubItems.Add(mhs.Nama);
            item.SubItems.Add(mhs.Angkatan);

            lvwMahasiswa.Items.Add(item);
        }
        private void frmEntry_OnUpdate(Mahasiswa mhs)
        {
            int row = lvwMahasiswa.SelectedIndices[0];

            ListViewItem itemRow = lvwMahasiswa.Items[row];
            itemRow.SubItems[1].Text = mhs.Npm;
            itemRow.SubItems[2].Text = mhs.Nama;
            itemRow.SubItems[3].Text = mhs.Angkatan;
        }
    }
}
