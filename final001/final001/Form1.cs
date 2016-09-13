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
    public partial class Form1 : Form
    {
        int idx=0;
        patientDataSet patientSet;
        patientDataSetTableAdapters.patientTableAdapter patientAdapter;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//首頁按登入
        {
            label1.Visible = label2.Visible = true;
            textBox1.Visible = textBox2.Visible = true;
            button4.Visible = button5.Visible = true;
            button1.Visible = button2.Visible = button3.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)//登入頁按取消
        {
            label1.Visible = label2.Visible = label3.Visible = false;
            textBox1.Visible = textBox2.Visible = false;
            button4.Visible = button5.Visible = false;
            button1.Visible = button2.Visible = button3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)//登入頁按登入
        {
            int check = 0;
            Form1_Load(sender, e);
            patientAdapter.Update(patientSet.patient);
            idx = patientSet.patient.Rows.Count -1;
            while (idx >= 0)
            {
                DataRow dr = patientSet.patient.Rows[idx];
                if (!dr.IsNull("identity"))
                {
                    if (textBox1.Text == dr["identity"].ToString())
                    {
                        if (!dr.IsNull("password"))
                        {
                            if (textBox2.Text == dr["password"].ToString())
                            {
                                check = 1;
                                Form3 f3 = new Form3(textBox1.Text);
                                f3.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                                f3.Show();
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

        private void button2_Click(object sender, EventArgs e)//首頁按新增
        {
            Form4 f4 = new Form4();
            f4.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            f4.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            patientAdapter = new patientDataSetTableAdapters.patientTableAdapter();
            patientSet = new patientDataSet();
            patientAdapter.Fill(patientSet.patient);
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();//子視窗關閉時,父視窗再顯示出來
            textBox1.Text = "";
            textBox2.Text = "";
            button4_Click(sender,e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            f2.Show();
            this.Hide();
        } 
    }
}
