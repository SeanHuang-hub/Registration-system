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
    public partial class Form5 : Form
    {
        String iden;
        int idx = 0, check = 0;
        patientDataSet subjectSet;
        patientDataSetTableAdapters.subjectTableAdapter subjectAdapter;
        patientDataSet doctorSet;
        patientDataSetTableAdapters.doctorTableAdapter doctorAdapter;
        public Form5()
        {
            InitializeComponent();

        }

        public void Send(String ident)
        {
            iden = ident;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            subjectAdapter = new patientDataSetTableAdapters.subjectTableAdapter();
            subjectSet = new patientDataSet();
            subjectAdapter.Fill(subjectSet.subject);

            doctorAdapter = new patientDataSetTableAdapters.doctorTableAdapter();
            doctorSet = new patientDataSet();
            doctorAdapter.Fill(doctorSet.doctor);

            comboBox1.Text = "1";
            comboBox2.Text = "1";
            comboBox3.Items.Add("一般內科");
            comboBox3.Items.Add("胸腔內科");
            comboBox3.Items.Add("神經內科");
            comboBox3.Items.Add("整形外科");
            comboBox3.Items.Add("骨科");
            comboBox3.Items.Add("皮膚科");
            comboBox3.Items.Add("眼科");
            comboBox3.Items.Add("牙科");
            comboBox3.Items.Add("婦產科");
            comboBox3.Items.Add("兒科");
            comboBox3.Items.Add("中醫");
            comboBox3.Items.Add("耳鼻喉科");
            comboBox3.Items.Add("泌尿科");

            for (int i = 1; i <= 12; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }

            for (int i = 1; i <= 31; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (check == 0)
            {
                idx = doctorSet.doctor.Count - 1;
                while (idx >= 0)
                {
                    DataRow dr = doctorSet.doctor.Rows[idx];
                    if (!dr.IsNull("subject"))
                    {
                        if (comboBox3.Text == dr["subject"].ToString())
                        {
                            comboBox4.Items.Add(dr["name"].ToString());
                        }
                        idx--;
                    }
                }
                label1.Visible = label2.Visible = label3.Visible = label4.Visible = false;
                comboBox1.Visible = comboBox2.Visible = comboBox3.Visible = false;
                label5.Visible = comboBox4.Visible = true;
                check++;
            }
            else
            {
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                int y = currentTime.Year;
                String year = y.ToString();
                DataRow dr = subjectSet.subject.NewRow();
                dr["name"] = comboBox3.Text;
                dr["identity"] = iden;
                dr["date"] = year + '/' + comboBox1.Text + '/' + comboBox2.Text;
                dr["doctor"] = comboBox4.Text;
                subjectSet.subject.Rows.Add(dr);

                subjectAdapter.Update(subjectSet.subject);
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
