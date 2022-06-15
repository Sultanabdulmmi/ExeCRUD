using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExeCRUD
{
    public partial class DataStatus : Form
    {
        public DataStatus()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DataStatus_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exeCRUDDataSet1.Status_Karyawan' table. You can move, or remove it, as needed.
            this.status_KaryawanTableAdapter.Fill(this.exeCRUDDataSet1.Status_Karyawan);

            txtID.Enabled = false;
            cbStatus.Items.Add("Ketua");
            cbStatus.Items.Add("Sekertaris");
            cbStatus.Items.Add("Bendahara");
            cbStatus.Items.Add("Bendahara2");
            cmdSave.Enabled = false;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string Code;

            cmdSave.Enabled = true;
            txtID.Enabled = true;
            cbStatus.Enabled = true;
            txtID.Text = "";
            cbStatus.Text = "";

            int ctr, len;
            string codeval;
            dt = exeCRUDDataSet1.Tables["Status"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            Code = dr["ccode"].ToString();
            codeval = Code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr >= 0) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtID.Text = "C00" + ctr;
            }
            else if ((ctr >= 9) && (ctr < 99))
            {
                ctr = ctr + 1;
                txtID.Text = "C0" + ctr;
            }
            else if (ctr >= 99)
            {
                ctr = ctr + 1;
                txtID.Text = "C" + ctr;
            }
            cmdAdd.Enabled = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string Code;

            dt = exeCRUDDataSet1.Tables["Status"];
            dr = dt.NewRow();
            dr[0] = txtID.Text;
            dr[1] = cbStatus.SelectedItem;
            dt.Rows.Add(dr);
            status_KaryawanTableAdapter.Update(exeCRUDDataSet1);
            txtID.Text = System.Convert.ToString(dr[0]);
            txtID.Enabled = false;
            cbStatus.Enabled = false;
            this.status_KaryawanTableAdapter.Fill(this.exeCRUDDataSet1.Status_Karyawan);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string Code;

            Code = txtID.Text;
            dr = exeCRUDDataSet1.Tables["Status"].Rows.Find(Code);
            dr.Delete();
            status_KaryawanTableAdapter.Update(exeCRUDDataSet1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Data Data3 = new Data();
            Data3.Show();
            this.Hide();
        }
    }
}
