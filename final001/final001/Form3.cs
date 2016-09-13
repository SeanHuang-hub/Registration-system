using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final001
{
    public partial class Form3 : Form
    {
        int idx = 0;
        String iden;
        patientDataSet patientSet;
        patientDataSetTableAdapters.patientTableAdapter patientAdapter;

        public Form3(String ident)
        {
            InitializeComponent();

            iden = ident;
            patientAdapter = new patientDataSetTableAdapters.patientTableAdapter();
            patientSet = new patientDataSet();
            patientAdapter.Fill(patientSet.patient);

            idx = patientSet.patient.Rows.Count - 1;
            while (idx >= 0)
            {
                DataRow dr = patientSet.patient.Rows[idx];
                if (!dr.IsNull("identity"))
                {
                    if (ident.ToString() == dr["identity"].ToString())
                    {

                        label1.Text = label1.Text + dr["name"].ToString()+" (先生/小姐)";
                    }
                    idx--;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Send(iden);
            f6.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            patientAdapter = new patientDataSetTableAdapters.patientTableAdapter();
            patientSet = new patientDataSet();
            patientAdapter.Fill(patientSet.patient);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Send(iden);
            f5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
