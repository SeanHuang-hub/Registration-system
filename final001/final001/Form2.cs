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
    public partial class Form2 : Form
    {
        int idx=0;
        patientDataSet doctorSet;
        patientDataSetTableAdapters.doctorTableAdapter doctorAdapter;

        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            doctorAdapter = new patientDataSetTableAdapters.doctorTableAdapter();
            doctorSet = new patientDataSet();
            doctorAdapter.Fill(doctorSet.doctor);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2_Load(sender,e);
            int check = 0;
            idx =doctorSet.doctor.Count-1;
            if (textBox1.Text == "0000" && textBox2.Text == "0000")
            {
                check = 1;
                Form7 f7 = new Form7("0000");
                f7.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                f7.Show();
                this.Hide();
                
            }
            while (idx >= 0)
            {
                DataRow dr = doctorSet.doctor.Rows[idx];
                if (!dr.IsNull("accountnumber"))
                {
                    if (textBox1.Text == dr["accountnumber"].ToString())
                    {
                        if (!dr.IsNull("password"))
                        {
                            if (textBox2.Text == dr["password"].ToString())
                            {
                                check = 1;
                                Form7 f7 = new Form7(dr["name"].ToString());
                                f7.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                                f7.Show();
                                this.Hide();
                                
                            }
                        }
                    }
                    idx--;
                }
            }
            if (check == 0)
                label3.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();//子視窗關閉時,父視窗再顯示出來
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
