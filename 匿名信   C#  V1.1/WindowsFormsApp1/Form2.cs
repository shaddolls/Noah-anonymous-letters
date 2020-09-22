using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int nowlv, have, tolv, x, y;
        int need;       //升至下一级所需经验
        int i;          //每级所需经验差值
        int j;          //每级中i的差值
        int all;        //一级至指定等级的下一级所需总经验
        int m;          //等级计数器

        public void Shuju()     //接收数据
        {
            if (textnowlv.Text != "")
            {
                if (Convert.ToInt32(textnowlv.Text) <= 120)
                {
                    nowlv = Convert.ToInt32(textnowlv.Text);
                }
                else
                {
                    textnowlv.Text = "120";
                    nowlv = 120;
                }

                if (Convert.ToInt32(textnowlv.Text) == 0)
                {
                    nowlv = 1;
                    textnowlv.Text = "1";
                }
            }
            else
            {
                nowlv = 1;
            };

            if (texthave.Text != "")
            {
                have = Convert.ToInt32(texthave.Text);
            }
            else
            {
                have = 0;
            };

            if (texttolv.Text != "")
            {
                if (Convert.ToInt32(texttolv.Text) <= 120)
                {
                    tolv = Convert.ToInt32(texttolv.Text);
                }
                else
                {
                    texttolv.Text = "120";
                    tolv = 120;
                }

                if (Convert.ToInt32(texttolv.Text) == 0)
                {
                    tolv = 1;
                    texttolv.Text = "1";
                }
            }
            else
            {
                tolv = 120;
            };
        }

        public int alljy(int lv)      //计算升级需要经验
        {
            if (lv <= 29)   //前29级升级经验
            {
                all = 0;
                need = 140;
                i = 80;
                for (m = 1; m <= lv; m++)
                {
                    need = 140 + (m - 1) * i;
                    all += need;
                }
            }

            if (lv >= 30 && lv <= 84)   //30到84级升级经验
            {
                alljy(29);      //29级数据
                for (m = 30; m <= lv; m++)
                {
                    j = 10;
                    j += 10 * ((m - 31) / 2);
                    i += j;
                    need += i;
                    all += need;
                }
            }

            if (lv >= 85 && lv <= 89)   //85到89级升级经验
            {
                alljy(84);      //84级数据
                for (m = 85; m <= lv; m++)
                {
                    j += 270;
                    i += j;
                    need += i;
                    all += need;
                }
            }

            if (lv >= 90 && lv <= 100)  //90到100级升级经验
            {
                alljy(89);      //89级数据
                for (m = 90; m <= lv; m++)
                {
                    j += 1620;
                    i += j;
                    need += i;
                    all += need;
                }
            }

            if (lv > 100)       //100到120级升级经验
            {
                alljy(100);     //100级数据
                i = 270;
                for (m = 101; m <= lv; m++)
                {
                    need += i;
                    all += need;
                }
            }

            return all - need;
        }

        private void textnowlv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8))
                e.Handled = true;
        }

        private void texttolv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8))
                e.Handled = true;
        }

        private void texthave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8))
                e.Handled = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Font = label2.Font = label3.Font = texthave.Font = labelout.Font = label4.Font = textnowlv.Font = texttolv.Font = Hanshu.Setmyfont(1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Shuju();
            x = alljy(nowlv);
            y = alljy(tolv);
            labelout.Text = Convert.ToString(y - x - have);
        }

        private void texthave_TextChanged(object sender, EventArgs e)
        {
            Shuju();
            x = alljy(nowlv);
            y = alljy(tolv);
            labelout.Text = Convert.ToString(y - x - have);
        }

        private void texttolv_TextChanged(object sender, EventArgs e)
        {
            Shuju();
            x = alljy(nowlv);
            y = alljy(tolv);
            labelout.Text = Convert.ToString(y - x - have);
        }
    }
}
