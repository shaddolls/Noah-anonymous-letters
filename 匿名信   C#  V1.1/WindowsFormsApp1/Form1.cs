using System;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        public static OleDbConnection conn = new OleDbConnection();
        public static OleDbCommand command = new OleDbCommand();
        //为相关对象声明变量

        internal LinkLabel QQ = new LinkLabel();
        internal LinkLabel tieba = new LinkLabel();
        internal LinkLabel wangpan = new LinkLabel();
        //初始化超链接控件

        private void Form1_Load(object sender, EventArgs e)
        {
            /*设置数据库链接*/
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|//database//letter.mdb;jet OleDB:Database Password=ESDT";
            command.Connection = conn;

            /*给comboname添加选项*/
            conn.Open();
            string liulan = "select distinct 送信人 from [all]";
            command.CommandText = liulan;
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())       //打印到comboname
            {
                comboname.Items.Add(reader.GetString(0));
            }
            reader.Close();
            conn.Close();   //关闭连接

            /*修改combobox下拉列表高度*/
            Hanshu.Bind(comboname, 16);
            Hanshu.Bind(combo2ji, 16);
            Hanshu.Bind(combofennei, 16);

            /*设置控件字体*/
            buttonout.Font = buttonsearch.Font = label1.Font = label2.Font = textBox1.Font = richTextBox1.Font = label3.Font = label4.Font = label5.Font = Hanshu.Setmyfont(1);
            wangpan.Font = tieba.Font = QQ.Font = label6.Font = Hanshu.Setmyfont(3);

            /*添加链接控件进窗口*/
            this.Controls.Add(Hanshu.Setlink(wangpan, "点击这里", "https://wws.lanzous.com/b01hkb20h", new Point(324, 218), Color.White));
            this.Controls.Add(Hanshu.Setlink(tieba, "点击这里", "https://tieba.baidu.com/p/6811887600?pid=133397585341&cid=0&red_tag=3392132044#133397585341", new Point(324, 197), Color.White));
            this.Controls.Add(Hanshu.Setlink(QQ, "932810430", "https://jq.qq.com/?_wv=1027&k=wXJJzuMd", new Point(324, 177), Color.White));

            /*将超链接放在前面图层*/
            richTextBox1.SendToBack();
        }

        private void buttonsearch_Click(object sender, EventArgs e)     //查找
        {
            richTextBox1.Text = "------------------------------------\r\n";     //先清空再查找
            int A = 0;      //信件数量计数器
            string liulan = "";       //进行查找的字符串
            this.QQ.Hide();
            this.tieba.Hide();
            this.wangpan.Hide();
            this.label6.Hide();

            /*多关键字对内容查找的字符串*/
            string x = textBox1.Text;
            char[] del = new char[] {'，',',',' ','.','。','/','`','~','·','、'};      //按照此要求分割
            string[]  a = x.Split(del,StringSplitOptions.RemoveEmptyEntries);       //去掉空内容后的字符串

            string c = "'%";
            for (int z = 1; z <= a.Length; z++)
            {
                c += a[z - 1] + "%";
            }
            c += "'";

            /*根据填入内容进行设置检索方法（谁会用这么多种查找啊→_→）*/
            if (comboname.Text != "" && textBox1.TextLength == 0 && combofennei.Text == "")
            {       //只有送信人查找，没有内容查找
                liulan = "select * from [all] where 送信人='" + comboname.Text + "';";
            }

            else if (comboname.Text == "" && textBox1.TextLength > 0 && combofennei.Text == "")
            {       //只有内容查找，没有送信人查找
                liulan = "select * from [all] where 内容 like "+ c;
            }

            else if (comboname.Text != "" && textBox1.TextLength > 0 && combofennei.Text == "")
            {       //同时查找送信人和内容
                liulan = "select * from [all] where 对应角色='" + comboname.Text + "' and 内容 like " + c;
            }

            else if (comboname.Text == "" && textBox1.TextLength == 0 && combofennei.Text != "" && combo2ji.Text == "")
            {       //查找所有一级对应的信件
                liulan = "select * from [all] where 备注='" + combofennei.Text + "';";
            }

            else if (comboname.Text == "" && textBox1.TextLength == 0 && combofennei.Text != "" && combo2ji.Text != "")
            {       //查找所有二级对应的信件
                liulan = "select * from [all] where 备注='" + combo2ji.Text + "';";
            }

            else if (comboname.Text != "" && textBox1.TextLength == 0 && combofennei.Text != "" && combo2ji.Text == "")
            {       //查找一级对应的送信人
                liulan = "select * from [all] where 备注='" + combofennei.Text + "' and 对应角色='" + comboname.Text + "';";
            }

            else if (comboname.Text != "" && textBox1.TextLength == 0 && combofennei.Text != "" && combo2ji.Text != "")
            {       //查找二级对应的送信人
                liulan = "select * from [all] where 备注='" + combo2ji.Text + "' and 对应角色='" + comboname.Text + "';";
            }

            else if (comboname.Text == "" && textBox1.TextLength > 0 && combofennei.Text != "" && combo2ji.Text == "")
            {       //查找一级对应的内容
                liulan = "select * from [all] where 备注='" + combofennei.Text + "' and 内容 like "+ c;
            }

            else if (comboname.Text == "" && textBox1.TextLength > 0 && combofennei.Text != "" && combo2ji.Text != "")
            {       //查找二级对应的内容
                liulan = "select * from [all] where 备注='" + combo2ji.Text + "' and 内容 like " + c;
            }

            else if (comboname.Text != "" && textBox1.TextLength > 0 && combofennei.Text != "" && combo2ji.Text == "")
            {       //查找一级对应的内容和送信人
                liulan = "select * from [all] where 备注='" + combofennei.Text + "' and 内容 like " + c + " and 对应角色='" + comboname.Text + "';";
            }

            else if (comboname.Text != "" && textBox1.TextLength > 0 && combofennei.Text != "" && combo2ji.Text != "")
            {       //查找二级对应的内容和送信人
                liulan = "select * from [all] where 备注='" + combo2ji.Text + "' and 内容 like " + c + " and 对应角色='" + comboname.Text + "';";
            }

            else
            {       //什么都没输入
                richTextBox1.Text = "请输入查找内容";
                richTextBox1.ForeColor=Color.Red;
            }

            if (liulan.Length > 0)      //数据库中进行查找并打印
            {
                conn.Open();
                command.CommandText = liulan;
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())   //打印到textbox并计数一次
                {
                    A++;
                    richTextBox1.Text += reader.GetString(0) + "\r\n" + reader.GetString(1) + "\r\n" + reader.GetString(2) + "\r\n" + reader.GetString(3) + "\r\n送信人：" + reader.GetString(4) + "\r\n------------------------------------\r\n";
                }
                label4.Text = "共" + A + "封信：";
                reader.Close();
                conn.Close();//关闭连接
            }

            if (a.Length > 0)       //保证有需要查找内容
            {
                for (int z = 1; z <= a.Length; z++)
                {
                    Hanshu.ChangeKey(richTextBox1, a[z-1], Color.Red, Hanshu.Setmyfont(2));     //内容查找标红,改变字体（加下划线）
                }
            }
        }

        private void buttonout_Click(object sender, EventArgs e)        //导出
        {
            if (richTextBox1.TextLength > 0)        //保证有输入
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "(*.txt)|*.txt";
                if (comboname.Text != "" && textBox1.TextLength == 0)
                {
                    saveFileDialog.FileName = comboname.Text + "的匿名信.txt";      //以输入的名字命名文档
                }
                else
                {
                    saveFileDialog.FileName = "查找到的匿名信.txt";
                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, true);
                    streamWriter.Write(this.richTextBox1.Text);
                    streamWriter.Close();
                }
            }
        }

        private void combofennei_SelectedIndexChanged(object sender, EventArgs e)       //信件分类的二级显示
        {
            this.combo2ji.Items.Clear();
            this.combo2ji.Text = "";        //每次一级改变都清空二级

            if (combofennei.Text == "")
            {
                this.combo2ji.Visible = false;
            }
            else if (this.combofennei.Text == "个人信件")
            {
                this.combo2ji.Visible = false;
            }
            else if (combofennei.Text == "通知报告")
            {
                this.combo2ji.Visible = false;
            }
            else if (combofennei.Text == "活动/节日信件")
            {
                this.combo2ji.Visible = true;

                conn.Open();
                string liulan = "select distinct 备注 from [all] where 信件类型='活动'";
                command.CommandText = liulan;
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())       //打印到combo2ji
                {
                    combo2ji.Items.Add(reader.GetString(0));
                }
                reader.Close();
                conn.Close();//关闭连接
            }
            else if (combofennei.Text == "校园互动")
            {
                this.combo2ji.Visible = true;

                conn.Open();
                string liulan = "select distinct 备注 from [all] where 信件类型='互动'";
                command.CommandText = liulan;
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())       //打印到combo2ji
                {
                    combo2ji.Items.Add(reader.GetString(0));
                }
                reader.Close();
                conn.Close();//关闭连接
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)        //禁用richtextbox的ctrl+C复制
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                base.OnKeyDown(e);
                e.Handled = true;
            }
        }
        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)    //禁用richtextbox的右键复制
        {
            if (e.Button == MouseButtons.Right)
            {
                richTextBox1.ContextMenu = new ContextMenu();
            }
        }

        private void label5_Click(object sender, EventArgs e)       //打开经验计算器
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void label6_Click(object sender, EventArgs e)       //一键复制
        {
            Clipboard.SetDataObject("cp8q");
        }
    }
}
