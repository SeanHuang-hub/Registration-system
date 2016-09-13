using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace final001
{
    public partial class Form4 : Form
    {
        int idx = 0;
        patientDataSet patientSet;
        patientDataSetTableAdapters.patientTableAdapter patientAdapter;

        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//取消
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            patientAdapter = new patientDataSetTableAdapters.patientTableAdapter();
            patientSet = new patientDataSet();
            patientAdapter.Fill(patientSet.patient);

            comboBox1.Text = (DateTime.Now.Year - 30).ToString();
            comboBox2.Text = "1";
            comboBox3.Text = "1";
            comboBox4.Items.Add("男");
            comboBox4.Items.Add("女");

            for (int i = DateTime.Now.Year - 30; i <= DateTime.Now.Year; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }

            for (int i = 1; i <= 12; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }

            for (int i = 1; i <= 31; i++)
            {
                comboBox3.Items.Add(i.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)//新增
        {
            String temp;
            int t2;
            temp = comboBox1.Text + '/' + comboBox2.Text + '/' + comboBox3.Text;
            DataRow dr = patientSet.patient.NewRow();
            dr["name"] = textBox1.Text;
            dr["identity"] = textBox2.Text;
            dr["birthday"]= temp;
            dr["gender"] = comboBox4.Text;
            dr["telephone"] = textBox5.Text;
            dr["cellphone"] = textBox6.Text;
            dr["address"] = textBox7.Text;
            dr["password"] = textBox8.Text;
            patientSet.patient.Rows.Add(dr);
            
            patientAdapter.Update(patientSet.patient);
            idx = patientSet.patient.Rows.Count -1 ;
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
