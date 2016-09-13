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
    public partial class Form8 : Form
    {
        int idx = 0;
        patientDataSet doctorSet;
        patientDataSetTableAdapters.doctorTableAdapter doctorAdapter;

        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr = doctorSet.doctor.NewRow();
            dr["name"] = textBox1.Text;
            dr["subject"] = comboBox1.Text;
            dr["accountnumber"] = textBox2.Text;
            dr["password"] = textBox3.Text;

            doctorSet.doctor.Rows.Add(dr);
            doctorAdapter.Update(doctorSet.doctor);
            this.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            doctorAdapter = new patientDataSetTableAdapters.doctorTableAdapter();
            doctorSet = new patientDataSet();
            doctorAdapter.Fill(doctorSet.doctor);

            comboBox1.Items.Add("一般內科");
            comboBox1.Items.Add("胸腔內科");
            comboBox1.Items.Add("神經內科");
            comboBox1.Items.Add("整形外科");
            comboBox1.Items.Add("骨科");
            comboBox1.Items.Add("皮膚科");
            comboBox1.Items.Add("眼科");
            comboBox1.Items.Add("牙科");
            comboBox1.Items.Add("婦產科");
            comboBox1.Items.Add("兒科");
            comboBox1.Items.Add("中醫");
            comboBox1.Items.Add("耳鼻喉科");
            comboBox1.Items.Add("泌尿科");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
