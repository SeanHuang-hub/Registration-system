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
    public partial class Form6 : Form
    {
        int idx;
        String iden;
        patientDataSet subjectSet;
        patientDataSetTableAdapters.subjectTableAdapter subjectAdapter;
        public Form6()
        {
            InitializeComponent();
        }
        public void Send(String ident)
        {
            iden = ident;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            subjectAdapter = new patientDataSetTableAdapters.subjectTableAdapter();
            subjectSet = new patientDataSet();
            subjectAdapter.Fill(subjectSet.subject);

            

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

        private void button1_Click(object sender, EventArgs e)
        {
            int check = 0;
            listView1.Clear();
            listView1.GridLines = true;//顯示行與行之間的分隔線
            listView1.FullRowSelect = true;//要選擇就是一行
            listView1.View = View.Details;//定義清單顯示的方式
            listView1.Scrollable = true;//需要時候顯示捲軸
            listView1.MultiSelect = false; // 不可以多行選擇
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;

            listView1.Columns.Add("日期", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("醫師", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("是否看診", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("科目", 100, HorizontalAlignment.Left);
            idx = subjectSet.subject.Rows.Count - 1;
            Console.Write(DateTime.Now.ToString("yyyy-MM-dd"));  
            while (idx >= 0)
            {
                DataRow dr = subjectSet.subject.Rows[idx];
                ListViewItem item = new ListViewItem();
                string[] arr = new string[4];
                item.SubItems.Clear();

                if (!dr.IsNull("identity"))
                {
                    if (iden == dr["identity"].ToString())
                    {
                        if (!dr.IsNull("name"))
                        {
                            if (comboBox1.Text == dr["name"].ToString())
                            {
                                arr[0] = dr["date"].ToString();
                                arr[1] = dr["doctor"].ToString();
                                arr[2] = "是";
                                arr[3] = dr["name"].ToString();
                                item = new ListViewItem(arr);
                                listView1.Items.Add(item);

                                check = 1;
                                //find data
                            }
                        }
                    }
                    idx--;
                }
            }
            if (check == 0)
                idx = 0;//unfind
            listView1.Visible = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
