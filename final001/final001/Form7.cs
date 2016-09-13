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
    public partial class Form7 : Form
    {
        int idx = 0, idt = 0, check = 0;
        String iden;
        patientDataSet subjectSet;
        patientDataSetTableAdapters.subjectTableAdapter subjectAdapter;
        patientDataSet patientSet;
        patientDataSetTableAdapters.patientTableAdapter patientAdapter;

        public Form7(String str)
        {
            InitializeComponent();
            if (str == "0000")
            {
                button1.Visible = true;
                button3.Visible = false;
            }
            iden = str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            listView1.Clear();
            listView1.GridLines = true;//顯示行與行之間的分隔線
            listView1.FullRowSelect = true;//要選擇就是一行
            listView1.View = View.Details;//定義清單顯示的方式
            listView1.Scrollable = true;//需要時候顯示捲軸
            listView1.MultiSelect = false; // 不可以多行選擇
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;

            listView1.Columns.Add("日期", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("病人", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("性別", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("生日", 100, HorizontalAlignment.Left);

            idx = subjectSet.subject.Rows.Count - 1;
            idt = patientSet.patient.Rows.Count - 1;

            while (idx >= 0)
            {
                DataRow dr = subjectSet.subject.Rows[idx];
                ListViewItem item = new ListViewItem();
                string[] arr = new string[4];
                item.SubItems.Clear();

                if (!dr.IsNull("doctor"))
                {
                    if (iden == dr["doctor"].ToString())
                    {
                        arr[0] = dr["date"].ToString();
                        arr[1] = dr["identity"].ToString();
                        while (idt >= 0)
                        {
                            DataRow dt = patientSet.patient.Rows[idt];
                            if (dr["identity"].ToString() == dt["identity"].ToString())
                            {
                                arr[2] = dt["gender"].ToString();
                                arr[3] = dt["birthday"].ToString();
                                break;
                            }
                            idt--;
                        }
                        item = new ListViewItem(arr);
                        listView1.Items.Add(item);

                        check = 1;
                        //find data
                    }
                    idx--;
                }
            }
            if (check == 0)
                idx = 0;//unfind
            listView1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            f8.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            subjectAdapter = new patientDataSetTableAdapters.subjectTableAdapter();
            subjectSet = new patientDataSet();
            subjectAdapter.Fill(subjectSet.subject);

            patientAdapter = new patientDataSetTableAdapters.patientTableAdapter();
            patientSet = new patientDataSet();
            patientAdapter.Fill(patientSet.patient);
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();//子視窗關閉時,父視窗再顯示出來
        }
    }
}
