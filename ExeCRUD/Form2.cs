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
    public partial class Data : Form
    {

        public Data()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exeCRUDDataSet.Karyawan' table. You can move, or remove it, as needed.
            this.karyawanTableAdapter.Fill(this.exeCRUDDataSet.Karyawan);


            this.karyawanTableAdapter.Fill(this.exeCRUDDataSet.Karyawan);

            txtNIK.Enabled= false;
            txtNama.Enabled= false;
            txtID.Enabled= false;
            cmdSave.Enabled= false;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string NIK;

            cmdSave.Enabled = true;
            txtNama.Enabled = true;
            txtNIK.Enabled = true;
            txtID.Enabled = true;
            txtNama.Text = "";
            txtNIK.Text = "";
            txtID.Text = "";

            int ctr, len;
            string codeval;
            dt = exeCRUDDataSet.Tables["Data"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            NIK = dr["Data"].ToString();
            codeval = NIK.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr >= 0) && (ctr < 9999))
            {
                ctr = ctr + 1;
                txtNIK.Text = "C00" + ctr;
            }
            else if ((ctr >= 9) && (ctr < 99999))
            {
                ctr = ctr + 1;
                txtNIK.Text = "C0" + ctr;
            }
            else if (ctr >= 999999)
            {
                ctr = ctr + 1;
                txtNIK.Text = "C" + ctr;
            }
            cmdAdd.Enabled = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string NIK;

            dt = exeCRUDDataSet.Tables["Data"];
            dr = dt.NewRow();
            dr[0] = txtNIK.Text;
            dr[1] = txtNama.Text;
            dr[2] = txtID.Text;
            dt.Rows.Add(dr);
            karyawanTableAdapter.Update(exeCRUDDataSet);
            txtNIK.Text = System.Convert.ToString(dr[0]);
            txtNIK.Enabled = false;
            txtNama.Enabled = false;
            txtID.Enabled = false;
            this.karyawanTableAdapter.Fill(this.exeCRUDDataSet.Karyawan);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string NIK;

            NIK = txtID.Text;
            dr = exeCRUDDataSet.Tables["Data"].Rows.Find(NIK);
            dr.Delete();
            karyawanTableAdapter.Update(exeCRUDDataSet);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DataStatus Data2 = new DataStatus();
            Data2.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Hide();
        }
    }
}
